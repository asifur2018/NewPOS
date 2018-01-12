using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class CustomerBankDetailsModel
    {
        public int      BANK_ID { get; set; }
        public string   BACS_REF { get; set; }
        public string   ACCOUNT_NAME { get; set; }
        public string   BANK_NAME { get; set; }
        public string   STREET1 { get; set; }
        public string   STREET2 { get; set; }
        public string   TOWN { get; set; }
        public string   COUNTRY { get; set; }
        public string   POST_CODE { get; set; }
        public string   SHORT_CODE { get; set; }
        public string   ACCOUNT_NUMBER { get; set; }
        public string   PAYMENT_REF { get; set; }
        public string   BIC_SWIFT { get; set; }
        public string   IBAN { get; set; }
        public string   ROLL_NO { get; set; }
        public string   PAYMENT_METHOD { get; set; }
        public bool?     ONLINE_RECEIPT { get; set; }
        public string   NOTES { get; set; }
        public string   CUSTOMER_CODE { get; set; }
        public bool?     IS_DELETE { get; set; }
        public bool?     STATUS { get; set; }
        public decimal?   STANDARD_DISC_PER { get; set; }
        public int?      STANDART_DISC_DAYS { get; set; }

    }
}