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
    class DeliveryModeViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public DeliveryModeViewModel()
        {
            selectedDeliveryMode = new DeliveryModeLookUpModel();

            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Hidden;
            GROUP_BOX_TITLE = "Add Delivery Mode";
        }

        private string _ID;
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                OnPropertyChanged("ID");

            }
        }

        private string _MODE_CODE;
        public string MODE_CODE
        {
            get
            {
                return _MODE_CODE;
            }
            set
            {
                _MODE_CODE = value;
                OnPropertyChanged("MODE_CODE");

            }
        }

        private string _MODE_NAME;
        public string MODE_NAME
        {
            get
            {
                return _MODE_NAME;
            }
            set
            {
                _MODE_NAME = value;
                OnPropertyChanged("MODE_NAME");

            }
        }

        private ICommand _AddDeliveryMode { get; set; }
        public ICommand AddDeliveryMode
        {
            get
            {
                if (_AddDeliveryMode == null)
                {
                    _AddDeliveryMode = new DelegateCommand(AddDeliveryMode_Click);
                }
                return _AddDeliveryMode;
            }

        }

        public async void AddDeliveryMode_Click()
        {

            
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/DeliveryModeLookUpAPI/CreateDeliveryModeLookUp/", selectedDeliveryMode);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Delivery added successfully");
                }


                //close window
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddDeliveryMode");
                if (win != null)
                {
                    win.Close();
                }

                //refresh parent window
                GetDeliveryModeList();
                NotifyPropertyChanged("ListGrid");
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewDeliveryModeWindow");
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
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddDeliveryMode");
            if (win != null)
            {
                win.Close();
            }
            //refresh parent window
            GetDeliveryModeList();
            NotifyPropertyChanged("ListGrid");
            Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewDeliveryModeWindow");
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


        public ObservableCollection<DeliveryModeLookUpModel> _ListGrid { get; set; }
        public ObservableCollection<DeliveryModeLookUpModel> ListGrid
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

        private DeliveryModeLookUpModel _selectedDeliveryMode;
        public DeliveryModeLookUpModel selectedDeliveryMode
        {
            get { return _selectedDeliveryMode; }
            set
            {
                if (_selectedDeliveryMode != value)
                {
                    _selectedDeliveryMode = value;
                    OnPropertyChanged("selectedDeliveryMode");
                }
            }
        }

        public async Task<ObservableCollection<DeliveryModeLookUpModel>> GetDeliveryModeList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/DeliveryModeLookUpAPI/GetDeliveryModeLookUpList/").Result;

                ObservableCollection<DeliveryModeLookUpModel> _ListGrid_Temp = new ObservableCollection<DeliveryModeLookUpModel>();

                if (response.IsSuccessStatusCode)
                {
                    DeliveryModeLookUpModel[] data = JsonConvert.DeserializeObject<DeliveryModeLookUpModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new DeliveryModeLookUpModel
                        {

                            ID = data[i].ID,
                            MODE_CODE = data[i].MODE_CODE,
                            MODE_NAME = data[i].MODE_NAME

                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<DeliveryModeLookUpModel>(_ListGrid_Temp);
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
                var response = await client.PostAsJsonAsync("api/DeliveryModeLookUpAPI/UpdateDeliveryModeLookUp/", selectedDeliveryMode);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Delivery Mode edited successfully");
                }
                //refresh grid
                GetDeliveryModeList();
                NotifyPropertyChanged("ListGrid");
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddDeliveryMode");
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
            if ((selectedDeliveryMode==null) || (selectedDeliveryMode.ID == 0))
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                DeliveryMode _AA = new DeliveryMode();
                AddButtonVisibility = Visibility.Hidden;
                EditButtonVisibility = Visibility.Visible;
                GROUP_BOX_TITLE = "Edit Delivery Mode";
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
            DeliveryMode DeliveryModeView = new DeliveryMode();
            DeliveryModeView.Show();
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
            if ((selectedDeliveryMode == null) || (selectedDeliveryMode.ID == 0))
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
                    var response = await client.PostAsJsonAsync("api/DeliveryModeLookUpAPI/DeleteDeliveryModeLookUp/", selectedDeliveryMode);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Delivery Mode deleted successfully");
                    }
                    //refresh grid
                    GetDeliveryModeList();
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
