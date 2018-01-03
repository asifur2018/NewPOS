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
using Accounts_Pos.ViewModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Accounts_Pos.ViewModel.LookUp
{
    class MarketCodeViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public MarketCodeViewModel()
        {
            selectedMarketCode = new MarketCodeLookUpModel();

            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Hidden;
            GROUP_BOX_TITLE = "Add Market Code";
        }

        private string _CODE;
        public string CODE
        {
            get
            {
                return _CODE;
            }
            set
            {
                _CODE = value;
                OnPropertyChanged("CODE");

            }
        }

        private string _DESCRIPTION;
        public string DESCRIPTION
        {
            get
            {
                return _DESCRIPTION;
            }
            set
            {
                _DESCRIPTION = value;
                OnPropertyChanged("DESCRIPTION");

            }
        }

        private string _DATE_ENTERED;
        public string DATE_ENTERED
        {
            get
            {
                return _DATE_ENTERED;
            }
            set
            {
                _DATE_ENTERED = value;
                OnPropertyChanged("DATE_ENTERED");

            }
        }


        private ICommand _AddMarketCode { get; set; }
        public ICommand AddMarketCode
        {
            get
            {
                if (_AddMarketCode == null)
                {
                    _AddMarketCode = new DelegateCommand(AddMarketCode_Click);
                }
                return _AddMarketCode;
            }

        }



        public async void AddMarketCode_Click()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/MarketCodeLookUpAPI/CreateMarketCodeLookUp/", selectedMarketCode);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Market Code added successfully");
                }

                //close window
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddMarketCode");
                if (win != null)
                {
                    win.Close();
                }

                //refresh parent window
                GetMarketCodeList();
                NotifyPropertyChanged("ListGrid");
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewMarketCodeWindow");
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
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddMarketCode");
            if (win != null)
            {
                win.Close();
            }
            //refresh parent window
            GetMarketCodeList();
            NotifyPropertyChanged("ListGrid");
            Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewMarketCodeWindow");
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


        public ObservableCollection<MarketCodeLookUpModel> _ListGrid { get; set; }
        public ObservableCollection<MarketCodeLookUpModel> ListGrid
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

        private MarketCodeLookUpModel _selectedMarketCode;
        public MarketCodeLookUpModel selectedMarketCode
        {
            get { return _selectedMarketCode; }
            set
            {
                if (_selectedMarketCode != value)
                {
                    _selectedMarketCode = value;
                    OnPropertyChanged("selectedMarketCode");
                }
            }
        }

        public async Task<ObservableCollection<MarketCodeLookUpModel>> GetMarketCodeList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/MarketCodeLookUpAPI/GetMarketCodeLookUpList/").Result;

                ObservableCollection<MarketCodeLookUpModel> _ListGrid_Temp = new ObservableCollection<MarketCodeLookUpModel>();

                if (response.IsSuccessStatusCode)
                {
                    MarketCodeLookUpModel[] data = JsonConvert.DeserializeObject<MarketCodeLookUpModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new MarketCodeLookUpModel
                        {

                            CODE = data[i].CODE,
                            DATE_ENTERED = data[i].DATE_ENTERED,
                            DESCRIPTION = data[i].DESCRIPTION,
                            MARKET_CODE_ID = data[i].MARKET_CODE_ID

                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<MarketCodeLookUpModel>(_ListGrid_Temp);
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
                var response = await client.PostAsJsonAsync("api/MarketCodeLookUpAPI/UpdateMarketCodeLookUp/", selectedMarketCode);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Market Code edited successfully");
                }
                //refresh grid
                GetMarketCodeList();
                NotifyPropertyChanged("ListGrid");
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddMarketCode");
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
            if ((selectedMarketCode == null) || (selectedMarketCode.MARKET_CODE_ID == 0))
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                MarketCode _AA = new MarketCode();
                AddButtonVisibility = Visibility.Hidden;
                EditButtonVisibility = Visibility.Visible;
                GROUP_BOX_TITLE = "Edit Market Code";
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
            MarketCode MarketCodeView = new MarketCode();
            MarketCodeView.Show();
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
            if ((selectedMarketCode == null) || (selectedMarketCode.MARKET_CODE_ID == 0))
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
                    var response = await client.PostAsJsonAsync("api/MarketCodeLookUpAPI/DeleteMarketCodeLookUp/", selectedMarketCode);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Market Code deleted successfully");
                    }
                    //refresh grid
                    GetMarketCodeList();
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
