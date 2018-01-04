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
    class QuickJournalEntryViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public HttpResponseMessage response;
        SalesModel[] data = null;
        ObservableCollection<SalesModel> _ListGrid_Temp = new ObservableCollection<SalesModel>();
        //int comp = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
        //int comp = 46;
        public QuickJournalEntryViewModel()
        {
            selectSales = new SalesModel();
            JOURNAL_DATE = System.DateTime.Now;


            CreatVisible = "Visible";
            UpdVisible = "Collapsed";
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

        private string _CreatVisible { get; set; }
        public string CreatVisible
        {

            get { return _CreatVisible; }
            set
            {
                if (value != _CreatVisible)
                {
                    _CreatVisible = value;
                    OnPropertyChanged("CreatVisible");
                }
            }
        }

        private string _UpdVisible { get; set; }
        public string UpdVisible
        {

            get { return _UpdVisible; }
            set
            {
                if (value != _UpdVisible)
                {
                    _UpdVisible = value;
                    OnPropertyChanged("UpdVisible");
                }
            }
        }

        //private string _AddVisible { get; set; }
        //public string AddVisible
        //{

        //    get { return _AddVisible; }
        //    set
        //    {
        //        if (value != _AddVisible)
        //        {
        //            _AddVisible = value;
        //            OnPropertyChanged("AddVisible");
        //        }
        //    }
        //}



        private string _QUICKJOURNAL_CODE;
        public string QUICKJOURNAL_CODE
        {
            get
            {
                return selectSales.QUICKJOURNAL_CODE;
            }
            set
            {
                selectSales.QUICKJOURNAL_CODE = value;
                OnPropertyChanged("QUICKJOURNAL_CODE");

            }
        }

        private DateTime _JOURNAL_DATE;
        public DateTime JOURNAL_DATE
        {
            get
            {
                return selectSales.JOURNAL_DATE;
            }
            set
            {
                selectSales.JOURNAL_DATE = value;
                OnPropertyChanged("JOURNAL_DATE");

            }
        }

        private string _CUSTOMER;
        public string CUSTOMER
        {
            get
            {
                return selectSales.CUSTOMER;
            }
            set
            {
                selectSales.CUSTOMER = value;
                OnPropertyChanged("CUSTOMER");

            }
        }

        //private string _PRODUCT;
        //public string PROJECT_CODE
        //{
        //    get
        //    {
        //        return selectSales.PRODUCT;
        //    }
        //    set
        //    {
        //        selectSales.PRODUCT = value;
        //        OnPropertyChanged("PRODUCT");

        //    }
        //}


        private string _REFERENCE;
        public string REFERENCE
        {
            get
            {
                return selectSales.REFERENCE;
            }
            set
            {
                selectSales.REFERENCE = value;
                OnPropertyChanged("REFERENCE");

            }
        }

        private string _JOURNAL_DESC;
        public string JOURNAL_DESC
        {
            get
            {
                return selectSales.JOURNAL_DESC;
            }
            set
            {
                selectSales.JOURNAL_DESC = value;
                OnPropertyChanged("JOURNAL_DESC");

            }
        }


        private string _NL_ACC1;
        public string NL_ACC1
        {
            get
            {
                return selectSales.NL_ACC1;
            }
            set
            {
                selectSales.NL_ACC1 = value;
                OnPropertyChanged("NL_ACC1");

            }
        }

        private string _NL_ACC2;
        public string NL_ACC2
        {
            get
            {
                return selectSales.NL_ACC2;
            }
            set
            {
                selectSales.NL_ACC1 = "100";
                OnPropertyChanged("NL_ACC2");

            }
        }


        private string _VAT_PER;
        public string VAT_PER
        {
            get
            {
                return selectSales.VAT_PER;
            }
            set
            {
                selectSales.VAT_PER = value;
                OnPropertyChanged("VAT_PER");

            }
        }



        private Decimal _TOTAL_VAT;
        public Decimal TOTAL_VAT
        {
            get
            {
                return selectSales.TOTAL_VAT;
            }
            set
            {
                selectSales.TOTAL_VAT = value;
                OnPropertyChanged("TOTAL_VAT");

            }
        }

        private Decimal _NET_AMOUNT;
        public Decimal NET_AMOUNT
        {
            get
            {
                return selectSales.NET_AMOUNT;
            }
            set
            {
                selectSales.NET_AMOUNT = value;
                OnPropertyChanged("NET_AMOUNT");

            }
        }

        private Decimal _TOTAL_AMOUNT;
        public Decimal TOTAL_AMOUNT
        {
            get
            {
                return selectSales.TOTAL_AMOUNT;
            }
            set
            {
                selectSales.TOTAL_AMOUNT = value;
                OnPropertyChanged("TOTAL_AMOUNT");

            }
        }

        #region Insert Data
        public ICommand _InsertData;
        public ICommand InsertData
        {
            get
            {
                if (_InsertData == null)
                {
                    _InsertData = new DelegateCommand(Insert_Data);
                }
                return _InsertData;
            }
        }



        public async void Insert_Data()
        {
            try
            {

                //selectSupplier.SUPPLIER_CODE = App.Current.Properties["Customer_Code"].ToString();
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/SalesAPI/CreateQuickJournal/", selectSales);
                if (response.StatusCode.ToString() == "OK")
                {

                    MessageBox.Show("Quick Journal Data Added Successfully");

                    //Cancel_Sale();
                    recurringsales _RS = new recurringsales();
                    _RS.ShowDialog();
                    Cancel_Sale();

                }

            }
            catch
            {

            }

        }

        #endregion
        // #region Cancel Data

        public ICommand _Cancel;
        public ICommand Cancel
        {
            get
            {
                if (_Cancel == null)
                {
                    _Cancel = new DelegateCommand(Cancel_Sale);
                }
                return _Cancel;
            }
        }



        public void Cancel_Sale()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }

        // #endregion


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
