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
using Accounts_Pos.View.SalesOrder.Report;
using System.Collections;



namespace Accounts_Pos.ViewModel.SalesOrder
{
    class SalesOrderEnquiryViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        SalesOrderModel[] data = null;
        SalesOrderLineItemModel[] itemData = null;
        SalesOrderCustomerInvoiceToModel invoiceToData = null;
        SalesOrderCustomerDeliveryToModel deliveryToData = null;

        public SalesOrderEnquiryViewModel()
        {
            IncludeAddressDetailsEnabled = false;
            IncludeAddressDetailsChecked = false;
        }


        #region databinding
        public bool _IncludeAddressDetailsEnabled { get; set; }
        public bool IncludeAddressDetailsEnabled
        {
            get
            {
                return _IncludeAddressDetailsEnabled;
            }
            set
            {
                this._IncludeAddressDetailsEnabled = value;
                NotifyPropertyChanged("IncludeAddressDetailsEnabled");
            }
        }

        public bool _IncludeAddressDetailsChecked { get; set; }
        public bool IncludeAddressDetailsChecked
        {
            get
            {
                return _IncludeAddressDetailsChecked;
            }
            set
            {
                this._IncludeAddressDetailsChecked = value;
                NotifyPropertyChanged("IncludeAddressDetailsChecked");
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
        public ArrayList _ReportList { get; set; }
        public ArrayList ReportList
        {
            get
            {
                return _ReportList;
            }
            set
            {
                this._ReportList = value;
                NotifyPropertyChanged("ReportList");
            }
        }

        public ArrayList _ReporDataSet2tList { get; set; }
        public ArrayList ReporDataSet2tList
        {
            get
            {
                return _ReporDataSet2tList;
            }
            set
            {
                this._ReporDataSet2tList = value;
                NotifyPropertyChanged("ReporDataSet2tList");
            }
        }

        public ArrayList _ReporDataSet3tList { get; set; }
        public ArrayList ReporDataSet3tList
        {
            get
            {
                return _ReporDataSet3tList;
            }
            set
            {
                this._ReporDataSet3tList = value;
                NotifyPropertyChanged("ReporDataSet3tList");
            }
        }

        public ArrayList _ReporDataSet4tList { get; set; }
        public ArrayList ReporDataSet4tList
        {
            get
            {
                return _ReporDataSet4tList;
            }
            set
            {
                this._ReporDataSet4tList = value;
                NotifyPropertyChanged("ReporDataSet4tList");
            }
        }

        public bool _isCustomerReport { get; set; }
        public bool isCustomerReport
        {
            get
            {
                return _isCustomerReport;
            }
            set
            {
                this._isCustomerReport = value;
                NotifyPropertyChanged("isCustomerReport");
            }
        }

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
                NotifyPropertyChanged("CustomerCode");
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
                NotifyPropertyChanged("OrderNo");
            }
        }

        #endregion

        private async Task<SalesOrderModel[]> PopulateSalesOrderList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/SalesOrderAPI/GetSalesOrderListForCustomer/?pCustCode=" + CustomerCode).Result;

                if (response.IsSuccessStatusCode)
                {
                    data = JsonConvert.DeserializeObject<SalesOrderModel[]>(await response.Content.ReadAsStringAsync());
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return data;
        }

        private async Task<SalesOrderLineItemModel[]> PopulateSalesOrderLineItemList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/SalesOrderAPI/GetSalesOrderLineItem/?OrderNo=" + SelectedSalesOrder.ORDER_NO).Result;

                if (response.IsSuccessStatusCode)
                {
                    itemData = JsonConvert.DeserializeObject<SalesOrderLineItemModel[]>(await response.Content.ReadAsStringAsync());
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return itemData;
        }

        private async Task<SalesOrderCustomerInvoiceToModel> PopulateSalesOrderInvoiceToData()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/SalesOrderAPI/GetSalesOrderCustomerInvoiceTo/?OrderNo=" + SelectedSalesOrder.ORDER_NO).Result;

                if (response.IsSuccessStatusCode)
                {
                    invoiceToData = JsonConvert.DeserializeObject<SalesOrderCustomerInvoiceToModel>(await response.Content.ReadAsStringAsync());
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return invoiceToData;
        }

        

        private async Task<SalesOrderCustomerDeliveryToModel> PopulateSalesOrderDeliveryToData()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/SalesOrderAPI/GetSalesOrderCustomerDeliveryTo/?OrderNo=" + SelectedSalesOrder.ORDER_NO).Result;

                if (response.IsSuccessStatusCode)
                {
                    deliveryToData = JsonConvert.DeserializeObject<SalesOrderCustomerDeliveryToModel>(await response.Content.ReadAsStringAsync());
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return deliveryToData;
        }

        #region command binding
        private ICommand _PrintCommand;
        public ICommand PrintCommand
        {
            get
            {
                if (_PrintCommand == null)
                {
                    _PrintCommand = new DelegateCommand(PrintCommand_Click);
                }
                return _PrintCommand;
            }

        }

        public void PrintCommand_Click()
        {
            NotifyPropertyChanged("OrderNo");
            if (!String.IsNullOrEmpty(CustomerCode) && String.IsNullOrEmpty(OrderNo))
            {
                isCustomerReport = true;
                PopulateSalesOrderList();
                ReportList = new ArrayList();
                for (int i = 0; i < data.Count(); i++)
                {
                    ReportList.Add(data[i]);
                }

            }
            else if(IncludeAddressDetailsChecked==false)
            {
                isCustomerReport = false;
                OrderNo = SelectedSalesOrder.ORDER_NO;
                ReportList = new ArrayList();
                ReportList.Add(SelectedSalesOrder);
                PopulateSalesOrderLineItemList();
                ReporDataSet2tList = new ArrayList();
                for (int i = 0; i < itemData.Count(); i++)
                {
                    ReporDataSet2tList.Add(itemData[i]);
                }
            }
            else if (IncludeAddressDetailsChecked == true)
            {
                isCustomerReport = false;
                OrderNo = SelectedSalesOrder.ORDER_NO;
                ReportList = new ArrayList();
                ReportList.Add(SelectedSalesOrder);
                PopulateSalesOrderLineItemList();
                ReporDataSet2tList = new ArrayList();
                for (int i = 0; i < itemData.Count(); i++)
                {
                    ReporDataSet2tList.Add(itemData[i]);
                }
                PopulateSalesOrderInvoiceToData();
                ReporDataSet3tList = new ArrayList();
                ReporDataSet3tList.Add(invoiceToData);
                PopulateSalesOrderDeliveryToData();
                ReporDataSet4tList = new ArrayList();
                ReporDataSet4tList.Add(deliveryToData);

            }
            SalesOrderEnquiry _SOE = new SalesOrderEnquiry();
            _SOE.DataContext = this;
            _SOE.Show();
        }

        private ICommand _OrderNoChanged;
        public ICommand OrderNoChanged
        {
            get
            {
                if (_OrderNoChanged == null)
                {
                    _OrderNoChanged = new DelegateCommand(OrderNo_Changed);
                }
                return _OrderNoChanged;
            }

        }

        private void OrderNo_Changed()
        {
            if (!String.IsNullOrEmpty(OrderNo))
            {
                IncludeAddressDetailsEnabled = true;
            }
            else
            {
                IncludeAddressDetailsEnabled = false;
                if (IncludeAddressDetailsChecked)
                {
                    IncludeAddressDetailsChecked = false;
                }
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
