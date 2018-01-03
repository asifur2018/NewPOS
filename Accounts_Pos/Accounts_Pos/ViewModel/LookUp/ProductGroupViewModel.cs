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
    class ProductGroupViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public ProductGroupViewModel()
        {
            selectedProductGroup = new ProductGroupLookUpModel();

            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Hidden;
            GROUP_BOX_TITLE = "Add Product Group";
        }

        private string _GROUP_CODE;
        public string GROUP_CODE
        {
            get
            {
                return _GROUP_CODE;
            }
            set
            {
                _GROUP_CODE = value;
                OnPropertyChanged("GROUP_CODE");

            }
        }

        private string _GROUP_DESCRIPTION;
        public string GROUP_DESCRIPTION
        {
            get
            {
                return _GROUP_DESCRIPTION;
            }
            set
            {
                _GROUP_DESCRIPTION = value;
                OnPropertyChanged("GROUP_DESCRIPTION");

            }
        }

        private ICommand _AddProductGroup { get; set; }
        public ICommand AddProductGroup
        {
            get
            {
                if (_AddProductGroup == null)
                {
                    _AddProductGroup = new DelegateCommand(AddProductGroup_Click);
                }
                return _AddProductGroup;
            }

        }

        public async void AddProductGroup_Click()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/ProductGroupLookUpAPI/CreateProductGroupLookUp/", selectedProductGroup);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("ProductGroup added successfully");
                }

                //close window
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddProductGroup");
                if (win != null)
                {
                    win.Close();
                }

                //refresh parent window
                GetProductGroupList();
                NotifyPropertyChanged("ListGrid");
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewProductGroupWindow");
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
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddProductGroup");
            if (win != null)
            {
                win.Close();
            }
            //refresh parent window
            GetProductGroupList();
            NotifyPropertyChanged("ListGrid");
            Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewProductGroupWindow");
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


        public ObservableCollection<ProductGroupLookUpModel> _ListGrid { get; set; }
        public ObservableCollection<ProductGroupLookUpModel> ListGrid
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

        private ProductGroupLookUpModel _selectedProductGroup;
        public ProductGroupLookUpModel selectedProductGroup
        {
            get { return _selectedProductGroup; }
            set
            {
                if (_selectedProductGroup != value)
                {
                    _selectedProductGroup = value;
                    OnPropertyChanged("selectedProductGroup");
                }
            }
        }

        public async Task<ObservableCollection<ProductGroupLookUpModel>> GetProductGroupList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/ProductGroupLookUpAPI/GetProductGroupLookUpList/").Result;

                ObservableCollection<ProductGroupLookUpModel> _ListGrid_Temp = new ObservableCollection<ProductGroupLookUpModel>();

                if (response.IsSuccessStatusCode)
                {
                    ProductGroupLookUpModel[] data = JsonConvert.DeserializeObject<ProductGroupLookUpModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new ProductGroupLookUpModel
                        {
                            PRODUCT_GROUP_ID = data[i].PRODUCT_GROUP_ID,
                            GROUP_CODE = data[i].GROUP_CODE,
                            GROUP_DESCRIPTION = data[i].GROUP_DESCRIPTION

                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<ProductGroupLookUpModel>(_ListGrid_Temp);
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
                var response = await client.PostAsJsonAsync("api/ProductGroupLookUpAPI/UpdateProductGroupLookUp/", selectedProductGroup);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Product Group edited successfully");
                }
                //refresh grid
                GetProductGroupList();
                NotifyPropertyChanged("ListGrid");
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddProductGroup");
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
            if ((selectedProductGroup == null) || (selectedProductGroup.PRODUCT_GROUP_ID == 0))
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                ProductGroup _AA = new ProductGroup();
                AddButtonVisibility = Visibility.Hidden;
                EditButtonVisibility = Visibility.Visible;
                GROUP_BOX_TITLE = "Edit Product Group";
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
            ProductGroup ProductGroupView = new ProductGroup();
            ProductGroupView.Show();
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
            if ((selectedProductGroup == null) || (selectedProductGroup.PRODUCT_GROUP_ID == 0))
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
                    var response = await client.PostAsJsonAsync("api/ProductGroupLookUpAPI/DeleteProductGroupLookUp/", selectedProductGroup);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Product Group deleted successfully");
                    }
                    //refresh grid
                    GetProductGroupList();
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
