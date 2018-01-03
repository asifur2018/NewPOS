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
    class MiscellaneousViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public MiscellaneousViewModel()
        {
            selectMiscellaneous = new MiscellaneousModel();
        }



        private MiscellaneousModel _selectMiscellaneous;
        public MiscellaneousModel selectMiscellaneous
        {
            get { return _selectMiscellaneous; }
            set
            {
                if (_selectMiscellaneous != value)
                {
                    _selectMiscellaneous = value;
                    OnPropertyChanged("selectMiscellaneous");
                }
            }
        }


        private string _BACS_REF;
        public string BACS_REF
        {
            get
            {
                return selectMiscellaneous.BACS_REF;
            }
            set
            {
                selectMiscellaneous.BACS_REF = value;
                OnPropertyChanged("BACS_REF");

            }
        }

        private string _ACCOUNT_NAME;
        public string ACCOUNT_NAME
        {
            get
            {
                return selectMiscellaneous.ACCOUNT_NAME;
            }
            set
            {
                selectMiscellaneous.ACCOUNT_NAME = value;
                OnPropertyChanged("ACCOUNT_NAME");

            }
        }

        private string _BANK_NAME;
        public string BANK_NAME
        {
            get
            {
                return selectMiscellaneous.BANK_NAME;
            }
            set
            {
                selectMiscellaneous.BANK_NAME = value;
                OnPropertyChanged("BANK_NAME");

            }
        }


        private string _STREET1;
        public string STREET1
        {
            get
            {
                return selectMiscellaneous.STREET1;
            }
            set
            {
                selectMiscellaneous.STREET1 = value;
                OnPropertyChanged("STREET1");

            }
        }


        private string _STREET2;
        public string STREET2
        {
            get
            {
                return selectMiscellaneous.STREET2;
            }
            set
            {
                selectMiscellaneous.STREET2 = value;
                OnPropertyChanged("STREET2");

            }
        }



        private string _TOWN;
        public string TOWN
        {
            get
            {
                return selectMiscellaneous.TOWN;
            }
            set
            {
                selectMiscellaneous.TOWN = value;
                OnPropertyChanged("ACCOUNT_NAME");

            }
        }




        private string _COUNTRY;
        public string COUNTRY
        {
            get
            {
                return selectMiscellaneous.COUNTRY;
            }
            set
            {
                selectMiscellaneous.COUNTRY = value;
                OnPropertyChanged("COUNTRY");

            }
        }


        private string _POST_CODE;
        public string POST_CODE
        {
            get
            {
                return selectMiscellaneous.POST_CODE;
            }
            set
            {
                selectMiscellaneous.POST_CODE = value;
                OnPropertyChanged("POST_CODE");

            }
        }



        private string _SHORT_CODE;
        public string SHORT_CODE
        {
            get
            {
                return selectMiscellaneous.SHORT_CODE;
            }
            set
            {
                selectMiscellaneous.SHORT_CODE = value;
                OnPropertyChanged("ACCOUNT_NAME");

            }
        }



        private string _ACCOUNT_NUMBER;
        public string ACCOUNT_NUMBER
        {
            get
            {
                return selectMiscellaneous.ACCOUNT_NUMBER;
            }
            set
            {
                selectMiscellaneous.ACCOUNT_NUMBER = value;
                OnPropertyChanged("ACCOUNT_NUMBER");

            }
        }


        private string _PAYMENT_REF;
        public string PAYMENT_REF
        {
            get
            {
                return selectMiscellaneous.PAYMENT_REF;
            }
            set
            {
                selectMiscellaneous.PAYMENT_REF = value;
                OnPropertyChanged("ACCOUNT_NAME");

            }
        }




        private string _BIC_SWIFT;
        public string BIC_SWIFT
        {
            get
            {
                return selectMiscellaneous.BIC_SWIFT;
            }
            set
            {
                selectMiscellaneous.BIC_SWIFT = value;
                OnPropertyChanged("BIC_SWIFT");

            }
        }
        private string _IBAN;
        public string IBAN
        {
            get
            {
                return selectMiscellaneous.IBAN;
            }
            set
            {
                selectMiscellaneous.IBAN = value;
                OnPropertyChanged("IBAN");

            }
        }
        private string _ROLL_NUMBER;
        public string ROLL_NUMBER
        {
            get
            {
                return selectMiscellaneous.ROLL_NUMBER;
            }
            set
            {
                selectMiscellaneous.ROLL_NUMBER = value;
                OnPropertyChanged("ROLL_NUMBER");

            }
        }

        private string _ADDITIONAL_REFERENCE;
        public string ADDITIONAL_REFERENCE
        {
            get
            {
                return selectMiscellaneous.ADDITIONAL_REFERENCE;
            }
            set
            {
                selectMiscellaneous.ADDITIONAL_REFERENCE = value;
                OnPropertyChanged("ADDITIONAL_REFERENCE");

            }
        }



        private string _PAYMENT_METHOD;
        public string PAYMENT_METHOD
        {
            get
            {
                return selectMiscellaneous.PAYMENT_METHOD;
            }
            set
            {
                selectMiscellaneous.PAYMENT_METHOD = value;
                OnPropertyChanged("ROLL_NO");

            }
        }

        private string _ONLINE_RECEIPT;
        public string ONLINE_RECEIPT
        {
            get
            {
                return selectMiscellaneous.ONLINE_RECEIPT;
            }
            set
            {
                selectMiscellaneous.ONLINE_RECEIPT = value;
                OnPropertyChanged("ONLINE_RECEIPT");

            }
        }

        private string _NOTES;
        public string NOTES
        {
            get
            {
                return selectMiscellaneous.NOTES;
            }
            set
            {
                selectMiscellaneous.NOTES = value;
                OnPropertyChanged("NOTES");

            }
        }
       

        private bool _IS_ONLINE_RECEIPT;
        public bool IS_ONLINE_RECEIPT
        {
            get
            {
                return selectMiscellaneous.IS_ONLINE_RECEIPT;
            }
            set
            {
                selectMiscellaneous.IS_ONLINE_RECEIPT = value;
                if (selectMiscellaneous.IS_ONLINE_RECEIPT != value)
                {
                    selectMiscellaneous.IS_ONLINE_RECEIPT = value;
                    OnPropertyChanged("IS_ONLINE_RECEIPT");
                }
            }
        }
        

        //private int COMPANY_ID;
        //public int COMPANY_ID
        //{
        //    get
        //    {
        //        return selectMiscellaneous.COMPANY_ID;
        //    }
        //    set
        //    {
        //        selectMiscellaneous.COMPANY_ID = value;
        //        OnPropertyChanged("COMPANY_ID");

        //    }
        //}


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

        //#region Insert Data
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
                
                    selectMiscellaneous.CUSTOMER_CODE = App.Current.Properties["Customer_Code"].ToString();
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    var response = await client.PostAsJsonAsync("api/MiscellaneousAPI/CreateMiscellaneous/", selectMiscellaneous);
                    if (response.StatusCode.ToString() == "OK")
                    {

                        MessageBox.Show("Miscellaneous Data Added Successfully");
                        foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)

                            if (window.DataContext == this)
                            {
                                window.Close();
                            }


                        DeliveryAddress _DA = new DeliveryAddress();
                        _DA.ShowDialog();

                    }
                
            }
            catch
            {

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
