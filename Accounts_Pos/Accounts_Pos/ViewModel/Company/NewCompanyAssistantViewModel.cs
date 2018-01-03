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
using Accounts_Pos.ViewModel.Company;
using Accounts_Pos.Model;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Accounts_Pos.ViewModel.Company
{
    class NewCompanyAssistantViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {

        public NewCompanyAssistantViewModel()
        {
            selectCompany = new CompanyModel();
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

        private bool _FROM_SCRATCH;
        public bool FROM_SCRATCH
        {
            get
            {
                return selectCompany.FROM_SCRATCH;
            }
            set
            {
                selectCompany.FROM_SCRATCH = value;
                if (selectCompany.FROM_SCRATCH != value)
                {
                    selectCompany.FROM_SCRATCH = value;
                    OnPropertyChanged("FROM_SCRATCH");
                }
            }
        }

        //private bool _IS_SUPPLIER;
        //public bool IS_SUPPLIER
        //{
        //    get
        //    {
        //        return selectCustomer.IS_SUPPLIER;
        //    }
        //    set
        //    {
        //        selectCustomer.IS_SUPPLIER = value;
        //        if (selectCustomer.IS_SUPPLIER != value)
        //        {
        //            selectCustomer.IS_SUPPLIER = value;
        //            OnPropertyChanged("IS_SUPPLIER");
        //        }
        //    }
        //}



        private bool _FROM_BACKUP;
        public bool FROM_BACKUP
        {
            get
            {
                return selectCompany.FROM_BACKUP;
            }
            set
            {
                selectCompany.FROM_BACKUP = value;
                if (selectCompany.FROM_BACKUP != value)
                {
                    selectCompany.FROM_BACKUP = value;
                    OnPropertyChanged("FROM_BACKUP");
                }
            }
        }

        private bool _CREATE_CONSOLIDATED;
        public bool CREATE_CONSOLIDATED
        {
            get
            {
                return selectCompany.CREATE_CONSOLIDATED;
            }
            set
            {
                selectCompany.CREATE_CONSOLIDATED = value;
                if (selectCompany.CREATE_CONSOLIDATED != value)
                {
                    selectCompany.CREATE_CONSOLIDATED = value;
                    OnPropertyChanged("CREATE_CONSOLIDATED");
                }
            }
        }

        private bool _CREATE_DEMONSTRATION;
        public bool CREATE_DEMONSTRATION
        {
            get
            {
                return selectCompany.CREATE_DEMONSTRATION;
            }
            set
            {
                selectCompany.CREATE_DEMONSTRATION = value;
                if (selectCompany.CREATE_DEMONSTRATION != value)
                {
                    selectCompany.CREATE_DEMONSTRATION = value;
                    OnPropertyChanged("CREATE_DEMONSTRATION");
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

        
        //private string _COMPANY_NAME;
        //public string COMPANY_NAME
        //{
        //    get
        //    {
        //        return selectCompany.COMPANY_NAME;
        //    }
        //    set
        //    {
        //        selectCompany.COMPANY_NAME = value;
        //        OnPropertyChanged("COMPANY_NAME");

        //    }
        //}


        //private string _COUNTRY;
        //public string COUNTRY
        //{
        //    get
        //    {
        //        return selectCompany.COUNTRY;
        //    }
        //    set
        //    {
        //        selectCompany.COUNTRY = value;
        //        OnPropertyChanged("COUNTRY");

        //    }
        //}


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

        //private string _POSTCODE;
        //public string POSTCODE
        //{
        //    get
        //    {
        //        return selectCompany.POSTCODE;
        //    }
        //    set
        //    {
        //        selectCompany.POSTCODE = value;
        //        OnPropertyChanged("POSTCODE");

        //    }
        //}

        //private string _TELEPHONE;
        //public string TELEPHONE
        //{
        //    get
        //    {
        //        return selectCompany.TELEPHONE;
        //    }
        //    set
        //    {
        //        selectCompany.TELEPHONE = value;
        //        OnPropertyChanged("TELEPHONE");

        //    }
        //}

        //private string _FAX;
        //public string FAX
        //{
        //    get
        //    {
        //        return selectCompany.FAX;
        //    }
        //    set
        //    {
        //        selectCompany.FAX = value;
        //        OnPropertyChanged("FAX");

        //    }
        //}

        //private string _WEBSITE;
        //public string WEBSITE
        //{
        //    get
        //    {
        //        return selectCompany.WEBSITE;
        //    }
        //    set
        //    {
        //        selectCompany.WEBSITE = value;
        //        OnPropertyChanged("WEBSITE");

        //    }
        //}

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

        //private string _COMPANY_STATUS;
        //public string COMPANY_STATUS
        //{
        //    get
        //    {
        //        return selectCompany.COMPANY_STATUS;
        //    }
        //    set
        //    {
        //        selectCompany.COMPANY_STATUS = value;
        //        OnPropertyChanged("COMPANY_STATUS");

        //    }
        //}


        //private string _COMPANY_TYPE;
        //public string COMPANY_TYPE
        //{
        //    get
        //    {
        //        return selectCompany.COMPANY_TYPE;
        //    }
        //    set
        //    {
        //        selectCompany.COMPANY_TYPE = value;
        //        OnPropertyChanged("COMPANY_TYPE");

        //    }
        //}

        //private string _START_YEAR;
        //public string START_YEAR
        //{
        //    get
        //    {
        //        return selectCompany.START_YEAR;
        //    }
        //    set
        //    {
        //        selectCompany.START_YEAR = value;
        //        OnPropertyChanged("START_YEAR");

        //    }
        //}


        //private string _START_FIN_YEAR;
        //public string START_FIN_YEAR
        //{
        //    get
        //    {
        //        return selectCompany.START_FIN_YEAR;
        //    }
        //    set
        //    {
        //        selectCompany.START_FIN_YEAR = value;
        //        OnPropertyChanged("START_FIN_YEAR");

        //    }
        //}


        //private string _END_FIN_YEAR;
        //public string END_FIN_YEAR
        //{
        //    get
        //    {
        //        return selectCompany.END_FIN_YEAR;
        //    }
        //    set
        //    {
        //        selectCompany.END_FIN_YEAR = value;
        //        OnPropertyChanged("END_FIN_YEAR");

        //    }
        //}

        //private string _USER_NAME;
        //public string USER_NAME
        //{
        //    get
        //    {
        //        return selectCompany.USER_NAME;
        //    }
        //    set
        //    {
        //        selectCompany.USER_NAME = value;
        //        OnPropertyChanged("USER_NAME");

        //    }
        //}

        //private string _PASSWORD;
        //public string PASSWORD
        //{
        //    get
        //    {
        //        return selectCompany.PASSWORD;
        //    }
        //    set
        //    {
        //        selectCompany.PASSWORD = value;
        //        OnPropertyChanged("PASSWORD");

        //    }
        //}

        //private string _CONFIRM_PASSWORD;
        //public string CONFIRM_PASSWORD
        //{
        //    get
        //    {
        //        return selectCompany.CONFIRM_PASSWORD;
        //    }
        //    set
        //    {
        //        selectCompany.CONFIRM_PASSWORD = value;
        //        OnPropertyChanged("CONFIRM_PASSWORD");

        //    }
        //}

        //private bool _IS_DELETE;
        //public bool IS_DELETE
        //{
        //    get
        //    {
        //        return selectCompany.IS_DELETE;
        //    }
        //    set
        //    {
        //        selectCompany.IS_DELETE = value;
        //        if (selectCompany.IS_DELETE != value)
        //        {
        //            selectCompany.IS_DELETE = value;
        //            OnPropertyChanged("IS_DELETE");
        //        }
        //    }
        //}


        private ICommand _AddCompanyClick { get; set; }
        public ICommand AddCompanyClick
        {
            get
            {
                if (_AddCompanyClick == null)
                {
                    _AddCompanyClick = new DelegateCommand(AddCompany_Click);
                }
                return _AddCompanyClick;
            }

        }

        public async void AddCompany_Click()
        {
        
            if(FROM_SCRATCH==true)
              selectCompany.CREATION_TYPE = "FROM_SCRATCH";
            if (selectCompany.FROM_BACKUP == true)
                selectCompany.CREATION_TYPE = "FROM_BACKUP";
            if (selectCompany.CREATE_CONSOLIDATED == true)
                selectCompany.CREATION_TYPE = "CREATE_CONSOLIDATED";
            if (selectCompany.CREATE_DEMONSTRATION == true)
                selectCompany.CREATION_TYPE = "CREATE_DEMONSTRATION";

            App.Current.Properties["Creation_Type"] = selectCompany.CREATION_TYPE;
   
            
                    //HttpClient client = new HttpClient();
                    //client.DefaultRequestHeaders.Accept.Add(
                    //    new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    //var response = await client.PostAsJsonAsync("api/MiscellaneousAPI/CreateMiscellaneous/", selectCompany);
                    //if (response.StatusCode.ToString() == "OK")
                    //{

                    //    MessageBox.Show("Miscellaneous Data Added Successfully");
                     Cancel_Company(); 
                      AddCompany _CA = new AddCompany();
                     _CA.ShowDialog();
                     //Cancel_Company();
        //             }

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
