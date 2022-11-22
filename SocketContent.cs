using System;
using System.Collections.Generic;
using System.Text;

namespace client
{
    public class SocketContent
    {
        #region Header
        /// <summary>
        /// 電文長度宣告
        /// </summary>
        public string MSG_TOTAL_LENGTH { get; set; }
        public string MSG_IN_FILLER { get; set; }
        public string MSG_IN_SESSION_ID { get; set; }
        /// <summary>
        /// 業務代號
        /// </summary>
        public string MSG_IN_TRAN_BUSINESS_NAME { get; set; }
        /// <summary>
        /// 業務子分類代號
        /// </summary>
        public string MSG_IN_TRAN_ID { get; set; }
        /// <summary>
        /// 訊息代號
        /// </summary>
        public string MSG_IN_RETURN_CODE { get; set; }
        public string MSG_IN_RETURN { get; set; }
        public string MSG_IN_RETURN_DIRECTIO { get; set; }
        /// <summary>
        /// Body 長度
        /// </summary>
        public string MSG_IN_LENGTH { get; set; }
        #endregion

        #region Body
        /// <summary>
        /// 交易代碼
        /// </summary>
        public string SEND_TRANS_TYPE { get; set; }
        /// <summary>
        /// 識別線路
        /// </summary>
        public string SEND_LINE_ID { get; set; }
        /// <summary>
        /// 系統序號
        /// </summary>
        public string SEND_SYS_SEQ { get; set; }
        /// <summary>
        /// 系統日期
        /// </summary>
        public string SEND_SYS_YMD { get; set; }
        /// <summary>
        /// 系統時間
        /// </summary>
        public string SEND_SYS_TIME { get; set; }
        /// <summary>
        /// 客戶統編
        /// </summary>
        public string SEND_IDNO { get; set; }
        /// <summary>
        /// 手續費出帳單位
        /// </summary>
        public string SEND_FEE_UNIT { get; set; }
        /// <summary>
        /// 核驗帳號之開戶銀行
        /// </summary>
        public string SEND_BANK_ID { get; set; }
        /// <summary>
        /// 端末設備代號
        /// </summary>
        public string SEND_TERM_ID { get; set; }
        /// <summary>
        /// IC卡交易序號
        /// </summary>
        public string SEND_IC_SEQ { get; set; }
        /// <summary>
        /// 端未設備查核碼
        /// </summary>
        public string SEND_CHK_TERM { get; set; }
        /// <summary>
        /// 交易日期時間
        /// </summary>
        public string SEND_IC_TXN_DTME { get; set; }
        /// <summary>
        /// 端末設備型態
        /// </summary>
        public string SEND_TERM_TYPE { get; set; }
        /// <summary>
        /// 業務類別
        /// </summary>
        public string SEND_BUSINESS_KIND { get; set; }
        /// <summary>
        /// 交易類別
        /// </summary>
        public string SEND_TRANS_KIND { get; set; }
        /// <summary>
        /// 核驗項目
        /// </summary>
        public string SEND_CHECK_ITEM { get; set; }
        /// <summary>
        /// 身分證號或營利事業統一編號
        /// </summary>
        public string SEND_ITEM_12_IDNO { get; set; }
        /// <summary>
        /// 行動電話號碼
        /// </summary>
        public string SEND_ITEM_12_PHONE { get; set; }
        /// <summary>
        /// 出生年月日
        /// </summary>
        public string SEND_ITEM_12_BIRTHDAY { get; set; }
        /// <summary>
        /// 空白
        /// </summary>
        public string FILLER { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string SEND_DEPACNO { get; set; }
        /// <summary>
        /// IC卡備註欄
        /// </summary>
        public string SEND_IC_MEMO { get; set; }
        /// <summary>
        /// 交易驗證碼
        /// </summary>
        public string SEND_TAC { get; set; }
        #endregion

    }
}
