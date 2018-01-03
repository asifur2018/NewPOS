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
using Accounts_Pos.View.Supplier;
using Newtonsoft.Json;


namespace Accounts_Pos.ViewModel.Supplier
{
    class SupplierViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public HttpResponseMessage response;
        SupplierModel[] data = null;
        //ConfigurationModel dataConfig = null;
        //DevelopmentCompanyModel dataDevelopmentCompany = null;
        //InternationalSettingsModel dataInternationalSettings = null;
        //SystemDetailsModel dataSystem = null;
        ObservableCollection<SupplierModel> _ListGrid_Temp = new ObservableCollection<SupplierModel>();

        int comp = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
        //int comp = 46;
        public SupplierViewModel()
        {
            if (App.Current.Properties["Action"].ToString() == "Edit")
            {
                CreatVisible = "Collapsed";
                UpdVisible = "Visible";
                selectSupplier = App.Current.Properties["SupplierEdit"] as SupplierModel;
                App.Current.Properties["Action"] = "";

            }
            else
            {
                CreatVisible = "Visible";
                UpdVisible = "Collapsed";
                selectSupplier = new SupplierModel();
                DATE_STARTED = System.DateTime.Now;
                LAST_PAYMENT = System.DateTime.Now;
                var comp = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
                GetSuppliers(comp);
            }

            //GetSuppliers(comp);


        }

        private SupplierModel _selectSupplier;
        public SupplierModel selectSupplier
        {
            get { return _selectSupplier; }
            set
            {
                if (_selectSupplier != value)
                {
                    _selectSupplier = value;
                    OnPropertyChanged("selectSupplier");
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



        private string _SUPPLIER_NAME;
        public string SUPPLIER_NAME
        {
            get
            {
                return selectSupplier.SUPPLIER_NAME;
            }
            set
            {
                selectSupplier.SUPPLIER_NAME = value;
                OnPropertyChanged("SUPPLIER_NAME");

            }
        }

        private string _SUPPLIER_CODE;
        public string SUPPLIER_CODE
        {
            get
            {
                return selectSupplier.SUPPLIER_CODE;
            }
            set
            {
                selectSupplier.SUPPLIER_CODE = value;
                OnPropertyChanged("SUPPLIER_CODE");

            }
        }

        private string _ADDRESS;
        public string ADDRESS
        {
            get
            {
                return selectSupplier.ADDRESS;
            }
            set
            {
                selectSupplier.ADDRESS = value;
                OnPropertyChanged("ADDRESS");

            }
        }

        private string _POSTCODE;
        public string POSTCODE
        {
            get
            {
                return selectSupplier.POSTCODE;
            }
            set
            {
                selectSupplier.POSTCODE = value;
                OnPropertyChanged("NAME");

            }
        }

        private string _COUNTRY;
        public string COUNTRY
        {
            get
            {
                return selectSupplier.COUNTRY;
            }
            set
            {
                selectSupplier.COUNTRY = value;
                OnPropertyChanged("COUNTRY");

            }
        }

        private string _STATEMENT;
        public string STATEMENT
        {
            get
            {
                return selectSupplier.STATEMENT;
            }
            set
            {
                selectSupplier.STATEMENT = value;
                OnPropertyChanged("STATEMENT");

            }
        }

        private string _PRICE_TYPE;
        public string PRICE_TYPE
        {
            get
            {
                return selectSupplier.PRICE_TYPE;
            }
            set
            {
                selectSupplier.PRICE_TYPE = value;
                OnPropertyChanged("PRICE_TYPE");

            }
        }


        private string _VAT_TYPE;
        public string VAT_TYPE
        {
            get
            {
                return selectSupplier.VAT_TYPE;
            }
            set
            {
                selectSupplier.VAT_TYPE = value;
                OnPropertyChanged("VAT_TYPE");

            }
        }



        private string _VAT_NUMBER;
        public string VAT_NUMBER
        {
            get
            {
                return selectSupplier.VAT_NUMBER;
            }
            set
            {
                selectSupplier.VAT_NUMBER = value;
                OnPropertyChanged("VAT_NUMBER");

            }
        }


        private string _DUNS_NO;
        public string DUNS_NO
        {
            get
            {
                return selectSupplier.DUNS_NO;
            }
            set
            {
                selectSupplier.DUNS_NO = value;
                OnPropertyChanged("DUNS_NO");

            }
        }





        // private string _STATEMENT;
        //public string STATEMENT
        //{
        //    get
        //    {
        //        return selectSupplier.STATEMENT;
        //    }
        //    set
        //    {
        //        selectSupplier.STATEMENT = value;
        //        OnPropertyChanged("STATEMENT");

        //    }
        //}





        private bool _IS_DELETE;
        public bool IS_DELETE
        {
            get
            {
                return selectSupplier.IS_DELETE;
            }
            set
            {
                selectSupplier.IS_DELETE = value;


                if (selectSupplier.IS_DELETE != value)
                {
                    selectSupplier.IS_DELETE = value;
                    OnPropertyChanged("IS_DELETE");
                }
            }
        }


        private string _SEND_MAIL;
        public string SEND_MAIL
        {
            get
            {
                return selectSupplier.SEND_MAIL;
            }
            set
            {
                selectSupplier.SEND_MAIL = value;


                if (selectSupplier.SEND_MAIL != value)
                {
                    selectSupplier.SEND_MAIL = value;

                    OnPropertyChanged("SEND_MAIL");
                }
            }
        }


        private string _DYNAMIC_DISC;
        public string DYNAMIC_DISC
        {
            get
            {
                return selectSupplier.DYNAMIC_DISC;
            }
            set
            {
                selectSupplier.DYNAMIC_DISC = value;


                if (selectSupplier.DYNAMIC_DISC != value)
                {
                    selectSupplier.DYNAMIC_DISC = value;
                    OnPropertyChanged("DYNAMIC_DISC");
                }
            }
        }

        private string _SUPPLIER_INACTIVE;
        public string SUPPLIER_INACTIVE
        {
            get
            {
                return selectSupplier.SUPPLIER_INACTIVE;
            }
            set
            {
                selectSupplier.SUPPLIER_INACTIVE = value;


                if (selectSupplier.SUPPLIER_INACTIVE != value)
                {
                    selectSupplier.SUPPLIER_INACTIVE = value;
                    OnPropertyChanged("SUPPLIER_INACTIVE");
                }
            }
        }


        private string _REGISTERED;
        public string REGISTERED
        {
            get
            {
                return selectSupplier.REGISTERED;
            }
            set
            {
                selectSupplier.REGISTERED = value;


                if (selectSupplier.REGISTERED != value)
                {
                    selectSupplier.REGISTERED = value;
                    OnPropertyChanged("REGISTERED");
                }
            }
        }

        //private bool _ON_CREDIT_STOP;
        //public bool ON_CREDIT_STOP
        //{
        //    get
        //    {
        //        return selectSupplier.ON_CREDIT_STOP;
        //    }
        //    set
        //    {
        //        selectSupplier.ON_CREDIT_STOP = value;


        //        if (selectSupplier.ON_CREDIT_STOP != value)
        //        {
        //            selectSupplier.ON_CREDIT_STOP = value;
        //            OnPropertyChanged("ON_CREDIT_STOP");
        //        }
        //    }
        //}



        private int _COMPANY_ID;
        public int COMPANY_ID
        {
            get
            {
                return _COMPANY_ID;
            }
            set
            {
                _COMPANY_ID = comp;
                OnPropertyChanged("COMPANY_ID");

            }
        }

        private int _SUPPLIER_ID;
        public int SUPPLIER_ID
        {
            get
            {
                return _SUPPLIER_ID;
            }
            set
            {
                _SUPPLIER_ID = comp;
                OnPropertyChanged("SUPPLIER_ID");

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
                return selectSupplier.DATE_STARTED;
            }
            set
            {
                selectSupplier.DATE_STARTED = value;


                if (selectSupplier.DATE_STARTED != value)
                {
                    selectSupplier.DATE_STARTED = value;
                    OnPropertyChanged("DATE_STARTED");
                }
            }
        }



        private string _CONTACT_TYPE;
        public string CONTACT_TYPE
        {
            get
            {
                return selectSupplier.CONTACT_TYPE;
            }
            set
            {
                selectSupplier.CONTACT_TYPE = value;
                OnPropertyChanged("CONTACT_TYPE");

            }
        }

        private string _CONTACT_NAME;
        public string CONTACT_NAME
        {
            get
            {
                return selectSupplier.CONTACT_NAME;
            }
            set
            {
                selectSupplier.CONTACT_NAME = value;
                OnPropertyChanged("CONTACT_NAME");

            }
        }

        private string _CONTACT_SALUTATION;
        public string CONTACT_SALUTATION
        {
            get
            {
                return selectSupplier.CONTACT_SALUTATION;
            }
            set
            {
                selectSupplier.CONTACT_SALUTATION = value;
                OnPropertyChanged("CONTACT_SALUTATION");

            }
        }


        private string _CONTACT_PHONE_NO;
        public string CONTACT_PHONE_NO
        {
            get
            {
                return selectSupplier.CONTACT_PHONE_NO;
            }
            set
            {
                selectSupplier.CONTACT_PHONE_NO = value;
                OnPropertyChanged("CONTACT_PHONE_NO");

            }
        }

        private string _CONTACT_EXTN_NO;
        public string CONTACT_EXTN_NO
        {
            get
            {
                return selectSupplier.CONTACT_EXTN_NO;
            }
            set
            {
                selectSupplier.CONTACT_EXTN_NO = value;
                OnPropertyChanged("CONTACT_EXTN_NO");

            }
        }


        private string _CONTACT_MOBILE_NO;
        public string CONTACT_MOBILE_NO
        {
            get
            {
                return selectSupplier.CONTACT_MOBILE_NO;
            }
            set
            {
                selectSupplier.CONTACT_MOBILE_NO = value;
                OnPropertyChanged("CONTACT_MOBILE_NO");

            }
        }

        private string _CONTACT_FAX;
        public string CONTACT_FAX
        {
            get
            {
                return selectSupplier.CONTACT_FAX;
            }
            set
            {
                selectSupplier.CONTACT_FAX = value;
                OnPropertyChanged("CONTACT_FAX");

            }
        }



        private string _EMAIL;
        public string EMAIL
        {
            get
            {
                return selectSupplier.EMAIL;
            }
            set
            {
                selectSupplier.EMAIL = value;
                OnPropertyChanged("EMAIL");

            }
        }

        private string _SKYPE;
        public string SKYPE
        {
            get
            {
                return selectSupplier.SKYPE;
            }
            set
            {
                selectSupplier.SKYPE = value;
                OnPropertyChanged("SKYPE");

            }
        }

        private bool _IS_CUSTOMER;
        public bool IS_CUSTOMER
        {
            get
            {
                return selectSupplier.IS_CUSTOMER;
            }
            set
            {
                selectSupplier.IS_CUSTOMER = value;
                if (selectSupplier.IS_CUSTOMER != value)
                {
                    selectSupplier.IS_CUSTOMER = value;
                    OnPropertyChanged("IS_CUSTOMER");
                }
            }
        }

        private string _CASH_ACC;
        public string CASH_ACC
        {
            get
            {
                return selectSupplier.CASH_ACC;
            }
            set
            {
                selectSupplier.CASH_ACC = value;
                OnPropertyChanged("CASH_ACC");

            }
        }

        private DateTime _LAST_PAYMENT;
        public DateTime LAST_PAYMENT
        {
            get
            {
                return selectSupplier.LAST_PAYMENT;
            }
            set
            {
                selectSupplier.LAST_PAYMENT = value;


                if (selectSupplier.LAST_PAYMENT != value)
                {
                    selectSupplier.LAST_PAYMENT = value;
                    OnPropertyChanged("LAST_PAYMENT");
                }
            }
        }


        private int _AVG_PMT_DAY;
        public int AVG_PMT_DAY
        {
            get
            {
                return selectSupplier.AVG_PMT_DAY;
            }
            set
            {
                selectSupplier.AVG_PMT_DAY = value;
                OnPropertyChanged("AVG_PMT_DAY");

            }
        }

        private int _DEF_PMT_DAY;
        public int DEF_PMT_DAY
        {
            get
            {
                return selectSupplier.DEF_PMT_DAY;
            }
            set
            {
                selectSupplier.DEF_PMT_DAY = value;
                OnPropertyChanged("DEF_PMT_DAY");

            }
        }

        private Decimal _CREDIT_LIMIT;
        public Decimal CREDIT_LIMIT
        {
            get
            {
                return selectSupplier.CREDIT_LIMIT;
            }
            set
            {
                selectSupplier.CREDIT_LIMIT = value;
                OnPropertyChanged("CREDIT_LIMIT");

            }
        }

        private string _GROUP;
        public string GROUP
        {
            get
            {
                return selectSupplier.GROUP;
            }
            set
            {
                selectSupplier.GROUP = value;
                OnPropertyChanged("GROUP");

            }
        }

        private string _GROUP_DESC;
        public string GROUP_DESC
        {
            get
            {
                return selectSupplier.GROUP_DESC;
            }
            set
            {
                selectSupplier.GROUP_DESC = value;
                OnPropertyChanged("GROUP_DESC");

            }
        }

        private string _SUB_CONTRACTOR;
        public string SUB_CONTRACTOR
        {
            get
            {
                return selectSupplier.SUB_CONTRACTOR;
            }
            set
            {
                selectSupplier.SUB_CONTRACTOR = value;
                OnPropertyChanged("SUB_CONTRACTOR");

            }
        }

        private string _WEBSITE;
        public string WEBSITE
        {
            get
            {
                return selectSupplier.WEBSITE;
            }
            set
            {
                selectSupplier.WEBSITE = value;
                OnPropertyChanged("WEBSITE");

            }
        }


        private ICommand _AddSupplierClick { get; set; }
        public ICommand AddSupplierClick
        {
            get
            {
                if (_AddSupplierClick == null)
                {
                    _AddSupplierClick = new DelegateCommand(AddSupplier_Click);
                }
                return _AddSupplierClick;
            }

        }

        public void AddSupplier_Click()
        {
            AddSupplier _AC = new AddSupplier();
            _AC.ShowDialog();

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


                App.Current.Properties["Supplier_Code"] = SUPPLIER_CODE;
                App.Current.Properties["Supplier_Name"] = SUPPLIER_NAME;
                App.Current.Properties["IS_CUSTOMER"] = IS_CUSTOMER;

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/SupplierAPI/CreateSupplier/", selectSupplier);
                if (response.StatusCode.ToString() == "OK")
                {

                    MessageBox.Show("Supplier Added Successfully");
                    Cancel_Supplier();
                    SettlementDisc _SD = new SettlementDisc();
                    _SD.ShowDialog();
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
            var response = await client.PostAsJsonAsync("api/SupplierAPI/SupplierUpdate/", selectSupplier);
            if (response.StatusCode.ToString() == "OK")
            {
                MessageBox.Show("Supplier Update Successfully");
                Cancel_Supplier();
                // ModalService.NavigateTo(new CustomerList(), delegate(bool returnValue) { });
                SupplierListing _SL = new SupplierListing();
                _SL.ShowDialog();

            }
        }

        private ObservableCollection<SupplierModel> _ListGrid { get; set; }
        public ObservableCollection<SupplierModel> ListGrid
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

        public async Task<ObservableCollection<SupplierModel>> GetSuppliers(int comp)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync("api/SupplierAPI/GetSuppliers?id=" + comp + "").Result;
                _ListGrid_Temp.Clear();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonConvert.DeserializeObject<SupplierModel[]>(await response.Content.ReadAsStringAsync());
                    // EmployeeData = new List<EmployeeModel>();
                    int x = 0;

                    for (int i = 0; i < data.Length; i++)
                    {
                        x++;
                        _ListGrid_Temp.Add(new SupplierModel
                        {
                            SLNO = x,


                            SUPPLIER_CODE = data[i].SUPPLIER_CODE,
                            SUPPLIER_NAME = data[i].SUPPLIER_NAME,
                            ADDRESS = data[i].ADDRESS,
                            COUNTRY = data[i].COUNTRY,
                            POSTCODE = data[i].POSTCODE,
                            SUPPLIER_ID = data[i].SUPPLIER_ID,

                            DATE_STARTED = data[i].DATE_STARTED,


                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                //DeliveryAddress.ListGridRef.ItemsSource = ListGrid.ToString();
                return new ObservableCollection<SupplierModel>(_ListGrid_Temp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ICommand _EditSupplier { get; set; }
        public ICommand EditSupplier
        {
            get
            {
                if (_EditSupplier == null)
                {

                    _EditSupplier = new DelegateCommand(Edit_Supplier);
                }
                return _EditSupplier;
            }
        }

        public async void Edit_Supplier()
        {


            try
            {
                if (selectSupplier.SUPPLIER_ID != null && selectSupplier.SUPPLIER_ID != 0)
                {
                    data = null;
                    App.Current.Properties["Action"] = "Edit";
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = new TimeSpan(500000000000);
                    HttpResponseMessage response = client.GetAsync("api/SupplierAPI/EditSuppliers/?id=" + selectSupplier.SUPPLIER_ID + "").Result;
                    //response = client.GetAsync("api/DeliveryAddressAPI/EditDelivery/?id=" + selectDelivery.DELIVERY_ID + "").Result;
                    if (response.StatusCode.ToString() == "OK")
                    {
                        data = JsonConvert.DeserializeObject<SupplierModel[]>(await response.Content.ReadAsStringAsync());
                        if (data.Length > 0)
                        {
                            for (int i = 0; i < data.Length; i++)
                            {
                                SUPPLIER_CODE = data[i].SUPPLIER_CODE;
                                SUPPLIER_NAME = data[i].SUPPLIER_NAME;
                                ADDRESS = data[i].ADDRESS;
                                COUNTRY = data[i].COUNTRY;
                                POSTCODE = data[i].POSTCODE;
                                SUPPLIER_ID = data[i].SUPPLIER_ID;
                                WEBSITE = data[i].WEBSITE;
                                VAT_TYPE = data[i].VAT_TYPE;
                                PRICE_TYPE = data[i].PRICE_TYPE;
                                DYNAMIC_DISC = data[i].DYNAMIC_DISC;
                                SEND_MAIL = data[i].SEND_MAIL;
                                //COMPANY_ID = a.COMPANY_ID,
                                SUPPLIER_INACTIVE = data[i].SUPPLIER_INACTIVE;
                                REGISTERED = data[i].REGISTERED;
                                DUNS_NO = data[i].DUNS_NO;
                                STATEMENT = data[i].STATEMENT;
                                IS_CUSTOMER = data[i].IS_CUSTOMER;
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
                                LAST_PAYMENT = data[i].LAST_PAYMENT;
                                GROUP = data[i].GROUP;
                                DEF_PMT_DAY = data[i].DEF_PMT_DAY;
                                CASH_ACC = data[i].CASH_ACC;
                                CREDIT_LIMIT = data[i].CREDIT_LIMIT;

                            }

                            App.Current.Properties["SupplierEdit"] = selectSupplier;
                            Cancel_Supplier();
                            AddSupplier _AS = new AddSupplier();
                            _AS.ShowDialog();
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Select Supplier first..", "Item Selection", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ICommand _DeleteSupplier;
        public ICommand DeleteSupplier
        {
            get
            {
                if (_DeleteSupplier == null)
                {
                    _DeleteSupplier = new DelegateCommand(Delete_Supplier);
                }
                return _DeleteSupplier;
            }
        }

        public async void Delete_Supplier()
        {
            if (selectSupplier.SUPPLIER_ID != null && selectSupplier.SUPPLIER_ID != 0)
            {

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure Delete this Supplier " + selectSupplier.SUPPLIER_ID + "?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var id = selectSupplier.SUPPLIER_ID;
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    HttpResponseMessage response = client.GetAsync("api/SupplierAPI/DeleteSupplier?id=" + selectSupplier.SUPPLIER_ID + "").Result;
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Supplier Deleted Successfully");
                        GetSuppliers(comp);
                        //ModalService.NavigateTo(new SupplierListing(), delegate(bool returnValue) { });


                    }
                }
                else
                {
                    Cancel_Supplier();
                }
            }
            else
            {
                MessageBox.Show("Select Supplier..");
            }

        }


        public ICommand _Cancel;
        public ICommand Cancel
        {
            get
            {
                if (_Cancel == null)
                {
                    _Cancel = new DelegateCommand(Cancel_Supplier);
                }
                return _Cancel;
            }
        }



        public void Cancel_Supplier()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)

                if (window.DataContext == this)
                {
                    window.Close();
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
