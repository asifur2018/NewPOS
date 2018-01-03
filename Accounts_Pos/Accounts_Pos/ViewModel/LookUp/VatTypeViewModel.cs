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
    class VatTypeViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public VatTypeViewModel()
        {
            selectedVatType = new VatTypeLookUpModel();
            selectedVatType.DELIVERY_TYPE_APPLICABLE = true;
            selectedVatType.DELIVERY_MODE = true;

            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Hidden;
            GROUP_BOX_TITLE = "Add Vat Type";
        }

        private string _VAT_TYPE_NAME;
        public string VAT_TYPE_NAME
        {
            get
            {
                return _VAT_TYPE_NAME;
            }
            set
            {
                _VAT_TYPE_NAME = value;
                OnPropertyChanged("VAT_TYPE_NAME");

            }
        }

        private bool _DELIVERY_TYPE_APPLICABLE;
        public bool DELIVERY_TYPE_APPLICABLE
        {
            get
            {
                return _DELIVERY_TYPE_APPLICABLE;
            }
            set
            {
                _DELIVERY_TYPE_APPLICABLE = value;
                OnPropertyChanged("DELIVERY_TYPE_APPLICABLE");

            }
        }

        private bool _DELIVERY_MODE;
        public bool DELIVERY_MODE
        {
            get
            {
                return _DELIVERY_MODE;
            }
            set
            {
                _DELIVERY_MODE = value;
                OnPropertyChanged("DELIVERY_MODE");

            }
        }
        private string _VAT_TYPE_ID;
        public string VAT_TYPE_ID
        {
            get
            {
                return _VAT_TYPE_ID;
            }
            set
            {
                _VAT_TYPE_ID = value;
                OnPropertyChanged("VAT_TYPE");

            }
        }

        private ICommand _AddVatType { get; set; }
        public ICommand AddVatType
        {
            get
            {
                if (_AddVatType == null)
                {
                    _AddVatType = new DelegateCommand(AddVatType_Click);
                }
                return _AddVatType;
            }

        }

        public async void AddVatType_Click()
        {

          
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/VatTypeLookUpAPI/CreateVatTypeLookUp/", selectedVatType);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("VatType added successfully");
                }

                //close window
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddVatType");
                if (win != null)
                {
                    win.Close();
                }

                //refresh parent window
                GetVatTypeList();
                NotifyPropertyChanged("ListGrid");
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewVatTypeWindow");
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
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddVatType");
            if (win != null)
            {
                win.Close();
            }
            //refresh parent window
            GetVatTypeList();
            NotifyPropertyChanged("ListGrid");
            Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewVatTypeWindow");
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


        public ObservableCollection<VatTypeLookUpModel> _ListGrid { get; set; }
        public ObservableCollection<VatTypeLookUpModel> ListGrid
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

        private VatTypeLookUpModel _selectedVatType;
        public VatTypeLookUpModel selectedVatType
        {
            get { return _selectedVatType; }
            set
            {
                if (_selectedVatType != value)
                {
                    _selectedVatType = value;
                    OnPropertyChanged("selectedVatType");
                }
            }
        }

        public async Task<ObservableCollection<VatTypeLookUpModel>> GetVatTypeList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/VatTypeLookUpAPI/GetVatTypeLookUpList/").Result;

                ObservableCollection<VatTypeLookUpModel> _ListGrid_Temp = new ObservableCollection<VatTypeLookUpModel>();

                if (response.IsSuccessStatusCode)
                {
                    VatTypeLookUpModel[] data = JsonConvert.DeserializeObject<VatTypeLookUpModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new VatTypeLookUpModel
                        {

                            VAT_TYPE_ID = data[i].VAT_TYPE_ID,
                            VAT_TYPE_NAME = data[i].VAT_TYPE_NAME,
                            DELIVERY_MODE = data[i].DELIVERY_MODE,
                            DELIVERY_TYPE_APPLICABLE = data[i].DELIVERY_TYPE_APPLICABLE

                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<VatTypeLookUpModel>(_ListGrid_Temp);
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
                var response = await client.PostAsJsonAsync("api/VatTypeLookUpAPI/UpdateVatTypeLookUp/", selectedVatType);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Vat Type edited successfully");
                }
                //refresh grid
                GetVatTypeList();
                NotifyPropertyChanged("ListGrid");
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddVatType");
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
            if ((selectedVatType == null) || (selectedVatType.VAT_TYPE_ID == 0))
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                VatType _AA = new VatType();
                AddButtonVisibility = Visibility.Hidden;
                EditButtonVisibility = Visibility.Visible;
                GROUP_BOX_TITLE = "Edit Vat Type";
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
            VatType VatTypeView = new VatType();
            VatTypeView.Show();
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
            if ((selectedVatType == null) || (selectedVatType.VAT_TYPE_ID == 0))
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
                    var response = await client.PostAsJsonAsync("api/VatTypeLookUpAPI/DeleteVatTypeLookUp/", selectedVatType);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Vat Type deleted successfully");
                    }
                    //refresh grid
                    GetVatTypeList();
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
