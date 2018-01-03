using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    //class CustomerModel : INotifyPropertyChanged, IDataErrorInfo
    public class CustomerModel : IDataErrorInfo
    {



        public string CUSTOMER_NAME { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public bool IS_CUSTOMER { get; set; }
        public string ADDRESS { get; set; }
        public string POSTCODE { get; set; }
        public string COUNTRY { get; set; }
        public string WEBSITE { get; set; }
        //public DateTime DATE_STARTED { get; set; }
        //public Nullable<System.DateTime> DATE_STARTED { get; set; }
        public string STATEMENT { get; set; }
        public string SEND_MAIL { get; set; }
        public string VAT_TYPE { get; set; }
        public string VAT_NUMBER { get; set; }
        public string DYNAMIC_DISC { get; set; }
        public string CUSTOMER_INACTIVE { get; set; }
        public string REGISTERED { get; set; }
        //public DateTime OLDEST_INV_DATE { get; set; }
        //public DateTime LAST_SALE { get; set; }
        //public DateTime LAST_PAYMENT { get; set; }
        //public DateTime AVG_PMT_DATE { get; set; }
        public decimal CREDIT_LIMIT { get; set; }
        //public decimal OS_BALANCE { get; set; }
        //public decimal OS_ORDERS { get; set; }
        //public decimal CR_REMAIN { get; set; }
        public bool ON_CREDIT_STOP { get; set; }
        //public string STOPPED_ON { get; set; }
        //public string ON_STOP_AFTER { get; set; }
        //public string PUT_ON_STOP_BY { get; set; }
        public string CONTACT_TYPE { get; set; }
        public string CONTACT_NAME { get; set; }
        public string CONTACT_SALUTATION { get; set; }
        public string CONTACT_PHONE_NO { get; set; }
        public string CONTACT_EXTN_NO { get; set; }
        public string CONTACT_MOBILE_NO { get; set; }
        public string CONTACT_FAX { get; set; }
        public string EMAIL { get; set; }
        public string SKYPE { get; set; }
        public string PRICE_TYPE { get; set; }
        public DateTime DATE_STARTED { get; set; }
        public int COMPANY_ID { get; set; }
        public string CUSTOMER_MAIL { get; set; }
        public bool IS_DELETE { get; set; }
        public string CUSTOMER_STATUS { get; set; }
        public string DUNS_NO { get; set; }
        public string STATUS { get; set; }
        public bool IS_SUPPLIER { get; set; }
        public int CUSTOMER_ID { get; set; }
        public int SLNO { get; set; }

        private string error = string.Empty;
        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        public string this[string columnName]
        {
            get
            {

                error = string.Empty;

                if (columnName == "CUSTOMER_NAME" && string.IsNullOrWhiteSpace(CUSTOMER_NAME))
                {
                    error = "CUSTOMER NAME is required!";

                }

                if (columnName == "CUSTOMER_CODE" && string.IsNullOrWhiteSpace(CUSTOMER_CODE))
                {
                    error = "CUSTOMER CODE is required!";

                }
                return error;
            }
        }


    }
}
