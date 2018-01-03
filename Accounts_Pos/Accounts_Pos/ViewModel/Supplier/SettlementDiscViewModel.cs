using System;
using System.Collections.Generic;
//using System.ComponentModel.Design;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Accounts_Pos.Helpers;
using Accounts_Pos.ViewModel;
using System.Collections.ObjectModel;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;
using Accounts_Pos.View.Customer;
using Accounts_Pos.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Accounts_Pos.View.Supplier;

namespace Accounts_Pos.ViewModel.Supplier
{
    class SettlementDiscViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public SettlementDiscViewModel()
        {
            selectSupplier = new SupplierModel();
            //SUPPLIER_CODE=App.Current.Properties["Supplier_Code"].ToString();
            //SUPPLIER_NAME=App.Current.Properties["Supplier_Name"].ToString();
            //IS_CUSTOMER=Convert.ToBoolean(App.Current.Properties["IS_CUSTOMER"]);
            COMPANY_ID = Convert.ToInt32(App.Current.Properties["Company_Id"]);

        }

        private SupplierModel _selectSupplier;
        public SupplierModel selectSupplier
        {
            get { return _selectSupplier; }
            set
            {
                if (_selectSupplier != value)
                {
                    _selectSupplier = value;
                    OnPropertyChanged("selectSupplier");
                }
            }
        }

        private int _COMPANY_ID;
        public int COMPANY_ID
        {
            get
            {
                return selectSupplier.COMPANY_ID;
            }
            set
            {
                selectSupplier.COMPANY_ID = value;
                OnPropertyChanged("COMPANY_ID");

            }
        }

        private string _SUPPLIER_CODE;
        public string SUPPLIER_CODE
        {
            get
            {
                return selectSupplier.SUPPLIER_CODE;
            }
            set
            {
                selectSupplier.SUPPLIER_CODE = value;
                OnPropertyChanged("SUPPLIER_CODE");

            }
        }

        private string _SUPPLIER_NAME;
        public string SUPPLIER_NAME
        {
            get
            {
                return selectSupplier.SUPPLIER_NAME;
            }
            set
            {
                selectSupplier.SUPPLIER_NAME = value;
                OnPropertyChanged("SUPPLIER_NAME");

            }
        }


        private string _BACS_REF;
        public string BACS_REF
        {
            get
            {
                return selectSupplier.BACS_REF;
            }
            set
            {
                selectSupplier.BACS_REF = value;
                OnPropertyChanged("BACS_REF");

            }
        }

        private string _ACCOUNT_NAME;
        public string ACCOUNT_NAME
        {
            get
            {
                return selectSupplier.ACCOUNT_NAME;
            }
            set
            {
                selectSupplier.ACCOUNT_NAME = value;
                OnPropertyChanged("ACCOUNT_NAME");

            }
        }

        private string _BANK_NAME;
        public string BANK_NAME
        {
            get
            {
                return selectSupplier.BANK_NAME;
            }
            set
            {
                selectSupplier.BANK_NAME = value;
                OnPropertyChanged("BANK_NAME");

            }
        }


        private string _STREET;
        public string STREET
        {
            get
            {
                return selectSupplier.STREET;
            }
            set
            {
                selectSupplier.STREET = value;
                OnPropertyChanged("STREET");

            }
        }




        private string _TOWN;
        public string TOWN
        {
            get
            {
                return selectSupplier.TOWN;
            }
            set
            {
                selectSupplier.TOWN = value;
                OnPropertyChanged("TOWN");

            }
        }




        private string _COUNTRY;
        public string COUNTRY
        {
            get
            {
                return selectSupplier.COUNTRY;
            }
            set
            {
                selectSupplier.COUNTRY = value;
                OnPropertyChanged("COUNTRY");

            }
        }


        private string _POSTCODE;
        public string POSTCODE
        {
            get
            {
                return selectSupplier.POSTCODE;
            }
            set
            {
                selectSupplier.POSTCODE = value;
                OnPropertyChanged("POSTCODE");

            }
        }



        private string _SHORT_CODE;
        public string SHORT_CODE
        {
            get
            {
                return selectSupplier.SHORT_CODE;
            }
            set
            {
                selectSupplier.SHORT_CODE = value;
                OnPropertyChanged("SHORT_CODE");

            }
        }



        private string _ACCOUNT_NUMBER;
        public string ACCOUNT_NUMBER
        {
            get
            {
                return selectSupplier.ACCOUNT_NUMBER;
            }
            set
            {
                selectSupplier.ACCOUNT_NUMBER = value;
                OnPropertyChanged("ACCOUNT_NUMBER");

            }
        }






        private string _BIC_SWIFT;
        public string BIC_SWIFT
        {
            get
            {
                return selectSupplier.BIC_SWIFT;
            }
            set
            {
                selectSupplier.BIC_SWIFT = value;
                OnPropertyChanged("BIC_SWIFT");

            }
        }
        private string _IBAN;
        public string IBAN
        {
            get
            {
                return selectSupplier.IBAN;
            }
            set
            {
                selectSupplier.IBAN = value;
                OnPropertyChanged("IBAN");

            }
        }

        private string _PAYMENT_METHOD;
        public string PAYMENT_METHOD
        {
            get
            {
                return selectSupplier.PAYMENT_METHOD;
            }
            set
            {
                selectSupplier.PAYMENT_METHOD = value;
                OnPropertyChanged("ROLL_NO");

            }
        }

        private string _NOTES;
        public string NOTES
        {
            get
            {
                return selectSupplier.NOTES;
            }
            set
            {
                selectSupplier.NOTES = value;
                OnPropertyChanged("NOTES");

            }
        }




        private string _PAYMENT_REF;
        public string PAYMENT_REF
        {
            get
            {
                return selectSupplier.PAYMENT_REF;
            }
            set
            {
                selectSupplier.PAYMENT_REF = value;
                OnPropertyChanged("PAYMENT_REF");

            }
        }

        private string _USE_E_PAYMENT;
        public string USE_E_PAYMENT
        {
            get
            {
                return selectSupplier.USE_E_PAYMENT;
            }
            set
            {
                selectSupplier.USE_E_PAYMENT = value;
                OnPropertyChanged("USE_E_PAYMENT");

            }
        }


        private string _LAST_DISC_PER;
        public string LAST_DISC_PER
        {
            get
            {
                return selectSupplier.LAST_DISC_PER;
            }
            set
            {
                selectSupplier.LAST_DISC_PER = value;
                OnPropertyChanged("LAST_DISC_PER");

            }
        }

        private Decimal _STANDARD_DISC_PER;
        public Decimal STANDARD_DISC_PER
        {
            get
            {
                return selectSupplier.STANDARD_DISC_PER;
            }
            set
            {
                selectSupplier.STANDARD_DISC_PER = value;
                OnPropertyChanged("STANDARD_DISC_PER");

            }
        }

        private string _BENIFICIARY;
        public string BENIFICIARY
        {
            get
            {
                return selectSupplier.BENEFICIARY;
            }
            set
            {
                selectSupplier.BENEFICIARY = value;
                OnPropertyChanged("BENEFICIARY");

            }
        }

        private int _LAST_DISC_DAYS;
        public int LAST_DISC_DAYS
        {
            get
            {
                return selectSupplier.LAST_DISC_DAYS;
            }
            set
            {
                selectSupplier.LAST_DISC_DAYS = value;
                OnPropertyChanged("LAST_DISC_DAYS");

            }
        }

        private int _STANDARD_DISC_DAYS;
        public int STANDARD_DISC_DAYS
        {
            get
            {
                return selectSupplier.STANDARD_DISC_DAYS;
            }
            set
            {
                selectSupplier.STANDARD_DISC_DAYS = value;
                OnPropertyChanged("STANDARD_DISC_DAYS");

            }
        }

        private bool _IS_CUSTOMER;
        public bool IS_CUSTOMER
        {
            get
            {
                return selectSupplier.IS_CUSTOMER;
            }
            set
            {
                selectSupplier.IS_CUSTOMER = value;
                if (selectSupplier.IS_CUSTOMER != value)
                {
                    selectSupplier.IS_CUSTOMER = value;
                    OnPropertyChanged("IS_CUSTOMER");
                }
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
                var response = await client.PostAsJsonAsync("api/SupplierAPI/CreateSettlement/", selectSupplier);
                if (response.StatusCode.ToString() == "OK")
                {

                    MessageBox.Show("Settlement Data Added Successfully");

                    Cancel_Supplier();
                    SubContractor _SC = new SubContractor();
                    _SC.ShowDialog();

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
                    _Cancel = new DelegateCommand(Cancel_Supplier);
                }
                return _Cancel;
            }
        }



        public void Cancel_Supplier()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)

                if (window.DataContext == this)
                {
                    window.Close();
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
