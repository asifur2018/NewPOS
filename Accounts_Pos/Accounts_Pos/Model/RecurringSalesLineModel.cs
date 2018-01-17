using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Accounts_Pos.Model
{
    class RecurringSalesLineModel : INotifyPropertyChanged
    {
        private int _NO;
        public int NO
        {
            get { return _NO; }
            set
            {
                _NO = value;
                NotifyPropertyChanged("NO");
            }
        }
        private int _RECURRING_SALES_LINE_ID;
        public int RECURRING_SALES_LINE_ID
        {
            get { return _RECURRING_SALES_LINE_ID; }
            set
            {
                _RECURRING_SALES_LINE_ID = value;
                NotifyPropertyChanged("RECURRING_SALES_LINE_ID");
            }
        }

        private string _PRODUCT_CODE;
        public string PRODUCT_CODE
        {
            get { return _PRODUCT_CODE; }
            set
            {
                _PRODUCT_CODE = value;
                NotifyPropertyChanged("PRODUCT_CODE");
            }
        }

        private string _DESCRIPTION;
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set
            {
                _DESCRIPTION = value;
                NotifyPropertyChanged("DESCRIPTION");
            }
        }

        private decimal _ORDER_QTY;
        public decimal ORDER_QTY
        {
            get { return _ORDER_QTY; }
            set
            {
                _ORDER_QTY = value;
                NotifyPropertyChanged("ORDER_QTY");
                NotifyPropertyChanged("LINE_AMOUNT");
            }
        }


        private decimal _UNIT_PRICE;
        public decimal UNIT_PRICE
        {
            get { return _UNIT_PRICE; }
            set
            {
                _UNIT_PRICE = value;
                NotifyPropertyChanged("UNIT_PRICE");
                NotifyPropertyChanged("LINE_AMOUNT");
            }
        }


        private decimal _DISCOUNT_PERCENT;
        public decimal DISCOUNT_PERCENT
        {
            get { return _DISCOUNT_PERCENT; }
            set
            {
                _DISCOUNT_PERCENT = value;
                NotifyPropertyChanged("DISCOUNT_PERCENT");
                NotifyPropertyChanged("LINE_AMOUNT");
            }
        }


        private decimal _LINE_AMOUNT;
        public decimal LINE_AMOUNT
        {
            get
            {
                _LINE_AMOUNT = ORDER_QTY * UNIT_PRICE - DISCOUNT_PERCENT * ORDER_QTY * UNIT_PRICE / 100;
                return _LINE_AMOUNT;
            }
            set
            {
                _LINE_AMOUNT = value;
                NotifyPropertyChanged("LINE_AMOUNT");
            }

        }

        private int _RECURRING_SALES_INVOICE_ID;
        public int RECURRING_SALES_INVOICE_ID
        {
            get { return _RECURRING_SALES_INVOICE_ID; }
            set
            {
                _RECURRING_SALES_INVOICE_ID = value;
                NotifyPropertyChanged("RECURRING_SALES_INVOICE_ID");
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
