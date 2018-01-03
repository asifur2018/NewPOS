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
    class DeliveryTypeViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public DeliveryTypeViewModel()
        {
            selectedDeliveryType = new DeliveryTypeLookUpModel();

            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Hidden;
            GROUP_BOX_TITLE = "Add Delivery Type";
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

        private string _NAME;
        public string NAME
        {
            get
            {
                return _NAME;
            }
            set
            {
                _NAME = value;
                OnPropertyChanged("NAME");

            }
        }

        private ICommand _AddDeliveryType { get; set; }
        public ICommand AddDeliveryType
        {
            get
            {
                if (_AddDeliveryType == null)
                {
                    _AddDeliveryType = new DelegateCommand(AddDeliveryType_Click);
                }
                return _AddDeliveryType;
            }

        }

        public async void AddDeliveryType_Click()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/DeliveryTypeLookUpAPI/CreateDeliveryTypeLookUp/", selectedDeliveryType);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("DeliveryType added successfully");
                }


                //close window
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddDeliveryType");
                if (win != null)
                {
                    win.Close();
                }

                //refresh parent window
                GetDeliveryTypeList();
                NotifyPropertyChanged("ListGrid");
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewDeliveryTypeWindow");
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
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddDeliveryType");
            if (win != null)
            {
                win.Close();
            }
            //refresh parent window
            GetDeliveryTypeList();
            NotifyPropertyChanged("ListGrid");
            Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewDeliveryTypeWindow");
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


        public ObservableCollection<DeliveryTypeLookUpModel> _ListGrid { get; set; }
        public ObservableCollection<DeliveryTypeLookUpModel> ListGrid
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

        private DeliveryTypeLookUpModel _selectedDeliveryType;
        public DeliveryTypeLookUpModel selectedDeliveryType
        {
            get { return _selectedDeliveryType; }
            set
            {
                if (_selectedDeliveryType != value)
                {
                    _selectedDeliveryType = value;
                    OnPropertyChanged("selectedDeliveryType");
                }
            }
        }

        public async Task<ObservableCollection<DeliveryTypeLookUpModel>> GetDeliveryTypeList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/DeliveryTypeLookUpAPI/GetDeliveryTypeLookUpList/").Result;

                ObservableCollection<DeliveryTypeLookUpModel> _ListGrid_Temp = new ObservableCollection<DeliveryTypeLookUpModel>();

                if (response.IsSuccessStatusCode)
                {
                    DeliveryTypeLookUpModel[] data = JsonConvert.DeserializeObject<DeliveryTypeLookUpModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new DeliveryTypeLookUpModel
                        {

                            ID = data[i].ID,
                            CODE = data[i].CODE,
                            NAME = data[i].NAME

                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<DeliveryTypeLookUpModel>(_ListGrid_Temp);
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
                var response = await client.PostAsJsonAsync("api/DeliveryTypeLookUpAPI/UpdateDeliveryTypeLookUp/", selectedDeliveryType);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Delivery Type edited successfully");
                }
                //refresh grid
                GetDeliveryTypeList();
                NotifyPropertyChanged("ListGrid");
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddDeliveryType");
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
            if ((selectedDeliveryType == null) || (selectedDeliveryType.ID == 0))
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                DeliveryType _AA = new DeliveryType();
                AddButtonVisibility = Visibility.Hidden;
                EditButtonVisibility = Visibility.Visible;
                GROUP_BOX_TITLE = "Edit Delivery Type";
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
            DeliveryType DeliveryTypeView = new DeliveryType();
            DeliveryTypeView.Show();
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
            if ((selectedDeliveryType == null) || (selectedDeliveryType.ID == 0))
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
                    var response = await client.PostAsJsonAsync("api/DeliveryTypeLookUpAPI/DeleteDeliveryTypeLookUp/", selectedDeliveryType);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Delivery Type deleted successfully");
                    }
                    //refresh grid
                    GetDeliveryTypeList();
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
