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
using Accounts_Pos.ViewModel.SalesOrder;

namespace Accounts_Pos.ViewModel.Customer
{
    class CustomerLookupViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public HttpResponseMessage response;
        CustomerModel[] data = null;
        ObservableCollection<CustomerModel> _ListGrid_Temp = new ObservableCollection<CustomerModel>(); 

        public CustomerLookupViewModel()
        {
            GetCustomers();
        }
        #region databinding
        private ObservableCollection<CustomerModel> _CustomerList { get; set; }
        public ObservableCollection<CustomerModel> CustomerList
        {
            get
            {
                return _CustomerList;
            }
            set
            {
                this._CustomerList = value;
                OnPropertyChanged("CustomerList");
            }
        }

        private CustomerModel _selectCustomer;
        public CustomerModel SelectedCustomer
        {
            get { return _selectCustomer; }
            set
            {
                if (_selectCustomer != value)
                {
                    _selectCustomer = value;
                    OnPropertyChanged("SelectedCustomer");
                }
            }
        }

        public async Task<ObservableCollection<CustomerModel>> GetCustomers()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync("api/CustomerAPI/GetCustomers/").Result;
                _ListGrid_Temp.Clear();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonConvert.DeserializeObject<CustomerModel[]>(await response.Content.ReadAsStringAsync(),new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore});
                    // EmployeeData = new List<EmployeeModel>();
                    int x = 0;

                    for (int i = 0; i < data.Length; i++)
                    {
                        x++;
                        _ListGrid_Temp.Add(new CustomerModel
                        {
                            SLNO = x,


                            CUSTOMER_CODE = data[i].CUSTOMER_CODE,
                            CUSTOMER_NAME = data[i].CUSTOMER_NAME,
                            ADDRESS = data[i].ADDRESS,
                            COUNTRY = data[i].COUNTRY,
                            POSTCODE = data[i].POSTCODE,
                            CUSTOMER_ID = data[i].CUSTOMER_ID,

                            DATE_STARTED = data[i].DATE_STARTED,


                        });
                    }

                }

                CustomerList = _ListGrid_Temp;
                //DeliveryAddress.ListGridRef.ItemsSource = ListGrid.ToString();
                return new ObservableCollection<CustomerModel>(_ListGrid_Temp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region command binding
        public ICommand _Cancel;
        public ICommand Cancel
        {
            get
            {
                if (_Cancel == null)
                {
                    _Cancel = new DelegateCommand(Cancel_Click);
                }
                return _Cancel;
            }
        }


        public void Cancel_Click()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)

                if (window.DataContext == this)
                {
                    window.Close();
                }
        }

        public ICommand _Select;
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
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)

            if (window.DataContext == this)
            {
                window.Close();
            }

            if (Application.Current.Windows[0].Title == "SalesOrderEnquiryForm")
            {
                ((SalesOrderEnquiryForm)Application.Current.Windows[0]).CustomerCodeTxt.Text = SelectedCustomer.CUSTOMER_CODE;
                ((SalesOrderEnquiryForm)Application.Current.Windows[0]).CustomerNameTxt.Text = SelectedCustomer.CUSTOMER_NAME;
                if ((((SalesOrderEnquiryViewModel)Application.Current.Windows[0].DataContext).SelectedSalesOrder != null) && !((SalesOrderEnquiryViewModel)Application.Current.Windows[0].DataContext).SelectedSalesOrder.INVOICE_TO.Equals(((SalesOrderEnquiryForm)Application.Current.Windows[0]).CustomerCodeTxt.Text))
                {
                    ((SalesOrderEnquiryForm)Application.Current.Windows[0]).SalesOrderTxt.Text = "";
                    ((SalesOrderEnquiryViewModel)Application.Current.Windows[0].DataContext).SelectedSalesOrder = null;
                }
            }
            else if (Application.Current.Windows[0].Title == "RecurringSalesInvoice")
            {
                ((RecurringSalesInvoice)Application.Current.Windows[0]).CustomerCodeTxt.Text = SelectedCustomer.CUSTOMER_CODE;
                ((RecurringSalesInvoice)Application.Current.Windows[0]).CustomerNameTxt.Text = SelectedCustomer.CUSTOMER_NAME;
                
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
