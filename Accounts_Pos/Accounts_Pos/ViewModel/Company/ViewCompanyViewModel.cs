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
using Accounts_Pos.View.Company;
using Newtonsoft.Json;

namespace Accounts_Pos.ViewModel.Company
{
    class ViewCompanyViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
       // DeliveryAddressModel[] data = null;
        public ViewCompanyViewModel()
        {
            selectCompany = new CompanyModel();
            selectCompany.COMPANY_NAME = App.Current.Properties["Company_Name"].ToString();
            selectCompany.ADDRESS = App.Current.Properties["Address"].ToString();
            selectCompany.COUNTRY = App.Current.Properties["Country"].ToString();
            selectCompany.POSTCODE = App.Current.Properties["Postcode"].ToString();
            selectCompany.FAX = App.Current.Properties["Fax"].ToString();
            selectCompany.WEBSITE = App.Current.Properties["Website"].ToString();
            selectCompany.TELEPHONE = App.Current.Properties["Telephone"].ToString();
            selectCompany.COMPANY_STATUS = App.Current.Properties["Company_Status"].ToString();
            selectCompany.COMPANY_TYPE = App.Current.Properties["Company_Type"].ToString();
            selectCompany.START_YEAR = App.Current.Properties["Start_Year"].ToString();
            selectCompany.START_FIN_YEAR = App.Current.Properties["Start_Fin_Year"].ToString();
            selectCompany.END_FIN_YEAR = App.Current.Properties["End_Fin_Year"].ToString();
            selectCompany.FIN_YEAR = selectCompany.START_FIN_YEAR + "-" + selectCompany.END_FIN_YEAR;

            }


        private CompanyModel _selectCompany;
        public CompanyModel selectCompany
        {
            get { return _selectCompany; }
            set
            {
                if (_selectCompany != value)
                {
                    _selectCompany = value;
                    OnPropertyChanged("selectCustomer");
                }
            }
        }

        private string _COMPANY_NAME;
        public string COMPANY_NAME
        {
            get
            {
                return selectCompany.COMPANY_NAME;
            }
            set
            {
                selectCompany.COMPANY_NAME = value;
                OnPropertyChanged("COMPANY_NAME");

            }
        }


        private string _COUNTRY;
        public string COUNTRY
        {
            get
            {
                return selectCompany.COUNTRY;
            }
            set
            {
                selectCompany.COUNTRY = value;
                OnPropertyChanged("COUNTRY");

            }
        }


        private string _ADDRESS;
        public string ADDRESS
        {
            get
            {
                return selectCompany.ADDRESS;
            }
            set
            {
                selectCompany.ADDRESS = value;
                OnPropertyChanged("ADDRESS");

            }
        }

        private string _POSTCODE;
        public string POSTCODE
        {
            get
            {
                return selectCompany.POSTCODE;
            }
            set
            {
                selectCompany.POSTCODE = value;
                OnPropertyChanged("POSTCODE");

            }
        }

        private string _TELEPHONE;
        public string TELEPHONE
        {
            get
            {
                return selectCompany.TELEPHONE;
            }
            set
            {
                selectCompany.TELEPHONE = value;
                OnPropertyChanged("TELEPHONE");

            }
        }

        private string _FAX;
        public string FAX
        {
            get
            {
                return selectCompany.FAX;
            }
            set
            {
                selectCompany.FAX = value;
                OnPropertyChanged("FAX");

            }
        }

        private string _WEBSITE;
        public string WEBSITE
        {
            get
            {
                return selectCompany.WEBSITE;
            }
            set
            {
                selectCompany.WEBSITE = value;
                OnPropertyChanged("WEBSITE");

            }
        }

        private string _COMPANY_STATUS;
        public string COMPANY_STATUS
        {
            get
            {
                return selectCompany.COMPANY_STATUS;
            }
            set
            {
                selectCompany.COMPANY_STATUS = value;
                OnPropertyChanged("COMPANY_STATUS");

            }
        }


        private string _COMPANY_TYPE;
        public string COMPANY_TYPE
        {
            get
            {
                return selectCompany.COMPANY_TYPE;
            }
            set
            {
                selectCompany.COMPANY_TYPE = value;
                OnPropertyChanged("COMPANY_TYPE");

            }
        }

        private string _START_YEAR;
        public string START_YEAR
        {
            get
            {
                return selectCompany.START_YEAR;
            }
            set
            {
                selectCompany.START_YEAR = value;
                OnPropertyChanged("START_YEAR");

            }
        }

        private string _FIN_YEAR;
        public string FIN_YEAR
        {
            get
            {
                return selectCompany.FIN_YEAR;
            }
            set
            {
                selectCompany.FIN_YEAR = value;
                OnPropertyChanged("FIN_YEAR");

            }
        }


       // #region Insert Data
        public ICommand _LoginCredentialClick;
        public ICommand LoginCredentialClick
        {
            get
            {
                if (_LoginCredentialClick == null)
                {
                    _LoginCredentialClick = new DelegateCommand(LoginCredential_Click);
                }
                return _LoginCredentialClick;
            }
        }

        //public async void Edit_Address()
        //{

        //    try
        //    {
               
                   
        //            App.Current.Properties["Action"] = "Edit";
        //            HttpClient client = new HttpClient();
        //            client.BaseAddress = new Uri(GlobalData.gblApiAdress);
        //            client.DefaultRequestHeaders.Accept.Add(
        //                new MediaTypeWithQualityHeaderValue("application/json"));
        //            client.Timeout = new TimeSpan(500000000000);
        //            HttpResponseMessage response = client.GetAsync("api/CompanyAPI/ShowData/").Result;
        //            //response = client.GetAsync("api/DeliveryAddressAPI/EditDelivery/?id=" + selectDelivery.DELIVERY_ID + "").Result;
        //            if (response.StatusCode.ToString() == "OK")
        //            {
        //                data = JsonConvert.DeserializeObject<DeliveryAddressModel[]>(await response.Content.ReadAsStringAsync());
        //                if (data.Length > 0)
        //                {
        //                    for (int i = 0; i < data.Length; i++)
        //                    {

        //                        DELIVERY_CODE = data[i].DELIVERY_CODE;
        //                        DELIVERY_COMPANY_NAME = data[i].DELIVERY_COMPANY_NAME;
        //                        ADDRESS = data[i].ADDRESS;
        //                        COUNTRY = data[i].COUNTRY;
        //                        CONTACTS = data[i].CONTACTS;
        //                        TELEPHONE = data[i].TELEPHONE;
        //                        POSTCODE = data[i].POSTCODE;
        //                        EC_COUNTRY = data[i].EC_COUNTRY;
        //                        SAME_STATEMENT = data[i].SAME_STATEMENT;
        //                        //DELIVERY_CODE = data[i].DELIVERY_CODE;
        //                        TELEPHONE = data[i].TELEPHONE;
        //                        FAX = data[i].FAX;
        //                        DELIVERY_MODE = data[i].DELIVERY_CODE;
        //                        DELIVERY_TIME = data[i].DELIVERY_CODE;


        //                    }
        //                    App.Current.Properties["CatagoryEdit"] = selectDelivery;
        //                    //selectDelivery = App.Current.Properties["CatagoryEdit"] as DeliveryAddressModel;

        //                }

        //            }
               
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}



        public async void LoginCredential_Click()
        {
            try
            {

                Cancel_Company();
                LoginCredential _LC = new LoginCredential();
                _LC.ShowDialog();
                //Cancel_Company();

            }
            catch
            {

            }

        }

       // #endregion

        public ICommand _Cancel;
        public ICommand Cancel
        {
            get
            {
                if (_Cancel == null)
                {
                    _Cancel = new DelegateCommand(Cancel_Company);
                }
                return _Cancel;
            }
        }



        public void Cancel_Company()
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
