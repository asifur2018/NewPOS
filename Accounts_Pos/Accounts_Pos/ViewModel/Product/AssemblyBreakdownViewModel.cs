using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Accounts_Pos.Helpers;
using Accounts_Pos.Model;
using Accounts_Pos.View.Customer;
using Accounts_Pos.View.Product;
using Newtonsoft.Json;

namespace Accounts_Pos.ViewModel.Product
{
    class AssemblyBreakdownViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {

        public HttpResponseMessage response;
        ProductModel[] data = null;
        ProductModel[] data1 = null;
        ObservableCollection<ProductModel> _ListGrid_Temp = new ObservableCollection<ProductModel>();
        ObservableCollection<ProductModel> _ListGrid_Temp1 = new ObservableCollection<ProductModel>();
        int comp = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
        //int comp = 46;
        public AssemblyBreakdownViewModel()
        {
            selectProduct = new ProductModel();
            //if (App.Current.Properties["DataGridLPO"] != null)
            //{
            //    _ListGrid_Temp1 = App.Current.Properties["DataGridLPO"] as ObservableCollection<ProductModel>;
            //}

            PRODUCT_CODE = App.Current.Properties["Product_Code"].ToString();
            DESCR = App.Current.Properties["Description"].ToString();
            BIN = App.Current.Properties["Bin"].ToString();

            //var comp = 1;
            ListGrid = _ListGrid_Temp;

            //GetAssembledProducts();
        }


        private ProductModel _selectProduct;
        public ProductModel selectProduct
        {
            get { return _selectProduct; }
            set
            {
                if (_selectProduct != value)
                {
                    _selectProduct = value;
                    OnPropertyChanged("selectProduct");
                }
            }
        }

        private ProductModel _selectedItem;
        public ProductModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }


        private string _DESCR;
        public string DESCR
        {
            get
            {
                return selectProduct.DESCR;
            }
            set
            {
                selectProduct.DESCR = value;
                OnPropertyChanged("DESCR");

            }
        }



        private string _PRODUCT_CODE;
        public string PRODUCT_CODE
        {
            get
            {
                return selectProduct.PRODUCT_CODE;
            }
            set
            {
                selectProduct.PRODUCT_CODE = value;
                OnPropertyChanged("PRODUCT_CODE");

            }
        }

        private string _BIN;
        public string BIN
        {
            get
            {
                return selectProduct.BIN;
            }
            set
            {
                selectProduct.BIN = value;
                OnPropertyChanged("BIN");

            }
        }


        public ObservableCollection<ProductModel> _ListGrid { get; set; }
        public ObservableCollection<ProductModel> ListGrid
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
        public async Task<ObservableCollection<ProductModel>> GetAssembledProducts()

        //public async void GetAssembledProducts()
        {
            try
            {
                //ObservableCollection<ProductModel> _ListGrid_Temp1 = new ObservableCollection<ProductModel>();
                selectProduct.PRODUCT_ID = Convert.ToInt32(App.Current.Properties["AssembledProId"]);
                //selectProduct.PRODUCT_ID = 6;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                //response = client.GetAsync("api/ProductAPI/GetProducts?id=" + comp + "").Result;
                response = client.GetAsync("api/ProductAPI/GetProductsAssembled?id=" + comp + "&pid=" + selectProduct.PRODUCT_ID + "").Result;
                //HttpResponseMessage response = client.GetAsync("api/CompanyAPI/CompanyLogin?id=" + USER_NAME + "&password=" + PASSWORD + "&comp=" + selectCompany.COMPANY_ID + "").Result;
                //_ListGrid_Temp.Clear();
                // int x = 0;
                if (App.Current.Properties["DataGridPA"] != null)
                {
                    _ListGrid_Temp1 = App.Current.Properties["DataGridPA"] as ObservableCollection<ProductModel>;
                    //var   _ListGrid_Temp1 = App.Current.Properties["DataGridPO"];
                    // x = x + 1;
                }

                var REMOVEI = (from a in _ListGrid_Temp1 where a.SLNO == 0 select a).FirstOrDefault();


                if (response.IsSuccessStatusCode)
                {
                    data1 = JsonConvert.DeserializeObject<ProductModel[]>(await response.Content.ReadAsStringAsync());
                    // EmployeeData = new List<EmployeeModel>();


                    int x = 0;
                    for (int i = 0; i < data1.Length; i++)
                    {
                        x++;
                        _ListGrid_Temp1.Remove(REMOVEI);
                        _ListGrid_Temp1.Add(new ProductModel
                        {
                            SLNO = x,
                            //SLNO=i+1,
                            PRODUCT_CODE = data1[i].PRODUCT_CODE,
                            DESCRIPTION = data1[i].DESCRIPTION,
                            BIN = data1[i].BIN,
                            PRODUCT_TYPE1 = data1[i].PRODUCT_TYPE1,
                            QUANTITY = data1[i].QUANTITY,
                            COST_PRICE = data1[i].COST_PRICE,
                            PRODUCT_ID = data1[i].PRODUCT_ID,


                        });
                    }


                }
                // ListGrid.Clear();

                //ListGrid = _ListGrid_Temp1;

                //else
                {
                    App.Current.Properties["DataGridPA"] = _ListGrid_Temp1;
                }
                //App.Current.Properties["DataGridPA"] = null;
                //_ListGrid_Temp1 = _ListGrid_Temp;
                AssemblyBreakdown.ListGridRef.ItemsSource = _ListGrid_Temp1;
                return new ObservableCollection<ProductModel>(_ListGrid_Temp1);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ObservableCollection<ProductModel>> GetAssembledProduct()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                //response = client.GetAsync("api/ProductAPI/GetProducts?id=" + comp + "&productId=" + PRODUCT_ID + "").Result;
                HttpResponseMessage response = client.GetAsync("api/ProductAPI/GetProducts?id=" + comp + "").Result;
                //HttpResponseMessage response = client.GetAsync("api/CompanyAPI/CompanyLogin?id=" + USER_NAME + "&password=" + PASSWORD + "&comp=" + selectCompany.COMPANY_ID + "").Result;
                _ListGrid_Temp.Clear();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonConvert.DeserializeObject<ProductModel[]>(await response.Content.ReadAsStringAsync());
                    // EmployeeData = new List<EmployeeModel>();
                    int x = 0;

                    for (int i = 0; i < data.Length; i++)
                    {
                        x++;
                        _ListGrid_Temp.Add(new ProductModel
                        {
                            SLNO = x,

                            PRODUCT_CODE = data[i].PRODUCT_CODE,
                            DESCRIPTION = data[i].DESCRIPTION,
                            BIN = data[i].BIN,
                            PRODUCT_TYPE1 = data[i].PRODUCT_TYPE1,
                            QUANTITY = data[i].QUANTITY,
                            COST_PRICE = data[i].COST_PRICE,
                            PRODUCT_ID = data[i].PRODUCT_ID,


                        });
                    }

                }
                // ListGrid.Clear();

                ListGrid = _ListGrid_Temp;
                //DeliveryAddress.ListGridRef.ItemsSource = _ListGrid_Temp.ToString();
                return new ObservableCollection<ProductModel>(_ListGrid_Temp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        #region Insert Data

        public ICommand _InsertData { get; set; }
        public ICommand InsertData
        {
            get
            {
                if (_InsertData == null)
                {
                    _InsertData = new DelegateCommand(Insert_Data);
                }
                return _InsertData;
            }
        }

        public async void Insert_Data()
        {
            try
            {


                var datagrid = App.Current.Properties["DataGridPA"] as ObservableCollection<ProductModel>;

                selectProduct.SelectedItem = datagrid;



                //if (PRODUCT_CODE == "" || PRODUCT_CODE == null)
                //{
                //    MessageBox.Show("PRODUCT CODE Should not be blank..");
                //}

                //else if (selectProduct.DESCR == "" || selectProduct.DESCR == null)
                //{
                //    MessageBox.Show("DESCRIPTION Should not be blank..");
                //}

                //else if (selectProduct.BIN == "" || selectProduct.BIN == null)
                //{
                //    MessageBox.Show("BIN Should not be blank..");
                //}

                //else
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    var response = await client.PostAsJsonAsync("api/ProductAPI/AssemblyBreak/", selectProduct);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Product Assembled Successfully");
                        //Cancel_Product();
                        ProductImage _PIMG = new ProductImage();
                        _PIMG.ShowDialog();


                    }
                }
            }

            catch
            {

            }

        }

        #endregion


        public ICommand _Cancel;
        public ICommand Cancel
        {
            get
            {
                if (_Cancel == null)
                {
                    _Cancel = new DelegateCommand(Cancel_Product);
                }
                return _Cancel;
            }
        }



        public void Cancel_Product()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
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

        private Stack<BackNavigationEventHandler> _backFunctions = new Stack<BackNavigationEventHandler>();

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
