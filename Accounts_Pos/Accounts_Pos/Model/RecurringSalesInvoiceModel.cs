using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Accounts_Pos.Model
{
    class RecurringSalesInvoiceModel : INotifyPropertyChanged
    {
        public int      RECURR_SALES_INVOICE_ID { get; set; }
        public string   INVOICE_TO { get; set; }
        public string   DELIVERY_TO { get; set; }
        public string   ORDER_DES { get; set; }
        public string   ORDER_REF { get; set; }
        public string   SALES_PERSON { get; set; }
        public string   MARKET_CODE { get; set; }
        public string   FREQUENCY { get; set; }
        public string   CURRENT_STATUS { get; set; }
        public DateTime LAST_POSTED { get; set; }
        public DateTime PROCESS_NEXT_OCCUR { get; set; }
        public int      NUM_OF_TIME_TO_POST { get; set; }
        private decimal _ORDER_NET_AMOUNT;
        public decimal  ORDER_NET_AMOUNT 
        { 
            get
            {
                
                return _ORDER_NET_AMOUNT;
            }

            set
            {
                this._ORDER_NET_AMOUNT = value;
                NotifyPropertyChanged("ORDER_NET_AMOUNT");
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
