using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Accounts_Pos.Model
{
    class SalesOrderLineItemModel : INotifyPropertyChanged
    {
        private int _LINE_ITEM_ID;
        public int LINE_ITEM_ID
        {
            get { return _LINE_ITEM_ID; }
            set
            {
                _LINE_ITEM_ID = value;
                NotifyPropertyChanged("LINE_ITEM_ID"); 
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

        private decimal? _ORDER_QTY;
        public decimal? ORDER_QTY
        {
            get { return _ORDER_QTY; }
            set
            {
                _ORDER_QTY = value;
                NotifyPropertyChanged("ORDER_QTY");
                NotifyPropertyChanged("LINE_AMOUNT");
            }
        }

        private decimal? _UNIT_PRICE;
        public decimal? UNIT_PRICE
        {
            get { return _UNIT_PRICE; }
            set
            {
                _UNIT_PRICE = value;
                NotifyPropertyChanged("UNIT_PRICE");
                NotifyPropertyChanged("LINE_AMOUNT");
            }
        }

        private decimal? _DISCOUNT;
        public decimal? DISCOUNT
        {
            get { return _DISCOUNT; }
            set
            {
                _DISCOUNT = value;
                NotifyPropertyChanged("DISCOUNT");
                NotifyPropertyChanged("LINE_AMOUNT");
            }
        }

        private decimal? _LINE_AMOUNT;
        public decimal? LINE_AMOUNT
        {
            get 
            {
                _LINE_AMOUNT = ORDER_QTY * UNIT_PRICE - DISCOUNT * ORDER_QTY * UNIT_PRICE / 100;
                return _LINE_AMOUNT; 
            }
            set
            {
                _LINE_AMOUNT = value;
                NotifyPropertyChanged("LINE_AMOUNT");
            }
            
        }

        private int _VAT;
        public int VAT
        {
            get { return _VAT; }
            set
            {
                _VAT = value;
                NotifyPropertyChanged("VAT");
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
