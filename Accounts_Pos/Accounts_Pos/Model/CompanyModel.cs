using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    class CompanyModel : IDataErrorInfo
    {
        private Regex numerciRegex = new Regex("[^0-9.-]+");
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
        public int SLNO { get; set; }
        public string FIN_YEAR { get; set; }
        public int COMPANY_ID { get; set; }
        public int LOGIN_ID { get; set; }
        private System.Text.RegularExpressions.Regex No = new System.Text.RegularExpressions.Regex("[^0-9]");
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

                if (columnName == "COMPANY_NAME" && string.IsNullOrWhiteSpace(COMPANY_NAME))
                {
                    error = "USER_NAME is required!";

                }

                if (columnName == "START_YEAR" && string.IsNullOrWhiteSpace(START_YEAR))
                {
                    error = "START_YEAR is required!";

                }

                if (columnName == "USER_NAME" && string.IsNullOrWhiteSpace(USER_NAME))
                {
                    error = "USER_NAME is required!";

                }
                if (columnName == "PASSWORD" && string.IsNullOrWhiteSpace(PASSWORD))
                {
                    error = "PASSWORD is required!";

                }
                if (columnName == "CONFIRM_PASSWORD" && string.IsNullOrWhiteSpace(CONFIRM_PASSWORD))
                {
                    error = "CONFIRM_PASSWORD is required!";

                }

                //switch (columnName)
                //{
                //    case "TAX_PAID": if ((TAX_PAID <= 0)) error = "Tax paid is required!"; break;
                //    case "SALES_PRICE": if ((SALES_PRICE <= 0)) error = "Sales Price can not be blank"; break;
                //    case "TAX_COLLECTED": if ((TAX_COLLECTED <= 0)) error = "Tax Collected can not be blank"; break;
                //    case "OPN_QNT": if ((OPN_QNT <= 0)) error = "Opening Qnt can not be blank"; break;
                //    case "MRP": if ((MRP <= 0)) error = "MRP can not be blank"; break;
                //};
                return error;
            }
        }

        private bool IsValidNumbers
        {
            get
            {
                if (TELEPHONE != null)
                {
                    return numerciRegex.IsMatch(TELEPHONE);
                }
                if (POSTCODE != null)
                {
                    return numerciRegex.IsMatch(POSTCODE);
                }
                if (FAX != null)
                {
                    return numerciRegex.IsMatch(FAX);
                }
                //if (Mobile != null)
                //{
                //    return numerciRegex.IsMatch(Mobile);
                //}
                //if (Fax != null)
                //{
                //    return numerciRegex.IsMatch(Fax);
                //}
                //if (Pin != null)
                //{
                //    return numerciRegex.IsMatch(Fax);
                //}
                else
                {
                    return false;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

}













