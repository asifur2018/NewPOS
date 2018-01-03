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
    class NatureOfProductViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public NatureOfProductViewModel()
        {
            selectedNatureOfProduct = new NatureOfProductLookUpModel();

            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Hidden;
            GROUP_BOX_TITLE = "Add Nature Of Product";
        }
        private string _NATURE_OF_PRODUCT_NAME;
        public string NATURE_OF_PRODUCT_NAME
        {
            get
            {
                return _NATURE_OF_PRODUCT_NAME;
            }
            set
            {
                _NATURE_OF_PRODUCT_NAME = value;
                OnPropertyChanged("NATURE_OF_PRODUCT_NAME");

            }
        }

        private string _NATURE_OF_PRODUCT_DESC;
        public string NATURE_OF_PRODUCT_DESC
        {
            get
            {
                return _NATURE_OF_PRODUCT_DESC;
            }
            set
            {
                _NATURE_OF_PRODUCT_DESC = value;
                OnPropertyChanged("NATURE_OF_PRODUCT_DESC");

            }
        }

        private ICommand _AddNatureOfProduct { get; set; }
        public ICommand AddNatureOfProduct
        {
            get
            {
                if (_AddNatureOfProduct == null)
                {
                    _AddNatureOfProduct = new DelegateCommand(AddNatureOfProduct_Click);
                }
                return _AddNatureOfProduct;
            }

        }

        public async void AddNatureOfProduct_Click()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/NatureOfProductLookUpAPI/CreateNatureOfProductLookUp/", selectedNatureOfProduct);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("NatureOfProduct added successfully");
                }

                //close window
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddNatureProduct");
                if (win != null)
                {
                    win.Close();
                }

                //refresh parent window
                GetNatureOfProductList();
                NotifyPropertyChanged("ListGrid");
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewNatureProductWindow");
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
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddNatureProduct");
            if (win != null)
            {
                win.Close();
            }
            //refresh parent window
            GetNatureOfProductList();
            NotifyPropertyChanged("ListGrid");
            Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewNatureProductWindow");
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


        public ObservableCollection<NatureOfProductLookUpModel> _ListGrid { get; set; }
        public ObservableCollection<NatureOfProductLookUpModel> ListGrid
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

        private NatureOfProductLookUpModel _selectedNatureOfProduct;
        public NatureOfProductLookUpModel selectedNatureOfProduct
        {
            get { return _selectedNatureOfProduct; }
            set
            {
                if (_selectedNatureOfProduct != value)
                {
                    _selectedNatureOfProduct = value;
                    OnPropertyChanged("selectedNatureOfProduct");
                }
            }
        }

        public async Task<ObservableCollection<NatureOfProductLookUpModel>> GetNatureOfProductList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/NatureOfProductLookUpAPI/GetNatureOfProductLookUpList/").Result;

                ObservableCollection<NatureOfProductLookUpModel> _ListGrid_Temp = new ObservableCollection<NatureOfProductLookUpModel>();

                if (response.IsSuccessStatusCode)
                {
                    NatureOfProductLookUpModel[] data = JsonConvert.DeserializeObject<NatureOfProductLookUpModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new NatureOfProductLookUpModel
                        {

                            NATURE_OF_PRODUCT_NAME = data[i].NATURE_OF_PRODUCT_NAME,
                            NATURE_OF_PRODUCT_DESC = data[i].NATURE_OF_PRODUCT_DESC,
                            NATURE_OF_PRODUCT_ID = data[i].NATURE_OF_PRODUCT_ID

                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<NatureOfProductLookUpModel>(_ListGrid_Temp);
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
                var response = await client.PostAsJsonAsync("api/NatureOfProductLookUpAPI/UpdateNatureOfProductLookUp/", selectedNatureOfProduct);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Nature Of Product edited successfully");
                }
                //refresh grid
                GetNatureOfProductList();
                NotifyPropertyChanged("ListGrid");
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddNatureProduct");
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
            if ((selectedNatureOfProduct == null) || (selectedNatureOfProduct.NATURE_OF_PRODUCT_ID == 0))
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                NatureProduct _AA = new NatureProduct();
                AddButtonVisibility = Visibility.Hidden;
                EditButtonVisibility = Visibility.Visible;
                GROUP_BOX_TITLE = "Edit Nature Of Product";
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
            NatureProduct NatureProductView = new NatureProduct();
            NatureProductView.Show();
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
            if ((selectedNatureOfProduct == null) || (selectedNatureOfProduct.NATURE_OF_PRODUCT_ID == 0))
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
                    var response = await client.PostAsJsonAsync("api/NatureOfProductLookUpAPI/DeleteNatureOfProductLookUp/", selectedNatureOfProduct);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Nature Of Product deleted successfully");
                    }
                    //refresh grid
                    GetNatureOfProductList();
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
