using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class SalesModel
    {
        public string LEDGER { get; set; }
        public string TRX_TYPE { get; set; }
        public string POSTING_NO { get; set; }
        public string POSTING_TYPE { get; set; }
        public string DEF_DIST { get; set; }
        public string GENERAL_CODE { get; set; }
        public string GENERAL_NAME { get; set; }
        public string REF_NO { get; set; }
        public DateTime POSTING_DATE { get; set; }
        public DateTime INV_DATE { get; set; }
        public DateTime INV_EXP_DATE { get; set; }
        public string DESCRIPTION { get; set; }
        public string PROJECT { get; set; }
        public decimal OS_BAL { get; set; }
        public decimal CREDIT_REMAINING { get; set; }
        public decimal NET_BAL { get; set; }
        //public string DESCRIPTION { get; set; }
        public decimal TAX_AMT { get; set; }
        public decimal TOTAL_AMT { get; set; }
        public decimal COST { get; set; }



        public string QUICKJOURNAL_CODE { get; set; }
        public string CUSTOMER { get; set; }
        public string REFERENCE { get; set; }
        public string JOURNAL_DESC { get; set; }
        public DateTime JOURNAL_DATE { get; set; }
        public string NL_ACC1 { get; set; }
        public string NL_ACC2 { get; set; }
        public string VAT_PER { get; set; }
        public decimal TOTAL_VAT { get; set; }
        public decimal NET_AMOUNT { get; set; }
        public decimal TOTAL_AMOUNT { get; set; }



        public int SLNO { get; set; }
        public bool IS_DELETE { get; set; }
        public string STATUS { get; set; }
        public int COMPANY_ID { get; set; }
    }
}