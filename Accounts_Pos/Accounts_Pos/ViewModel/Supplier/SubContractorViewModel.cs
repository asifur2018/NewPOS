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
    class SubContractorViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public SubContractorViewModel()
        {
            selectSupplier = new SupplierModel();
            SUPPLIER_CODE = App.Current.Properties["Supplier_Code"].ToString();
            SUPPLIER_NAME = App.Current.Properties["Supplier_Name"].ToString();
            IS_CUSTOMER = Convert.ToBoolean(App.Current.Properties["IS_CUSTOMER"]);
            DATE_LAST_VERIFIED = System.DateTime.Now;
            DATE_VALID_FROM = System.DateTime.Now;
            DATE_VALID_TO = System.DateTime.Now;
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


        private string _BUSINESS_TYPE;
        public string BUSINESS_TYPE
        {
            get
            {
                return selectSupplier.BUSINESS_TYPE;
            }
            set
            {
                selectSupplier.BUSINESS_TYPE = value;
                OnPropertyChanged("BUSINESS_TYPE");

            }
        }

        private string _PARTNERSHIP_NAME;
        public string PARTNERSHIP_NAME
        {
            get
            {
                return selectSupplier.PARTNERSHIP_NAME;
            }
            set
            {
                selectSupplier.PARTNERSHIP_NAME = value;
                OnPropertyChanged("PARTNERSHIP_NAME");

            }
        }


        private string _PARTNERSHIP_UTR;
        public string PARTNERSHIP_UTR
        {
            get
            {
                return selectSupplier.PARTNERSHIP_UTR;
            }
            set
            {
                selectSupplier.PARTNERSHIP_UTR = value;
                OnPropertyChanged("PARTNERSHIP_UTR");

            }
        }


        private string _TRADING_NAME;
        public string TRADING_NAME
        {
            get
            {
                return selectSupplier.TRADING_NAME;
            }
            set
            {
                selectSupplier.TRADING_NAME = value;
                OnPropertyChanged("TRADING_NAME");

            }
        }



        private bool _USE_LEGAL_NAME;
        public bool USE_LEGAL_NAME
        {
            get
            {
                return selectSupplier.USE_LEGAL_NAME;
            }
            set
            {
                selectSupplier.USE_LEGAL_NAME = value;
                OnPropertyChanged("USE_LEGAL_NAME");

            }
        }

        private string _FORENAME;
        public string FORENAME
        {
            get
            {
                return selectSupplier.FORENAME;
            }
            set
            {
                selectSupplier.FORENAME = value;
                OnPropertyChanged("FORENAME");

            }
        }
        //private string MIDDLE_NAME;
        //public string MIDDLE_NAME
        //{
        //    get
        //    {
        //        return selectSupplier.MIDDLE_NAME;
        //    }
        //    set
        //    {
        //        selectSupplier.MIDDLE_NAME = value;
        //        OnPropertyChanged("MIDDLE_NAME");

        //    }
        //}
        private string _SURNAME;
        public string SURNAME
        {
            get
            {
                return selectSupplier.SURNAME;
            }
            set
            {
                selectSupplier.SURNAME = value;
                OnPropertyChanged("SURNAME");

            }
        }
        //private string UTR;
        //public string UTR
        //{
        //    get
        //    {
        //        return selectSupplier.UTR;
        //    }
        //    set
        //    {
        //        selectSupplier.UTR = value;
        //        OnPropertyChanged("UTR");

        //    }
        //}
        private string _INSURANCE_NO;
        public string INSURANCE_NO
        {
            get
            {
                return selectSupplier.INSURANCE_NO;
            }
            set
            {
                selectSupplier.INSURANCE_NO = value;
                OnPropertyChanged("INSURANCE_NO");

            }
        }

        string _CO_REG_NO;
        public string CO_REG_NO
        {
            get
            {
                return selectSupplier.CO_REG_NO;
            }
            set
            {
                selectSupplier.CO_REG_NO = value;
                OnPropertyChanged("CO_REG_NO");

            }
        }
        private string _STATUS_VERIFICATION;
        public string STATUS_VERIFICATION
        {
            get
            {
                return selectSupplier.STATUS_VERIFICATION;
            }
            set
            {
                selectSupplier.STATUS_VERIFICATION = value;
                OnPropertyChanged("STATUS_VERIFICATION");

            }
        }

        private string _VERIFICATION_NO;
        public string VERIFICATION_NO
        {
            get
            {
                return selectSupplier.VERIFICATION_NO;
            }
            set
            {
                selectSupplier.VERIFICATION_NO = value;
                OnPropertyChanged("VERIFICATION_NO");

            }
        }

        private string _TAX_TREATMENT;
        public string TAX_TREATMENT
        {
            get
            {
                return selectSupplier.TAX_TREATMENT;
            }
            set
            {
                selectSupplier.TAX_TREATMENT = value;
                OnPropertyChanged("TAX_TREATMENT");

            }
        }




        private DateTime _DATE_LAST_VERIFIED;
        public DateTime DATE_LAST_VERIFIED
        {
            get
            {
                return selectSupplier.DATE_LAST_VERIFIED;
            }
            set
            {
                selectSupplier.DATE_LAST_VERIFIED = value;
                OnPropertyChanged("DATE_LAST_VERIFIED");

            }
        }

        private string _PRODUCE_STATEMENT;
        public string PRODUCE_STATEMENT
        {
            get
            {
                return selectSupplier.PRODUCE_STATEMENT;
            }
            set
            {
                selectSupplier.PRODUCE_STATEMENT = value;
                OnPropertyChanged("PRODUCE_STATEMENT");

            }
        }

        private string _CIS_TYPE;
        public string CIS_TYPE
        {
            get
            {
                return selectSupplier.CIS_TYPE;
            }
            set
            {
                selectSupplier.CIS_TYPE = value;
                OnPropertyChanged("CIS_TYPE");

            }
        }

        private string _CIS_CETT;
        public string CIS_CETT
        {
            get
            {
                return selectSupplier.CIS_CETT;
            }
            set
            {
                selectSupplier.CIS_CETT = value;
                OnPropertyChanged("CIS_CETT");

            }
        }

        private string _CIS_CERT_NO;
        public string CIS_CERT_NO
        {
            get
            {
                return selectSupplier.CIS_CERT_NO;
            }
            set
            {
                selectSupplier.CIS_CERT_NO = value;
                OnPropertyChanged("CIS_CERT_NO");

            }
        }

        private DateTime _DATE_VALID_FROM;
        public DateTime DATE_VALID_FROM
        {
            get
            {
                return selectSupplier.DATE_VALID_FROM;
            }
            set
            {
                selectSupplier.DATE_VALID_FROM = value;
                OnPropertyChanged("DATE_VALID_FROM");

            }
        }

        private DateTime _DATE_VALID_TO;
        public DateTime DATE_VALID_TO
        {
            get
            {
                return selectSupplier.DATE_VALID_TO;
            }
            set
            {
                selectSupplier.DATE_VALID_TO = value;
                OnPropertyChanged("DATE_VALID_TO");

            }
        }


        #region Insert_Data

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
                App.Current.Properties["Supplier_Code"] = SUPPLIER_CODE;
                //selectSupplier.SUPPLIER_CODE = App.Current.Properties["Customer_Code"].ToString();
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/SupplierAPI/CreateSubContractor/", selectSupplier);
                if (response.StatusCode.ToString() == "OK")
                {

                    MessageBox.Show("SubContractor Data Added Successfully..");
                    //Cancel_Supplier();

                    //SupplierNLDistribution _SNL = new SupplierNLDistribution();
                    //_SNL.ShowDialog();
                    SupplierDocuments _SD = new SupplierDocuments();
                    _SD.ShowDialog();
                    Cancel_Supplier();

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
