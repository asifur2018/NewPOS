using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Accounts_Pos.Model
{
    class SalesOrderModel : INotifyPropertyChanged
    {   private int _SALESORDER_ID;
        public int SALESORDER_ID
        {
            get { return _SALESORDER_ID; }
            set
            {
                _SALESORDER_ID = value;
                NotifyPropertyChanged("SALESORDER_ID");
            }
        }

        private string _INVOICE_TO;
        public string INVOICE_TO
        {
            get { return _INVOICE_TO; }
            set
            {
                _INVOICE_TO = value;
                NotifyPropertyChanged("INVOICE_TO");
            }
        }

        private string _DELIVERY_TO;
        public string DELIVERY_TO
        {
            get { return _DELIVERY_TO; }
            set
            {
                _DELIVERY_TO = value;
                NotifyPropertyChanged("DELIVERY_TO");
            }
        }


        private string _ORDER_NO;
        public string ORDER_NO
        {
            get { return _ORDER_NO; }
            set
            {
                _ORDER_NO = value;
                NotifyPropertyChanged("ORDER_NO");
            }
        }

        private string _ORDER_REF;
        public string ORDER_REF
        {
            get { return _ORDER_REF; }
            set
            {
                _ORDER_REF = value;
                NotifyPropertyChanged("ORDER_NO");
            }
        }

        private DateTime _ORDER_DATE;
        public DateTime ORDER_DATE
        {
            get { return _ORDER_DATE; }
            set
            {
                _ORDER_DATE = value;
                NotifyPropertyChanged("ORDER_DATE");
            }
        }

        private string _SALES_PERSON;
        public string SALES_PERSON
        {
            get { return _SALES_PERSON; }
            set
            {
                _SALES_PERSON = value;
                NotifyPropertyChanged("SALES_PERSON");
            }
        }

        private string _MARKET_CODE;
        public string MARKET_CODE
        {
            get { return _MARKET_CODE; }
            set
            {
                _MARKET_CODE = value;
                NotifyPropertyChanged("MARKET_CODE");
            }
        }

        private decimal _OVERALL_DISC_PER;
        public decimal OVERALL_DISC_PER
        {
            get { return _OVERALL_DISC_PER; }
            set
            {
                _OVERALL_DISC_PER = value;
                NotifyPropertyChanged("OVERALL_DISC_PER");
            }
        }

        private decimal _ORDER_VALUE;
        public decimal ORDER_VALUE
        {
            get { return _ORDER_VALUE; }
            set
            {
                _ORDER_VALUE = value;
                NotifyPropertyChanged("ORDER_VALUE");
            }
        }
        private decimal _STANDARD_DISCOUNT;
        public decimal STANDARD_DISCOUNT
        {
            get { return _STANDARD_DISCOUNT; }
            set
            {
                _STANDARD_DISCOUNT = value;
                NotifyPropertyChanged("STANDARD_DISCOUNT");
            }
        }
        private decimal _TOTAL_VAT;
        public decimal TOTAL_VAT 
        {
            get { return _TOTAL_VAT; }
            set
            {
                _TOTAL_VAT = value;
                NotifyPropertyChanged("TOTAL_VAT");
            }
        }

        private decimal _TOTAL_ORDER_VALUE;
        public decimal TOTAL_ORDER_VALUE
        {
            get { return _TOTAL_ORDER_VALUE; }
            set
            {
                _TOTAL_ORDER_VALUE = value;
                NotifyPropertyChanged("TOTAL_ORDER_VALUE");
            }
        }

        private string _COST;
        public string COST
        {
            get { return _COST; }
            set
            {
                _COST = value;
                NotifyPropertyChanged("COST");
            }
        }

        private string _MARGIN;
        public string MARGIN
        {
            get { return _MARGIN; }
            set
            {
                _MARGIN = value;
                NotifyPropertyChanged("MARGIN");
            }
        }


        private string _MARGIN_PERCENT;
        public string MARGIN_PERCENT
        {
            get { return _MARGIN_PERCENT; }
            set
            {
                _MARGIN_PERCENT = value;
                NotifyPropertyChanged("MARGIN_PERCENT");
            }
        }

        private decimal _NET_VALUE;
        public decimal NET_VALUE
        {
            get { return _NET_VALUE; }
            set
            {
                _NET_VALUE = value;
                NotifyPropertyChanged("NET_VALUE");
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

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
