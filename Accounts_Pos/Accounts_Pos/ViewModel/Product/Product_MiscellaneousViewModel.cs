using System;
using System.Collections.Generic;
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
namespace Accounts_Pos.ViewModel.Product
{
    class Product_MiscellaneousViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {

        public Product_MiscellaneousViewModel()
        {
            selectProduct = new ProductModel();
            selectProduct.PRODUCT_CODE = App.Current.Properties["Product_Code"].ToString();
            selectProduct.DESCRIPTION = App.Current.Properties["Description"].ToString();
            selectProduct.BIN = App.Current.Properties["Bin"].ToString();
            int comp = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());

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

        private string _DESCRIPTION;
        public string DESCRIPTION
        {
            get
            {
                return selectProduct.DESCRIPTION = App.Current.Properties["Description"].ToString();
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
                selectProduct.PRODUCT_CODE = App.Current.Properties["Product_Code"].ToString();
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
                selectProduct.BIN = App.Current.Properties["Bin"].ToString();
                OnPropertyChanged("BIN");

            }
        }

        private decimal _SALES_AC1;
        public decimal SALES_AC1
        {
            get
            {
                return _SALES_AC1;
            }
            set
            {
                _SALES_AC1 = value;
                OnPropertyChanged("SALES_AC1");

            }
        }

        private decimal _SALES_AC2;
        public decimal SALES_AC2
        {
            get
            {
                return _SALES_AC2;
            }
            set
            {
                _SALES_AC2 = value;
                OnPropertyChanged("SALES_AC2");

            }
        }

        private decimal _SALES_AC4;
        public decimal SALES_AC4
        {
            get
            {
                return _SALES_AC4;
            }
            set
            {
                _SALES_AC4 = value;
                OnPropertyChanged("SALES_AC4");

            }
        }

        private decimal _SALES_AC5;
        public decimal SALES_AC5
        {
            get
            {
                return _SALES_AC5;
            }
            set
            {
                _SALES_AC5 = value;
                OnPropertyChanged("SALES_AC5");

            }
        }

        private decimal _SALES_AC3;
        public decimal SALES_AC3
        {
            get
            {
                return _SALES_AC3;
            }
            set
            {
                _SALES_AC3 = value;
                OnPropertyChanged("SALES_AC3");

            }
        }

        private decimal _PERCENT1;
        public decimal PERCENT1
        {
            get
            {
                return _PERCENT1;
            }
            set
            {
                _PERCENT1 = value;
                OnPropertyChanged("PERCENT1");

            }
        }


        private decimal _PERCENT2;
        public decimal PERCENT2
        {
            get
            {
                return _PERCENT2;
            }
            set
            {
                _PERCENT2 = value;
                OnPropertyChanged("PERCENT2");

            }
        }

        private decimal _PERCENT3;
        public decimal PERCENT3
        {
            get
            {
                return _PERCENT3;
            }
            set
            {
                _PERCENT3 = value;
                OnPropertyChanged("PERCENT3");

            }
        }

        private decimal _PERCENT4;
        public decimal PERCENT4
        {
            get
            {
                return _PERCENT4;
            }
            set
            {
                _PERCENT4 = value;
                OnPropertyChanged("PERCENT4");

            }
        }

        private decimal _PERCENT5;
        public decimal PERCENT5
        {
            get
            {
                return _PERCENT5;
            }
            set
            {
                _PERCENT5 = value;
                OnPropertyChanged("PERCENT5");

            }
        }



        private string _GROUP1;
        public string GROUP1
        {
            get
            {
                return _GROUP1;
            }
            set
            {
                _GROUP1 = value;
                OnPropertyChanged("GROUP1");

            }
        }

        private string _GROUP2;
        public string GROUP2
        {
            get
            {
                return _GROUP2;
            }
            set
            {
                _GROUP2 = value;
                OnPropertyChanged("GROUP2");

            }
        }

        private string _GROUP3;
        public string GROUP3
        {
            get
            {
                return _GROUP3;
            }
            set
            {
                _GROUP3 = value;
                OnPropertyChanged("GROUP3");

            }
        }

        private string _GROUP4;
        public string GROUP4
        {
            get
            {
                return _GROUP4;
            }
            set
            {
                _GROUP4 = value;
                OnPropertyChanged("GROUP4");

            }
        }

        private string _GROUP5;
        public string GROUP5
        {
            get
            {
                return _GROUP5;
            }
            set
            {
                _GROUP5 = value;
                OnPropertyChanged("GROUP5");

            }
        }


        private decimal _REORDER;
        public decimal REORDER
        {
            get
            {
                return _REORDER;
            }
            set
            {
                _REORDER = value;

                //_SELL_PRICE1 = RETAIL_STANDARD;
                OnPropertyChanged("REORDER");

            }
        }


        private decimal _MS_QUANTITY;
        public decimal MS_QUANTITY
        {
            get
            {
                return _MS_QUANTITY;
            }
            set
            {
                _MS_QUANTITY = value;

                //_SELL_PRICE1 = RETAIL_STANDARD;
                OnPropertyChanged("MS_QUANTITY");

            }
        }


        private decimal _PERCENT1_CAL1;
        public decimal PERCENT1_CAL1
        {
            get
            {
                return _PERCENT1_CAL1;
            }
            set
            {
                _PERCENT1_CAL1 = value;

                //_SELL_PRICE1 = RETAIL_STANDARD;
                OnPropertyChanged("PERCENT1_CAL1");

            }
        }


        private decimal _PERCENT1_CAL2;
        public decimal PERCENT1_CAL2
        {
            get
            {
                return _PERCENT1_CAL2;
            }
            set
            {
                _PERCENT1_CAL2 = value;

                //_SELL_PRICE1 = RETAIL_STANDARD;
                OnPropertyChanged("PERCENT1_CAL2");

            }
        }

        private decimal _PERCENT1_CAL3;
        public decimal PERCENT1_CAL3
        {
            get
            {
                return _PERCENT1_CAL3;
            }
            set
            {
                _PERCENT1_CAL3 = value;

                //_SELL_PRICE1 = RETAIL_STANDARD;
                OnPropertyChanged("PERCENT1_CAL3");

            }
        }

        private string _SUPPLIER_CODE1;
        public string SUPPLIER_CODE1
        {
            get
            {
                return _SUPPLIER_CODE1;
            }
            set
            {
                _SUPPLIER_CODE1 = value;

                //_SELL_PRICE1 = RETAIL_STANDARD;
                OnPropertyChanged("SUPPLIER_CODE1");

            }
        }


        private string _SUPPLIER_CODE2;
        public string SUPPLIER_CODE2
        {
            get
            {
                return _SUPPLIER_CODE2;
            }
            set
            {
                _SUPPLIER_CODE2 = value;

                //_SELL_PRICE1 = RETAIL_STANDARD;
                OnPropertyChanged("SUPPLIER_CODE2");

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

                //_SELL_PRICE1 = RETAIL_STANDARD;
                OnPropertyChanged("CODE");

            }
        }



        private decimal _MIN_ORDER;
        public decimal MIN_ORDER
        {
            get
            {
                return _MIN_ORDER;
            }
            set
            {
                _MIN_ORDER = value;

                //_SELL_PRICE1 = RETAIL_STANDARD;
                OnPropertyChanged("MIN_ORDER");

            }
        }


        private string _DESC;
        public string DESC
        {
            get
            {
                return _DESC;
            }
            set
            {
                _DESC = value;

                //_SELL_PRICE1 = RETAIL_STANDARD;
                OnPropertyChanged("DESC");

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
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/ProductAPI/CreateMiscellaneous_Product/", selectProduct);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Product Miscellaneous Data Added Successfully");

                    AssemblyBreakdown _AB = new AssemblyBreakdown();
                    _AB.ShowDialog();
                    Cancel_Product();

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
