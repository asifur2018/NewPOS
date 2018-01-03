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
using System.Windows;

namespace Accounts_Pos.ViewModel.LookUp
{
    class AccountAnalysisViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public AccountAnalysisViewModel()
        {
            selectedAccountAnalysis = new AccountAnalysisLookUpModel();
            selectedAccountAnalysis.TYPE = "Cr";
            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Hidden;
            GROUP_BOX_TITLE = "Add Account Analysis";
            
        }

        private string _ACCOUNT_ANALYSIS_ID;
        public string ACCOUNT_ANALYSIS_ID
        {
            get
            {
                return _ACCOUNT_ANALYSIS_ID;
            }
            set
            {
                _ACCOUNT_ANALYSIS_ID = value;
                OnPropertyChanged("ACCOUNT_ANALYSIS_ID");

            }
        }

        private string _ACCOUNT_ANALYSIS_DESC;
        public string ACCOUNT_ANALYSIS_DESC
        {
            get
            {
                return _ACCOUNT_ANALYSIS_DESC;
            }
            set
            {
                _ACCOUNT_ANALYSIS_DESC = value;
                OnPropertyChanged("ACCOUNT_ANALYSIS_DESC");

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

        private ICommand _AddAccountAnalysis { get; set; }
        public ICommand AddAccountAnalysis
        {
            get
            {
                if (_AddAccountAnalysis == null)
                {
                    _AddAccountAnalysis = new DelegateCommand(AddAccountAnalysis_Click);
                }
                return _AddAccountAnalysis;
            }

        }

        public async void AddAccountAnalysis_Click()
        {


            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/AccountAnalysisLookUpAPI/CreateAccountAnalysisModeLookUp/", selectedAccountAnalysis);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Account Analysis added successfully");
                }
               
                //close window
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddAccountAnalysisWindow");
                win.Close();
                //refresh parent window
                GetAccountAnalysisList();
                NotifyPropertyChanged("ListGrid");
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewAccountAnalysisWindow");
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
            //refresh grid
            GetAccountAnalysisList();
            NotifyPropertyChanged("ListGrid");
            //close window
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddAccountAnalysisWindow");
            if (win != null)
            {
                win.Close();
            }
        }

        #region ViewPage


        public ObservableCollection<AccountAnalysisLookUpModel> _ListGrid { get; set; }
        public ObservableCollection<AccountAnalysisLookUpModel> ListGrid
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

        private AccountAnalysisLookUpModel _selectedAccountAnalysis;
        public AccountAnalysisLookUpModel selectedAccountAnalysis
        {
            get { return _selectedAccountAnalysis; }
            set
            {
                if (_selectedAccountAnalysis != value)
                {
                    _selectedAccountAnalysis = value;
                    OnPropertyChanged("selectedAccountAnalysis");
                }
            }
        }

        public async Task<ObservableCollection<AccountAnalysisLookUpModel>> GetAccountAnalysisList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/AccountAnalysisLookUpAPI/GetAccountAnalysisLookUpList/").Result;

                ObservableCollection<AccountAnalysisLookUpModel> _ListGrid_Temp = new ObservableCollection<AccountAnalysisLookUpModel>();

                if (response.IsSuccessStatusCode)
                {
                    AccountAnalysisLookUpModel[] data = JsonConvert.DeserializeObject<AccountAnalysisLookUpModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new AccountAnalysisLookUpModel
                        {

                            ACCOUNT_ANALYSIS_ID = data[i].ACCOUNT_ANALYSIS_ID,
                            ACCOUNT_ANALYSIS_DESC = data[i].ACCOUNT_ANALYSIS_DESC,
                            TYPE = data[i].TYPE

                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<AccountAnalysisLookUpModel>(_ListGrid_Temp);
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
                var response = await client.PostAsJsonAsync("api/AccountAnalysisLookUpAPI/UpdateAccountAnalysisModeLookUp/", selectedAccountAnalysis);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Account Analysis edited successfully");
                }
                //refresh grid
                GetAccountAnalysisList();
                NotifyPropertyChanged("ListGrid");
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddAccountAnalysisWindow");
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
            if ((selectedAccountAnalysis==null) || (selectedAccountAnalysis.ACCOUNT_ANALYSIS_ID == 0))
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                AccountAnalysis _AA = new AccountAnalysis();
                AddButtonVisibility = Visibility.Hidden;
                EditButtonVisibility = Visibility.Visible;
                GROUP_BOX_TITLE = "Edit Account Analysis";
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
            AccountAnalysis AccountAnalysisView = new AccountAnalysis();
            AccountAnalysisView.Show();            
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
            if ((selectedAccountAnalysis==null) || (selectedAccountAnalysis.ACCOUNT_ANALYSIS_ID == 0))
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
                    var response = await client.PostAsJsonAsync("api/AccountAnalysisLookUpAPI/DeleteAccountAnalysisModeLookUp/", selectedAccountAnalysis);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Account Analysis deleted successfully");
                    }
                    //refresh grid
                    GetAccountAnalysisList();
                    NotifyPropertyChanged("ListGrid");

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
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
