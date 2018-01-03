using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounts_Pos.View.Lookup;
using Accounts_Pos.ViewModel;
using Accounts_Pos.ViewModel.LookUp;
using System.Net.Http;
using System.Net.Http.Headers;
using Accounts_Pos.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using Accounts_Pos.Helpers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;


namespace Accounts_Pos.ViewModel.LookUp
{
    class AccountTypeViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public AccountTypeViewModel()
        {
            selectedAccountType = new AccountTypeLookUpModel();
            selectedAccountType.TYPE = "Cr";
            selectedAccountType.STATUS = true;

            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Hidden;
            GROUP_BOX_TITLE = "Add Account Type";
        }

        private string _ACC_TYPE_ID;
        public string ACC_TYPE_ID
        {
            get
            {
                return _ACC_TYPE_ID;
            }
            set
            {
                _ACC_TYPE_ID = value;
                OnPropertyChanged("_ACC_TYPE_ID");

            }
        }

        private string _ACC_TYPE_DESC;
        public string ACC_TYPE_DESC
        {
            get
            {
                return _ACC_TYPE_DESC;
            }
            set
            {
                _ACC_TYPE_DESC = value;
                OnPropertyChanged("ACC_TYPE_DESC");

            }
        }

        private string _TYPE;
        public string TYPE
        {
            get
            {
                return _TYPE;
            }
            set
            {
                _TYPE = value;
                OnPropertyChanged("TYPE");

            }
        }


        private bool _STATUS;
        public bool STATUS
        {
            get
            {
                return _STATUS;
            }
            set
            {
                _STATUS = value;
                OnPropertyChanged("TYPE");

            }
        }

        private ICommand _AddAccountType { get; set; }
        public ICommand AddAccountType
        {
            get
            {
                if (_AddAccountType == null)
                {
                    _AddAccountType = new DelegateCommand(AddAccountType_Click);
                }
                return _AddAccountType;
            }

        }

        public async void AddAccountType_Click()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/AccountTypeLookUpAPI/CreateAccountTypeModeLookUp/", selectedAccountType);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Account Type added successfully");
                }


                //close window
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddAccountType");
                if (win != null)
                {
                    win.Close();
                }

                //refresh parent window
                GetAccountTypeList();
                NotifyPropertyChanged("ListGrid");
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewAccountTypeWindow");
                if (winv != null)
                {
                    winv.DataContext = this;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }


        private ICommand _Cancel { get; set; }
        public ICommand Cancel
        {
            get
            {
                if (_Cancel == null)
                {
                    _Cancel = new DelegateCommand(Cancel_click);
                }
                return _Cancel;
            }

        }


        public void Cancel_click()
        {
            //close window
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddAccountType");
            if (win != null)
            {
                win.Close();
            }
            //refresh parent window
            GetAccountTypeList();
            NotifyPropertyChanged("ListGrid");
            Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewAccountTypeWindow");
            if (winv != null)
            {
                winv.DataContext = this;
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


        #region ViewPage


        public ObservableCollection<AccountTypeLookUpModel> _ListGrid { get; set; }
        public ObservableCollection<AccountTypeLookUpModel> ListGrid
        {
            get
            {
                return _ListGrid;
            }
            set
            {
                this._ListGrid = value;
                OnPropertyChanged("ListGrid");
            }
        }

        private AccountTypeLookUpModel _selectedAccountType;
        public AccountTypeLookUpModel selectedAccountType
        {
            get { return _selectedAccountType; }
            set
            {
                if (_selectedAccountType != value)
                {
                    _selectedAccountType = value;
                    OnPropertyChanged("selectedAccountType");
                }
            }
        }

        public async Task<ObservableCollection<AccountTypeLookUpModel>> GetAccountTypeList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/AccountTypeLookUpAPI/GetAccountTypeLookUpList/").Result;

                ObservableCollection<AccountTypeLookUpModel> _ListGrid_Temp = new ObservableCollection<AccountTypeLookUpModel>();

                if (response.IsSuccessStatusCode)
                {
                    AccountTypeLookUpModel[] data = JsonConvert.DeserializeObject<AccountTypeLookUpModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new AccountTypeLookUpModel
                        {

                            ACC_TYPE_ID = data[i].ACC_TYPE_ID,
                            ACC_TYPE_DESC = data[i].ACC_TYPE_DESC,
                            TYPE = data[i].TYPE,
                            STATUS = data[i].STATUS

                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<AccountTypeLookUpModel>(_ListGrid_Temp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region EditLookup


        private ICommand _Update { get; set; }
        public ICommand Update
        {
            get
            {
                if (_Update == null)
                {
                    _Update = new DelegateCommand(Update_Click);
                }
                return _Update;
            }

        }

        public async void Update_Click()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/AccountTypeLookUpAPI/UpdateAccountTypeModeLookUp/", selectedAccountType);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Account Type edited successfully");
                }
                //refresh grid
                GetAccountTypeList();
                NotifyPropertyChanged("ListGrid");
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddAccountType");
                if (win != null)
                {
                    win.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private ICommand _Edit { get; set; }
        public ICommand Edit
        {
            get
            {
                if (_Edit == null)
                {
                    _Edit = new DelegateCommand(Edit_Click);
                }
                return _Edit;
            }

        }

        public void Edit_Click()
        {
            if ((selectedAccountType==null) || (selectedAccountType.ACC_TYPE_ID == 0))
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                AccountType _AA = new AccountType();
                AddButtonVisibility = Visibility.Hidden;
                EditButtonVisibility = Visibility.Visible;
                GROUP_BOX_TITLE = "Edit Account Type";
                _AA.DataContext = this;
                _AA.ShowDialog();
            }
        }

        private Visibility _AddButtonVisibility;
        public Visibility AddButtonVisibility
        {
            get
            {
                return _AddButtonVisibility;
            }
            set
            {
                _AddButtonVisibility = value;

                OnPropertyChanged("AddButtonVisibility");
            }
        }
        private Visibility _EditButtonVisibility;
        public Visibility EditButtonVisibility
        {
            get
            {
                return _EditButtonVisibility;
            }
            set
            {
                _EditButtonVisibility = value;

                OnPropertyChanged("EditButtonVisibility");
            }
        }

        private string _GROUP_BOX_TITLE;
        public string GROUP_BOX_TITLE
        {
            get
            {
                return _GROUP_BOX_TITLE;
            }
            set
            {
                _GROUP_BOX_TITLE = value;
                OnPropertyChanged("GROUP_BOX_TITLE");

            }
        }
        #endregion

        #region Add Lookup

        private ICommand _Add { get; set; }
        public ICommand Add
        {
            get
            {
                if (_Add == null)
                {
                    _Add = new DelegateCommand(Add_Click);
                }
                return _Add;
            }

        }

        public void Add_Click()
        {
            AccountType AccountTypeView = new AccountType();
            AccountTypeView.Show();
        }

        #endregion

        #region DeleteLookup


        private ICommand _Delete { get; set; }
        public ICommand Delete
        {
            get
            {
                if (_Delete == null)
                {
                    _Delete = new DelegateCommand(Delete_Click);
                }
                return _Delete;
            }

        }

        public async void Delete_Click()
        {
            if ((selectedAccountType == null) || (selectedAccountType.ACC_TYPE_ID == 0))
            {
                MessageBox.Show("Please select a row to delete");
            }
            else
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    var response = await client.PostAsJsonAsync("api/AccountTypeLookUpAPI/DeleteAccountTypeModeLookUp/", selectedAccountType);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Account Type deleted successfully");
                    }
                    //refresh grid
                    GetAccountTypeList();
                    NotifyPropertyChanged("ListGrid");

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

        }

        #endregion


    }
}
