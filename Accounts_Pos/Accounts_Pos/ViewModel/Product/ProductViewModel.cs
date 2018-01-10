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
    class ProductViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public HttpResponseMessage response;
        ProductModel[] data = null;
        ObservableCollection<ProductModel> _ListGrid_Temp = new ObservableCollection<ProductModel>();
        int comp = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
        //int comp = 46;
        public ProductViewModel()
        {
            //if (App.Current.Properties["Action"].ToString() == "Edit")
            //{
            //    CreatVisible = "Collapsed";
            //    UpdVisible = "Visible";
            //    selectProduct = App.Current.Properties["ProductEdit"] as ProductModel;
            //    App.Current.Properties["Action"] = "";

            //}
            //else
            {
                CreatVisible = "Visible";
                UpdVisible = "Collapsed";
                selectProduct = new ProductModel();
                VAT_RATE = "1-20.00% VAT Standard Rate";
                PRODUCT_TYPE1 = "Assembly";
                PRODUCT_TYPE2 = "Goods";
                DESCRIPTION = "Kilos";
                DISCONTINUED = "No";
                COMMISSION = "No";
                // var comp = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
                //int comp = 1;
                if (App.Current.Properties["AssembledPro"] != null)
                {

                    BtnVisible = "Visible";
                    //Product_Listing.BtnOk.Visibility = Visible;
                }
                else
                {
                    BtnVisible = "Collapsed";
                }
                GetProducts(comp);
            }

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

        private string _BtnVisible { get; set; }
        public string BtnVisible
        {

            get { return _BtnVisible; }
            set
            {
                if (value != _BtnVisible)
                {
                    _BtnVisible = value;
                    OnPropertyChanged("BtnVisible");
                }
            }
        }

        private string _CreatVisible { get; set; }
        public string CreatVisible
        {

            get { return _CreatVisible; }
            set
            {
                if (value != _CreatVisible)
                {
                    _CreatVisible = value;
                    OnPropertyChanged("CreatVisible");
                }
            }
        }

        private string _UpdVisible { get; set; }
        public string UpdVisible
        {

            get { return _UpdVisible; }
            set
            {
                if (value != _UpdVisible)
                {
                    _UpdVisible = value;
                    OnPropertyChanged("UpdVisible");
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

        private string _DESCRIPTION;
        public string DESCRIPTION
        {
            get
            {
                return selectProduct.DESCRIPTION;
            }
            set
            {
                selectProduct.DESCRIPTION = value;
                OnPropertyChanged("DESCRIPTION");

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

        private string _PRODUCT_TYPE1;
        public string PRODUCT_TYPE1
        {
            get
            {
                return selectProduct.PRODUCT_TYPE1;
            }
            set
            {
                selectProduct.PRODUCT_TYPE1 = value;
                OnPropertyChanged("PRODUCT_TYPE1");

            }
        }

        private string _DISCONTINUED;
        public string DISCONTINUED
        {
            get
            {
                return selectProduct.DISCONTINUED;
            }
            set
            {
                selectProduct.DISCONTINUED = value;
                OnPropertyChanged("DISCONTINUED");

            }
        }

        private string _PRODUCT_TYPE2;
        public string PRODUCT_TYPE2
        {
            get
            {
                return selectProduct.PRODUCT_TYPE2;
            }
            set
            {
                selectProduct.PRODUCT_TYPE2 = value;
                OnPropertyChanged("PRODUCT_TYPE2");

            }
        }

        public decimal vat;

        private string _VAT_RATE;
        public string VAT_RATE
        {
            get
            {
                return selectProduct.VAT_RATE;
            }
            set
            {
                selectProduct.VAT_RATE = value;

                if (VAT_RATE == "1-20.00% VAT Standard Rate")
                    vat = 20;
                if (VAT_RATE == "2-5.00% VAT Lower Rate")
                    vat = 5;
                if (VAT_RATE == "3-0.00% VAT Zero Rate")
                    vat = 0;
                if (VAT_RATE == "4-0.00% VAT Exempt Rate")
                    vat = 0;
                if (VAT_RATE == "5-0.00% Outside Scope")
                    vat = 0;
                OnPropertyChanged("VAT_RATE");

            }
        }

        private string _GROUP;
        public string GROUP
        {
            get
            {
                return selectProduct.GROUP;
            }
            set
            {
                selectProduct.GROUP = value;
                OnPropertyChanged("GROUP");

            }
        }

        //private string _DISCONTINUED;
        //public string DISCONTINUED
        //{
        //    get
        //    {
        //        return selectProduct.DISCONTINUED;
        //    }
        //    set
        //    {
        //        selectProduct.DISCONTINUED = value;
        //        OnPropertyChanged("DISCONTINUED");

        //    }
        //}

        private string _COMMISSION;
        public string COMMISSION
        {
            get
            {
                return selectProduct.COMMISSION;
            }
            set
            {
                selectProduct.COMMISSION = value;
                OnPropertyChanged("COMMISSION");

            }
        }

        private string _BAR_CODE;
        public string BAR_CODE
        {
            get
            {
                return selectProduct.BAR_CODE;
            }
            set
            {
                selectProduct.BAR_CODE = value;
                OnPropertyChanged("BAR_CODE");

            }
        }


        private string _UNIT_DESC;
        public string UNIT_DESC
        {
            get
            {
                return selectProduct.UNIT_DESC;
            }
            set
            {
                selectProduct.UNIT_DESC = value;
                OnPropertyChanged("UNIT_DESC");

            }
        }




        private string _ALTERNATIVE;
        public string ALTERNATIVE
        {
            get
            {
                return selectProduct.ALTERNATIVE;
            }
            set
            {
                selectProduct.ALTERNATIVE = value;
                OnPropertyChanged("ALTERNATIVE");

            }
        }

        private decimal _WEIGHT;
        public decimal WEIGHT
        {
            get
            {
                return selectProduct.WEIGHT;
            }
            set
            {
                selectProduct.WEIGHT = value;
                OnPropertyChanged("WEIGHT");

            }
        }

        private decimal _QUANTITY;
        public decimal QUANTITY
        {
            get
            {
                return _QUANTITY;
            }
            set
            {
                _QUANTITY = value;
                OnPropertyChanged("QUANTITY");

            }
        }

        private decimal _COST_PRICE;
        public decimal COST_PRICE
        {
            get
            {
                return selectProduct.COST_PRICE;
            }
            set
            {
                selectProduct.COST_PRICE = value;
                if (_COST_PRICE == 0)
                {
                    _COST_PRICE = selectProduct.COST_PRICE;
                }
                else
                {
                    _COST_PRICE = value;
                }
                //decimal RetailPrice = 0;
                //RetailPrice = (COST_PRICE * (vat / 100)) + COST_PRICE;
                //RETAIL_PRICE = RetailPrice;
                //selectProduct.COST_PRICE = _COST_PRICE;
                OnPropertyChanged("COST_PRICE");

            }
        }

        private decimal _LAST_SALE;
        public decimal LAST_SALE
        {
            get
            {
                return _LAST_SALE;
            }
            set
            {
                _LAST_SALE = value;
                OnPropertyChanged("LAST_SALE");

            }
        }

        private decimal _RETAIL_PRICE;
        public decimal RETAIL_PRICE
        {
            get
            {
                return _RETAIL_PRICE;
            }
            set
            {
                _RETAIL_PRICE = value;


                OnPropertyChanged("RETAIL_PRICE");

            }
        }

        private decimal _RETAIL_STANDARD;
        public decimal RETAIL_STANDARD
        {
            get
            {
                return _RETAIL_STANDARD;
            }
            set
            {
                _RETAIL_STANDARD = value;
                decimal RetailPrice = 0;
                RetailPrice = (RETAIL_STANDARD * (vat / 100)) + RETAIL_STANDARD;
                RETAIL_PRICE = RetailPrice;
                SELL_PRICE1 = RETAIL_STANDARD;
                if (RETAIL_STANDARD != 0)
                {
                    RETAIL_MARGIN = (RETAIL_STANDARD - COST_PRICE) / RETAIL_STANDARD * 100;
                }
                OnPropertyChanged("RETAIL_STANDARD");

            }
        }

        private decimal _TRADE;
        public decimal TRADE
        {
            get
            {
                return _TRADE;
            }
            set
            {
                _TRADE = value;
                if (TRADE != 0)
                {
                    TRADE_DISC = (RETAIL_STANDARD - TRADE) / RETAIL_STANDARD * 100;
                    TRADE_MARGIN = (TRADE - COST_PRICE) / TRADE * 100;
                }
                OnPropertyChanged("TRADE");

            }
        }

        private decimal _WHOLESALE;
        public decimal WHOLESALE
        {
            get
            {
                return _WHOLESALE;
            }
            set
            {
                _WHOLESALE = value;

                WHOLESALE_DISC = (RETAIL_STANDARD - WHOLESALE) / RETAIL_STANDARD * 100;
                WHOLESALE_MARGIN = (WHOLESALE - COST_PRICE) / WHOLESALE * 100;
                OnPropertyChanged("WHOLESALE");

            }
        }

        private decimal _TRADE_DISC;
        public decimal TRADE_DISC
        {
            get
            {
                return _TRADE_DISC;
            }
            set
            {
                _TRADE_DISC = value;
                OnPropertyChanged("TRADE_DISC");

            }
        }

        private decimal _WHOLESALE_DISC;
        public decimal WHOLESALE_DISC
        {
            get
            {
                return _WHOLESALE_DISC;
            }
            set
            {
                _WHOLESALE_DISC = value;
                OnPropertyChanged("WHOLESALE_DISC");

            }
        }

        private decimal _RETAIL_MARGIN;
        public decimal RETAIL_MARGIN
        {
            get
            {
                return _RETAIL_MARGIN;
            }
            set
            {
                _RETAIL_MARGIN = value;
                OnPropertyChanged("RETAIL_MARGIN");

            }
        }

        private decimal _TRADE_MARGIN;
        public decimal TRADE_MARGIN
        {
            get
            {
                return _TRADE_MARGIN;
            }
            set
            {
                _TRADE_MARGIN = value;
                OnPropertyChanged("TRADE_MARGIN");

            }
        }

        private decimal _WHOLESALE_MARGIN;
        public decimal WHOLESALE_MARGIN
        {
            get
            {
                return _WHOLESALE_MARGIN;
            }
            set
            {
                _WHOLESALE_MARGIN = value;
                OnPropertyChanged("WHOLESALE_MARGIN");

            }
        }

        private decimal _SELL_PRICE1;
        public decimal SELL_PRICE1
        {
            get
            {
                return _SELL_PRICE1;
            }
            set
            {
                _SELL_PRICE1 = value;

                //_SELL_PRICE1 = RETAIL_STANDARD;
                OnPropertyChanged("SELL_PRICE1");

            }
        }

        private decimal _SELL_PRICE2;
        public decimal SELL_PRICE2
        {
            get
            {
                return _SELL_PRICE2;
            }
            set
            {
                _SELL_PRICE2 = value;

                SELL_MARGIN2 = (SELL_PRICE2 - COST_PRICE) / SELL_PRICE2 * 100;
                OnPropertyChanged("SELL_PRICE2");

            }
        }

        private decimal _SELL_PRICE3;
        public decimal SELL_PRICE3
        {
            get
            {
                return _SELL_PRICE3;
            }
            set
            {
                _SELL_PRICE3 = value;

                SELL_MARGIN3 = (SELL_PRICE3 - COST_PRICE) / SELL_PRICE3 * 100;
                OnPropertyChanged("SELL_PRICE3");

            }
        }

        private decimal _SELL_PRICE4;
        public decimal SELL_PRICE4
        {
            get
            {
                return _SELL_PRICE4;
            }
            set
            {
                _SELL_PRICE4 = value;
                SELL_MARGIN4 = (SELL_PRICE4 - COST_PRICE) / SELL_PRICE4 * 100;
                OnPropertyChanged("SELL_PRICE4");

            }
        }

        private decimal _SELL_QTY2;
        public decimal SELL_QTY2
        {
            get
            {
                return _SELL_QTY2;
            }
            set
            {
                _SELL_QTY2 = value;
                OnPropertyChanged("SELL_QTY2");

            }
        }

        private decimal _SELL_QTY3;
        public decimal SELL_QTY3
        {
            get
            {
                return _SELL_QTY3;
            }
            set
            {
                _SELL_QTY3 = value;
                OnPropertyChanged("SELL_QTY3");

            }
        }

        private decimal _SELL_QTY4;
        public decimal SELL_QTY4
        {
            get
            {
                return _SELL_QTY4;
            }
            set
            {
                _SELL_QTY4 = value;
                OnPropertyChanged("SELL_QTY4");

            }
        }

        private decimal _SELL_MARGIN2;
        public decimal SELL_MARGIN2
        {
            get
            {
                return _SELL_MARGIN2;
            }
            set
            {
                _SELL_MARGIN2 = value;
                OnPropertyChanged("SELL_MARGIN2");

            }
        }

        private decimal _SELL_MARGIN3;
        public decimal SELL_MARGIN3
        {
            get
            {
                return _SELL_MARGIN3;
            }
            set
            {
                _SELL_MARGIN3 = value;
                OnPropertyChanged("SELL_MARGIN3");

            }
        }


        private decimal _SELL_MARGIN4;
        public decimal SELL_MARGIN4
        {
            get
            {
                return _SELL_MARGIN4;
            }
            set
            {
                _SELL_MARGIN4 = value;
                OnPropertyChanged("SELL_MARGIN4");

            }
        }

        private ICommand _AddProductClick { get; set; }
        public ICommand AddProductClick
        {
            get
            {
                if (_AddProductClick == null)
                {
                    _AddProductClick = new DelegateCommand(AddProduct_Click);
                }
                return _AddProductClick;
            }

        }

        public void AddProduct_Click()
        {
            AddProduct _AP = new AddProduct();
            _AP.ShowDialog();

        }





        public ICommand _UpdateData { get; set; }
        public ICommand UpdateData
        {
            get
            {
                if (_UpdateData == null)
                {
                    _UpdateData = new DelegateCommand(Update_Product);
                }
                return _UpdateData;
            }
        }


        public async void Update_Product()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalData.gblApiAdress);
            //selectDelivery.COMPANY_ID = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(500000000000);
            var response = await client.PostAsJsonAsync("api/ProductAPI/ProductUpdate/", selectProduct);
            if (response.StatusCode.ToString() == "OK")
            {
                MessageBox.Show("Product Update Successfully");
                Cancel_Product();
                //ModalService.NavigateTo(new Product_Listing(), delegate(bool returnValue) { });
                Product_Listing _PL = new Product_Listing();
                _PL.ShowDialog();

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
                App.Current.Properties["Product_Code"] = selectProduct.PRODUCT_CODE;
                App.Current.Properties["Description"] = selectProduct.DESCR;
                App.Current.Properties["Bin"] = selectProduct.BIN;

                if (PRODUCT_CODE == "" || PRODUCT_CODE == null)
                {
                    MessageBox.Show("PRODUCT CODE Should not be blank..");
                }

                else if (selectProduct.DESCR == "" || selectProduct.DESCR == null)
                {
                    MessageBox.Show("DESCRIPTION Should not be blank..");
                }

                else if (selectProduct.BIN == "" || selectProduct.BIN == null)
                {
                    MessageBox.Show("BIN Should not be blank..");
                }

                else
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    var response = await client.PostAsJsonAsync("api/ProductAPI/CreateProduct/", selectProduct);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Product Added Successfully");
                        //foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)

                        //    if (window.DataContext == this)
                        //    {
                        //        window.Close();
                        //    }

                        //Cancel_Product();

                        Product_Miscellaneous _PMS = new Product_Miscellaneous();
                        _PMS.ShowDialog();


                    }
                }
            }

            catch
            {

            }

        }

        #endregion


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
        public async Task<ObservableCollection<ProductModel>> GetProducts(int comp)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync("api/ProductAPI/GetProducts?id=" + comp + "").Result;
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
                            DISCONTINUED = data[i].DISCONTINUED,
                            PRODUCT_ID = data[i].PRODUCT_ID,


                        });
                    }

                }
                // ListGrid.Clear();

                ListGrid = _ListGrid_Temp;
                //DeliveryAddress.ListGridRef.ItemsSource = ListGrid.ToString();
                return new ObservableCollection<ProductModel>(_ListGrid_Temp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ICommand _EditProduct { get; set; }
        public ICommand EditProduct
        {
            get
            {
                if (_EditProduct == null)
                {

                    _EditProduct = new DelegateCommand(Edit_Product);
                }
                return _EditProduct;
            }
        }

        public async void Edit_Product()
        {


            try
            {
                if (selectProduct.PRODUCT_ID != null && selectProduct.PRODUCT_ID != 0)
                {
                    data = null;
                    App.Current.Properties["Action"] = "Edit";
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = new TimeSpan(500000000000);
                    HttpResponseMessage response = client.GetAsync("api/ProductAPI/EditProducts?id=" + selectProduct.PRODUCT_ID + "").Result;
                    //response = client.GetAsync("api/DeliveryAddressAPI/EditDelivery/?id=" + selectDelivery.DELIVERY_ID + "").Result;
                    if (response.StatusCode.ToString() == "OK")
                    {
                        data = JsonConvert.DeserializeObject<ProductModel[]>(await response.Content.ReadAsStringAsync());
                        if (data.Length > 0)
                        {
                            for (int i = 0; i < data.Length; i++)
                            {


                                PRODUCT_CODE = data[i].PRODUCT_CODE;
                                DESCR = data[i].DESCR;
                                //DESCRIPTION = data[i].DESCRIPTION;
                                BIN = data[i].BIN;
                                PRODUCT_TYPE1 = data[i].PRODUCT_TYPE1;
                                PRODUCT_TYPE2 = data[i].PRODUCT_TYPE2;
                                //VAT_RATE = data[i].VAT_RATE;
                                //GROUP = data[i].GROUP;
                                //DISCONTINUED = data[i].DISCONTINUED;
                                //COMMISSION = data[i].COMMISSION;
                                //BAR_CODE = data[i].BAR_CODE;
                                //UNIT_DESC = data[i].UNIT_DESC;
                                //ALTERNATIVE = data[i].ALTERNATIVE;
                                //WEIGHT = data[i].WEIGHT;
                                //QUANTITY = data[i].QUANTITY;
                                //COST_PRICE = data[i].COST_PRICE;
                                //LAST_SALE = data[i].LAST_SALE;
                                //RETAIL_PRICE = data[i].RETAIL_PRICE;
                                //RETAIL_STANDARD = data[i].RETAIL_STANDARD;
                                //TRADE = data[i].TRADE;
                                //WHOLESALE = data[i].WHOLESALE;
                                //TRADE_DISC = data[i].TRADE_DISC;
                                //WHOLESALE_DISC = data[i].WHOLESALE_DISC;
                                //RETAIL_MARGIN = data[i].RETAIL_MARGIN;
                                //TRADE_MARGIN = data[i].TRADE_MARGIN;
                                //WHOLESALE_MARGIN = data[i].WHOLESALE_MARGIN;
                                //SELL_PRICE1 = data[i].SELL_PRICE1;
                                //SELL_PRICE2 = data[i].SELL_PRICE2;
                                //SELL_PRICE3 = data[i].SELL_PRICE3;
                                //SELL_PRICE4 = data[i].SELL_PRICE4;
                                //SELL_QTY2 = data[i].SELL_QTY2;
                                //SELL_QTY3 = data[i].SELL_QTY3;
                                //SELL_QTY4 = data[i].SELL_QTY4;
                                //SELL_MARGIN2 = data[i].SELL_MARGIN2;
                                //SELL_MARGIN3 = data[i].SELL_MARGIN3;
                                //SELL_MARGIN4 = data[i].SELL_MARGIN4;
                                


                            }
                            App.Current.Properties["ProductEdit"] = selectProduct;
                            AddProduct _AP = new AddProduct();
                            _AP.ShowDialog();
                            //

                        }

                    }
                }
                else
                {

                    MessageBox.Show("Select Product first", "Item Selection", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }





        public ICommand _DeleteProduct;
        public ICommand DeleteProduct
        {
            get
            {
                if (_DeleteProduct == null)
                {
                    _DeleteProduct = new DelegateCommand(Delete_Product);
                }
                return _DeleteProduct;
            }
        }

        public async void Delete_Product()
        {
            if (selectProduct.PRODUCT_ID != null && selectProduct.PRODUCT_ID != 0)
            {

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure Delete this Product " + selectProduct.PRODUCT_ID + "?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var id = selectProduct.PRODUCT_ID;
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    HttpResponseMessage response = client.GetAsync("api/ProductAPI/DeleteProduct?id=" + selectProduct.PRODUCT_ID + "").Result;
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Delivery Address Deleted Successfully");
                        GetProducts(comp);
                        //ModalService.NavigateTo(new Product_Listing(), delegate(bool returnValue) { });

                    }
                }
                else
                {
                    Cancel_Product();
                }
            }
            else
            {
                MessageBox.Show("Select Product..");
            }

        }

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

        public ICommand _SelectOk { get; set; }
        public ICommand SelectOk
        {
            get
            {
                if (_SelectOk == null)
                {
                    _SelectOk = new DelegateCommand(Select_Ok);
                }
                return _SelectOk;
            }
        }

        public void Select_Ok()
        {
            if (selectProduct.PRODUCT_ID != null && selectProduct.PRODUCT_ID != 0)
            {

                App.Current.Properties["AssembledPro"] = "2";
                App.Current.Properties["AssembledProId"] = selectProduct.PRODUCT_ID;
                AssemblyBreakdownViewModel abm = new AssemblyBreakdownViewModel();

                //var comp = 1;
                //abm.GetAssembledProducts(PRODUCT_ID);
                abm.GetAssembledProducts();
                App.Current.Properties["AssembledPro"] = null;
            }
            else
            {

                MessageBox.Show("Select Product first", "Item Selection", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            Cancel_Product();
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

        public Visibility Visible { get; set; }
    }
}
