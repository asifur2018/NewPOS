using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Accounts_Pos.Helpers;
using Accounts_Pos.Model;
using Accounts_Pos.View.Company;

namespace Accounts_Pos.ViewModel.Company
{
    class LoginCredentialsViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {

        public LoginCredentialsViewModel()
        {
            selectCompany = new CompanyModel();
            selectCompany.USER_NAME = App.Current.Properties["Company_Name"].ToString();
            _isviewmode = true;
            IsViewMode = true;
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
        public ICommand _MyUserId;
        public ICommand MyUserId
        {
            get
            {
                if (_MyUserId == null)
                {
                    _MyUserId = new DelegateCommand(MyUser_Id);
                }
                return _MyUserId;
            }

        }
        public string _ButtonText;
        public String ButtonText
        {
            get { return _ButtonText ?? (_ButtonText = "Define My Own"); }
            set
            {
                _ButtonText = value;
                NotifyPropertyChanged("ButtonText");
            }
        }

        public void MyUser_Id()
        {
            if (ButtonText == "Auto Generate")
            {
                ButtonText = "Define My Own";
                LoginCredential.UserName.Text = App.Current.Properties["Company_Name"].ToString();              
               _isviewmode = true;
                IsViewMode = true;
            }
            else if (ButtonText == "Define My Own")
            {
                 ButtonText = "Auto Generate";
                _isviewmode = false;
                IsViewMode = false;
                LoginCredential.UserName.Text = "";
                
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

        private string _CONFIRM_PASSWORD;
        public string CONFIRM_PASSWORD
        {
            get
            {
                return selectCompany.CONFIRM_PASSWORD;
            }
            set
            {
                selectCompany.CONFIRM_PASSWORD = value;
                OnPropertyChanged("CONFIRM_PASSWORD");

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


        //private DateTime _LAST_LOGIN;
        //public DateTime LAST_LOGIN
        //{
        //    get
        //    {
        //        return selectCompany.LAST_LOGIN;
        //    }
        //    set
        //    {
        //        selectCompany.LAST_LOGIN = value;
        //        OnPropertyChanged("LAST_LOGIN");

        //    }
        //}



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


        public ICommand _CreateLoginClick;
        public ICommand CreateLoginClick
        {
            get
            {
                if (_CreateLoginClick == null)
                {
                    _CreateLoginClick = new DelegateCommand(CreateLogin_Click);
                }
                return _CreateLoginClick;
            }
        }



        public async void CreateLogin_Click()
        {
            try
            {
                if (selectCompany.USER_NAME == "" || selectCompany.USER_NAME == null)
            {
                MessageBox.Show("Mobile No is not blank");
            }
                else if (selectCompany.PASSWORD == "" || selectCompany.PASSWORD == null)
            {
                MessageBox.Show("Email is not blank");
            }
                else if (selectCompany.CONFIRM_PASSWORD == "" || selectCompany.CONFIRM_PASSWORD == null)
                {
                    MessageBox.Show("Customer Group is not blank");
                }
            
                else if (!Regex.IsMatch(selectCompany.PASSWORD,
                    
                "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
                    
               RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    MessageBox.Show("Please check Password format");
                    return;
                }                

             else
             {

                 if (PASSWORD == CONFIRM_PASSWORD)
                 {


                     HttpClient client = new HttpClient();
                     client.DefaultRequestHeaders.Accept.Add(
                         new MediaTypeWithQualityHeaderValue("application/json"));
                     client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                     var response = await client.PostAsJsonAsync("api/CompanyAPI/CreateLogin/", selectCompany);
                     if (response.StatusCode.ToString() == "OK")
                     {

                         MessageBox.Show("Login Details Added Successfully");
                         Cancel_Company();
                         CompanyList _CM = new CompanyList();
                         _CM.ShowDialog();
                         //Cancel_Company();
                         //Cancel_Item();

                         //ModalService.NavigateTo(new Items(), delegate(bool returnValue) { });

                     }
                 }
                 else
                 {
                     MessageBox.Show("Your Password Doesnot Matches to Confirm Password..");
                 }

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


        public bool _isviewmode;
        public bool _isenable;
        public bool IsViewMode
        {
            get { return _isviewmode; }
            set
            {
                _isviewmode = value;
                // Call NotifyPropertyChanged when the source property is updated.
                NotifyPropertyChanged("IsViewMode");
            }
        }
        public bool isenable
        {
            get { return _isenable; }
            set
            {
                _isenable = value;
                // Call NotifyPropertyChanged when the source property is updated.
                NotifyPropertyChanged("isenable");
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
