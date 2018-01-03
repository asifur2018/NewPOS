using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class SupplierModel
    {
        public int SUPPLIER_ID { get; set; }
        public int COMPANY_ID { get; set; }
        public string SUPPLIER_CODE { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public bool? IS_CUSTOMER { get; set; }
        public string ADDRESS { get; set; }
        public string POSTCODE { get; set; }
        public string COUNTRY { get; set; }
        public string WEBSITE { get; set; }
        public string STATEMENT { get; set; }
        public string SEND_MAIL { get; set; }
        public string DUNS_NO { get; set; }
        public string VAT_TYPE { get; set; }
        public string VAT_NUMBER { get; set; }
        public string DYNAMIC_DISC { get; set; }
        public string REGISTERED { get; set; }
        public string SUPPLIER_INACTIVE { get; set; }
        public string PRICE_TYPE { get; set; }
        public DateTime? DATE_STARTED { get; set; }
        public string CONTACT_TYPE { get; set; }
        public string CONTACT_NAME { get; set; }
        public string CONTACT_SALUTATION { get; set; }
        public string CONTACT_PHONE_NO { get; set; }
        public string CONTACT_EXTN_NO { get; set; }
        public string CONTACT_MOBILE_NO { get; set; }
        public string CONTACT_FAX { get; set; }
        public string EMAIL { get; set; }
        public string SKYPE { get; set; }
        public DateTime LAST_PAYMENT { get; set; }
        public string CASH_ACC { get; set; }
        public int AVG_PMT_DAY { get; set; }
        public int? DEF_PMT_DAY { get; set; }
        public decimal CREDIT_LIMIT { get; set; }
        public string GROUP { get; set; }
        public string GROUP_DESC { get; set; }
        public string SUB_CONTRACTOR { get; set; }
        public bool IS_DELETE { get; set; }
        public string STATUS { get; set; }
        public int SLNO { get; set; }

        public string BACS_REF { get; set; }
        public string ACCOUNT_NAME { get; set; }
        public string BANK_NAME { get; set; }
        public string STREET { get; set; }
        public string TOWN { get; set; }
        public string SHORT_CODE { get; set; }
        public string ACCOUNT_NUMBER { get; set; }
        public string LAST_DISC_PER { get; set; }
        public string BIC_SWIFT { get; set; }
        public string PAYMENT_REF { get; set; }
        public string IBAN { get; set; }
        public string PAYMENT_METHOD { get; set; }
        public string NOTES { get; set; }
        public string USE_E_PAYMENT { get; set; }
        public decimal STANDARD_DISC_PER { get; set; }
        //public decimal LAST_DISC_PER { get; set; }
        public string BENEFICIARY { get; set; }
        public int LAST_DISC_DAYS { get; set; }
        public int STANDARD_DISC_DAYS { get; set; }

        public string BUSINESS_TYPE { get; set; }
        public string PARTNERSHIP_NAME { get; set; }
        public string PARTNERSHIP_UTR { get; set; }
        public string TRADING_NAME { get; set; }
        public string LEGAL_NAME { get; set; }
        public bool USE_LEGAL_NAME { get; set; }
        public string PRODUCE_STATEMENT { get; set; }
        public string CIS_TYPE { get; set; }
        public string CIS_CETT { get; set; }
        public string CIS_CERT_NO { get; set; }
        public DateTime DATE_LAST_VERIFIED { get; set; }
        public DateTime DATE_VALID_FROM { get; set; }
        public DateTime DATE_VALID_TO { get; set; }
        public string FORENAME { get; set; }
        public string MIDDLE_NAME { get; set; }
        public string SURNAME { get; set; }
        public string UTR { get; set; }
        public string INSURANCE_NO { get; set; }
        public string CO_REG_NO { get; set; }
        public string STATUS_VERIFICATION { get; set; }
        public string VERIFICATION_NO { get; set; }
        public string TAX_TREATMENT { get; set; }
       
        
        
    }
}