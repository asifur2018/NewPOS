using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class CompanyModel
    {
        public string CREATION_TYPE { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public DateTime CREATE_DATE_TIME { get; set; }
        public string COMPANY_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string COUNTRY { get; set; }
        public string POSTCODE { get; set; }
        public string TELEPHONE { get; set; }
        public string FAX { get; set; }
        public string WEBSITE { get; set; }
        public string COMPANY_STATUS { get; set; }
        public string COMPANY_TYPE { get; set; }
        public string START_YEAR { get; set; }
        public string START_FIN_YEAR { get; set; }
        public string END_FIN_YEAR { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string CONFIRM_PASSWORD { get; set; }
        public bool IS_DELETE { get; set; }
        public bool FROM_SCRATCH { get; set; }
        public bool FROM_BACKUP { get; set; }
        public bool CREATE_CONSOLIDATED { get; set; }
        public bool CREATE_DEMONSTRATION { get; set; }
        public string MONTH1 { get; set; }
        public string YEAR1 { get; set; }
        public string DATE2 { get; set; }
        public string MONTH2 { get; set; }
        public string YEAR2 { get; set; }
        public string YEAR3 { get; set; }
        public bool MONTH_YEAR { get; set; }
        public bool DATE_MONTH_YEAR { get; set; }
        public bool YEAR { get; set; }
        public string FIN_YEAR { get; set; }
        public int? COMPANY_ID { get; set; }
        public int SLNO { get; set; }
        public int LOGIN_ID { get; set; }
    }
}