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
    class CustomerJournalDebitViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public HttpResponseMessage response;
        SalesModel[] data = null;
        ObservableCollection<SalesModel> _ListGrid_Temp = new ObservableCollection<SalesModel>();
        //int comp = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
        //int comp = 46;
        public CustomerJournalDebitViewModel()
        {
            selectSales = new SalesModel();
            INV_DATE = System.DateTime.Now;
            INV_EXP_DATE = System.DateTime.Now;
            POSTING_DATE = System.DateTime.Now;

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

        private string _SUPPLIER_CODE;
        public string SUPPLIER_CODE
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


        private string _TRX_TYPE;
        public string TRX_TYPE
        {
            get
            {
                return selectSales.TRX_TYPE;
            }
            set
            {
                selectSales.TRX_TYPE = value;
                OnPropertyChanged("TRX_TYPE");

            }
        }

        private string _POSTING_NO;
        public string POSTING_NO
        {
            get
            {
                return selectSales.POSTING_NO;
            }
            set
            {
                selectSales.POSTING_NO = value;
                OnPropertyChanged("POSTING_NO");

            }
        }

        private string _POSTING_TYPE;
        public string POSTING_TYPE
        {
            get
            {
                return selectSales.POSTING_TYPE;
            }
            set
            {
                selectSales.POSTING_TYPE = value;
                OnPropertyChanged("POSTING_TYPE");

            }
        }

        private string _DEF_DIST;
        public string DEF_DIST
        {
            get
            {
                return selectSales.DEF_DIST;
            }
            set
            {
                selectSales.DEF_DIST = value;
                OnPropertyChanged("DEF_DIST");

            }
        }

        private string _GENERAL_CODE;
        public string GENERAL_CODE
        {
            get
            {
                return selectSales.GENERAL_CODE;
            }
            set
            {
                selectSales.GENERAL_CODE = value;
                OnPropertyChanged("GENERAL_CODE");

            }
        }

        private string _GENERAL_NAME;
        public string GENERAL_NAME
        {
            get
            {
                return selectSales.GENERAL_NAME;
            }
            set
            {
                selectSales.GENERAL_NAME = value;
                OnPropertyChanged("GENERAL_NAME");

            }
        }

        private string _REF_NO;
        public string REF_NO
        {
            get
            {
                return selectSales.REF_NO;
            }
            set
            {
                selectSales.REF_NO = value;
                OnPropertyChanged("REF_NO");

            }
        }

        private DateTime _POSTING_DATE;
        public DateTime POSTING_DATE
        {
            get
            {
                return selectSales.POSTING_DATE;
            }
            set
            {
                selectSales.POSTING_DATE = value;
                OnPropertyChanged("POSTING_DATE");

            }
        }

        private DateTime _INV_DATE;
        public DateTime INV_DATE
        {
            get
            {
                return selectSales.INV_DATE;
            }
            set
            {
                selectSales.INV_DATE = value;
                OnPropertyChanged("INV_DATE");

            }
        }

        private DateTime _INV_EXP_DATE;
        public DateTime INV_EXP_DATE
        {
            get
            {
                return selectSales.INV_EXP_DATE;
            }
            set
            {
                selectSales.INV_EXP_DATE = value;
                OnPropertyChanged("INV_EXP_DATE");

            }
        }

        private string _DESCRIPTION;
        public string DESCRIPTION
        {
            get
            {
                return selectSales.DESCRIPTION;
            }
            set
            {
                selectSales.DESCRIPTION = value;
                OnPropertyChanged("DESCRIPTION");

            }
        }

        private string _PROJECT;
        public string PROJECT
        {
            get
            {
                return selectSales.PROJECT;
            }
            set
            {
                selectSales.PROJECT = value;
                OnPropertyChanged("PROJECT");

            }
        }

        private Decimal _OS_BAL;
        public Decimal OS_BAL
        {
            get
            {
                return selectSales.OS_BAL;
            }
            set
            {
                selectSales.OS_BAL = value;
                OnPropertyChanged("OS_BAL");

            }
        }



        private Decimal _CREDIT_REMAINING;
        public Decimal CREDIT_REMAINING
        {
            get
            {
                return selectSales.CREDIT_REMAINING;
            }
            set
            {
                selectSales.CREDIT_REMAINING = value;
                OnPropertyChanged("CREDIT_REMAINING");

            }
        }


        private Decimal _NET_BAL;
        public Decimal NET_BAL
        {
            get
            {
                return selectSales.NET_BAL;
            }
            set
            {
                selectSales.NET_BAL = value;
                OnPropertyChanged("NET_BAL");

            }
        }

        private Decimal _TAX_AMT;
        public Decimal TAX_AMT
        {
            get
            {
                return selectSales.TAX_AMT;
            }
            set
            {
                selectSales.TAX_AMT = value;
                OnPropertyChanged("TAX_AMT");

            }
        }

        private Decimal _TOTAL_AMT;
        public Decimal TOTAL_AMT
        {
            get
            {
                return selectSales.TOTAL_AMT;
            }
            set
            {
                selectSales.TOTAL_AMT = value;
                OnPropertyChanged("TOTAL_AMT");

            }
        }

        private Decimal _COST;
        public Decimal COST
        {
            get
            {
                return selectSales.COST;
            }
            set
            {
                selectSales.COST = value;
                OnPropertyChanged("COST");

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
                var response = await client.PostAsJsonAsync("api/SalesAPI/CreateCustomerJournal/", selectSales);
                if (response.StatusCode.ToString() == "OK")
                {

                    MessageBox.Show("Journal Debit Data Added Successfully");

                    //Cancel_Sale();
                    QuickJournalEntry _QE = new QuickJournalEntry();
                    _QE.ShowDialog();
                    Cancel_Sale();

                }

            }
            catch
            {

            }

        }

        #endregion
        #region Cancel Data

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

        #endregion



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
