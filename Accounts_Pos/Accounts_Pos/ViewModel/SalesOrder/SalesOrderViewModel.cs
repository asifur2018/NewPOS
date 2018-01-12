using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounts_Pos.View.SalesOrder;
using Accounts_Pos.ViewModel;
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
using System.Threading;
using System.Globalization;


namespace Accounts_Pos.ViewModel.SalesOrder
{
    class SalesOrderViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {

        public SalesOrderViewModel()
        {
            
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
            if (SelectedSalesOrder == null)
            {
                SelectedSalesOrder = new SalesOrderModel();
                SelectedSalesOrder.ORDER_NO = DateTime.Now.ToString("yyMMddHHmmssff");
            }

            SelectedSalesOrderCustomerDeliveryTo = new SalesOrderCustomerDeliveryToModel();
            SelectedSalesOrderCustomerInvoiceTo = new SalesOrderCustomerInvoiceToModel();
            SelectedSalesOrderCustomerOtherDetails = new SalesOrderCustomerOtherDetailsModel();
            SelectedSalesOrderCustomerRecurringSalesInvoice = new SalesOrderCustomerRecurringSalesInvoiceModel();
            SelectedSalesOrderCustomerRecurringSalesLines = new SalesOrderCustomerRecurringSalesLinesModel();
            SelectedSalesOrderDelivery = new SalesOrderDeliveryModel();
            SelectedSalesOrderVATLine = new SalesOrderVATLineModel();
            SelectedSalesOrderLineItem = new SalesOrderLineItemModel();
            SelectedSalesOrderCreditInformation = new SalesOrderCreditInformationModel();
            SelectedSalesOrderCustomer = new SalesOrderCustomerModel();
            SelectedSalesOrderContactsInformation = new SalesOrderContactsInformationModel();
            GridColor = "#f9f9f9";
            ItemLineEditability = true;
            prepareItemLine(0);
            prepareVatLine();
        }

        #region ShowItemLine

        public ObservableCollection<SalesOrderLineItemModel> _ListGrid { get; set; }
        public ObservableCollection<SalesOrderLineItemModel> ListGrid
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

        public ObservableCollection<SalesOrderModel> _SalesOrderList { get; set; }
        public ObservableCollection<SalesOrderModel> SalesOrderList
        {
            get
            {
                return _SalesOrderList;
            }
            set
            {
                this._SalesOrderList = value;
                OnPropertyChanged("SalesOrderList");
            }
        }

        public async Task<SalesOrderCustomerDeliveryToModel> GetSalesOrderCustomerDeliveryTo(string orderNo)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/SalesOrderAPI/GetSalesOrderCustomerDeliveryTo?OrderNo=" + orderNo ).Result;
                SalesOrderCustomerDeliveryToModel data;

                if (response.IsSuccessStatusCode)
                {
                     data = JsonConvert.DeserializeObject<SalesOrderCustomerDeliveryToModel>(await response.Content.ReadAsStringAsync());
                     SelectedSalesOrderCustomerDeliveryTo = data;
                     return data;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SalesOrderCustomerInvoiceToModel> GetSalesOrderCustomerInvoiceTo(string orderNo)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/SalesOrderAPI/GetSalesOrderCustomerInvoiceTo?OrderNo=" + orderNo + "").Result;
                SalesOrderCustomerInvoiceToModel data;

                if (response.IsSuccessStatusCode)
                {
                     data = JsonConvert.DeserializeObject<SalesOrderCustomerInvoiceToModel>(await response.Content.ReadAsStringAsync());
                     SelectedSalesOrderCustomerInvoiceTo = data;
                     return data;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SalesOrderCustomerOtherDetailsModel> GetSalesOrderCustomerOtherDetails(string orderNo)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/SalesOrderAPI/GetSalesOrderCustomerOtherDetails?OrderNo=" + orderNo + "").Result;
                SalesOrderCustomerOtherDetailsModel data;

                if (response.IsSuccessStatusCode)
                {
                    data = JsonConvert.DeserializeObject<SalesOrderCustomerOtherDetailsModel>(await response.Content.ReadAsStringAsync());
                    SelectedSalesOrderCustomerOtherDetails = data;
                    return data;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<ObservableCollection<SalesOrderModel>> GetSalesOrderList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/SalesOrderAPI/GetSalesOrderList/").Result;

                ObservableCollection<SalesOrderModel> _ListGrid_Temp = new ObservableCollection<SalesOrderModel>();

                if (response.IsSuccessStatusCode)
                {
                    SalesOrderModel[] data = JsonConvert.DeserializeObject<SalesOrderModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new SalesOrderModel
                        {

                            SALESORDER_ID = data[i].SALESORDER_ID,
                            INVOICE_TO = data[i].INVOICE_TO,
                            DELIVERY_TO = data[i].DELIVERY_TO,
                            ORDER_NO = data[i].ORDER_NO,
                            ORDER_REF = data[i].ORDER_REF,
                            ORDER_DATE = data[i].ORDER_DATE,
                            SALES_PERSON = data[i].SALES_PERSON,
                            MARKET_CODE = data[i].MARKET_CODE,
                            OVERALL_DISC_PER = data[i].OVERALL_DISC_PER,
                            ORDER_VALUE = data[i].ORDER_VALUE,
                            STANDARD_DISCOUNT = data[i].STANDARD_DISCOUNT,
                            TOTAL_VAT = data[i].TOTAL_VAT,
                            TOTAL_ORDER_VALUE = data[i].TOTAL_ORDER_VALUE,
                            COST = data[i].COST,
                            MARGIN = data[i].MARGIN.ToString(),
                            MARGIN_PERCENT = data[i].MARGIN_PERCENT.ToString(),
                            NET_VALUE = data[i].NET_VALUE

                        });
                    }

                }

                SalesOrderList = _ListGrid_Temp;
                return new ObservableCollection<SalesOrderModel>(_ListGrid_Temp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ObservableCollection<SalesOrderLineItemModel>> GetSalesOrderItemLineList(string orderNo)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/SalesOrderAPI/GetSalesOrderLineItem?OrderNo=" + orderNo + "").Result;

                ObservableCollection<SalesOrderLineItemModel> _ListGrid_Temp = new ObservableCollection<SalesOrderLineItemModel>();

                if (response.IsSuccessStatusCode)
                {
                    SalesOrderLineItemModel[] data = JsonConvert.DeserializeObject<SalesOrderLineItemModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new SalesOrderLineItemModel
                        {

                            NO = i+1,
                            ORDER_NO = data[i].ORDER_NO,
                            PRODUCT_CODE = data[i].PRODUCT_CODE,
                            DESCRIPTION = data[i].DESCRIPTION,
                            ORDER_QTY = data[i].ORDER_QTY,
                            UNIT_PRICE = data[i].UNIT_PRICE,
                            DISCOUNT = data[i].DISCOUNT,
                            LINE_AMOUNT = data[i].LINE_AMOUNT,
                            VAT = data[i].VAT
                        });
                    }

                    if (data.Length < 20)
                    {
                        for (int i = data.Length; i < 20; i++)
                        {
                            _ListGrid_Temp.Add(new SalesOrderLineItemModel
                            {
                                NO = i + 1,
                                ORDER_NO = SelectedSalesOrder.ORDER_NO
                            });
                        }
                    }
                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<SalesOrderLineItemModel>(_ListGrid_Temp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void prepareItemLine(int n)
        {
             ObservableCollection<SalesOrderLineItemModel> _ListGrid_Temp;
             if (ListGrid == null)
             {
                 _ListGrid_Temp = new ObservableCollection<SalesOrderLineItemModel>();
             }
             else
             {
                 _ListGrid_Temp = ListGrid;
             }
            for (int i = n; i < n+20; i++)
            {
                _ListGrid_Temp.Add(new SalesOrderLineItemModel
                    {
                        NO = i + 1,
                        ORDER_NO = SelectedSalesOrder.ORDER_NO
                    });
            }


            ListGrid = _ListGrid_Temp;
        }

        public async Task<ObservableCollection<SalesOrderVATLineModel>> GetSalesOrderVATLineList(string orderNo)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/SalesOrderAPI/GetSalesOrderVATLine?OrderNo=" + orderNo + "").Result;

                ObservableCollection<SalesOrderVATLineModel> _ListGrid_Temp = new ObservableCollection<SalesOrderVATLineModel>();

                if (response.IsSuccessStatusCode)
                {
                    SalesOrderVATLineModel[] data = JsonConvert.DeserializeObject<SalesOrderVATLineModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new SalesOrderVATLineModel
                        {

                            NO = i+1,
                            ORDER_NO = data[i].ORDER_NO,
                            VAT_RATE = data[i].VAT_RATE,
                            DESCRIPTION = data[i].DESCRIPTION,
                            NET_AMOUNT = data[i].NET_AMOUNT,
                            VAT_AMOUNT = data[i].VAT_AMOUNT,
                            TOTAL = data[i].TOTAL
                        });
                    }

                    
                }

                VatListGrid = _ListGrid_Temp;
                return new ObservableCollection<SalesOrderVATLineModel>(_ListGrid_Temp);
            }
            catch (Exception ex)
            {
                throw;
            }
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
        public int _LINE_ITEM_ID { get; set; }
        public int LINE_ITEM_ID
        {
            get
            {
                return _LINE_ITEM_ID;
            }
            set
            {
                this._LINE_ITEM_ID = value;
                RaisePropertyChanged("LINE_ITEM_ID");
            }
        }

        public string _PRODUCT_CODE { get; set; }
        public string PRODUCT_CODE
        {
            get
            {
                return _PRODUCT_CODE;
            }
            set
            {
                this._PRODUCT_CODE = value;
                NotifyPropertyChanged("PRODUCT_CODE");
            }
        }


        public string _DESCRIPTION { get; set; }
        public string DESCRIPTION
        {
            get
            {
                return _DESCRIPTION;
            }
            set
            {
                this._DESCRIPTION = value;
                NotifyPropertyChanged("DESCRIPTION");
            }
        }

        public decimal? _ORDER_QTY { get; set; }
        public decimal? ORDER_QTY
        {
            get
            {
                return _ORDER_QTY;
            }
            set
            {
                this._ORDER_QTY = value;
                NotifyPropertyChanged("ORDER_QTY");
            }
        }

        public decimal? _UNIT_PRICE { get; set; }
        public decimal? UNIT_PRICE
        {
            get
            {
                return _UNIT_PRICE;
            }
            set
            {
                this._UNIT_PRICE = value;
                NotifyPropertyChanged("UNIT_PRICE");
            }
        }

        public decimal? _DISCOUNT { get; set; }
        public decimal? DISCOUNT
        {
            get
            {
                return _DISCOUNT;
            }
            set
            {
                this._DISCOUNT = value;
                NotifyPropertyChanged("DISCOUNT");
            }
        }

        public int _VAT { get; set; }
        public int VAT
        {
            get
            {
                return _VAT;
            }
            set
            {
                this._VAT = value;
                NotifyPropertyChanged("VAT");
            }
        }

        public decimal? _LINE_AMOUNT { get; set; }
        public decimal? LINE_AMOUNT
        {
            get
            {
                return _LINE_AMOUNT;
            }
            set
            {
                this._LINE_AMOUNT = value;
                NotifyPropertyChanged("LINE_AMOUNT");
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

        public string _SalesPersonDescription { get; set; }
        public string SalesPersonDescription
        {
            get
            {
                return _SalesPersonDescription;
            }
            set
            {
                this._SalesPersonDescription = value;
                NotifyPropertyChanged("SalesPersonDescription");
            }
        }

        public string _MarketCodeDescription { get; set; }
        public string MarketCodeDescription
        {
            get
            {
                return _MarketCodeDescription;
            }
            set
            {
                this._MarketCodeDescription = value;
                NotifyPropertyChanged("MarketCodeDescription");
            }
        }

        public SalesOrderCreditInformationModel _SelectedSalesOrderCreditInformation { get; set; }
        public SalesOrderCreditInformationModel SelectedSalesOrderCreditInformation
        {
            get
            {
                return _SelectedSalesOrderCreditInformation;
            }
            set
            {
                this._SelectedSalesOrderCreditInformation = value;
                NotifyPropertyChanged("SelectedSalesOrderCreditInformation");
            }
        }

        public SalesOrderCustomerModel _SelectedSalesOrderCustomer { get; set; }
        public SalesOrderCustomerModel SelectedSalesOrderCustomer
        {
            get
            {
                return _SelectedSalesOrderCustomer;
            }
            set
            {
                this._SelectedSalesOrderCustomer = value;
                NotifyPropertyChanged("SelectedSalesOrderCustomer");
            }
        }

        public SalesOrderContactsInformationModel _SelectedSalesOrderContactsInformation { get; set; }
        public SalesOrderContactsInformationModel SelectedSalesOrderContactsInformation
        {
            get
            {
                return _SelectedSalesOrderContactsInformation;
            }
            set
            {
                this._SelectedSalesOrderContactsInformation = value;
                NotifyPropertyChanged("SelectedSalesOrderContactsInformation");
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
                NotifyPropertyChanged("SelectedCustomer");
            }
        }

        public CustomerBankDetailsModel _SelectedCustomerBankDetails { get; set; }
        public CustomerBankDetailsModel SelectedCustomerBankDetails
        {
            get
            {
                return _SelectedCustomerBankDetails;
            }
            set
            {
                this._SelectedCustomerBankDetails = value;
                NotifyPropertyChanged("SelectedCustomerBankDetails");
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
                NotifyPropertyChanged("SelectedSalesOrder");
            }
        }

        public SalesOrderModel _SelectedSalesOrderForEdit { get; set; }
        public SalesOrderModel SelectedSalesOrderForEdit
        {
            get
            {
                return _SelectedSalesOrderForEdit;
            }
            set
            {
                this._SelectedSalesOrderForEdit = value;
                NotifyPropertyChanged("SelectedSalesOrderForEdit");
            }
        }

        public SalesOrderCustomerDeliveryToModel _SelectedSalesOrderCustomerDeliveryTo { get; set; }
        public SalesOrderCustomerDeliveryToModel SelectedSalesOrderCustomerDeliveryTo
        {
            get
            {
                return _SelectedSalesOrderCustomerDeliveryTo;
            }
            set
            {
                this._SelectedSalesOrderCustomerDeliveryTo = value;
                NotifyPropertyChanged("SelectedSalesOrderCustomerDeliveryTo");
            }
        }

        public SalesOrderCustomerInvoiceToModel _SelectedSalesOrderCustomerInvoiceTo { get; set; }
        public SalesOrderCustomerInvoiceToModel SelectedSalesOrderCustomerInvoiceTo
        {
            get
            {
                return _SelectedSalesOrderCustomerInvoiceTo;
            }
            set
            {
                this._SelectedSalesOrderCustomerInvoiceTo = value;
                NotifyPropertyChanged("SelectedSalesOrderCustomerInvoiceTo");
            }
        }

        public SalesOrderCustomerOtherDetailsModel _SelectedSalesOrderCustomerOtherDetails { get; set; }
        public SalesOrderCustomerOtherDetailsModel SelectedSalesOrderCustomerOtherDetails
        {
            get
            {
                return _SelectedSalesOrderCustomerOtherDetails;
            }
            set
            {
                this._SelectedSalesOrderCustomerOtherDetails = value;
                NotifyPropertyChanged("SelectedSalesOrderCustomerOtherDetails");
            }
        }


        public SalesOrderCustomerRecurringSalesInvoiceModel _SelectedSalesOrderCustomerRecurringSalesInvoice { get; set; }
        public SalesOrderCustomerRecurringSalesInvoiceModel SelectedSalesOrderCustomerRecurringSalesInvoice
        {
            get
            {
                return _SelectedSalesOrderCustomerRecurringSalesInvoice;
            }
            set
            {
                this._SelectedSalesOrderCustomerRecurringSalesInvoice = value;
                NotifyPropertyChanged("SelectedSalesOrderCustomerRecurringSalesInvoice");
            }
        }

        public SalesOrderCustomerRecurringSalesLinesModel _SelectedSalesOrderCustomerRecurringSalesLines { get; set; }
        public SalesOrderCustomerRecurringSalesLinesModel SelectedSalesOrderCustomerRecurringSalesLines
        {
            get
            {
                return _SelectedSalesOrderCustomerRecurringSalesLines;
            }
            set
            {
                this._SelectedSalesOrderCustomerRecurringSalesLines = value;
                NotifyPropertyChanged("SelectedSalesOrderCustomerRecurringSalesLines");
            }
        }

        public SalesOrderDeliveryModel _SelectedSalesOrderDelivery { get; set; }
        public SalesOrderDeliveryModel SelectedSalesOrderDelivery
        {
            get
            {
                return _SelectedSalesOrderDelivery;
            }
            set
            {
                this._SelectedSalesOrderDelivery = value;
                NotifyPropertyChanged("SelectedSalesOrderDelivery");
            }
        }

        
        public SalesOrderLineItemModel _SelectedSalesOrderLineItem { get; set; }
        public SalesOrderLineItemModel SelectedSalesOrderLineItem
        {
            get
            {
                return _SelectedSalesOrderLineItem;
            }
            set
            {
                this._SelectedSalesOrderLineItem = value;
                NotifyPropertyChanged("SelectedSalesOrderLineItem");
            }
        }

        public SalesOrderVATLineModel _SelectedSalesOrderVATLine { get; set; }
        public SalesOrderVATLineModel SelectedSalesOrderVATLine
        {
            get
            {
                return _SelectedSalesOrderVATLine;
            }
            set
            {
                this._SelectedSalesOrderVATLine = value;
                NotifyPropertyChanged("SelectedSalesOrderVATLine");
            }
        }

        public string _OrderType { get; set; }
        public string OrderType
        {
            get
            {
                return _OrderType;
            }
            set
            {
                this._OrderType = value;
                NotifyPropertyChanged("OrderType");
            }
        }
        public string _GridColor { get; set; }
        public string GridColor
        {
            get
            {
                return _GridColor;
            }
            set
            {
                this._GridColor = value;
                NotifyPropertyChanged("GridColor");
            }
        }

        public int _SelectedTabIndex { get; set; }
        public int SelectedTabIndex
        {
            get
            {
                return _SelectedTabIndex;
            }
            set
            {
                this._SelectedTabIndex = value;
                NotifyPropertyChanged("SelectedTabIndex");
            }
        }

        
        #endregion

        #region CommandBinding

        private ICommand _Select { get; set; }
        public ICommand Select
        {
            get
            {
                if (_Select == null)
                {
                    _Select = new DelegateCommand(Select_Click);
                }
                return _Select;
            }

        }

        public void Select_Click()
        {
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "SalesOrderWindow" || w.Name == "SalesOrderLookupWindow");
            if (win != null)
            {
                win.Close();
            }
            ((SalesOrderEnquiryForm)Application.Current.Windows[0]).SalesOrderTxt.Text = SelectedSalesOrder.ORDER_NO;
            ((SalesOrderEnquiryViewModel)Application.Current.Windows[0].DataContext).SelectedSalesOrder = SelectedSalesOrder;
            ((SalesOrderEnquiryForm)Application.Current.Windows[0]).CustomerCodeTxt.Text = SelectedSalesOrder.INVOICE_TO;
            GetCustomerForSalesOrder(SelectedSalesOrder.INVOICE_TO);
            ((SalesOrderEnquiryForm)Application.Current.Windows[0]).CustomerNameTxt.Text = SelectedCustomer.CUSTOMER_NAME;
        }

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
            Accounts_Pos.View.SalesOrder.SalesOrder salesOrderView = new Accounts_Pos.View.SalesOrder.SalesOrder();
            salesOrderView.Show();
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
            //refresh grid
            GetSalesOrderList();
            NotifyPropertyChanged("SalesOrderList");
            //close window
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "SalesOrderWindow" || w.Name == "SalesOrderLookupWindow");
            if (win != null)
            {
                win.Close();
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
            if (SelectedSalesOrder == null) 
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                Accounts_Pos.View.SalesOrder.SalesOrder _SO = new Accounts_Pos.View.SalesOrder.SalesOrder();
                
                GetSalesOrderCustomerDeliveryTo(SelectedSalesOrder.ORDER_NO);
                GetSalesOrderCustomerInvoiceTo(SelectedSalesOrder.ORDER_NO);
                GetSalesOrderCustomerOtherDetails(SelectedSalesOrder.ORDER_NO);
                GetSalesOrderItemLineList(SelectedSalesOrder.ORDER_NO);
                GetSalesOrderVATLineList(SelectedSalesOrder.ORDER_NO);
                GetCustomerForSalesOrder(SelectedSalesOrder.INVOICE_TO);
                GetCustomerBankDetailsForSalesOrder(SelectedSalesOrder.INVOICE_TO);
                this.OrderTypeReadOnly = true;
                this.OrderType = "Sales Order";
                this.ItemLineEditability = false;
                this.DateReadOnly = true;
                //from lostfocus


                DeliveryToReadOnly = false;
                OrderTypeReadOnly = true;
                RefReadOnly = false;
                OrderTypeNameReadOnly = false;
                OverAllDiscReadOnly = false;
                OrderSalesPersonReadOnly = false;
                MarketCodeReadOnly = false;
                ProjectCodeReadOnly = false;

                SelectedSalesOrderContactsInformation.TYPE = SelectedCustomer.CONTACT_TYPE;
                SelectedSalesOrderContactsInformation.NAME = SelectedCustomer.CONTACT_NAME;
                SelectedSalesOrderContactsInformation.SALUT = SelectedCustomer.CONTACT_SALUTATION;
                SelectedSalesOrderContactsInformation.TEL_NO = SelectedCustomer.CONTACT_PHONE_NO;
                SelectedSalesOrderContactsInformation.FAX = SelectedCustomer.CONTACT_FAX;
                SelectedSalesOrderContactsInformation.EXTENSION = SelectedCustomer.CONTACT_EXTN_NO;
                SelectedSalesOrderContactsInformation.MOBILE = SelectedCustomer.CONTACT_MOBILE_NO;
                SelectedSalesOrderContactsInformation.EMAIL = SelectedCustomer.EMAIL;
                NotifyPropertyChanged("SelectedSalesOrderContactsInformation");

                SelectedSalesOrderCreditInformation.CREDIT_LIMIT = SelectedCustomer.CREDIT_LIMIT;
                SelectedSalesOrderCreditInformation.OS_BALANCE = SelectedCustomer.OS_BALANCE;
                SelectedSalesOrderCreditInformation.OS_ORDERS = SelectedCustomer.OS_ORDERS;
                SelectedSalesOrderCreditInformation.CREDIT = SelectedCustomer.CR_REMAIN;
                if (SelectedCustomer.ON_CREDIT_STOP == true)
                {
                    SelectedSalesOrderCreditInformation.CREDIT_STOP = "Yes";
                }
                else
                {
                    SelectedSalesOrderCreditInformation.CREDIT_STOP = "No";
                }
                SelectedSalesOrderCreditInformation.STOPPED_BY = SelectedCustomer.PUT_ON_STOP_BY;
                SelectedSalesOrderCreditInformation.STOP_DATE = SelectedCustomer.STOPPED_ON.ToString();
                NotifyPropertyChanged("SelectedSalesOrderCreditInformation");

                if (SelectedCustomer.DATES_STARTED != null)
                {
                    SelectedSalesOrderCustomer.DATE_STARTED = ((DateTime)SelectedCustomer.DATES_STARTED).ToString("d");
                }
                if (SelectedCustomer.OLDEST_INV_DATE != null)
                {
                    SelectedSalesOrderCustomer.OLD_INV_DATE = ((DateTime)SelectedCustomer.OLDEST_INV_DATE).ToString("d");
                }
                if (SelectedCustomer.LAST_SALE != null)
                {
                    SelectedSalesOrderCustomer.LAST_SALE = ((DateTime)SelectedCustomer.LAST_SALE).ToString("d");
                }
                if (SelectedCustomer.LAST_PAYMENT != null)
                {
                    SelectedSalesOrderCustomer.LAST_PMT = ((DateTime)SelectedCustomer.LAST_PAYMENT).ToString("d");
                }
                SelectedSalesOrderCustomer.AVG_PMT_DAYS = SelectedCustomer.AVG_PMT_DAYS;
                NotifyPropertyChanged("SelectedSalesOrderCustomer");


                
                //////////////

                _SO.DataContext = this;
                _SO.ShowDialog();
            }
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
            if (String.IsNullOrEmpty(SelectedSalesOrder.INVOICE_TO))
            {
                ItemLineEditability = true;
            }
            else if (String.IsNullOrEmpty(ListGrid[SelectedProductIndex].PRODUCT_CODE))
            {
                if ((SelectedProductIndex > 0) && (String.IsNullOrEmpty(ListGrid[SelectedProductIndex - 1].PRODUCT_CODE)))
                {
                    ItemLineEditability = true;
                }
                else if ((SelectedProductIndex > 0)
                    && (!String.IsNullOrEmpty(ListGrid[SelectedProductIndex - 1].PRODUCT_CODE))
                    && (ListGrid[SelectedProductIndex - 1].LINE_AMOUNT == 0))
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

            if ((ListGrid.Count == SelectedSalesOrderLineItem.NO) && ((SelectedSalesOrderLineItem.NO % 20) == 0))
            {
                prepareItemLine(SelectedSalesOrderLineItem.NO);
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
            if (String.IsNullOrEmpty(ListGrid[SelectedProductIndex].PRODUCT_CODE))
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
            if (String.IsNullOrEmpty(ListGrid[SelectedProductIndex].PRODUCT_CODE))
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
            if (String.IsNullOrEmpty(ListGrid[SelectedProductIndex].PRODUCT_CODE))
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
            if (String.IsNullOrEmpty(ListGrid[SelectedProductIndex].PRODUCT_CODE))
            {
                ItemLineEditability = true;
            }
            else
            {
                ItemLineEditability = false;
            }
        }


        private ICommand _SelectProductVATCommand { get; set; }
        public ICommand SelectProductVATCommand
        {
            get
            {
                if (_SelectProductVATCommand == null)
                {
                    _SelectProductVATCommand = new DelegateCommand(SelectProductVATCommandMethod);
                }
                return _SelectProductVATCommand;

            }

        }
        public void SelectProductVATCommandMethod()
        {
            if (String.IsNullOrEmpty(ListGrid[SelectedProductIndex].PRODUCT_CODE))
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

        private ICommand _ProductAmountTextChangedCommand { get; set; }
        public ICommand ProductAmountTextChangedCommand
        {
            get
            {
                if (_ProductAmountTextChangedCommand == null)
                {
                    _ProductAmountTextChangedCommand = new DelegateCommand(ProductAmountTextChangedCommandMethod);
                }
                return _ProductAmountTextChangedCommand;

            }

        }
        public void ProductAmountTextChangedCommandMethod()
        {
            if ((SelectedSalesOrderLineItem.VAT < 1) || (SelectedSalesOrderLineItem.VAT > 5))
            {
                MessageBox.Show("Invalid Vat Rate");
                SelectedSalesOrderLineItem.VAT = 1;
            }
            
            prepareVatLine();
        }



        private ICommand _OrderTypeChange { get; set; }
        public ICommand OrderTypeChange
        {
            get
            {
                if (_OrderTypeChange == null)
                {
                    _OrderTypeChange = new DelegateCommand(_OrderTypeChangeMethod);
                }
                return _OrderTypeChange;

            }

        }
        public void _OrderTypeChangeMethod()
        {
            if (OrderType == "Credit Order")
            {
                GridColor = "#f9e6e0";
            }
            else
            {
                GridColor = "#f9f9f9";
            }
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

        public async void GetCustomerForSalesOrder(string CODE)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/CustomerAPI/GetCustomer?_CustomerCode=" + CODE).Result;

                if (response.IsSuccessStatusCode)
                {
                    SelectedCustomer = JsonConvert.DeserializeObject<CustomerModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                }
            }
            catch
            {
            }
        }

        public async void GetCustomerBankDetailsForSalesOrder(string CODE)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/CustomerAPI/GetCustomerBankDetails/?_CustomerCode=" + CODE).Result;

                if (response.IsSuccessStatusCode)
                {
                    SelectedCustomerBankDetails = JsonConvert.DeserializeObject<CustomerBankDetailsModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                }
            }
            catch
            {
            }
        }


        public async void InvoiceLostFocusCommandMethod()
        {
            if (!String.IsNullOrEmpty(SelectedSalesOrder.INVOICE_TO))
             {
                 try
                 {
                     HttpClient client = new HttpClient();
                     client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                     client.DefaultRequestHeaders.Accept.Add(
                         new MediaTypeWithQualityHeaderValue("application/json"));
                     var response = client.GetAsync("api/CustomerAPI/GetCustomer/?_CustomerCode=" + SelectedSalesOrder.INVOICE_TO).Result;

                     if (response.IsSuccessStatusCode)
                     {
                         CustomerModel data = JsonConvert.DeserializeObject<CustomerModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                         if (data == null)
                         {
                             MessageBox.Show("Customer Code is Invalid");
                             SelectedSalesOrder.INVOICE_TO = "";
                             NotifyPropertyChanged("SelectedSalesOrder");
                         }
                         else
                         {
                             SelectedCustomer = data;
                             DeliveryToReadOnly = false;
                             OrderTypeReadOnly = true;
                             RefReadOnly = false;
                             DateReadOnly = false;
                             OrderTypeNameReadOnly = false;
                             OverAllDiscReadOnly = false;
                             OrderSalesPersonReadOnly = false;
                             MarketCodeReadOnly = false;
                             ProjectCodeReadOnly = false;
                             SelectedSalesOrder.MARKET_CODE = "DEFAULT";
                             MarketCodeDescription = "Default Marketing Code";
                             SelectedSalesOrder.SALES_PERSON = "DEF";
                             SalesPersonDescription = "Default SalesPerson";

                             Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                             //SelectedSalesOrder.ORDER_DATE = DateTime.Now;
                             SelectedSalesOrder.ORDER_DATE = DateTime.Now.Date;
                             SelectedSalesOrder.ORDER_VALUE = 0;
                             SelectedSalesOrder.COST = "*N/A*";
                             SelectedSalesOrder.MARGIN = "*N/A*";
                             SelectedSalesOrder.MARGIN_PERCENT = "*N/A*";
                             SelectedSalesOrder.NET_VALUE = 0;
                             SelectedSalesOrder.TOTAL_VAT = 0;
                             SelectedSalesOrder.STANDARD_DISCOUNT = 0;
                             SelectedSalesOrder.TOTAL_ORDER_VALUE = 0;
                             //SelectedSalesOrder.ORDER_NO = DateTime.Now.ToString("yyMMddHHmmssff");

                             NotifyPropertyChanged("SelectedSalesOrder");
                             SelectedSalesOrderCustomerDeliveryTo.ORDER_NO = SelectedSalesOrder.ORDER_NO;
                             SelectedSalesOrderCustomerDeliveryTo.NAME = SelectedCustomer.CUSTOMER_NAME;
                             SelectedSalesOrderCustomerDeliveryTo.ADDRESS = SelectedCustomer.ADDRESS;
                             SelectedSalesOrderCustomerDeliveryTo.POSTCODE = SelectedCustomer.POSTCODE;
                             SelectedSalesOrderCustomerDeliveryTo.COUNTRY = SelectedCustomer.COUNTRY;
                             SelectedSalesOrderCustomerDeliveryTo.CONTACT = SelectedCustomer.CONTACT_NAME;
                             NotifyPropertyChanged("SelectedSalesOrderCustomerDeliveryTo");

                             SelectedSalesOrderCustomerInvoiceTo.CODE = SelectedCustomer.CUSTOMER_CODE;
                             SelectedSalesOrderCustomerInvoiceTo.NAME = SelectedCustomer.CUSTOMER_NAME;
                             SelectedSalesOrderCustomerInvoiceTo.ADDRESS = SelectedCustomer.ADDRESS;
                             SelectedSalesOrderCustomerInvoiceTo.POSTCODE = SelectedCustomer.POSTCODE;
                             SelectedSalesOrderCustomerInvoiceTo.COUNTRY = SelectedCustomer.COUNTRY;
                             SelectedSalesOrderCustomerInvoiceTo.CONTACT = SelectedCustomer.CONTACT_NAME;
                             SelectedSalesOrderCustomerInvoiceTo.EC = "GB";
                             SelectedSalesOrderCustomerInvoiceTo.ORDER_NO = SelectedSalesOrder.ORDER_NO;
                             NotifyPropertyChanged("SelectedSalesOrderCustomerInvoiceTo");

                             SelectedSalesOrderContactsInformation.TYPE = SelectedCustomer.CONTACT_TYPE;
                             SelectedSalesOrderContactsInformation.NAME = SelectedCustomer.CONTACT_NAME;
                             SelectedSalesOrderContactsInformation.SALUT = SelectedCustomer.CONTACT_SALUTATION;
                             SelectedSalesOrderContactsInformation.TEL_NO = SelectedCustomer.CONTACT_PHONE_NO;
                             SelectedSalesOrderContactsInformation.FAX = SelectedCustomer.CONTACT_FAX;
                             SelectedSalesOrderContactsInformation.EXTENSION = SelectedCustomer.CONTACT_EXTN_NO;
                             SelectedSalesOrderContactsInformation.MOBILE = SelectedCustomer.CONTACT_MOBILE_NO;
                             SelectedSalesOrderContactsInformation.EMAIL = SelectedCustomer.EMAIL;
                             NotifyPropertyChanged("SelectedSalesOrderContactsInformation");

                             SelectedSalesOrderCreditInformation.CREDIT_LIMIT = SelectedCustomer.CREDIT_LIMIT;
                             SelectedSalesOrderCreditInformation.OS_BALANCE = SelectedCustomer.OS_BALANCE;
                             SelectedSalesOrderCreditInformation.OS_ORDERS = SelectedCustomer.OS_ORDERS;
                             SelectedSalesOrderCreditInformation.CREDIT = SelectedCustomer.CR_REMAIN;
                             if (SelectedCustomer.ON_CREDIT_STOP == true)
                             {
                                 SelectedSalesOrderCreditInformation.CREDIT_STOP = "Yes";
                             }
                             else
                             {
                                 SelectedSalesOrderCreditInformation.CREDIT_STOP = "No";
                             }
                             SelectedSalesOrderCreditInformation.STOPPED_BY = SelectedCustomer.PUT_ON_STOP_BY;
                             SelectedSalesOrderCreditInformation.STOP_DATE = SelectedCustomer.STOPPED_ON.ToString();
                             NotifyPropertyChanged("SelectedSalesOrderCreditInformation");

                             if (SelectedCustomer.DATES_STARTED != null)
                             {
                                 SelectedSalesOrderCustomer.DATE_STARTED = ((DateTime)SelectedCustomer.DATES_STARTED).ToString("d");
                             }
                             if (SelectedCustomer.OLDEST_INV_DATE != null)
                             {
                                 SelectedSalesOrderCustomer.OLD_INV_DATE = ((DateTime)SelectedCustomer.OLDEST_INV_DATE).ToString("d");
                             }
                             if (SelectedCustomer.LAST_SALE != null)
                             {
                                 SelectedSalesOrderCustomer.LAST_SALE = ((DateTime)SelectedCustomer.LAST_SALE).ToString("d");
                             }
                             if (SelectedCustomer.LAST_PAYMENT != null)
                             {
                                 SelectedSalesOrderCustomer.LAST_PMT = ((DateTime)SelectedCustomer.LAST_PAYMENT).ToString("d");
                             }
                             SelectedSalesOrderCustomer.AVG_PMT_DAYS = SelectedCustomer.AVG_PMT_DAYS;
                             NotifyPropertyChanged("SelectedSalesOrderCustomer");

                             response = client.GetAsync("api/CustomerAPI/GetCustomerBankDetails/?_CustomerCode=" + SelectedSalesOrder.INVOICE_TO).Result;
                             if (response.IsSuccessStatusCode)
                             {
                                 CustomerBankDetailsModel data1 = JsonConvert.DeserializeObject<CustomerBankDetailsModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                                 if (data1 != null)
                                 {
                                     SelectedCustomerBankDetails = data1;
                                 }
                             }

                             SelectedSalesOrderCustomerOtherDetails.NO_OF_COPIES = 1;
                             SelectedSalesOrderCustomerOtherDetails.STANDARD_DISC_PER = SelectedCustomerBankDetails.STANDARD_DISC_PER;
                             SelectedSalesOrderCustomerOtherDetails.STANDART_DISC_DAYS = SelectedCustomerBankDetails.STANDART_DISC_DAYS;
                             SelectedSalesOrderCustomerOtherDetails.LAST_CHANGE_SYSTEM_DATE = DateTime.Now.Date;
                             SelectedSalesOrderCustomerOtherDetails.DEL = "N/A - Not Applicable";
                             SelectedSalesOrderCustomerOtherDetails.MODE = "0-Not Applicable";
                             SelectedSalesOrderCustomerOtherDetails.ORDER_NO = SelectedSalesOrder.ORDER_NO;
                             //SelectedSalesOrderCustomerOtherDetails.EXPECTED_PAYMENT = SelectedSalesOrderCustomerOtherDetails.EXPECTED_SHIP + SelectedCustomer.AVG_PMT_DAYS;
                             NotifyPropertyChanged("SelectedSalesOrderCustomerOtherDetails");
                         }

                     }

                
                 }
                 catch (Exception ex)
                 {
                     throw;
                 }
             }


        }

        private ICommand _CustomerDetailsTabClick { get; set; }
        public ICommand CustomerDetailsTabClick
        {
            get
            {
                if (_CustomerDetailsTabClick == null)
                {
                    _CustomerDetailsTabClick = new DelegateCommand(CustomerDetailsTab_Click);
                }
                return _CustomerDetailsTabClick;
            }

        }
        public void CustomerDetailsTab_Click()
        {
           
            if(SelectedTabIndex == 1)
            {
                if (String.IsNullOrEmpty(SelectedSalesOrder.INVOICE_TO)
                || String.IsNullOrEmpty(OrderType)
                //|| String.IsNullOrEmpty(SelectedSalesOrder.ORDER_DATE)
                || (SelectedSalesOrder.ORDER_DATE == null)
                || String.IsNullOrEmpty(SelectedSalesOrder.SALES_PERSON)
                || String.IsNullOrEmpty(SelectedSalesOrder.MARKET_CODE))
                //|| (SelectedSalesOrder.ORDER_DATE=="__/__/____" ))
                {
                    string str = "Before entering the line details for this order you must supply the following details - ";
                    if (String.IsNullOrEmpty(SelectedSalesOrder.INVOICE_TO))
                        str = str + "\n valid Customer Code";
                    if (String.IsNullOrEmpty(OrderType))
                        str = str + " \n valid Order type";
                    //if (String.IsNullOrEmpty(SelectedSalesOrder.ORDER_DATE) || (SelectedSalesOrder.ORDER_DATE == "__/__/____"))
                    if(SelectedSalesOrder.ORDER_DATE == null)
                        str = str + " \n valid Order date";
                    if (String.IsNullOrEmpty(SelectedSalesOrder.SALES_PERSON))
                        str = str + " \n valid Sales Person";
                    if (String.IsNullOrEmpty(SelectedSalesOrder.MARKET_CODE))
                        str = str + " \n Valid Marketing Code";
                    MessageBox.Show(str);
                    SelectedTabIndex = 0;
                }
               
            }

           
           
        }

        private ICommand _Delete { get; set; }
        public ICommand Delete
        {
            get
            {
                if (_Delete == null)
                {
                    _Delete = new DelegateCommand(DeleteButton_Click);
                }
                return _Delete;
            }

        }
        public async void DeleteButton_Click()
        {
            if (SelectedSalesOrder == null)
            {
                MessageBox.Show("Please select a row to delete");
            }
            else
            {
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "SalesOrderWindow");
                if (win != null)
                {
                    win.IsEnabled = false;
                }
                await DeleteSalesOrder(SelectedSalesOrder.ORDER_NO);
                MessageBox.Show("SalesOrder deleted succssfully");
                //refresh grid
                GetSalesOrderList();
                NotifyPropertyChanged("SalesOrderList");
                if (win != null)
                {
                    win.Close();
                }
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewSalesOrderWindow");
                if (winv != null)
                {
                    winv.DataContext = this;
                }
            }

        }

        private ICommand _SaveCommand { get; set; }
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new DelegateCommand(SaveButton_Click);
                }
                return _SaveCommand;
            }

        }
        public async void SaveButton_Click()
        {
            if (String.IsNullOrEmpty(SelectedSalesOrder.INVOICE_TO)
                || String.IsNullOrEmpty(OrderType)
                //|| String.IsNullOrEmpty(SelectedSalesOrder.ORDER_DATE)
                ||(SelectedSalesOrder.ORDER_DATE==null)
                || String.IsNullOrEmpty(SelectedSalesOrder.SALES_PERSON)
                || String.IsNullOrEmpty(SelectedSalesOrder.MARKET_CODE))
                //|| (SelectedSalesOrder.ORDER_DATE == "__/__/____"))
            {
                string str = "Before saving this order you must supply the following details - ";
                if (String.IsNullOrEmpty(SelectedSalesOrder.INVOICE_TO))
                    str = str + "\n valid Customer Code";
                if (String.IsNullOrEmpty(OrderType))
                    str = str + " \n valid Order type";
               // if (String.IsNullOrEmpty(SelectedSalesOrder.ORDER_DATE) || (SelectedSalesOrder.ORDER_DATE == "__/__/____"))
                if(SelectedSalesOrder.ORDER_DATE==null)
                    str = str + " \n valid Order date";
                if (String.IsNullOrEmpty(SelectedSalesOrder.SALES_PERSON))
                    str = str + " \n valid Sales Person";
                if (String.IsNullOrEmpty(SelectedSalesOrder.MARKET_CODE))
                    str = str + " \n Valid Marketing Code";
                MessageBox.Show(str);
                SelectedTabIndex = 0;
            }
            else if (SelectedSalesOrder.TOTAL_ORDER_VALUE <= 0)
            {
                MessageBox.Show("You can not save a SalesOrder without any detail line");
            }
            else
            {
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "SalesOrderWindow");
                if (win != null)
                {
                    win.IsEnabled = false;
                }
                try
                {
                    await DeleteSalesOrder(SelectedSalesOrder.ORDER_NO);
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    var response = await client.PostAsJsonAsync("api/SalesOrderAPI/CreateSalesOrder/", SelectedSalesOrder);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        for (int i = 0; i < ListGrid.Count(); i++)
                        {
                            if (ListGrid[i].LINE_AMOUNT > 0)
                            {
                                var resp = await client.PostAsJsonAsync("api/SalesOrderAPI/CreateSalesOrderLineItem/", ListGrid[i]);
                                if (resp.StatusCode.ToString() != "OK")
                                {
                                    MessageBox.Show("Failed to add line item");
                                    await DeleteSalesOrder(SelectedSalesOrder.ORDER_NO);
                                    if (win != null)
                                    {
                                        win.IsEnabled = true;
                                    }
                                    return;
                                }
                            }
                        }

                        for (int i = 0; i < VatListGrid.Count(); i++)
                        {
                            var resp = await client.PostAsJsonAsync("api/SalesOrderAPI/CreateSalesOrderVATLine/", VatListGrid[i]);
                            if (resp.StatusCode.ToString() != "OK")
                            {
                                MessageBox.Show("Failed to add vatline");
                                await DeleteSalesOrder(SelectedSalesOrder.ORDER_NO);
                                if (win != null)
                                {
                                    win.IsEnabled = true;
                                }
                                return;
                            }
                        }

                        var resp1 = await client.PostAsJsonAsync("api/SalesOrderAPI/CreateSalesOrderCustomerOtherDetails/", SelectedSalesOrderCustomerOtherDetails);
                        if (resp1.StatusCode.ToString() != "OK")
                        {
                            MessageBox.Show("Failed to add Customer Other Details");
                            await DeleteSalesOrder(SelectedSalesOrder.ORDER_NO);
                            if (win != null)
                            {
                                win.IsEnabled = true;
                            }
                            return;
                        }

                        var resp2 = await client.PostAsJsonAsync("api/SalesOrderAPI/CreateSalesOrderCustomerInvoiceTo/", SelectedSalesOrderCustomerInvoiceTo);
                        if (resp2.StatusCode.ToString() != "OK")
                        {
                            MessageBox.Show("Failed to add CustomerInvoiceTo");
                            await DeleteSalesOrder(SelectedSalesOrder.ORDER_NO);
                            if (win != null)
                            {
                                win.IsEnabled = true;
                            }
                            return;
                        }

                        var resp3 = await client.PostAsJsonAsync("api/SalesOrderAPI/CreateSalesOrderCustomerDeliveryTo/", SelectedSalesOrderCustomerDeliveryTo);
                        if (resp3.StatusCode.ToString() != "OK")
                        {
                            MessageBox.Show("Failed to add CustomerDeliveryTo");
                            await DeleteSalesOrder(SelectedSalesOrder.ORDER_NO);
                            if (win != null)
                            {
                                win.IsEnabled = true;
                            }
                            return;
                        }

                        MessageBox.Show("SalesOrder Saved successfully");
                        //refresh grid
                        await GetSalesOrderList();
                        NotifyPropertyChanged("SalesOrderList");
                        if (win != null)
                        {
                            win.Close();
                        }
                        Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewSalesOrderWindow");
                        if (winv != null)
                        {
                            winv.DataContext = this;
                        }
                    }
                }
                catch
                {
                }
            }
        }


        public async Task<bool> DeleteSalesOrder(string OrderNo)
        {
            if (!String.IsNullOrEmpty(OrderNo))
            {
                try
                {
                    SalesOrderModel so = new SalesOrderModel();
                    so.ORDER_NO = OrderNo;
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.PostAsJsonAsync("api/SalesOrderAPI/DeleteSalesOrderLineItems/", so);
                    var response1 = await client.PostAsJsonAsync("api/SalesOrderAPI/DeleteSalesOrderVATLineItems/" , so);
                    var response2 = await client.PostAsJsonAsync("api/SalesOrderAPI/DeleteSalesOrderCustomerOtherDetails/" , so);
                    var response3 = await client.PostAsJsonAsync("api/SalesOrderAPI/DeleteSalesOrderCustomerInvoiceTo/" , so);
                    var response4 = await client.PostAsJsonAsync("api/SalesOrderAPI/DeleteSalesOrderCustomerDeliveryTo/" , so);
                    var response5 = await client.PostAsJsonAsync("api/SalesOrderAPI/DeleteSalesOrder/" , so);
                }
                catch
                {
                }
            }
            return true;
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
            if (!String.IsNullOrEmpty(SelectedSalesOrderLineItem.PRODUCT_CODE))
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("api/ProductAPI/GetProduct/?_ProductCode=" + SelectedSalesOrderLineItem.PRODUCT_CODE).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        ProductModel data = JsonConvert.DeserializeObject<ProductModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                        if (data == null)
                        {
                            MessageBox.Show("Product Code is Invalid");
                            SelectedSalesOrderLineItem.PRODUCT_CODE = "";
                            NotifyPropertyChanged("SelectedSalesOrderLineItem");
                        }
                        else
                        {
                            SelectedSalesOrderLineItem.PRODUCT_CODE = data.PRODUCT_CODE;
                            SelectedSalesOrderLineItem.DESCRIPTION = data.DESCRIPTION;
                            SelectedSalesOrderLineItem.UNIT_PRICE = data.SELL_PRICE1;
                            SelectedSalesOrderLineItem.ORDER_QTY = 0;
                            SelectedSalesOrderLineItem.DISCOUNT = 0;
                            if (!String.IsNullOrEmpty(data.VAT_RATE))
                            {
                                char c = data.VAT_RATE[0];
                                SelectedSalesOrderLineItem.VAT = Convert.ToInt32(c.ToString());
                            }
                            else
                            {
                                SelectedSalesOrderLineItem.VAT = 0;
                            }
                        }
                    }
                }
                catch
                {
                }
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
                NotifyPropertyChanged("DeliveryToReadOnly");
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
                NotifyPropertyChanged("OrderTypeReadOnly");
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
                NotifyPropertyChanged("RefReadOnly");
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
                NotifyPropertyChanged("DateReadOnly");
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
                NotifyPropertyChanged("OrderTypeNameReadOnly");
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
                NotifyPropertyChanged("OverAllDiscReadOnly");
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
                NotifyPropertyChanged("OrderSalesPersonReadOnly");
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
                NotifyPropertyChanged("MarketCodeReadOnly");
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
                NotifyPropertyChanged("ProjectCodeReadOnly");
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
                NotifyPropertyChanged("ProductGridReadOnly");
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
            List<decimal> netAmount = new List<decimal> { 0, 0, 0, 0, 0 };
            List<decimal> vatAmount = new List<decimal> { 0, 0, 0, 0, 0 };
            List<decimal> totAmount = new List<decimal> { 0, 0, 0, 0, 0 };
            List<decimal> vatRate = new List<decimal> { 20, 8, 0, 0, 0 };
            List<string> description = new List<string> { "VAT Standard Rate", "VAT Lower Rate", "VAT Zero Rate", "VAT Exempt", "VAT Exempt" };
            for (int i = 0; i < ListGrid.Count; i++)
            {
                SalesOrderLineItemModel SOLIM = ListGrid.ElementAt(i);
                if ((SOLIM.VAT >= 1)&&(SOLIM.VAT <= 5))
                {
                    if (SOLIM.LINE_AMOUNT != null)
                    {
                        netAmount[SOLIM.VAT-1] = netAmount[SOLIM.VAT-1] + SOLIM.LINE_AMOUNT;
                    }
                    vatAmount[SOLIM.VAT-1] = netAmount[SOLIM.VAT-1] * vatRate[SOLIM.VAT-1] / 100;
                    totAmount[SOLIM.VAT-1] = netAmount[SOLIM.VAT-1] + vatAmount[SOLIM.VAT-1];
                }
            }
            for (int i = 0; i < 5; i++)
            {
                _ListGrid_Temp.Add(new SalesOrderVATLineModel
                {
                    ORDER_NO = SelectedSalesOrder.ORDER_NO,
                    NO = i+1,
                    VAT_RATE = vatRate[i],
                    DESCRIPTION = description[i],
                    NET_AMOUNT = netAmount[i],
                    VAT_AMOUNT = vatAmount[i],
                    TOTAL = totAmount[i]
                });
            }
            

            VatListGrid = _ListGrid_Temp;
            if (SelectedSalesOrder != null)
            {
                decimal netamt = 0;
                for (int i = 0; i < 5; i++)
                {
                    netamt = netamt + netAmount[i];
                }
                SelectedSalesOrder.ORDER_VALUE = netamt;
                SelectedSalesOrder.COST = "*N/A*";
                SelectedSalesOrder.MARGIN = "*N/A*";
                SelectedSalesOrder.MARGIN_PERCENT = "*N/A*";
                SelectedSalesOrder.NET_VALUE = netamt;
                decimal vatamt = 0;
                for (int i = 0; i < 5; i++)
                {
                    vatamt = vatamt + vatAmount[i];
                }
                SelectedSalesOrder.TOTAL_VAT = vatamt;
                //SelectedSalesOrder.STANDARD_DISCOUNT =
                decimal totamt = 0;
                for (int i = 0; i < 5; i++)
                {
                    totamt = totamt + totAmount[i];
                }
                SelectedSalesOrder.TOTAL_ORDER_VALUE = totamt;
            }
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
