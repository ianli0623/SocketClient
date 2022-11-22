//https://docs.microsoft.com/en-us/dotnet/framework/network-programming/asynchronous-client-socket-example
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading; 
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using client;
using System.Globalization;

// State object for receiving data from remote device.  
public class StateObject {  
    // Client socket.  
    public Socket workSocket = null;  
    // Size of receive buffer.  
    public const int BufferSize = 256;  
    // Receive buffer.  
    public byte[] buffer = new byte[BufferSize];  
    // Received data string.  
    public StringBuilder sb = new StringBuilder();  
}

public class SocketPackage
{
    static short MSG_PACKAGE = 4096;
    #region HEADER
    static short MSG_TOTAL_LENGTH_SIZE = 5;
    static short MSG_IN_FILLER_SIZE = 10;
    static short MSG_IN_SESSION_ID_SIZE = 10;
    static short MSG_IN_TRAN_BUSINESS_NAME_SIZE = 5;
    static short MSG_IN_TRAN_ID_SIZE = 5;
    static short MSG_IN_RETURN_CODE_SIZE = 4;
    static short MSG_IN_RETURN_SEQ = 15;
    static short MSG_IN_RETURN_DIRECTIO_SIZE = 2;
    static short MSG_IN_LENGTH_SIZE = 5;

    static byte[] MSG_TOTAL_LENGTH = new byte[MSG_TOTAL_LENGTH_SIZE];
    static byte[] MSG_IN_FILLER = new byte[MSG_IN_FILLER_SIZE];
    static byte[] MSG_IN_SESSION_ID = new byte[MSG_IN_SESSION_ID_SIZE];
    static byte[] MSG_IN_TRAN_BUSINESS_NAME = new byte[MSG_IN_TRAN_BUSINESS_NAME_SIZE];
    static byte[] MSG_IN_TRAN_ID = new byte[MSG_IN_TRAN_ID_SIZE];
    static byte[] MSG_IN_RETURN_CODE = new byte[MSG_IN_RETURN_CODE_SIZE];
    static byte[] MSG_IN_RETURN = new byte[MSG_IN_RETURN_SEQ];
    static byte[] MSG_IN_RETURN_DIRECTIO = new byte[MSG_IN_RETURN_DIRECTIO_SIZE];
    static byte[] MSG_IN_LENGTH = new byte[MSG_IN_LENGTH_SIZE];
    #endregion

    #region DATA
    static short SEND_TRANS_TYPE_SIZE = 4;
    static short SEND_LINE_ID_SIZE = 2;
    static short SEND_SYS_SEQ_SIZE = 14;
    static short SEND_SYS_YMD_SIZE = 7;
    static short SEND_SYS_TIME_SIZE = 6;
    static short SEND_IDNO_SIZE = 10;
    static short SEND_FEE_UNIT_SIZE = 3;
    static short SEND_BANK_ID_SIZE = 7;
    static short SEND_TERM_ID_SIZE = 8;
    static short SEND_IC_SEQ_SIZE = 8;
    static short SEND_CHK_TERM_SIZE = 8;
    static short SEND_IC_TXN_DTME_SIZE = 14;
    static short SEND_TERM_TYPE_SIZE = 4;
    static short SEND_BUSINESS_KIND_SIZE = 2;
    static short SEND_TRANS_KIND_SIZE = 2;
    static short SEND_CHECK_ITEM_SIZE = 2;
    static short SEND_ITEM_12_IDNO_SIZE = 10;
    static short SEND_ITEM_12_PHONE_SIZE = 10;
    static short SEND_ITEM_12_BIRTHDAY_SIZE = 8;
    static short FILLER_SIZE = 56;
    static short SEND_DEPACNO_SIZE = 16;
    static short SEND_IC_MEMO_SIZE = 30;
    static short SEND_TAC_SIZE = 10;

    static byte[] SEND_TRANS_TYPE = new byte[SEND_TRANS_TYPE_SIZE];
    static byte[] SEND_LINE_ID = new byte[SEND_LINE_ID_SIZE];
    static byte[] SEND_SYS_SEQ = new byte[SEND_SYS_SEQ_SIZE];
    static byte[] SEND_SYS_YMD = new byte[SEND_SYS_YMD_SIZE];
    static byte[] SEND_SYS_TIME = new byte[SEND_SYS_TIME_SIZE];
    static byte[] SEND_IDNO = new byte[SEND_IDNO_SIZE];
    static byte[] SEND_FEE_UNIT = new byte[SEND_FEE_UNIT_SIZE];
    static byte[] SEND_BANK_ID = new byte[SEND_BANK_ID_SIZE];
    static byte[] SEND_TERM_ID = new byte[SEND_TERM_ID_SIZE];
    static byte[] SEND_IC_SEQ = new byte[SEND_IC_SEQ_SIZE];
    static byte[] SEND_CHK_TERM = new byte[SEND_CHK_TERM_SIZE];
    static byte[] SEND_IC_TXN_DTME = new byte[SEND_IC_TXN_DTME_SIZE];
    static byte[] SEND_TERM_TYPE = new byte[SEND_TERM_TYPE_SIZE];
    static byte[] SEND_BUSINESS_KIND = new byte[SEND_BUSINESS_KIND_SIZE];
    static byte[] SEND_TRANS_KIND = new byte[SEND_TRANS_KIND_SIZE];
    static byte[] SEND_CHECK_ITEM = new byte[SEND_CHECK_ITEM_SIZE];
    static byte[] SEND_ITEM_12_IDNO = new byte[SEND_ITEM_12_IDNO_SIZE];
    static byte[] SEND_ITEM_12_PHONE = new byte[SEND_ITEM_12_PHONE_SIZE];
    static byte[] SEND_ITEM_12_BIRTHDAY = new byte[SEND_ITEM_12_BIRTHDAY_SIZE];
    static byte[] FILLER = new byte[FILLER_SIZE];
    static byte[] SEND_DEPACNO = new byte[SEND_DEPACNO_SIZE];
    static byte[] SEND_IC_MEMO = new byte[SEND_IC_MEMO_SIZE];
    static byte[] SEND_TAC = new byte[SEND_TAC_SIZE];
    #endregion

    static byte[] PACKAGE = new byte[MSG_PACKAGE];

    //public void SetMSGFromChar(ByteArray ref MSG, char[] value)
    //{

    //}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="package"></param>
    public static void CreateInPackage(string name, SocketContent socketContent, ref byte[] package)
    {

        for (int i = 0; i < package.Length; i++)
        {
            PACKAGE[i] = 0;
        }

        // Header
        MSG_TOTAL_LENGTH = Encoding.UTF8.GetBytes(socketContent.MSG_TOTAL_LENGTH);
        MSG_IN_FILLER = Encoding.UTF8.GetBytes(socketContent.MSG_IN_FILLER);
        MSG_IN_SESSION_ID = Encoding.UTF8.GetBytes(socketContent.MSG_IN_SESSION_ID);
        MSG_IN_TRAN_BUSINESS_NAME = Encoding.UTF8.GetBytes(socketContent.MSG_IN_TRAN_BUSINESS_NAME); // 
        MSG_IN_TRAN_ID = Encoding.UTF8.GetBytes(socketContent.MSG_IN_TRAN_ID);
        MSG_IN_RETURN_CODE = Encoding.UTF8.GetBytes(socketContent.MSG_IN_RETURN_CODE);
        MSG_IN_RETURN = Encoding.UTF8.GetBytes(socketContent.MSG_IN_RETURN);
        MSG_IN_RETURN_DIRECTIO = Encoding.UTF8.GetBytes(socketContent.MSG_IN_RETURN_DIRECTIO);
        MSG_IN_LENGTH = Encoding.UTF8.GetBytes(socketContent.MSG_IN_LENGTH);

        // Body
        SEND_TRANS_TYPE = Encoding.UTF8.GetBytes(socketContent.SEND_TRANS_TYPE);// 4 
        SEND_LINE_ID = Encoding.UTF8.GetBytes(socketContent.SEND_LINE_ID);// 2
        SEND_SYS_SEQ = Encoding.UTF8.GetBytes(socketContent.SEND_SYS_SEQ);// 14
        SEND_SYS_YMD = Encoding.UTF8.GetBytes(socketContent.SEND_SYS_YMD);// 7
        SEND_SYS_TIME = Encoding.UTF8.GetBytes(socketContent.SEND_SYS_TIME);// 6
        SEND_IDNO = Encoding.UTF8.GetBytes(socketContent.SEND_IDNO);// 10
        SEND_FEE_UNIT = Encoding.UTF8.GetBytes(socketContent.SEND_FEE_UNIT);// 3
        SEND_BANK_ID = Encoding.UTF8.GetBytes(socketContent.SEND_BANK_ID);// 7
        SEND_TERM_ID = Encoding.UTF8.GetBytes(socketContent.SEND_TERM_ID);//  8
        SEND_IC_SEQ = Encoding.UTF8.GetBytes(socketContent.SEND_IC_SEQ);// 8
        SEND_CHK_TERM = Encoding.UTF8.GetBytes(socketContent.SEND_CHK_TERM);// 8
        SEND_IC_TXN_DTME = Encoding.UTF8.GetBytes(socketContent.SEND_IC_TXN_DTME);// 14
        SEND_TERM_TYPE = Encoding.UTF8.GetBytes(socketContent.SEND_TERM_TYPE);// 4
        SEND_BUSINESS_KIND = Encoding.UTF8.GetBytes(socketContent.SEND_BUSINESS_KIND);// 2
        SEND_TRANS_KIND = Encoding.UTF8.GetBytes(socketContent.SEND_TRANS_KIND);// 2
        SEND_CHECK_ITEM = Encoding.UTF8.GetBytes(socketContent.SEND_CHECK_ITEM);// 2
        SEND_ITEM_12_IDNO = Encoding.UTF8.GetBytes(socketContent.SEND_ITEM_12_IDNO);// 10
        SEND_ITEM_12_PHONE = Encoding.UTF8.GetBytes(socketContent.SEND_ITEM_12_PHONE);// 10
        SEND_ITEM_12_BIRTHDAY = Encoding.UTF8.GetBytes(socketContent.SEND_ITEM_12_BIRTHDAY);// 8
        FILLER = Encoding.UTF8.GetBytes(socketContent.FILLER);// 56
        SEND_DEPACNO = Encoding.UTF8.GetBytes(socketContent.SEND_DEPACNO);// 16
        SEND_IC_MEMO = Encoding.UTF8.GetBytes(socketContent.SEND_IC_MEMO);// 30
        SEND_TAC = Encoding.UTF8.GetBytes(socketContent.SEND_TAC);// 10

        if (name == "DA10")
        {
            IEnumerable<byte> packageheader =
                MSG_TOTAL_LENGTH
                .Concat(MSG_IN_FILLER)
                .Concat(MSG_IN_SESSION_ID)
                .Concat(MSG_IN_TRAN_BUSINESS_NAME)
                .Concat(MSG_IN_TRAN_ID)
                .Concat(MSG_IN_RETURN_CODE)
                .Concat(MSG_IN_RETURN)
                .Concat(MSG_IN_RETURN_DIRECTIO)
                .Concat(MSG_IN_LENGTH)
                .Concat(SEND_TRANS_TYPE)
                .Concat(SEND_LINE_ID)
                .Concat(SEND_SYS_SEQ)
                .Concat(SEND_SYS_YMD)
                .Concat(SEND_SYS_TIME)
                .Concat(SEND_IDNO)
                .Concat(SEND_FEE_UNIT)
                .Concat(SEND_BANK_ID)
                .Concat(SEND_TERM_ID)
                .Concat(SEND_IC_SEQ)
                .Concat(SEND_CHK_TERM)
                .Concat(SEND_IC_TXN_DTME)
                .Concat(SEND_TERM_TYPE)
                .Concat(SEND_BUSINESS_KIND)
                .Concat(SEND_TRANS_KIND)
                .Concat(SEND_CHECK_ITEM)
                .Concat(SEND_ITEM_12_IDNO)
                .Concat(SEND_ITEM_12_PHONE)
                .Concat(SEND_ITEM_12_BIRTHDAY)
                .Concat(FILLER)
                .Concat(SEND_DEPACNO)
                .Concat(SEND_IC_MEMO)
                .Concat(SEND_TAC);
            package = packageheader.ToArray();
        }
    }

    //public ByteArray CreateOutDA11Package()
    //{

    //}
}

public class AsynchronousClient {  
    // The port number for the remote device.  
    private const int port = 8800;  
  
    // ManualResetEvent instances signal completion.  
    private static ManualResetEvent connectDone =
        new ManualResetEvent(false);  
    private static ManualResetEvent sendDone =
        new ManualResetEvent(false);  
    private static ManualResetEvent receiveDone =
        new ManualResetEvent(false);  
  
    // The response from the remote device.  
    private static String response = String.Empty;

    private static bool? areWeConnected = null;
    private static void StartClient(SocketContent bankAccount) {
        string time = DateTime.Now.ToString("yyyyMMddHHmmss");
        string SEND_IC_TXN_DTME_STR = string.Empty;
        //TEST Data
        bankAccount.MSG_TOTAL_LENGTH = "00297";
        bankAccount.MSG_IN_FILLER = "0000000000";
        bankAccount.MSG_IN_SESSION_ID = "0000000000";
        bankAccount.MSG_IN_TRAN_BUSINESS_NAME = "PB   ";
        bankAccount.MSG_IN_TRAN_ID = "00001";
        bankAccount.MSG_IN_RETURN_CODE = "0000";
        bankAccount.MSG_IN_RETURN = "000000000000000";
        bankAccount.MSG_IN_RETURN_DIRECTIO = "00";
        bankAccount.MSG_IN_LENGTH = "00241";
        bankAccount.SEND_TRANS_TYPE = "DA10";
        bankAccount.SEND_LINE_ID = "PB";
        bankAccount.SEND_SYS_SEQ = time;//FIX
        bankAccount.SEND_SYS_YMD = ToTaiwanDate();//FIX
        bankAccount.SEND_SYS_TIME = DateTime.Now.ToString("HHmmss");//FIX
        bankAccount.SEND_IDNO = "16091049  ";
        bankAccount.SEND_FEE_UNIT = "004";
        //bankAccount.SEND_BANK_ID = "0090000";
        bankAccount.SEND_TERM_ID = "00000001";
        bankAccount.SEND_IC_SEQ = "00000000";
        bankAccount.SEND_CHK_TERM = "00000001";
        if (bankAccount.SEND_BANK_ID == "1080000")
        {
            SEND_IC_TXN_DTME_STR = "              ";
        }
        else
        {
            SEND_IC_TXN_DTME_STR = time;
        }
        bankAccount.SEND_IC_TXN_DTME = SEND_IC_TXN_DTME_STR;//FIX
        bankAccount.SEND_TERM_TYPE = "6590";
        bankAccount.SEND_BUSINESS_KIND = "10";
        bankAccount.SEND_TRANS_KIND = "01";
        bankAccount.SEND_CHECK_ITEM = "12";
        //bankAccount.SEND_ITEM_12_IDNO = "T123456789";
        //bankAccount.SEND_ITEM_12_PHONE = "0988046193";
        //bankAccount.SEND_ITEM_12_BIRTHDAY = "19930623";
        bankAccount.FILLER = "                                                        ";
        //bankAccount.SEND_DEPACNO = "0050505001225100";
        bankAccount.SEND_IC_MEMO = "                              ";
        bankAccount.SEND_TAC = "          ";
        // Connect to a remote device.  
        try {  
            // Establish the local endpoint for the socket.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());  
            IPAddress ipAddress = ipHostInfo.AddressList[0];  
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8800);

            int timeout = 10000;
            int ctr = 0;

            // Create a TCP/IP socket.  
            Socket client = new Socket(ipAddress.AddressFamily,  
                SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.  
            IAsyncResult ar =  client.BeginConnect( remoteEP,
                new AsyncCallback(ConnectCallback), client);

            ar.AsyncWaitHandle.WaitOne(timeout, true);

            while (areWeConnected == null && ctr < timeout)
            {
                Thread.Sleep(1000);
                ctr += 100;
            }

            if (areWeConnected == true)
            {
                connectDone.WaitOne();

                byte[] package = new byte[4096];
                //SocketPackage.CreateInPackage("DA10", bankAccount, ref package);
                package = Encoding.ASCII.GetBytes("0029700000000000000000000DA   0000100000000000000000000000241DA10DA202011000037191091116161149P120XXX04800200900000       000000000       202011161611496590100112P120XXX048091195091119740530                                                        0050505001225100                                       ");

                // Send test data to the remote device.
                Send(client, package);
                sendDone.WaitOne();

                // Receive the response from the remote device.
                Console.WriteLine("Response received.....");
                client.ReceiveTimeout = 10000;
                Receive(client);
                //Wait at most 10 seconds to end
                receiveDone.WaitOne(120000);

                // Write the response to the console.
                Console.WriteLine("Response received : {0}", response);

                // Release the socket.
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private static void ConnectCallback(IAsyncResult ar) {
        areWeConnected = null;
        try {  
            // Retrieve the socket from the state object.  
            Socket client = (Socket) ar.AsyncState;

            areWeConnected = client.Connected;
            if (areWeConnected == false)
            {
                Console.WriteLine("Connect fail");
            }
            // Complete the connection.  
            client.EndConnect(ar);

            Console.WriteLine("Socket connected to {0}",  
                client.RemoteEndPoint.ToString());  
  
            // Signal that the connection has been made.  
            connectDone.Set();  
        } catch (Exception e) {
            areWeConnected = false;
            Console.WriteLine(e.ToString());
        }  
    }  
  
    private static void Receive(Socket client) {  
        try {  
            // Create the state object.  
            StateObject state = new StateObject();  
            state.workSocket = client;  
  
            // Begin receiving the data from the remote device.  
            client.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,  
                new AsyncCallback(ReceiveCallback), state);  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    }

    private static void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the state object and the client socket
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;

            // Read data from the remote device.  
            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.  
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                state.sb.Append(Encoding.GetEncoding("big5").GetString(state.buffer, 0, bytesRead));

                // Get the rest of the data.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            else
            {
                // All the data has arrived; put it in response.  
                if (state.sb.Length > 1)
                {
                    response = state.sb.ToString();
                }
                // Signal that all bytes have been received.  
                receiveDone.Set();
                receiveDone.Reset();
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private static void Send(Socket client, byte[] data) {
        // Convert the string data to byte data using ASCII encoding.  
        //byte[] byteData = Encoding.ASCII.GetBytes(data);  

        // Begin sending the data to the remote device.  
        client.BeginSend(data, 0, data.Length, 0,  
            new AsyncCallback(SendCallback), client);
    }  
  
    private static void SendCallback(IAsyncResult ar) {  
        try {  
            // Retrieve the socket from the state object.  
            Socket client = (Socket) ar.AsyncState;  
  
            // Complete sending the data to the remote device.  
            int bytesSent = client.EndSend(ar);  
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);  
  
            // Signal that all bytes have been sent.  
            sendDone.Set();  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    } 

    public static int Main(String[] args) {
        SocketContent bankAccount = new SocketContent();
        StartClient(bankAccount);
        return 0;  
    }
    /// <summary>
    /// AD Conversion to R.O.C . 西元轉民國年
    /// </summary>
    /// <param name="date">The datetime.</param>
    /// <returns></returns>
    private static string ToTaiwanDate()
    {
        DateTime birthdate = DateTime.Now;
        string Month = string.Empty;
        string Day = string.Empty;
        TaiwanCalendar taiwanCalendar = new TaiwanCalendar();
        if (birthdate.Month.ToString().Length == 1)
        {
            Month = "0" + birthdate.Month.ToString();
        }
        if (birthdate.Day.ToString().Length == 1)
        {
            Day = "0" + birthdate.Day.ToString();
        }
        return $"{taiwanCalendar.GetYear(birthdate)}{Month}{Day}";
    }
}  