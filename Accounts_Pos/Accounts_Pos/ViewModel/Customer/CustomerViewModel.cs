using System;
using System.Collections.Generic;
//using System.ComponentModel.Design;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Accounts_Pos.Helpers;
using Accounts_Pos.ViewModel;
using System.Collections.ObjectModel;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;
using Accounts_Pos.View.Customer;
using Accounts_Pos.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Accounts_Pos.ViewModel.Customer
{
    class CustomerViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {

        public HttpResponseMessage response;
        CustomerModel[] data = null;
        ConfigurationModel dataConfig = null;
        DevelopmentCompanyModel dataDevelopmentCompany = null;
        InternationalSettingsModel dataInternationalSettings = null;
        SystemDetailsModel dataSystem = null;
        ObservableCollection<CustomerModel> _ListGrid_Temp = new ObservableCollection<CustomerModel>();
        //ObservableCollection<CustomerModel> _ListGrid_Temp = new ObservableCollection<CustomerModel>();

        public CustomerViewModel()
        {

            if (App.Current.Properties["Action"].ToString() == "Edit")
            {
                CreatVisible = "Collapsed";
                UpdVisible = "Visible";
                selectCustomer = App.Current.Properties["CustomerEdit"] as CustomerModel;
                App.Current.Properties["Action"] = "";

            }
            else
            {
                CreatVisible = "Visible";
                UpdVisible = "Collapsed";
                selectCustomer = new CustomerModel();
                DATE_STARTED = System.DateTime.Now;
                var comp = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
                GetCustomers(comp);
            }

        }


        private CustomerModel _selectCustomer;
        public CustomerModel selectCustomer
        {
            get { return _selectCustomer; }
            set
            {
                if (_selectCustomer != value)
                {
                    _selectCustomer = value;
                    OnPropertyChanged("selectCustomer");
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



        private string _CUSTOMER_NAME;
        public string CUSTOMER_NAME
        {
            get
            {
                return selectCustomer.CUSTOMER_NAME;
            }
            set
            {
                selectCustomer.CUSTOMER_NAME = value;
                OnPropertyChanged("CUSTOMER_NAME");

            }
        }

        private string _CUSTOMER_CODE;
        public string CUSTOMER_CODE
        {
            get
            {
                return selectCustomer.CUSTOMER_CODE;
            }
            set
            {
                selectCustomer.CUSTOMER_CODE = value;
                OnPropertyChanged("CUSTOMER_CODE");

            }
        }

        private string _ADDRESS;
        public string ADDRESS
        {
            get
            {
                return selectCustomer.ADDRESS;
            }
            set
            {
                selectCustomer.ADDRESS = value;
                OnPropertyChanged("ADDRESS");

            }
        }

        private string _POSTCODE;
        public string POSTCODE
        {
            get
            {
                return selectCustomer.POSTCODE;
            }
            set
            {
                selectCustomer.POSTCODE = value;
                OnPropertyChanged("NAME");

            }
        }

        private string _COUNTRY;
        public string COUNTRY
        {
            get
            {
                return selectCustomer.COUNTRY;
            }
            set
            {
                selectCustomer.COUNTRY = value;
                OnPropertyChanged("COUNTRY");

            }
        }

        private int _SLNO;
        public int SLNO
        {
            get
            {
                return selectCustomer.SLNO;
            }
            set
            {
                selectCustomer.SLNO = value;
                OnPropertyChanged("SLNO");

            }
        }


        private int _CUSTOMER_ID;
        public int CUSTOMER_ID
        {
            get
            {
                return selectCustomer.CUSTOMER_ID;
            }
            set
            {
                selectCustomer.CUSTOMER_ID = value;
                OnPropertyChanged("CUSTOMER_ID");

            }
        }


        private string _STATEMENT;
        public string STATEMENT
        {
            get
            {
                return selectCustomer.STATEMENT;
            }
            set
            {
                selectCustomer.STATEMENT = value;
                OnPropertyChanged("STATEMENT");

            }
        }

        private string _PRICE_TYPE;
        public string PRICE_TYPE
        {
            get
            {
                return selectCustomer.PRICE_TYPE;
            }
            set
            {
                selectCustomer.PRICE_TYPE = value;
                OnPropertyChanged("PRICE_TYPE");

            }
        }


        private string _VAT_TYPE;
        public string VAT_TYPE
        {
            get
            {
                return selectCustomer.VAT_TYPE;
            }
            set
            {
                selectCustomer.VAT_TYPE = value;
                OnPropertyChanged("VAT_TYPE");

            }
        }



        private string _VAT_NUMBER;
        public string VAT_NUMBER
        {
            get
            {
                return selectCustomer.VAT_NUMBER;
            }
            set
            {
                selectCustomer.VAT_NUMBER = value;
                OnPropertyChanged("VAT_NUMBER");

            }
        }


        private string _DUNS_NO;
        public string DUNS_NO
        {
            get
            {
                return selectCustomer.DUNS_NO;
            }
            set
            {
                selectCustomer.DUNS_NO = value;
                OnPropertyChanged("DUNS_NO");

            }
        }





        // private string _STATEMENT;
        //public string STATEMENT
        //{
        //    get
        //    {
        //        return selectCustomer.STATEMENT;
        //    }
        //    set
        //    {
        //        selectCustomer.STATEMENT = value;
        //        OnPropertyChanged("STATEMENT");

        //    }
        //}



        private bool _IS_CUSTOMER;
        public bool IS_CUSTOMER
        {
            get
            {
                return selectCustomer.IS_CUSTOMER;
            }
            set
            {
                selectCustomer.IS_CUSTOMER = value;


                if (selectCustomer.IS_CUSTOMER != value)
                {
                    selectCustomer.IS_CUSTOMER = value;
                    OnPropertyChanged("IS_CUSTOMER");
                }
            }
        }


        private bool _IS_DELETE;
        public bool IS_DELETE
        {
            get
            {
                return selectCustomer.IS_DELETE;
            }
            set
            {
                selectCustomer.IS_DELETE = value;


                if (selectCustomer.IS_DELETE != value)
                {
                    selectCustomer.IS_DELETE = value;
                    OnPropertyChanged("IS_DELETE");
                }
            }
        }


        private string _SEND_MAIL;
        public string SEND_MAIL
        {
            get
            {
                return selectCustomer.SEND_MAIL;
            }
            set
            {
                selectCustomer.SEND_MAIL = value;


                if (selectCustomer.SEND_MAIL != value)
                {
                    selectCustomer.SEND_MAIL = value;

                    OnPropertyChanged("SEND_MAIL");
                }
            }
        }


        private string _DYNAMIC_DISC;
        public string DYNAMIC_DISC
        {
            get
            {
                return selectCustomer.DYNAMIC_DISC;
            }
            set
            {
                selectCustomer.DYNAMIC_DISC = value;


                if (selectCustomer.DYNAMIC_DISC != value)
                {
                    selectCustomer.DYNAMIC_DISC = value;
                    OnPropertyChanged("DYNAMIC_DISC");
                }
            }
        }

        private string _CUSTOMER_INACTIVE;
        public string CUSTOMER_INACTIVE
        {
            get
            {
                return selectCustomer.CUSTOMER_INACTIVE;
            }
            set
            {
                selectCustomer.CUSTOMER_INACTIVE = value;


                if (selectCustomer.CUSTOMER_INACTIVE != value)
                {
                    selectCustomer.CUSTOMER_INACTIVE = value;
                    OnPropertyChanged("IS_REQUEST_VAI_SMS");
                }
            }
        }


        private string _REGISTERED;
        public string REGISTERED
        {
            get
            {
                return selectCustomer.REGISTERED;
            }
            set
            {
                selectCustomer.REGISTERED = value;


                if (selectCustomer.REGISTERED != value)
                {
                    selectCustomer.REGISTERED = value;
                    OnPropertyChanged("REGISTERED");
                }
            }
        }





        private int _COMPANY_ID;
        public int COMPANY_ID
        {
            get
            {
                return _COMPANY_ID;
            }
            set
            {
                _COMPANY_ID = value;
                OnPropertyChanged("COMPANY_ID");

            }
        }
        //private DateTime _DATE_STARTED;
        //public DateTime DATE_STARTED
        //{
        //    get
        //    {
        //        return _DATE_STARTED;
        //    }
        //    set
        //    {
        //        _DATE_STARTED = System.DateTime.Now;
        //        OnPropertyChanged("DATE_STARTED");

        //    }
        //}


        private DateTime _DATE_STARTED;
        public DateTime DATE_STARTED
        {
            get
            {
                return selectCustomer.DATE_STARTED;
            }
            set
            {
                selectCustomer.DATE_STARTED = value;


                if (selectCustomer.DATE_STARTED != value)
                {
                    selectCustomer.DATE_STARTED = System.DateTime.Now;
                    OnPropertyChanged("DATE_STARTED");
                }
            }
        }



        private string _CONTACT_TYPE;
        public string CONTACT_TYPE
        {
            get
            {
                return selectCustomer.CONTACT_TYPE;
            }
            set
            {
                selectCustomer.CONTACT_TYPE = value;
                OnPropertyChanged("CONTACT_TYPE");

            }
        }

        private string _CONTACT_NAME;
        public string CONTACT_NAME
        {
            get
            {
                return selectCustomer.CONTACT_NAME;
            }
            set
            {
                selectCustomer.CONTACT_NAME = value;
                OnPropertyChanged("CONTACT_NAME");

            }
        }

        private string _CONTACT_SALUTATION;
        public string CONTACT_SALUTATION
        {
            get
            {
                return selectCustomer.CONTACT_SALUTATION;
            }
            set
            {
                selectCustomer.CONTACT_SALUTATION = value;
                OnPropertyChanged("CONTACT_SALUTATION");

            }
        }


        private string _CONTACT_PHONE_NO;
        public string CONTACT_PHONE_NO
        {
            get
            {
                return selectCustomer.CONTACT_PHONE_NO;
            }
            set
            {
                selectCustomer.CONTACT_PHONE_NO = value;
                OnPropertyChanged("CONTACT_PHONE_NO");

            }
        }

        private string _CONTACT_EXTN_NO;
        public string CONTACT_EXTN_NO
        {
            get
            {
                return selectCustomer.CONTACT_EXTN_NO;
            }
            set
            {
                selectCustomer.CONTACT_EXTN_NO = value;
                OnPropertyChanged("CONTACT_EXTN_NO");

            }
        }


        private string _CONTACT_MOBILE_NO;
        public string CONTACT_MOBILE_NO
        {
            get
            {
                return selectCustomer.CONTACT_MOBILE_NO;
            }
            set
            {
                selectCustomer.CONTACT_MOBILE_NO = value;
                OnPropertyChanged("CONTACT_MOBILE_NO");

            }
        }

        private string _CONTACT_FAX;
        public string CONTACT_FAX
        {
            get
            {
                return selectCustomer.CONTACT_FAX;
            }
            set
            {
                selectCustomer.CONTACT_FAX = value;
                OnPropertyChanged("CONTACT_FAX");

            }
        }



        private string _EMAIL;
        public string EMAIL
        {
            get
            {
                return selectCustomer.EMAIL;
            }
            set
            {
                selectCustomer.EMAIL = value;
                OnPropertyChanged("EMAIL");

            }
        }

        private string _SKYPE;
        public string SKYPE
        {
            get
            {
                return selectCustomer.SKYPE;
            }
            set
            {
                selectCustomer.SKYPE = value;
                OnPropertyChanged("SKYPE");

            }
        }




        private string _WEBSITE;
        public string WEBSITE
        {
            get
            {
                return selectCustomer.WEBSITE;
            }
            set
            {
                selectCustomer.WEBSITE = value;
                OnPropertyChanged("WEBSITE");

            }
        }

        private bool _IS_SUPPLIER;
        public bool IS_SUPPLIER
        {
            get
            {
                return selectCustomer.IS_SUPPLIER;
            }
            set
            {
                selectCustomer.IS_SUPPLIER = value;
                if (selectCustomer.IS_SUPPLIER != value)
                {
                    selectCustomer.IS_SUPPLIER = value;
                    OnPropertyChanged("IS_SUPPLIER");
                }
            }
        }


        private bool _ON_CREDIT_STOP;
        public bool ON_CREDIT_STOP
        {
            get
            {
                return selectCustomer.ON_CREDIT_STOP;
            }
            set
            {
                selectCustomer.ON_CREDIT_STOP = value;


                if (selectCustomer.ON_CREDIT_STOP != value)
                {
                    selectCustomer.ON_CREDIT_STOP = value;
                    OnPropertyChanged("ON_CREDIT_STOP");
                }
            }
        }


        private DateTime _OLDEST_INV_DATE;
        public DateTime OLDEST_INV_DATE
        {
            get
            {
                return OLDEST_INV_DATE;
            }
            set
            {
                OLDEST_INV_DATE = value;
                OnPropertyChanged("DATE_STARTED");

            }
        }


        private int _AVG_PMT_DATE;
        public int AVG_PMT_DATE
        {
            get
            {
                return _AVG_PMT_DATE;
            }
            set
            {
                _AVG_PMT_DATE = value;
                OnPropertyChanged("AVG_PMT_DATE");

            }
        }


        private decimal _OS_BALANCE;
        public decimal OS_BALANCE
        {
            get
            {
                return _OS_BALANCE;
            }
            set
            {
                _OS_BALANCE = value;
                OnPropertyChanged("OS_BALANCE");

            }
        }

        private decimal _OS_ORDERS;
        public decimal OS_ORDERS
        {
            get
            {
                return _OS_ORDERS;
            }
            set
            {
                _OS_ORDERS = value;
                OnPropertyChanged("OS_ORDERS");

            }
        }

        private decimal _CR_REMAIN;
        public decimal CR_REMAIN
        {
            get
            {
                return _CR_REMAIN;
            }
            set
            {
                _CR_REMAIN = value;
                OnPropertyChanged("CR_REMAIN");

            }
        }

        private decimal _CREDIT_LIMIT;
        public decimal CREDIT_LIMIT
        {
            get
            {
                return _CREDIT_LIMIT;
            }
            set
            {
                _CREDIT_LIMIT = value;
                OnPropertyChanged("CREDIT_LIMIT");

            }
        }

        private decimal _STOPPED_ON;
        public decimal STOPPED_ON
        {
            get
            {
                return _STOPPED_ON;
            }
            set
            {
                _STOPPED_ON = value;
                OnPropertyChanged("STOPPED_ON");

            }
        }

        private decimal _ON_STOP_AFTER;
        public decimal ON_STOP_AFTER
        {
            get
            {
                return _ON_STOP_AFTER;
            }
            set
            {
                _ON_STOP_AFTER = value;
                OnPropertyChanged("ON_STOP_AFTER");

            }
        }



        private decimal _PUT_ON_STOP_BY;
        public decimal PUT_ON_STOP_BY
        {
            get
            {
                return _PUT_ON_STOP_BY;
            }
            set
            {
                _PUT_ON_STOP_BY = value;
                OnPropertyChanged("PUT_ON_STOP_BY");

            }
        }


        //private decimal _PUT_ON_STOP_BY;
        //public decimal PUT_ON_STOP_BY
        //{
        //    get
        //    {
        //        return _PUT_ON_STOP_BY;
        //    }
        //    set
        //    {
        //        _PUT_ON_STOP_BY = value;
        //        OnPropertyChanged("PUT_ON_STOP_BY");

        //    }
        //}


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


        private decimal _LAST_PAYMENT;
        public decimal LAST_PAYMENT
        {
            get
            {
                return _LAST_PAYMENT;
            }
            set
            {
                _LAST_PAYMENT = value;
                OnPropertyChanged("LAST_PAYMENT");

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


                App.Current.Properties["Customer_Code"] = CUSTOMER_CODE;
                App.Current.Properties["Customer_Name"] = CUSTOMER_NAME;

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/CustomerAPI/CreateCustomer/", selectCustomer);
                if (response.StatusCode.ToString() == "OK")
                {




                    MessageBox.Show("Customer Added Successfully");
                    Cancel_Customer();



                    Miscellaneous _MS = new Miscellaneous();
                    _MS.ShowDialog();
                }
            }

            catch
            {

            }

        }

        #endregion
        public ICommand _UpdateData { get; set; }
        public ICommand UpdateData
        {
            get
            {
                if (_UpdateData == null)
                {

                    _UpdateData = new DelegateCommand(Update_Data);
                }
                return _UpdateData;
            }
        }

        public async void Update_Data()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalData.gblApiAdress);
            //selectDelivery.COMPANY_ID = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(500000000000);
            var response = await client.PostAsJsonAsync("api/CustomerAPI/CustomerUpdate/", selectCustomer);
            if (response.StatusCode.ToString() == "OK")
            {
                MessageBox.Show("Customer Update Successfully");
                Cancel_Customer();
                // ModalService.NavigateTo(new CustomerList(), delegate(bool returnValue) { });
                CustomerList _CL = new CustomerList();
                _CL.ShowDialog();

            }
        }

        //public ICommand _Cancel;
        //public ICommand Cancel
        //{
        //    get
        //    {
        //        if (_Cancel == null)
        //        {
        //            _Cancel = new DelegateCommand(Cancel_Catagory);
        //        }
        //        return _Cancel;
        //    }
        //}



        //public void Cancel_Catagory()
        //{
        //    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)

        //        if (window.DataContext == this)
        //        {
        //            window.Close();
        //        }

        //}


        private ObservableCollection<CustomerModel> _ListGrid { get; set; }
        public ObservableCollection<CustomerModel> ListGrid
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


        public async Task<ObservableCollection<CustomerModel>> GetCustomers(int comp)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync("api/CustomerAPI/GetCustomers?id=" + comp + "").Result;
                _ListGrid_Temp.Clear();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonConvert.DeserializeObject<CustomerModel[]>(await response.Content.ReadAsStringAsync());
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

                ListGrid = _ListGrid_Temp;
                //DeliveryAddress.ListGridRef.ItemsSource = ListGrid.ToString();
                return new ObservableCollection<CustomerModel>(_ListGrid_Temp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ICommand _EditCustomer { get; set; }
        public ICommand EditCustomer
        {
            get
            {
                if (_EditCustomer == null)
                {

                    _EditCustomer = new DelegateCommand(Edit_Customer);
                }
                return _EditCustomer;
            }
        }

        public async void Edit_Customer()
        {


            try
            {
                if (selectCustomer.CUSTOMER_ID != null && selectCustomer.CUSTOMER_ID != 0)
                {
                    data = null;
                    App.Current.Properties["Action"] = "Edit";



                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = new TimeSpan(500000000000);
                    HttpResponseMessage response = client.GetAsync("api/CustomerAPI/EditCustomers/?id=" + selectCustomer.CUSTOMER_ID + "").Result;
                    //response = client.GetAsync("api/DeliveryAddressAPI/EditDelivery/?id=" + selectDelivery.DELIVERY_ID + "").Result;
                    if (response.StatusCode.ToString() == "OK")
                    {
                        data = JsonConvert.DeserializeObject<CustomerModel[]>(await response.Content.ReadAsStringAsync());
                        if (data.Length > 0)
                        {
                            for (int i = 0; i < data.Length; i++)
                            {



                                CUSTOMER_CODE = data[i].CUSTOMER_CODE;
                                CUSTOMER_NAME = data[i].CUSTOMER_NAME;
                                ADDRESS = data[i].ADDRESS;
                                COUNTRY = data[i].COUNTRY;
                                POSTCODE = data[i].POSTCODE;
                                CUSTOMER_ID = data[i].CUSTOMER_ID;

                                //string date = null;
                                //if (data[i].DATE_STARTED != null)
                                //{
                                //    date = data[i].DATE_STARTED.ToString();
                                //}
                                WEBSITE = data[i].WEBSITE;
                                VAT_TYPE = data[i].VAT_TYPE;
                                PRICE_TYPE = data[i].PRICE_TYPE;
                                DYNAMIC_DISC = data[i].DYNAMIC_DISC;
                                SEND_MAIL = data[i].SEND_MAIL;
                                //COMPANY_ID = a.COMPANY_ID,
                                CUSTOMER_INACTIVE = data[i].CUSTOMER_STATUS;
                                REGISTERED = data[i].REGISTERED;
                                DUNS_NO = data[i].DUNS_NO;
                                STATEMENT = data[i].STATEMENT;
                                IS_SUPPLIER = data[i].IS_SUPPLIER;

                                CONTACT_TYPE = data[i].CONTACT_TYPE;
                                CONTACT_NAME = data[i].CONTACT_NAME;
                                CONTACT_SALUTATION = data[i].CONTACT_SALUTATION;
                                CONTACT_PHONE_NO = data[i].CONTACT_PHONE_NO;
                                CONTACT_EXTN_NO = data[i].CONTACT_EXTN_NO;
                                CONTACT_MOBILE_NO = data[i].CONTACT_MOBILE_NO;
                                CONTACT_FAX = data[i].CONTACT_FAX;
                                EMAIL = data[i].EMAIL;
                                SKYPE = data[i].SKYPE;


                                DATE_STARTED = data[i].DATE_STARTED;







                            }

                            App.Current.Properties["CustomerEdit"] = selectCustomer;
                            AddCustomer _AC = new AddCustomer();
                            _AC.ShowDialog();


                        }


                    }
                }

                else
                {

                    MessageBox.Show("Select Customer first", "Item Selection", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if (selectCustomer.CUSTOMER_ID != null && selectCustomer.CUSTOMER_ID != 0)
            {

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure Delete this Product " + selectCustomer.CUSTOMER_ID + "?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var id = selectCustomer.CUSTOMER_ID;
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    HttpResponseMessage response = client.GetAsync("api/ProductAPI/DeleteProduct?id=" + selectCustomer.CUSTOMER_ID + "").Result;
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Customer Deleted Successfully");
                        //GetDeliveryAddress(comp);
                        ModalService.NavigateTo(new CustomerList(), delegate(bool returnValue) { });

                    }
                }
                else
                {
                    Cancel_Customer();
                }
            }
            else
            {
                MessageBox.Show("Select Customer..");
            }

        }

        public ICommand _Cancel;
        public ICommand Cancel
        {
            get
            {
                if (_Cancel == null)
                {
                    _Cancel = new DelegateCommand(Cancel_Customer);
                }
                return _Cancel;
            }
        }


        public void Cancel_Customer()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)

                if (window.DataContext == this)
                {
                    window.Close();
                }
        }

        private ICommand _AddCustomerClick { get; set; }
        public ICommand AddCustomerClick
        {
            get
            {
                if (_AddCustomerClick == null)
                {
                    _AddCustomerClick = new DelegateCommand(AddCustomer_Click);
                }
                return _AddCustomerClick;
            }

        }

        public void AddCustomer_Click()
        {
            AddCustomer _AC = new AddCustomer();
            _AC.ShowDialog();

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
            //get { return (IModalService) }
            //get{return IModalService.NavigateTo(Window uc, BackNavigationEventHandler backFromDialog);}
            get { return (IModalService)Application.Current.MainWindow; }
        }
    }
}
