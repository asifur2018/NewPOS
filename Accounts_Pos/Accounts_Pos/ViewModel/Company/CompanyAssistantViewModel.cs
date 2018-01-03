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
using Accounts_Pos.ViewModel;
using Accounts_Pos.ViewModel.Company;


namespace Accounts_Pos.ViewModel.Company
{
    class CompanyAssistantViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {

        public CompanyAssistantViewModel()
        {
            selectCompany = new CompanyModel();
            selectCompany.CREATED_DATE = System.DateTime.Now;
            selectCompany.MONTH_YEAR = true;
            ENABLE_DATE2 = false;
            ENABLE_MONTH2 = false;
            ENABLE_YEAR2 = false;
            ENABLE_YEAR3 = false;
            ENABLE_MONTH1 = true;
            ENABLE_YEAR1 = true;

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


        private string _START_FIN_YEAR;
        public string START_FIN_YEAR
        {
            get
            {
                return selectCompany.START_FIN_YEAR;
            }
            set
            {
                selectCompany.START_FIN_YEAR = value;
                OnPropertyChanged("START_FIN_YEAR");

            }
        }

        private bool _MONTH_YEAR;
        public bool MONTH_YEAR
        {
            get
            {
                return selectCompany.MONTH_YEAR;
            }
            set
            {
                selectCompany.MONTH_YEAR = value;
                if (selectCompany.MONTH_YEAR == true)
                {
                    ENABLE_DATE2 = false;
                    ENABLE_MONTH2 = false;
                    ENABLE_YEAR2 = false;
                    ENABLE_YEAR3 = false;
                    ENABLE_MONTH1 = true;
                    ENABLE_YEAR1 = true;
                }
                //else
                //{
                //    ENABLE_MONTH1 = false;
                //    ENABLE_YEAR1 = false;
                //}


                if (selectCompany.MONTH_YEAR != value)
                {
                    selectCompany.MONTH_YEAR = value;
                    OnPropertyChanged("MONTH_YEAR");
                }
            }
        }

        private bool _DATE_MONTH_YEAR;
        public bool DATE_MONTH_YEAR
        {
            get
            {
                return selectCompany.DATE_MONTH_YEAR;
            }
            set
            {
                selectCompany.DATE_MONTH_YEAR = value;
                if (selectCompany.DATE_MONTH_YEAR == true)
                {
                    ENABLE_DATE2 = true;
                    ENABLE_MONTH2 = true;
                    ENABLE_YEAR2 = true;
                    ENABLE_YEAR3 = false;
                    ENABLE_MONTH1 = false;
                    ENABLE_YEAR1 = false;
                }
                //else
                //{
                //    ENABLE_MONTH1 = false;
                //    ENABLE_YEAR1 = false;
                //}

                if (selectCompany.DATE_MONTH_YEAR != value)
                {
                    selectCompany.DATE_MONTH_YEAR = value;
                    OnPropertyChanged("DATE_MONTH_YEAR");
                }
            }
        }

        private bool _YEAR;
        public bool YEAR
        {
            get
            {
                return selectCompany.YEAR;
            }
            set
            {
                selectCompany.YEAR = value;
                if (selectCompany.YEAR == true)
                {
                    ENABLE_DATE2 = false;
                    ENABLE_MONTH2 = false;
                    ENABLE_YEAR2 = false;
                    ENABLE_YEAR3 = true;
                    ENABLE_MONTH1 = false;
                    ENABLE_YEAR1 = false;
                }
                if (selectCompany.YEAR != value)
                {
                    selectCompany.YEAR = value;
                    OnPropertyChanged("YEAR");
                }
            }
        }


        private string _END_FIN_YEAR;
        public string END_FIN_YEAR
        {
            get
            {
                return selectCompany.END_FIN_YEAR;
            }
            set
            {
                selectCompany.END_FIN_YEAR = value;
                OnPropertyChanged("END_FIN_YEAR");

            }
        }

        private string _MONTH1;
        public string MONTH1
        {
            get
            {
                return selectCompany.MONTH1;
            }
            set
            {
                selectCompany.MONTH1 = value;
                OnPropertyChanged("MONTH1");

            }
        }

        private string _YEAR1;
        public string YEAR1
        {
            get
            {
                return selectCompany.YEAR1;
            }
            set
            {
                selectCompany.YEAR1 = value;
                OnPropertyChanged("YEAR1");

            }
        }

        private string _DATE2;
        public string DATE2
        {
            get
            {
                return selectCompany.DATE2;
            }
            set
            {
                selectCompany.DATE2 = value;
                OnPropertyChanged("DATE2");

            }
        }

        private string _MONTH2;
        public string MONTH2
        {
            get
            {
                return selectCompany.MONTH2;
            }
            set
            {
                selectCompany.MONTH2 = value;
                OnPropertyChanged("MONTH2");

            }
        }

        private string _YEAR2;
        public string YEAR2
        {
            get
            {
                return selectCompany.YEAR2;
            }
            set
            {
                selectCompany.YEAR2 = value;
                OnPropertyChanged("YEAR2");

            }
        }

        private string _YEAR3;
        public string YEAR3
        {
            get
            {
                return selectCompany.YEAR3;
            }
            set
            {
                selectCompany.YEAR3 = value;
                OnPropertyChanged("YEAR3");

            }
        }

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

        private bool _ENABLE_MONTH1;
        public bool ENABLE_MONTH1
        {

            get
            {
                return _ENABLE_MONTH1;
            }
            set
            {

                _ENABLE_MONTH1 = value;
                OnPropertyChanged("ENABLE_MONTH1");
            }
        }

        private bool _ENABLE_YEAR1;
        public bool ENABLE_YEAR1
        {

            get
            {
                return _ENABLE_YEAR1;
            }
            set
            {

                _ENABLE_YEAR1 = value;
                OnPropertyChanged("ENABLE_YEAR1");
            }
        }

        private bool _ENABLE_MONTH2;
        public bool ENABLE_MONTH2
        {

            get
            {
                return _ENABLE_MONTH2;
            }
            set
            {

                _ENABLE_MONTH2 = value;
                OnPropertyChanged("ENABLE_MONTH2");
            }
        }

        private bool _ENABLE_DATE2;
        public bool ENABLE_DATE2
        {

            get
            {
                return _ENABLE_DATE2;
            }
            set
            {

                _ENABLE_DATE2 = value;
                OnPropertyChanged("ENABLE_DATE2");
            }
        }

        private bool _ENABLE_YEAR2;
        public bool ENABLE_YEAR2
        {

            get
            {
                return _ENABLE_YEAR2;
            }
            set
            {

                _ENABLE_YEAR2 = value;
                OnPropertyChanged("ENABLE_YEAR2");
            }
        }

        private bool _ENABLE_YEAR3;
        public bool ENABLE_YEAR3
        {

            get
            {
                return _ENABLE_YEAR3;
            }
            set
            {

                _ENABLE_YEAR3 = value;
                OnPropertyChanged("ENABLE_YEAR3");
            }
        }

       // #region Insert Data
        public ICommand _ViewCompanyClick;
        public ICommand ViewCompanyClick
        {
            get
            {
                if (_ViewCompanyClick == null)
                {
                    _ViewCompanyClick = new DelegateCommand(ViewCompany_Click);
                }
                return _ViewCompanyClick;
            }
        }



        public async void ViewCompany_Click()
        {
            try
            {

                if (MONTH_YEAR == true)
                {

                    selectCompany.START_FIN_YEAR = selectCompany.MONTH1 +"-"+ selectCompany.YEAR1;
                    selectCompany.END_FIN_YEAR = "SEPTEMBER-2018";
                }

                if (selectCompany.DATE_MONTH_YEAR == true)
                {
                    selectCompany.START_FIN_YEAR = DATE2 + MONTH2 + YEAR2;
                    selectCompany.END_FIN_YEAR = "26-SEPTEMBER-2018";
                }
                if (selectCompany.YEAR == true)
                {
                    selectCompany.START_FIN_YEAR = YEAR3;
                    selectCompany.END_FIN_YEAR = "5-APRIL-2018";
                }


                selectCompany.CREATION_TYPE = App.Current.Properties["Creation_Type"].ToString();
                COMPANY_NAME = App.Current.Properties["Company_Name"].ToString();
                COUNTRY = App.Current.Properties["Country"].ToString();
                ADDRESS = App.Current.Properties["Address"].ToString();
                POSTCODE = App.Current.Properties["Postcode"].ToString();
                TELEPHONE = App.Current.Properties["Telephone"].ToString();
                FAX = App.Current.Properties["Fax"].ToString();
                WEBSITE = App.Current.Properties["Website"].ToString();

                App.Current.Properties["Company_Status"] = selectCompany.COMPANY_STATUS;
                App.Current.Properties["Company_Type"] = selectCompany.COMPANY_TYPE;
                App.Current.Properties["Start_Year"] = selectCompany.START_YEAR;
                App.Current.Properties["Start_Fin_Year"] = selectCompany.START_FIN_YEAR;
                App.Current.Properties["End_Fin_Year"] = selectCompany.END_FIN_YEAR;


                if (selectCompany.START_YEAR == "" || selectCompany.START_YEAR == null)
                {
                    MessageBox.Show("Start_Year Should not be blank..");
                }
                else
                {

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    var response = await client.PostAsJsonAsync("api/CompanyAPI/CreateCompanyAssistant/", selectCompany);
                    if (response.StatusCode.ToString() == "OK")
                    {

                        MessageBox.Show("Company Details Added Successfully");
                        Cancel_Company();
                        ViewCompany _VC = new ViewCompany();
                        _VC.ShowDialog();

                        //Cancel_Item();

                        //ModalService.NavigateTo(new Items(), delegate(bool returnValue) { });

                    }

                }

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
