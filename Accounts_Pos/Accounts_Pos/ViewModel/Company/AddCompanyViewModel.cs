using System;
using System.Collections.Generic;
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
using Accounts_Pos.View.Company;
using Accounts_Pos.ViewModel;
using Accounts_Pos.ViewModel.Company;
using System.Net.Http;
using System.Net.Http.Headers;
using Accounts_Pos.Model;


namespace Accounts_Pos.ViewModel.Company
{
    class AddCompanyViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {

        public AddCompanyViewModel()
        {
            selectCompany = new CompanyModel();
            selectCompany.CREATED_DATE = System.DateTime.Now;
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

        //private string _ADDRESS;
        //public string ADDRESS
        //{
        //    get
        //    {
        //        return selectCompany.ADDRESS;
        //    }
        //    set
        //    {
        //        selectCompany.ADDRESS = value;
        //        OnPropertyChanged("ADDRESS");

        //    }
        //}

        private bool _IS_DELETE;
        public bool IS_DELETE
        {
            get
            {
                return selectCompany.IS_DELETE;
            }
            set
            {
                selectCompany.IS_DELETE = value;
                if (selectCompany.IS_DELETE != value)
                {
                    selectCompany.IS_DELETE = value;
                    OnPropertyChanged("IS_DELETE");
                }
            }
        }


        private string _CREATION_TYPE;
        public string CREATION_TYPE
        {
            get
            {
                return selectCompany.CREATION_TYPE;
            }
            set
            {
                selectCompany.CREATION_TYPE = value;
                OnPropertyChanged("CREATION_TYPE");

            }
        }

        private DateTime _CREATED_DATE;
        public DateTime CREATED_DATE
        {
            get
            {
                return selectCompany.CREATED_DATE;
            }
            set
            {
                selectCompany.CREATED_DATE = System.DateTime.Now;
                OnPropertyChanged("CREATED_DATE");

            }
        }



        private ICommand _CompanyAssistantClick { get; set; }
        public ICommand CompanyAssistantClick
        {
            get
            {
                if (_CompanyAssistantClick == null)
                {
                    _CompanyAssistantClick = new DelegateCommand(CompanyAssistant_Click);
                }
                return _CompanyAssistantClick;
            }

        }

        public async void CompanyAssistant_Click()
        {

            //selectCompany.CREATION_TYPE = App.Current.Properties["Creation_Type"].ToString();
            App.Current.Properties["Company_Name"] = selectCompany.COMPANY_NAME;
            App.Current.Properties["Country"] = selectCompany.COUNTRY;
            App.Current.Properties["Address"] = selectCompany.ADDRESS;
            App.Current.Properties["Postcode"] = selectCompany.POSTCODE;
            App.Current.Properties["Telephone"] = selectCompany.TELEPHONE;
            App.Current.Properties["Fax"] = selectCompany.FAX;
            App.Current.Properties["Website"] = selectCompany.WEBSITE;



            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
            //client.BaseAddress = new Uri(GlobalData.gblApiAdress);
            //var response = await client.PostAsJsonAsync("api/CompanyAPI/CreateCompanyAssistant/", selectCompany);
            //if (response.StatusCode.ToString() == "OK")
            //{

            if (selectCompany.COMPANY_NAME == "" || selectCompany.COMPANY_NAME == null)
            {
                MessageBox.Show("Company Name Should not be blank..");
            }
            else if (Regex.IsMatch(selectCompany.TELEPHONE,

           "[^0-9.-]+",
                //"[^0-9]",

          RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                MessageBox.Show("Telephone No Must be numeric");
                return;
            }                

            else
            {
                MessageBox.Show("Company Data Added Successfully");
                Cancel_Company();
                CompanyAssistant _CA = new CompanyAssistant();
                _CA.ShowDialog();
            }
                //Cancel_Company();
          
            //}

            //foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            //{
            //    if (window.DataContext == this)
            //    {
            //        window.Close();
            //    }
            //}

           
        }
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

        private Stack<BackNavigationEventHandler> _backFunctions
           = new Stack<BackNavigationEventHandler>();

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
