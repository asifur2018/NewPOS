using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Accounts_Pos.Helpers;
using Accounts_Pos.Model;
using Accounts_Pos.View.Customer;
using Accounts_Pos.View.Product;
using Accounts_Pos.View.Sales;
using Newtonsoft.Json;

namespace Accounts_Pos.ViewModel.Sales
{
    class RecurringSalesViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {

        public HttpResponseMessage response;
        SalesModel[] data = null;
        ObservableCollection<SalesModel> _ListGrid_Temp = new ObservableCollection<SalesModel>();
        //int comp = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
        //int comp = 46;
        public RecurringSalesViewModel()
        {
            selectSales = new SalesModel();
            //CUT_OFF_DATE = System.DateTime.Now;


            //CreatVisible = "Visible";
            //UpdVisible = "Collapsed";
            //AddVisible = "Visible";

        }

        private SalesModel _selectSales;
        public SalesModel selectSales
        {
            get { return _selectSales; }
            set
            {
                if (_selectSales != value)
                {
                    _selectSales = value;
                    OnPropertyChanged("selectSales");
                }
            }
        }

        private string _LEDGER;
        public string LEDGER
        {
            get
            {
                return selectSales.LEDGER;
            }
            set
            {
                selectSales.LEDGER = value;
                OnPropertyChanged("LEDGER");

            }
        }



        //private string _TRANSCATION_TYPE;
        //public string TRANSCATION_TYPE
        //{
        //    get
        //    {
        //        return selectSales.TRANSCATION_TYPE;
        //    }
        //    set
        //    {
        //        selectSales.TRANSCATION_TYPE = value;
        //        OnPropertyChanged("TRANSCATION_TYPE");

        //    }
        //}

        //private string _FREQUENCY;
        //public string FREQUENCY
        //{
        //    get
        //    {
        //        return selectSales.FREQUENCY;
        //    }
        //    set
        //    {
        //        selectSales.FREQUENCY = value;
        //        OnPropertyChanged("FREQUENCY");

        //    }
        //}

        //private DateTime _CUT_OFF_DATE;
        //public DateTime CUT_OFF_DATE
        //{
        //    get
        //    {
        //        return selectSales.CUT_OFF_DATE;
        //    }
        //    set
        //    {
        //        selectSales.CUT_OFF_DATE = value;
        //        OnPropertyChanged("CUT_OFF_DATE");

        //    }
        //}


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

        private Stack<BackNavigationEventHandler> _backFunctions = new Stack<BackNavigationEventHandler>();

        void IModalService.NavigateTo(Window uc, BackNavigationEventHandler backFromDialog)
        {

        }

        void IModalService.GoBackward(bool dialogReturnValue)
        {
        }


        public static IModalService ModalService
        {
            get { return (IModalService)Application.Current.MainWindow; }
        }
    }
}
