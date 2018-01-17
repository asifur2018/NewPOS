using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounts_Pos.Helpers;
using Accounts_Pos.ViewModel;
using Accounts_Pos.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Accounts_Pos.View.SalesOrder;
using System.Collections;

namespace Accounts_Pos.ViewModel.SalesOrder
{
    class RecurringSalesInvoiceViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public RecurringSalesInvoiceViewModel()
        {
            if (SelectedRecurringSalesInvoice == null)
            {
                SelectedRecurringSalesInvoice = new RecurringSalesInvoiceModel();
            }
            populateRecurringSalesInvoiceList();
            SelectedRecurringSalesInvoice.FREQUENCY = "Only Once";
            prepareItemLine(0);
            ItemLineEditability = false;
            
        }
        #region data binding
        private RecurringSalesInvoiceModel _SelectedRecurringSalesInvoice;
        public RecurringSalesInvoiceModel SelectedRecurringSalesInvoice
        {
            get
            {
                return _SelectedRecurringSalesInvoice;
            }
            set
            {
                this._SelectedRecurringSalesInvoice = value;
                NotifyPropertyChanged("SelectedRecurringSalesInvoice");
            }
        }

        private RecurringSalesLineModel _SelectedRecurringSalesLine;
        public RecurringSalesLineModel SelectedRecurringSalesLine
        {
            get
            {
                return _SelectedRecurringSalesLine;
            }
            set
            {
                this._SelectedRecurringSalesLine = value;
                NotifyPropertyChanged("SelectedRecurringSalesLine");
            }
        }


        public bool _ItemLineEditability { get; set; }
        public bool ItemLineEditability
        {
            get
            {
                return _ItemLineEditability;
            }
            set
            {
                this._ItemLineEditability = value;
                NotifyPropertyChanged("ItemLineEditability");
            }
        }
        public int _SelectedProductIndex { get; set; }
        public int SelectedProductIndex
        {
            get
            {
                if (_SelectedProductIndex < 0)
                {
                    return _SelectedProductIndex + 20;
                }
                else
                {
                    return _SelectedProductIndex;
                }
            }
            set
            {
                this._SelectedProductIndex = value;
                NotifyPropertyChanged("SelectedProductIndex");
            }
        }

        private string _StatusMessage;
        public string StatusMessage
        {
            get
            {
                return _StatusMessage;
            }
            set
            {
                this._StatusMessage = value;
            }
        }

        private string _Frequency;
        public string Frequency
        {
            get
            {
                return _Frequency;
            }
            set
            {
                this._Frequency = value;
                OnPropertyChanged("Frequency");
            }
        }

        public ObservableCollection<RecurringSalesInvoiceModel> _RecurringSalesInvoiceList { get; set; }
        public ObservableCollection<RecurringSalesInvoiceModel> RecurringSalesInvoiceList
        {
            get
            {
                return _RecurringSalesInvoiceList;
            }
            set
            {
                this._RecurringSalesInvoiceList = value;
                OnPropertyChanged("RecurringSalesInvoiceList");
            }
        }

        public ObservableCollection<RecurringSalesLineModel> _ProductGrid { get; set; }
        public ObservableCollection<RecurringSalesLineModel> ProductGrid
        {
            get
            {
                return _ProductGrid;
            }
            set
            {
                this._ProductGrid = value;
                OnPropertyChanged("ProductGrid");
            }
        }
        #endregion

        #region command binding

        private ICommand _LineAmountChanged { get; set; }
        public ICommand LineAmountChanged
        {
            get
            {
                if (_LineAmountChanged == null)
                {
                    _LineAmountChanged = new DelegateCommand(LineAmount_Changed);
                }
                return _LineAmountChanged;
            }

        }

        public void LineAmount_Changed()
        {
            decimal sum = 0;
            for (int i = 0; i < ProductGrid.Count(); i++)
            {
                sum = sum + ProductGrid[i].LINE_AMOUNT;
            }
            SelectedRecurringSalesInvoice.ORDER_NET_AMOUNT = sum;
        }

        private ICommand _SelectProductCodeCommand { get; set; }
        public ICommand SelectProductCodeCommand
        {
            get
            {
                if (_SelectProductCodeCommand == null)
                {
                    _SelectProductCodeCommand = new DelegateCommand(SelectProductCodeCommandMethod);
                }
                return _SelectProductCodeCommand;

            }

        }
        public void SelectProductCodeCommandMethod()
        {
            /*if (String.IsNullOrEmpty(SelectedSalesOrder.INVOICE_TO))
            {
                ItemLineEditability = true;
            }else*/
            if (String.IsNullOrEmpty(ProductGrid[SelectedProductIndex].PRODUCT_CODE))
            {
                if ((SelectedProductIndex > 0) && (String.IsNullOrEmpty(ProductGrid[SelectedProductIndex - 1].PRODUCT_CODE)))
                {
                    ItemLineEditability = true;
                }
                else if ((SelectedProductIndex > 0)
                    && (!String.IsNullOrEmpty(ProductGrid[SelectedProductIndex - 1].PRODUCT_CODE))
                    && (ProductGrid[SelectedProductIndex - 1].LINE_AMOUNT == 0))
                {
                    ItemLineEditability = true;
                }
                else
                {
                    ItemLineEditability = false;
                }
            }
            else
            {
                ItemLineEditability = false;
            }

            if ((ProductGrid.Count == SelectedRecurringSalesLine.NO) && ((SelectedRecurringSalesLine.NO % 20) == 0))
            {
                prepareItemLine(SelectedRecurringSalesLine.NO);
            }

        }

        private ICommand _SelectProductDescriptionCommand { get; set; }
        public ICommand SelectProductDescriptionCommand
        {
            get
            {
                if (_SelectProductDescriptionCommand == null)
                {
                    _SelectProductDescriptionCommand = new DelegateCommand(SelectProductDescriptionCommandMethod);
                }
                return _SelectProductDescriptionCommand;

            }

        }
        public void SelectProductDescriptionCommandMethod()
        {
            if (String.IsNullOrEmpty(ProductGrid[SelectedProductIndex].PRODUCT_CODE))
            {
                ItemLineEditability = true;
            }
            else
            {
                ItemLineEditability = false;
            }
        }

        private ICommand _SelectProductQtyCommand { get; set; }
        public ICommand SelectProductQtyCommand
        {
            get
            {
                if (_SelectProductQtyCommand == null)
                {
                    _SelectProductQtyCommand = new DelegateCommand(SelectProductQtyCommandMethod);
                }
                return _SelectProductQtyCommand;

            }

        }
        public void SelectProductQtyCommandMethod()
        {
            if (String.IsNullOrEmpty(ProductGrid[SelectedProductIndex].PRODUCT_CODE))
            {
                ItemLineEditability = true;
            }
            else
            {
                ItemLineEditability = false;
            }
        }

        private ICommand _SelectProductPriceCommand { get; set; }
        public ICommand SelectProductPriceCommand
        {
            get
            {
                if (_SelectProductPriceCommand == null)
                {
                    _SelectProductPriceCommand = new DelegateCommand(SelectProductPriceCommandMethod);
                }
                return _SelectProductPriceCommand;

            }

        }
        public void SelectProductPriceCommandMethod()
        {
            if (String.IsNullOrEmpty(ProductGrid[SelectedProductIndex].PRODUCT_CODE))
            {
                ItemLineEditability = true;
            }
            else
            {
                ItemLineEditability = false;
            }
        }

        private ICommand _SelectProductDiscountCommand { get; set; }
        public ICommand SelectProductDiscountCommand
        {
            get
            {
                if (_SelectProductDiscountCommand == null)
                {
                    _SelectProductDiscountCommand = new DelegateCommand(SelectProductDiscountCommandMethod);
                }
                return _SelectProductDiscountCommand;

            }

        }
        public void SelectProductDiscountCommandMethod()
        {
            if (String.IsNullOrEmpty(ProductGrid[SelectedProductIndex].PRODUCT_CODE))
            {
                ItemLineEditability = true;
            }
            else
            {
                ItemLineEditability = false;
            }
        }
        private ICommand _SelectProductAmountCommand { get; set; }
        public ICommand SelectProductAmountCommand
        {
            get
            {
                if (_SelectProductAmountCommand == null)
                {
                    _SelectProductAmountCommand = new DelegateCommand(SelectProductAmountCommandMethod);
                }
                return _SelectProductAmountCommand;

            }

        }
        public void SelectProductAmountCommandMethod()
        {
            ItemLineEditability = true;

        }

        private ICommand _InvoiceClick { get; set; }
        public ICommand InvoiceClick
        {
            get
            {
                if (_InvoiceClick == null)
                {
                    _InvoiceClick = new DelegateCommand(InvoiceClickMethod);
                }
                return _InvoiceClick;
            }

        }
        public void InvoiceClickMethod()
        {
            StatusMessage = "Enter Customer Code";
            NotifyPropertyChanged("StatusMessage");
        }

        private ICommand _ProductCodeLostFocusCommand { get; set; }
        public ICommand ProductCodeLostFocusCommand
        {
            get
            {
                if (_ProductCodeLostFocusCommand == null)
                {
                    _ProductCodeLostFocusCommand = new DelegateCommand(ProductCodeLostFocusMethod);
                }
                return _ProductCodeLostFocusCommand;
            }

        }
        public async void ProductCodeLostFocusMethod()
        {
            if (!String.IsNullOrEmpty(SelectedRecurringSalesLine.PRODUCT_CODE))
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("api/ProductAPI/GetProduct/?_ProductCode=" + SelectedRecurringSalesLine.PRODUCT_CODE).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        ProductModel data = JsonConvert.DeserializeObject<ProductModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                        if (data == null)
                        {
                            MessageBox.Show("Product Code is Invalid");
                            SelectedRecurringSalesLine.PRODUCT_CODE = "";
                            NotifyPropertyChanged("SelectedSalesOrderLineItem");
                        }
                        else
                        {
                            SelectedRecurringSalesLine.PRODUCT_CODE = data.PRODUCT_CODE;
                            SelectedRecurringSalesLine.DESCRIPTION = data.DESCRIPTION;
                            SelectedRecurringSalesLine.UNIT_PRICE = data.SELL_PRICE1;
                            SelectedRecurringSalesLine.ORDER_QTY = 0;
                            SelectedRecurringSalesLine.DISCOUNT_PERCENT = 0;
                           
                        }
                    }
                }
                catch
                {
                }
            }
        }
        #endregion

        #region methods

        public async Task<ObservableCollection<RecurringSalesInvoiceModel>> populateRecurringSalesInvoiceList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/SalesOrderAPI/GetRecurringSalesInvoiceList/").Result;

                ObservableCollection<RecurringSalesInvoiceModel> _ListGrid_Temp = new ObservableCollection<RecurringSalesInvoiceModel>();

                if (response.IsSuccessStatusCode)
                {
                    RecurringSalesInvoiceModel[] data = JsonConvert.DeserializeObject<RecurringSalesInvoiceModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new RecurringSalesInvoiceModel
                        {

                            RECURR_SALES_INVOICE_ID = data[i].RECURR_SALES_INVOICE_ID,
                            INVOICE_TO = data[i].INVOICE_TO,
                            DELIVERY_TO = data[i].DELIVERY_TO,
                            ORDER_DES = data[i].ORDER_DES,
                            ORDER_REF = data[i].ORDER_REF,
                            SALES_PERSON = data[i].SALES_PERSON,
                            MARKET_CODE = data[i].MARKET_CODE,
                            FREQUENCY = data[i].FREQUENCY,
                            CURRENT_STATUS = data[i].CURRENT_STATUS,
                            LAST_POSTED = data[i].LAST_POSTED,
                            PROCESS_NEXT_OCCUR = data[i].PROCESS_NEXT_OCCUR,
                            NUM_OF_TIME_TO_POST = data[i].NUM_OF_TIME_TO_POST,
                            ORDER_NET_AMOUNT = data[i].ORDER_NET_AMOUNT

                        });
                    }

                }

                RecurringSalesInvoiceList = _ListGrid_Temp;
                return new ObservableCollection<RecurringSalesInvoiceModel>(_ListGrid_Temp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void prepareItemLine(int n)
        {
            ObservableCollection<RecurringSalesLineModel> _ListGrid_Temp;
            if (ProductGrid == null)
            {
                _ListGrid_Temp = new ObservableCollection<RecurringSalesLineModel>();
            }
            else
            {
                _ListGrid_Temp = ProductGrid;
            }
            for (int i = n; i < n + 20; i++)
            {
                _ListGrid_Temp.Add(new RecurringSalesLineModel
                {
                    NO = i + 1
                });
            }


            ProductGrid = _ListGrid_Temp;
        }
        #endregion

        #region default
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
            //get { return (IModalService) }
            //get{return IModalService.NavigateTo(Window uc, BackNavigationEventHandler backFromDialog);}
            get { return (IModalService)Application.Current.MainWindow; }
        }
        #endregion 

    }
}
