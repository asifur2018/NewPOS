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
using Newtonsoft.Json;
//using System.Windows.Controls.ItemCollection;

namespace Accounts_Pos.ViewModel.Customer
{
    class DeliveryAddressViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public HttpResponseMessage response;
        DeliveryAddressModel[] data = null;
       // List<DeliveryAddressModel> _ListGrid_Temp = new List<DeliveryAddressModel>();
        ObservableCollection<DeliveryAddressModel> _ListGrid_Temp = new ObservableCollection<DeliveryAddressModel>();
       int comp = 1;
        public DeliveryAddressViewModel()
        {
            selectDelivery = new DeliveryAddressModel();


            selectDelivery.CUSTOMER_NAME = App.Current.Properties["Customer_Name"].ToString();
            selectDelivery.CUSTOMER_CODE = App.Current.Properties["Customer_Code"].ToString();
           // var comp = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
           

            //if (App.Current.Properties["Action"] == "Edit")
            //{

            //    selectDelivery = App.Current.Properties["CatagoryEdit"] as DeliveryAddressModel;
            //    App.Current.Properties["Action"] = "";

            //}

            //else
            {
                CreatVisible = "Visible";
                UpdVisible = "Collapsed";
                AddVisible = "Visible";
                //var comp = 1;
                GetDeliveryAddress(comp);
            }

        }

        private DeliveryAddressModel _selectDelivery;
        public DeliveryAddressModel selectDelivery
        {
            get { return _selectDelivery; }
            set
            {
                if (_selectDelivery != value)
                {
                    _selectDelivery = value;
                    OnPropertyChanged("selectMiscellaneous");
                }
            }
        }

        private string _CUSTOMER_CODE;
        public string CUSTOMER_CODE
        {
            get
            {
                return selectDelivery.CUSTOMER_CODE;
            }
            set
            {
                selectDelivery.CUSTOMER_CODE = App.Current.Properties["CUSTOMER_CODE"].ToString();
                OnPropertyChanged("DELIVERY_CODE");

            }
        }


        private string _CUSTOMER_NAME;
        public string CUSTOMER_NAME
        {
            get
            {
                return selectDelivery.CUSTOMER_NAME;
            }
            set
            {
                selectDelivery.CUSTOMER_NAME = App.Current.Properties["CUSTOMER_NAME"].ToString(); 
                OnPropertyChanged("DELIVERY_CODE");

            }
        }

        private string _DELIVERY_CODE;
        public string DELIVERY_CODE
        {
            get
            {
                return selectDelivery.DELIVERY_CODE;
            }
            set
            {
                selectDelivery.DELIVERY_CODE = value;
                OnPropertyChanged("DELIVERY_CODE");

            }
        }



        private string _DELIVERY_COMPANY_NAME;
        public string DELIVERY_COMPANY_NAME
        {
            get
            {
                return selectDelivery.DELIVERY_COMPANY_NAME;
            }
            set
            {
                selectDelivery.DELIVERY_COMPANY_NAME = value;
                OnPropertyChanged("DELIVERY_COMPANY_NAME");

            }
        }

        private string _ADDRESS;
        public string ADDRESS
        {
            get
            {
                return selectDelivery.ADDRESS;
            }
            set
            {
                selectDelivery.ADDRESS = value;
                OnPropertyChanged("ADDRESS");

            }
        }


        private string _COUNTRY;
        public string COUNTRY
        {
            get
            {
                return selectDelivery.COUNTRY;
            }
            set
            {
                selectDelivery.COUNTRY = value;
                OnPropertyChanged("COUNTRY");

            }
        }

        private string _POSTCODE;
        public string POSTCODE
        {
            get
            {
                return selectDelivery.POSTCODE;
            }
            set
            {
                selectDelivery.POSTCODE = value;
                OnPropertyChanged("POSTCODE");

            }
        }



        private string _SAME_STATEMENT;
        public string SAME_STATEMENT
        {
            get
            {
                return selectDelivery.SAME_STATEMENT;
            }
            set
            {
                selectDelivery.SAME_STATEMENT = value;
                OnPropertyChanged("SAME_STATEMENT");

            }
        }

        private string _CONTACTS;
        public string CONTACTS
        {
            get
            {
                return selectDelivery.CONTACTS;
            }
            set
            {
                selectDelivery.CONTACTS = value;
                OnPropertyChanged("CONTACTS");

            }
        }


        private string _TELEPHONE;
        public string TELEPHONE
        {
            get
            {
                return selectDelivery.TELEPHONE;
            }
            set
            {
                selectDelivery.TELEPHONE = value;
                OnPropertyChanged("TELEPHONE");

            }
        }

        private string _FAX;
        public string FAX
        {
            get
            {
                return selectDelivery.FAX;
            }
            set
            {
                selectDelivery.FAX = value;
                OnPropertyChanged("FAX");

            }
        }


        private string _EC_COUNTRY;
        public string EC_COUNTRY
        {
            get
            {
                return selectDelivery.EC_COUNTRY;
            }
            set
            {
                selectDelivery.EC_COUNTRY = value;
                OnPropertyChanged("EC_COUNTRY");

            }
        }

        private string _DELIVERY_TIME;
        public string DELIVERY_TIME
        {
            get
            {
                return selectDelivery.DELIVERY_TIME;
            }
            set
            {
                selectDelivery.DELIVERY_TIME = value;
                OnPropertyChanged("DELIVERY_TIME");

            }
        }

        private string _DELIVERY_MODE;
        public string DELIVERY_MODE
        {
            get
            {
                return selectDelivery.DELIVERY_MODE;
            }
            set
            {
                selectDelivery.DELIVERY_MODE = value;
                OnPropertyChanged("DELIVERY_MODE");

            }
        }
        private DeliveryAddressModel _selectedItem;
        public DeliveryAddressModel SelectedItem
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

        private string _AddVisible { get; set; }
        public string AddVisible
        {

            get { return _AddVisible; }
            set
            {
                if (value != _AddVisible)
                {
                    _AddVisible = value;
                    OnPropertyChanged("AddVisible");
                }
            }
        }


        //public List<DeliveryAddressModel> _ListGrid { get; set; }
        //public List<DeliveryAddressModel> ListGrid
        //{
        //    get
        //    {
        //        return _ListGrid;
        //    }
        //    set
        //    {
        //        this._ListGrid = value;
        //        OnPropertyChanged("ListGrid");
        //    }
        //}

        public ObservableCollection<DeliveryAddressModel> _ListGrid { get; set; }
        public ObservableCollection<DeliveryAddressModel> ListGrid
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

        public async Task<ObservableCollection<DeliveryAddressModel>> GetDeliveryAddress(int comp)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync("api/DeliveryAddressAPI/AddressList?id=" + comp + "").Result;
                _ListGrid_Temp.Clear();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonConvert.DeserializeObject<DeliveryAddressModel[]>(await response.Content.ReadAsStringAsync());
                    // EmployeeData = new List<EmployeeModel>();
                    int x = 0;
                   
                    for (int i = 0; i < data.Length; i++)
                    {
                        x++;
                        _ListGrid_Temp.Add(new DeliveryAddressModel
                        {
                            SLNO = x,

                            DELIVERY_CODE = data[i].DELIVERY_CODE,
                            DELIVERY_COMPANY_NAME = data[i].DELIVERY_COMPANY_NAME,
                            ADDRESS = data[i].ADDRESS,
                            COUNTRY = data[i].COUNTRY,
                            CONTACTS = data[i].CONTACTS,
                            TELEPHONE = data[i].TELEPHONE,
                            POSTCODE = data[i].POSTCODE,
                            DELIVERY_ID = data[i].DELIVERY_ID,
                            

                        });
                    }
                   
                }
               // ListGrid.Clear();
              
                ListGrid = _ListGrid_Temp;
                //DeliveryAddress.ListGridRef.ItemsSource = ListGrid.ToString();
                return new ObservableCollection<DeliveryAddressModel>(_ListGrid_Temp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        #region Insert Data
        public ICommand _InsertData;
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
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    var response = await client.PostAsJsonAsync("api/DeliveryAddressAPI/CreateDelivery/", selectDelivery);
                    if (response.StatusCode.ToString() == "OK")
                    {

                        MessageBox.Show("Item Added Successfully");
                        DELIVERY_CODE ="";
                            DELIVERY_COMPANY_NAME = "";
                            ADDRESS = "";
                            COUNTRY = "";
                            CONTACTS = "";
                            TELEPHONE = "";
                            POSTCODE = "";
                            DELIVERY_COMPANY_NAME = "";
                            CONTACTS = "";
                            TELEPHONE = "";
                            FAX = "";
                            DELIVERY_MODE = "";
                           DELIVERY_TIME="";
                           EC_COUNTRY = "";
                           SAME_STATEMENT = "";
                           //var comp = 1;
                           GetDeliveryAddress(comp);


                        //Cancel_Item();

                        //ModalService.NavigateTo(new Items(), delegate(bool returnValue) { });
                    }
                }
               
            }
            catch
            {

            }

        }

        #endregion


        public ICommand _MoveNext;
        public ICommand MoveNext
        {
            get
            {
                if (_MoveNext == null)
                {
                    _MoveNext = new DelegateCommand(Move_Next);
                }
                return _MoveNext;
            }
        }

        public async void Move_Next()
        {
            
            SalesSummery _SS = new SalesSummery();
            _SS.ShowDialog();
            Cancel_Address();

        }

        public ICommand _EditAddress { get; set; }
        public ICommand EditAddress
        {
            get
            {
                if (_EditAddress == null)
                {

                    _EditAddress = new DelegateCommand(Edit_Address);
                }
                return _EditAddress;
            }
        }

        public async void Edit_Address()
        {

            CreatVisible = "Collapsed";
            UpdVisible = "Visible";
            AddVisible = "Collapsed";
            try
            {
                if (selectDelivery.DELIVERY_ID != null && selectDelivery.DELIVERY_ID != 0)
                {
                    data = null;
                    App.Current.Properties["Action"] = "Edit";
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = new TimeSpan(500000000000);
                   HttpResponseMessage response = client.GetAsync("api/DeliveryAddressAPI/EditDelivery/?id=" + selectDelivery.DELIVERY_ID + "").Result;
                  //response = client.GetAsync("api/DeliveryAddressAPI/EditDelivery/?id=" + selectDelivery.DELIVERY_ID + "").Result;
                    if (response.StatusCode.ToString() == "OK")
                    {
                        data = JsonConvert.DeserializeObject<DeliveryAddressModel[]>(await response.Content.ReadAsStringAsync());
                        if (data.Length > 0)
                        {
                            for (int i = 0; i < data.Length; i++)
                            {

                                DELIVERY_CODE = data[i].DELIVERY_CODE;
                                DELIVERY_COMPANY_NAME = data[i].DELIVERY_COMPANY_NAME;
                                ADDRESS = data[i].ADDRESS;
                                COUNTRY = data[i].COUNTRY;
                                CONTACTS = data[i].CONTACTS;
                                TELEPHONE = data[i].TELEPHONE;
                                POSTCODE = data[i].POSTCODE;
                                EC_COUNTRY = data[i].EC_COUNTRY;
                                SAME_STATEMENT = data[i].SAME_STATEMENT;
                                //DELIVERY_CODE = data[i].DELIVERY_CODE;
                                TELEPHONE = data[i].TELEPHONE;
                                FAX = data[i].FAX;
                                DELIVERY_MODE = data[i].DELIVERY_CODE;
                                DELIVERY_TIME = data[i].DELIVERY_CODE;


                            }
                            App.Current.Properties["CatagoryEdit"] = selectDelivery;
                            selectDelivery = App.Current.Properties["CatagoryEdit"] as DeliveryAddressModel;

                        }

                    }
                }
                else
                {

                    MessageBox.Show("Select Catagory first", "Item Selection", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ICommand _UpdateAddress { get; set; }
        public ICommand UpdateAddress
        {
            get
            {
                if (_UpdateAddress == null)
                {

                    _UpdateAddress = new DelegateCommand(Update_Address);
                }
                return _UpdateAddress;
            }
        }

        public async void Update_Address()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GlobalData.gblApiAdress);
            //selectDelivery.COMPANY_ID = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(500000000000);
            var response = await client.PostAsJsonAsync("api/DeliveryAddressAPI/AddressUpdate/", selectDelivery);
            if (response.StatusCode.ToString() == "OK")
            {
                MessageBox.Show("Address Update Successfully");
                CreatVisible = "Visible";
                UpdVisible = "Collapsed";
                AddVisible = "Visible";
                DELIVERY_CODE = "";
                DELIVERY_COMPANY_NAME = "";
                ADDRESS = "";
                COUNTRY = "";
                CONTACTS = "";
                TELEPHONE = "";
                POSTCODE = "";
                DELIVERY_COMPANY_NAME = "";
                CONTACTS = "";
                TELEPHONE = "";
                FAX = "";
                DELIVERY_MODE = "";
                DELIVERY_TIME = "";
                EC_COUNTRY = "";
                SAME_STATEMENT = "";
                GetDeliveryAddress(comp);

                //Cancel_Catagory();
                //ModalService.NavigateTo(new CategoryList(), delegate(bool returnValue) { });
            }
        }

        public ICommand _DeleteAddress;
        public ICommand DeleteAddress
        {
            get
            {
                if (_DeleteAddress == null)
                {
                    _DeleteAddress = new DelegateCommand(Delete_Address);
                }
                return _DeleteAddress;
            }
        }

        public async void Delete_Address()
        {
            if (selectDelivery.DELIVERY_ID != null && selectDelivery.DELIVERY_ID != 0)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure Delete this Address " + selectDelivery.DELIVERY_CODE + "?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var id = selectDelivery.DELIVERY_ID;
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    HttpResponseMessage response = client.GetAsync("api/DeliveryAddressAPI/DeleteAddress?id=" + selectDelivery.DELIVERY_ID + "").Result;
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Delivery Address Deleted Successfully");
                        GetDeliveryAddress(comp);
                        //ModalService.NavigateTo(new CategoryList(), delegate(bool returnValue) { });

                    }
                }
                //else
                //{
                //    Cancel_Address();
                //}
            }
            else
            {
                MessageBox.Show("Select aDDRESS");
            }

        }


        public ICommand _Cancel;
        public ICommand Cancel
        {
            get
            {
                if (_Cancel == null)
                {
                    _Cancel = new DelegateCommand(Cancel_Address);
                }
                return _Cancel;
            }
        }



        public void Cancel_Address()
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
