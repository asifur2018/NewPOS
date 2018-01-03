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
using Accounts_Pos.View.Customer;
using Accounts_Pos.ViewModel;
using Accounts_Pos.ViewModel.Company;
using Newtonsoft.Json;

namespace Accounts_Pos.ViewModel.Company
{
    class Company_LoginViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        CompanyModel data = null;
        public Company_LoginViewModel()
        {
            selectCompany = new CompanyModel();
            selectCompany.COMPANY_ID = Convert.ToInt32(App.Current.Properties["Company_Id"]);
            //selectCompany.COMPANY_ID = 46;
            selectCompany.CREATE_DATE_TIME = System.DateTime.Now;
            App.Current.Properties["Action"] = "";
            // selectCompany.COMPANY_ID = 99;
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
                    OnPropertyChanged("selectCompany");
                }
            }
        }

        private string _USER_NAME;
        public string USER_NAME
        {
            get
            {
                return selectCompany.USER_NAME;
            }
            set
            {
                selectCompany.USER_NAME = value;
                OnPropertyChanged("USER_NAME");

            }
        }

        private string _PASSWORD;
        public string PASSWORD
        {
            get
            {
                return selectCompany.PASSWORD;
            }
            set
            {
                selectCompany.PASSWORD = value;
                OnPropertyChanged("PASSWORD");

            }
        }

        private int _COMPANY_ID;
        public int COMPANY_ID
        {
            get
            {
                return selectCompany.COMPANY_ID;
            }
            set
            {
                selectCompany.COMPANY_ID = Convert.ToInt32(App.Current.Properties["Company_Id"]);
                //selectCompany.COMPANY_ID = 45;
                OnPropertyChanged("COMPANY_ID");

            }
        }

        private int _LOGIN_ID;
        public int LOGIN_ID
        {
            get
            {
                return selectCompany.LOGIN_ID;
            }
            set
            {
                selectCompany.LOGIN_ID = value;
                OnPropertyChanged("LOGIN_ID");

            }
        }

        private DateTime _CREATE_DATE_TIME;
        public DateTime CREATE_DATE_TIME
        {
            get
            {
                return selectCompany.CREATE_DATE_TIME;
            }
            set
            {
                selectCompany.CREATE_DATE_TIME = System.DateTime.Now;
                OnPropertyChanged("CREATE_DATE_TIME");

            }
        }

        #region Insert Data

        //OpenPage
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

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.Timeout = new TimeSpan(500000000000);
                HttpResponseMessage response = client.GetAsync("api/CompanyAPI/CompanyLogin?id=" + USER_NAME + "&password=" + PASSWORD + "&comp=" + selectCompany.COMPANY_ID + "").Result;
                //var response = await client.PostAsJsonAsync("api/CompanyAPI/CompanyLogin?id="+ USER_NAME + "&password=" + PASSWORD + "").Result;
                if (response.IsSuccessStatusCode)
                {
                    data = JsonConvert.DeserializeObject<CompanyModel>(await response.Content.ReadAsStringAsync());
                    if (data != null)
                    {
                        selectCompany.LOGIN_ID = data.LOGIN_ID;
                        var response1 = await client.PostAsJsonAsync("api/CompanyAPI/UpdateLogin/", selectCompany);
                        if (response.IsSuccessStatusCode)
                        {


                            CustomerList _C = new CustomerList();
                            _C.ShowDialog();
                            //foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)


                            //    if (window.DataContext == this)
                            //    {
                            //        window.Close();
                            //    }

                            //AddCustomer _AC = new AddCustomer();
                            //_AC.ShowDialog();


                        }
                    }
                    else
                    {
                        MessageBox.Show("Your Credentials is wrong");
                    }
                }
                else
                {
                    MessageBox.Show("Your Credentials is wrong");
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
