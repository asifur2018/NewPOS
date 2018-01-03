using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Accounts_Pos.Helpers;
using Accounts_Pos.Model;
using Accounts_Pos.View.Customer;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Accounts_Pos.ViewModel.Customer
{
    class DefaultsViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {


        public DefaultsViewModel()
        {
            selectDefault = new DefaultModel();
            selectDefault.DEFAULT_NOMINAL_CODE = "4000";
            selectDefault.DEFAULT_TAX_CODE = "T1 14.00";
            selectDefault.CURRENCY_CODE = "4000";
            selectDefault.DEPARTMENT = "4000";
        }



        private DefaultModel _selectDefault;
        public DefaultModel selectDefault
        {
            get { return _selectDefault; }
            set
            {
                if (_selectDefault != value)
                {
                    _selectDefault = value;
                    OnPropertyChanged("selectDefault");
                }
            }
        }

        private string _DEFAULT_NOMINAL_CODE;
        public string DEFAULT_NOMINAL_CODE
        {
            get
            {
                return selectDefault.DEFAULT_NOMINAL_CODE;
            }
            set
            {
                selectDefault.DEFAULT_NOMINAL_CODE = value;
                OnPropertyChanged("DEFAULT_NOMINAL_CODE");

            }
        }

        private bool _IS_NOMINALCODE_SALES;
        public bool IS_NOMINALCODE_SALES
        {
            get
            {
                return selectDefault.IS_NOMINALCODE_SALES;
            }
            set
            {
                selectDefault.IS_NOMINALCODE_SALES = value;
                if (selectDefault.IS_NOMINALCODE_SALES != value)
                {
                    selectDefault.IS_NOMINALCODE_SALES = value;
                    OnPropertyChanged("IS_NOMINALCODE_SALES");
                }
            }
        }

        private string _DEFAULT_TAX_CODE;
        public string DEFAULT_TAX_CODE
        {
            get
            {
                return selectDefault.DEFAULT_TAX_CODE;
            }
            set
            {
                selectDefault.DEFAULT_TAX_CODE = value;
                OnPropertyChanged("DEFAULT_TAX_CODE");

            }
        }

        private bool _IS_TAXCODE_SALE;
        public bool IS_TAXCODE_SALE
        {
            get
            {
                return selectDefault.IS_TAXCODE_SALE;
            }
            set
            {
                selectDefault.IS_TAXCODE_SALE = value;
                if (selectDefault.IS_TAXCODE_SALE != value)
                {
                    selectDefault.IS_TAXCODE_SALE = value;
                    OnPropertyChanged("IS_TAXCODE_SALE");
                }
            }
        }

        private string _CURRENCY_CODE;
        public string CURRENCY_CODE
        {
            get
            {
                return selectDefault.CURRENCY_CODE;
            }
            set
            {
                selectDefault.CURRENCY_CODE = value;
                OnPropertyChanged("CURRENCY_CODE");

            }
        }

        private string _DEPARTMENT;
        public string DEPARTMENT
        {
            get
            {
                return selectDefault.DEPARTMENT;
            }
            set
            {
                selectDefault.DEPARTMENT = value;
                OnPropertyChanged("DEPARTMENT");

            }
        }

        private string _departmentName;
        public string departmentName
        {
            get
            {
                return _departmentName;
            }
            set
            {
                if (_departmentName != value)
                {
                    _departmentName = value;
                    OnPropertyChanged("departmentName");
                }

            }
        }

        private string _REPORTING_PASSWORD;
        public string REPORTING_PASSWORD
        {
            get
            {
                return selectDefault.REPORTING_PASSWORD;
            }
            set
            {
                selectDefault.REPORTING_PASSWORD = value;
                OnPropertyChanged("REPORTING_PASSWORD");

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
                selectDefault.CUSTOMER_CODE = App.Current.Properties["Customer_Code"].ToString();
                if (departmentName != null)
                {
                    if (selectDefault.DEPARTMENT != null)
                    {
                        selectDefault.DEPARTMENT += "-";
                    }
                    selectDefault.DEPARTMENT += departmentName;
                }
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/DefaultAPI/CreateDefault/", selectDefault);
                if (response.StatusCode.ToString() == "OK")
                {

                    MessageBox.Show("Default Data Added Successfully");
                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                    {
                        if (window.DataContext == this)
                        {
                            window.Close();
                        }
                    }

                    Documents _DF = new Documents();
                    _DF.ShowDialog();


                }




            }
            catch
            {

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
