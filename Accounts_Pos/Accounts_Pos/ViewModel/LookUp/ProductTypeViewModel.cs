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
    class ProductTypeViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public ProductTypeViewModel()
        {
            selectedProductType = new ProductTypeLookUpModel();

            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Hidden;
            GROUP_BOX_TITLE = "Add Product Type";
        }


        private string _PRODUCT_TYPE_NAME;
        public string PRODUCT_TYPE_NAME
        {
            get
            {
                return _PRODUCT_TYPE_NAME;
            }
            set
            {
                _PRODUCT_TYPE_NAME = value;
                OnPropertyChanged("PRODUCT_TYPE_NAME");

            }
        }

        private string _PRODUCT_TYPE_DESCRIPTION;
        public string PRODUCT_TYPE_DESCRIPTION
        {
            get
            {
                return _PRODUCT_TYPE_DESCRIPTION;
            }
            set
            {
                _PRODUCT_TYPE_DESCRIPTION = value;
                OnPropertyChanged("PRODUCT_TYPE_DESCRIPTION");

            }
        }


        private ICommand _AddProductType { get; set; }
        public ICommand AddProductType
        {
            get
            {
                if (_AddProductType == null)
                {
                    _AddProductType = new DelegateCommand(AddProductType_Click);
                }
                return _AddProductType;
            }

        }

        public async void AddProductType_Click()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/ProductTypeLookUpAPI/CreateProductTypeLookUp/", selectedProductType);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("ProductType added successfully");
                }

                //close window
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddProductType");
                if (win != null)
                {
                    win.Close();
                }

                //refresh parent window
                GetProductTypeList();
                NotifyPropertyChanged("ListGrid");
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewProductTypeWindow");
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
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddProductType");
            if (win != null)
            {
                win.Close();
            }
            //refresh parent window
            GetProductTypeList();
            NotifyPropertyChanged("ListGrid");
            Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewProductTypeWindow");
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


        public ObservableCollection<ProductTypeLookUpModel> _ListGrid { get; set; }
        public ObservableCollection<ProductTypeLookUpModel> ListGrid
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

        private ProductTypeLookUpModel _selectedProductType;
        public ProductTypeLookUpModel selectedProductType
        {
            get { return _selectedProductType; }
            set
            {
                if (_selectedProductType != value)
                {
                    _selectedProductType = value;
                    OnPropertyChanged("selectedProductType");
                }
            }
        }

        public async Task<ObservableCollection<ProductTypeLookUpModel>> GetProductTypeList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/ProductTypeLookUpAPI/GetProductTypeLookUpList/").Result;

                ObservableCollection<ProductTypeLookUpModel> _ListGrid_Temp = new ObservableCollection<ProductTypeLookUpModel>();

                if (response.IsSuccessStatusCode)
                {
                    ProductTypeLookUpModel[] data = JsonConvert.DeserializeObject<ProductTypeLookUpModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new ProductTypeLookUpModel
                        {
                            PRODUCT_TYPE_ID = data[i].PRODUCT_TYPE_ID,
                            PRODUCT_TYPE_NAME = data[i].PRODUCT_TYPE_NAME,
                            PRODUCT_TYPE_DESCRIPTION = data[i].PRODUCT_TYPE_DESCRIPTION

                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<ProductTypeLookUpModel>(_ListGrid_Temp);
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
                var response = await client.PostAsJsonAsync("api/ProductTypeLookUpAPI/UpdateProductTypeLookUp/", selectedProductType);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Product Type edited successfully");
                }
                //refresh grid
                GetProductTypeList();
                NotifyPropertyChanged("ListGrid");
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddProductType");
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
            if ((selectedProductType == null) || (selectedProductType.PRODUCT_TYPE_ID == 0))
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                ProductType _AA = new ProductType();
                AddButtonVisibility = Visibility.Hidden;
                EditButtonVisibility = Visibility.Visible;
                GROUP_BOX_TITLE = "Edit Product Type";
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
            ProductType ProductTypeView = new ProductType();
            ProductTypeView.Show();
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
            if ((selectedProductType == null) || (selectedProductType.PRODUCT_TYPE_ID == 0))
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
                    var response = await client.PostAsJsonAsync("api/ProductTypeLookUpAPI/DeleteProductTypeLookUp/", selectedProductType);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Product Type deleted successfully");
                    }
                    //refresh grid
                    GetProductTypeList();
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
