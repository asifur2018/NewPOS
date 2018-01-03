using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounts_Pos.View.SalesOrder;
using Accounts_Pos.ViewModel;
using Accounts_Pos.ViewModel.SalesOrder;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using Accounts_Pos.Helpers;
using System.Collections.ObjectModel;
using Accounts_Pos.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace Accounts_Pos.ViewModel.SalesOrder
{
    class SalesOrderViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {

        public SalesOrderViewModel()
        {
            prepareItemLine();
            prepareVatLine();

            DeliveryToReadOnly = true;
            OrderTypeReadOnly = false;
            RefReadOnly = true;
            DateReadOnly = true;
            OrderTypeNameReadOnly = true;
            OverAllDiscReadOnly = true;
            OrderSalesPersonReadOnly = true;
            MarketCodeReadOnly = true;
            ProjectCodeReadOnly = true;
            ProductGridReadOnly = true;
        }

        #region ShowItemLine

        public ObservableCollection<SalesOrderItemLineModel> _ListGrid { get; set; }
        public ObservableCollection<SalesOrderItemLineModel> ListGrid
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

        private void prepareItemLine()
        {
            ObservableCollection<SalesOrderItemLineModel> _ListGrid_Temp = new ObservableCollection<SalesOrderItemLineModel>();

            for (int i = 0; i < 20; i++)
            {
                _ListGrid_Temp.Add(new SalesOrderItemLineModel
                    {
                        NO = i + 1,
                    });
            }


            ListGrid = _ListGrid_Temp;
        }

        #endregion

        #region StatusBarProperties
        public string _StatusMessage { get; set; }
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

        public string _LastRecord { get; set; }
        public string LastRecord
        {
            get
            {
                return _LastRecord;
            }
            set
            {
                this._LastRecord = value;
            }
        }
       
        #endregion

        #region DataBinding
        public string _CustomerCode { get; set; }
        public string CustomerCode
        {
            get
            {
                return _CustomerCode;
            }
            set
            {
                this._CustomerCode = value;
            }
        }

        public string _OrderNo { get; set; }
        public string OrderNo
        {
            get
            {
                return _OrderNo;
            }
            set
            {
                this._OrderNo = value;
            }
        }

        public CustomerModel _SelectedCustomer { get; set; }
        public CustomerModel SelectedCustomer 
        {
            get
            {
                return _SelectedCustomer;
            }
            set
            {
                this._SelectedCustomer = value;
            }
        }


        public SalesOrderModel _SelectedSalesOrder { get; set; }
        public SalesOrderModel SelectedSalesOrder
        {
            get
            {
                return _SelectedSalesOrder;
            }
            set
            {
                this._SelectedSalesOrder = value;
            }
        }

        #endregion

        #region CommandBinding
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

        private ICommand _OrderClick { get; set; }
        public ICommand OrderClick
        {
            get
            {
                if (_OrderClick == null)
                {
                    _OrderClick = new DelegateCommand(OrderClickMethod);
                }
                return _OrderClick;
            }

        }
        public void OrderClickMethod()
        {
            StatusMessage = "Enter the Order Number to recall or leave blank for a new order";
            NotifyPropertyChanged("StatusMessage");
        }

        private ICommand _InvoiceLostFocusCommand { get; set; }
        public ICommand InvoiceLostFocusCommand
        {
            get
            {
                if (_InvoiceLostFocusCommand == null)
                {
                    _InvoiceLostFocusCommand = new DelegateCommand(InvoiceLostFocusCommandMethod);
                }
                return _InvoiceLostFocusCommand;
            }

        }
        public async void InvoiceLostFocusCommandMethod()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/CustomerAPI/GetCustomer/?_CustomerCode="+CustomerCode ).Result;

                if (response.IsSuccessStatusCode)
                {
                    CustomerModel data = JsonConvert.DeserializeObject<CustomerModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    if (data == null)
                    {
                        MessageBox.Show("Customer Code is Invalid");
                    }

                }

                
            }
            catch (Exception ex)
            {
                throw;
            }

           
        }
        #endregion

        #region readOnlyProperty

        public bool _DeliveryToReadOnly { get; set; }
        public bool DeliveryToReadOnly
        {
            get
            {
                return _DeliveryToReadOnly;
            }
            set
            {
                this._DeliveryToReadOnly = value;
            }
        }

        public bool _OrderTypeReadOnly { get; set; }
        public bool OrderTypeReadOnly
        {
            get
            {
                return _OrderTypeReadOnly;
            }
            set
            {
                this._OrderTypeReadOnly = value;
            }
        }

        public bool _RefReadOnly { get; set; }
        public bool RefReadOnly
        {
            get
            {
                return _RefReadOnly;
            }
            set
            {
                this._RefReadOnly = value;
            }
        }

        public bool _DateReadOnly { get; set; }
        public bool DateReadOnly
        {
            get
            {
                return _DateReadOnly;
            }
            set
            {
                this._DateReadOnly = value;
            }
        }

        public bool _OrderTypeNameReadOnly { get; set; }
        public bool OrderTypeNameReadOnly
        {
            get
            {
                return _OrderTypeNameReadOnly;
            }
            set
            {
                this._OrderTypeNameReadOnly = value;
            }
        }

        public bool _OverAllDiscReadOnly { get; set; }
        public bool OverAllDiscReadOnly
        {
            get
            {
                return _OverAllDiscReadOnly;
            }
            set
            {
                this._OverAllDiscReadOnly = value;
            }
        }

        public bool _OrderSalesPersonReadOnly { get; set; }
        public bool OrderSalesPersonReadOnly
        {
            get
            {
                return _OrderSalesPersonReadOnly;
            }
            set
            {
                this._OrderSalesPersonReadOnly = value;
            }
        }

        public bool _MarketCodeReadOnly { get; set; }
        public bool MarketCodeReadOnly
        {
            get
            {
                return _MarketCodeReadOnly;
            }
            set
            {
                this._MarketCodeReadOnly = value;
            }
        }

        public bool _ProjectCodeReadOnly { get; set; }
        public bool ProjectCodeReadOnly
        {
            get
            {
                return _ProjectCodeReadOnly;
            }
            set
            {
                this._ProjectCodeReadOnly = value;
            }
        }

        public bool _ProductGridReadOnly { get; set; }
        public bool ProductGridReadOnly
        {
            get
            {
                return _ProductGridReadOnly;
            }
            set
            {
                this._ProductGridReadOnly = value;
            }
        }
        #endregion

        #region ShowVatLine

        public ObservableCollection<SalesOrderVATLineModel> _VatListGrid { get; set; }
        public ObservableCollection<SalesOrderVATLineModel> VatListGrid
        {
            get
            {
                return _VatListGrid;
            }
            set
            {
                this._VatListGrid = value;
                OnPropertyChanged("VatListGrid");
            }
        }

        private void prepareVatLine()
        {
            ObservableCollection<SalesOrderVATLineModel> _ListGrid_Temp = new ObservableCollection<SalesOrderVATLineModel>();
            _ListGrid_Temp.Add(new SalesOrderVATLineModel
            {
                NO =  1,
                VAT_RATE = 20,
                DESCRIPTION = "VAT Standard Rate",
                NET_AMOUNT = 0,
                VAT_AMOUNT = 0,
                TOTAL = 0
            });

            _ListGrid_Temp.Add(new SalesOrderVATLineModel
            {
                NO = 2,
                VAT_RATE = 8,
                DESCRIPTION = "VAT Lower Rate",
                NET_AMOUNT = 0,
                VAT_AMOUNT = 0,
                TOTAL = 0
            });

            _ListGrid_Temp.Add(new SalesOrderVATLineModel
            {
                NO = 3,
                VAT_RATE = 0,
                DESCRIPTION = "VAT Zero Rate",
                NET_AMOUNT = 0,
                VAT_AMOUNT = 0,
                TOTAL = 0
            });

            _ListGrid_Temp.Add(new SalesOrderVATLineModel
            {
                NO = 4,
                VAT_RATE = 0,
                DESCRIPTION = "VAT Exempt",
                NET_AMOUNT = 0,
                VAT_AMOUNT = 0,
                TOTAL = 0
            });

            _ListGrid_Temp.Add(new SalesOrderVATLineModel
            {
                NO = 5,
                VAT_RATE = 0,
                DESCRIPTION = "Outside Scope",
                NET_AMOUNT = 0,
                VAT_AMOUNT = 0,
                TOTAL = 0
            });

            VatListGrid = _ListGrid_Temp;
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
        #endregion
    }
}
