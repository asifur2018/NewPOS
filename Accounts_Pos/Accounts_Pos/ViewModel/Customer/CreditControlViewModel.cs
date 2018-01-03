using System;
using System.Collections.Generic;
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

namespace Accounts_Pos.ViewModel.Customer
{
    class CreditControlViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {

        public CreditControlViewModel()
        {
            selectCreditControl = new CreditControlModel();
            selectCreditControl.ACCOUNT_OPENED = System.DateTime.Now;
            selectCreditControl.APPLICATION_DATE = System.DateTime.Now;
            selectCreditControl.DATE_RECEIVED = System.DateTime.Now;
            //.PAYMENT_FROM = System.DateTime.Now;
            
                
        }


        private CreditControlModel _selectCreditControl;
        public CreditControlModel selectCreditControl
        {
            get { return _selectCreditControl; }
            set
            {
                if (_selectCreditControl != value)
                {
                    _selectCreditControl = value;
                    OnPropertyChanged("selectCreditControl");
                }
            }
        }

        private decimal _CREDIT_LIMIT;
        public decimal CREDIT_LIMIT
        {
            get
            {
                return selectCreditControl.CREDIT_LIMIT;
            }
            set
            {
                selectCreditControl.CREDIT_LIMIT = value;
                OnPropertyChanged("CREDIT_LIMIT");

            }
        }

        private int _SETTLEMENT_DUE;
        public int SETTLEMENT_DUE
        {
            get
            {
                return selectCreditControl.SETTLEMENT_DUE;
            }
            set
            {
                selectCreditControl.SETTLEMENT_DUE = value;
                OnPropertyChanged("SETTLEMENT_DUE");

            }
        }

        private decimal _SETTLEMENT_DISCOUNT;
        public decimal SETTLEMENT_DISCOUNT
        {
            get
            {
                return selectCreditControl.SETTLEMENT_DISCOUNT;
            }
            set
            {
                selectCreditControl.SETTLEMENT_DISCOUNT = value;
                OnPropertyChanged("SETTLEMENT_DISCOUNT");

            }
        }

        private int _PAYMENT_DUE;
        public int PAYMENT_DUE
        {
            get
            {
                return selectCreditControl.PAYMENT_DUE;
            }
            set
            {
                selectCreditControl.PAYMENT_DUE = value;
                OnPropertyChanged("PAYMENT_DUE");

            }
        }


        private int _AVG_TIME;
        public int AVG_TIME
        {
            get
            {
                return selectCreditControl.AVG_TIME;
            }
            set
            {
                selectCreditControl.AVG_TIME = value;
                OnPropertyChanged("AVG_TIME");

            }
        }

        private string _PAYMENT_FROM;
        public string PAYMENT_FROM
        {
            get
            {
                return selectCreditControl.PAYMENT_FROM;
            }
            set
            {
                selectCreditControl.PAYMENT_FROM = value;


                if (selectCreditControl.PAYMENT_FROM != value)
                {
                    selectCreditControl.PAYMENT_FROM = value;
                    OnPropertyChanged("PAYMENT_FROM");
                }
            }
        }


        private string _TREDING_TERMS;
        public string TREDING_TERMS
        {
            get
            {
                return selectCreditControl.TREDING_TERMS;
            }
            set
            {
                selectCreditControl.TREDING_TERMS = value;
                OnPropertyChanged("CREDIT_LIMIT");

            }
        }

        private string _CREDIT_REF;
        public string CREDIT_REF
        {
            get
            {
                return selectCreditControl.CREDIT_REF;
            }
            set
            {
                selectCreditControl.CREDIT_REF = value;
                OnPropertyChanged("CREDIT_REF");

            }
        }

        private bool _IS_PRIORITY;
        public bool IS_PRIORITY
        {
            get
            {
                return selectCreditControl.IS_PRIORITY;
            }
            set
            {
                selectCreditControl.IS_PRIORITY = value;
                OnPropertyChanged("IS_PRIORITY");

            }
        }

        private string _BUREAU;
        public string BUREAU
        {
            get
            {
                return selectCreditControl.BUREAU;
            }
            set
            {
                selectCreditControl.BUREAU = value;
                OnPropertyChanged("BUREAU");

            }
        }


        private string _CREDIT_POSITION;
        public string CREDIT_POSITION
        {
            get
            {
                return selectCreditControl.CREDIT_POSITION;
            }
            set
            {
                selectCreditControl.CREDIT_POSITION = value;
                OnPropertyChanged("CREDIT_POSITION");

            }
        }

        private string _ACCOUNT_STATUS;
        public string ACCOUNT_STATUS
        {
            get
            {
                return selectCreditControl.ACCOUNT_STATUS;
            }
            set
            {
                selectCreditControl.ACCOUNT_STATUS = value;
                OnPropertyChanged("ACCOUNT_STATUS");

            }
        }

        private string _DUNG_NUMBER;
        public string DUNG_NUMBER
        {
            get
            {
                return selectCreditControl.DUNS_NUMBER;
            }
            set
            {
                selectCreditControl.DUNS_NUMBER = value;
                OnPropertyChanged("DUNG_NUMBER");

            }
        }

        private DateTime _ACCOUNT_OPENED;
        public DateTime ACCOUNT_OPENED
        {
            get
            {
                return selectCreditControl.ACCOUNT_OPENED;
            }
            set
            {
                selectCreditControl.ACCOUNT_OPENED = value;


                if (selectCreditControl.ACCOUNT_OPENED != value)
                {
                    selectCreditControl.ACCOUNT_OPENED = value;
                    OnPropertyChanged("ACCOUNT_OPENED");
                }
            }
        }

        private string _LAST_CREDIT;
        public string LAST_CREDIT
        {
            get
            {
                return selectCreditControl.LAST_CREDIT;
            }
            set
            {
                selectCreditControl.LAST_CREDIT = value;
                OnPropertyChanged("LAST_CREDIT");

            }
        }

        private string _NEXT_CREDIT;
        public string NEXT_CREDIT
        {
            get
            {
                return selectCreditControl.NEXT_CREDIT;
            }
            set
            {
                selectCreditControl.NEXT_CREDIT = value;
                OnPropertyChanged("NEXT_CREDIT");

            }
        }


        private string _MEMO;
        public string MEMO
        {
            get
            {
                return selectCreditControl.MEMO;
            }
            set
            {
                selectCreditControl.MEMO = value;
                OnPropertyChanged("MEMO");

            }
        }



        private DateTime _APPLICATION_DATE;
        public DateTime APPLICATION_DATE
        {
            get
            {
                return selectCreditControl.APPLICATION_DATE;
            }
            set
            {
                selectCreditControl.APPLICATION_DATE = value;


                if (selectCreditControl.APPLICATION_DATE != value)
                {
                    selectCreditControl.APPLICATION_DATE = value;
                    OnPropertyChanged("APPLICATION_DATE");
                }
            }
        }

        private DateTime _DATE_RECEIVED;
        public DateTime DATE_RECEIVED
        {
            get
            {
                return selectCreditControl.DATE_RECEIVED;
            }
            set
            {
                selectCreditControl.DATE_RECEIVED = value;


                if (selectCreditControl.DATE_RECEIVED != value)
                {
                    selectCreditControl.DATE_RECEIVED = value;
                    OnPropertyChanged("DATE_RECEIVED");
                }
            }
        }

        private string _CUSTOMER_CODE;
        public string CUSTOMER_CODE
        {
            get
            {
                return selectCreditControl.CUSTOMER_CODE;
            }
            set
            {
                selectCreditControl.CUSTOMER_CODE = value;
                OnPropertyChanged("CUSTOMER_CODE");

            }
        }


        public ICommand _InsertData { get; set; }
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


                App.Current.Properties["Customer_Code"] = CUSTOMER_CODE;
                //App.Current.Properties["Customer_Name"] = CUSTOMER_NAME;

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/CreditControlAPI/CreateCreditControl/", selectCreditControl);
                if (response.StatusCode.ToString() == "OK")
                {




                    MessageBox.Show("Customer Added Successfully");
                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)

                        if (window.DataContext == this)
                        {
                            window.Close();
                        }



                    Miscellaneous _MS = new Miscellaneous();
                    _MS.ShowDialog();
                }
            }

            catch
            {

            }

        }


    public ICommand _Cancel;
        public ICommand Cancel
        {
            get
            {
                if (_Cancel == null)
                {
                    _Cancel = new DelegateCommand(Cancel_Catagory);
                }
                return _Cancel;
            }
        }



        public void Cancel_Catagory()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
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
