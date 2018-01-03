using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounts_Pos.View.Lookup;
using Accounts_Pos.ViewModel;
using Accounts_Pos.ViewModel.LookUp;
using System.Net.Http;
using System.Net.Http.Headers;
using Accounts_Pos.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using Accounts_Pos.Helpers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Accounts_Pos.ViewModel.LookUp
{
    class TaxibilityCISViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public TaxibilityCISViewModel()
        {
            selectedTaxabilityCIS = new TaxibilityCISLookUpModel();

            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Hidden;
            GROUP_BOX_TITLE = "Add Taxability CIS";
        }
        private string _TAXABLE_CIS_ID;
        public string TAXABLE_CIS_ID
        {
            get
            {
                return _TAXABLE_CIS_ID;
            }
            set
            {
                _TAXABLE_CIS_ID = value;
                OnPropertyChanged("TAXABLE_CIS_ID");

            }
        }

        private string _TAXABLE_CIS_DESC;
        public string TAXABLE_CIS_DESC
        {
            get
            {
                return _TAXABLE_CIS_DESC;
            }
            set
            {
                _TAXABLE_CIS_DESC = value;
                OnPropertyChanged("TAXABLE_CIS_DESC");

            }
        }

        private ICommand _AddTaxibilityCIS { get; set; }
        public ICommand AddTaxibilityCIS
        {
            get
            {
                if (_AddTaxibilityCIS == null)
                {
                    _AddTaxibilityCIS = new DelegateCommand(AddTaxibilityCIS_Click);
                }
                return _AddTaxibilityCIS;
            }

        }

        public async void AddTaxibilityCIS_Click()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/TaxibilityCISLookUpAPI/CreateTaxibilityCISModelLookUp/", selectedTaxabilityCIS);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Taxable CIS added successfully");
                }


                //close window
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddTaxabilityCIS");
                if (win != null)
                {
                    win.Close();
                }

                //refresh parent window
                GetTaxableCISList();
                NotifyPropertyChanged("ListGrid");
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewTaxabilityCISWindow");
                if (winv != null)
                {
                    winv.DataContext = this;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

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
            //close window
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddTaxabilityCIS");
            if (win != null)
            {
                win.Close();
            }
            //refresh parent window
            GetTaxableCISList();
            NotifyPropertyChanged("ListGrid");
            Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewTaxabilityCISWindow");
            if (winv != null)
            {
                winv.DataContext = this;
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

        #region ViewPage


        public ObservableCollection<TaxibilityCISLookUpModel> _ListGrid { get; set; }
        public ObservableCollection<TaxibilityCISLookUpModel> ListGrid
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

        private TaxibilityCISLookUpModel _selectedTaxabilityCIS;
        public TaxibilityCISLookUpModel selectedTaxabilityCIS
        {
            get { return _selectedTaxabilityCIS; }
            set
            {
                if (_selectedTaxabilityCIS != value)
                {
                    _selectedTaxabilityCIS = value;
                    OnPropertyChanged("selectedTaxabilityCIS");
                }
            }
        }

        public async Task<ObservableCollection<TaxibilityCISLookUpModel>> GetTaxableCISList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/TaxibilityCISLookUpAPI/GetTaxabilityCISLookUpList/").Result;

                ObservableCollection<TaxibilityCISLookUpModel> _ListGrid_Temp = new ObservableCollection<TaxibilityCISLookUpModel>();

                if (response.IsSuccessStatusCode)
                {
                    TaxibilityCISLookUpModel[] data = JsonConvert.DeserializeObject<TaxibilityCISLookUpModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new TaxibilityCISLookUpModel
                        {

                            TAXABLE_CIS_ID = data[i].TAXABLE_CIS_ID,
                            TAXABLE_CIS_DESC = data[i].TAXABLE_CIS_DESC

                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<TaxibilityCISLookUpModel>(_ListGrid_Temp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion



        #region EditLookup


        private ICommand _Update { get; set; }
        public ICommand Update
        {
            get
            {
                if (_Update == null)
                {
                    _Update = new DelegateCommand(Update_Click);
                }
                return _Update;
            }

        }

        public async void Update_Click()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/TaxibilityCISLookUpAPI/UpdateTaxibilityCISModelLookUp/", selectedTaxabilityCIS);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Taxable CIS edited successfully");
                }
                //refresh grid
                GetTaxableCISList();
                NotifyPropertyChanged("ListGrid");
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddTaxabilityCIS");
                if (win != null)
                {
                    win.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
            if ((selectedTaxabilityCIS == null) || (selectedTaxabilityCIS.TAXABLE_CIS_ID == 0))
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                TaxabilityCIS _AA = new TaxabilityCIS();
                AddButtonVisibility = Visibility.Hidden;
                EditButtonVisibility = Visibility.Visible;
                GROUP_BOX_TITLE = "Edit Taxable CIS";
                _AA.DataContext = this;
                _AA.ShowDialog();
            }
        }

        private Visibility _AddButtonVisibility;
        public Visibility AddButtonVisibility
        {
            get
            {
                return _AddButtonVisibility;
            }
            set
            {
                _AddButtonVisibility = value;

                OnPropertyChanged("AddButtonVisibility");
            }
        }
        private Visibility _EditButtonVisibility;
        public Visibility EditButtonVisibility
        {
            get
            {
                return _EditButtonVisibility;
            }
            set
            {
                _EditButtonVisibility = value;

                OnPropertyChanged("EditButtonVisibility");
            }
        }

        private string _GROUP_BOX_TITLE;
        public string GROUP_BOX_TITLE
        {
            get
            {
                return _GROUP_BOX_TITLE;
            }
            set
            {
                _GROUP_BOX_TITLE = value;
                OnPropertyChanged("GROUP_BOX_TITLE");

            }
        }
        #endregion

        #region Add Lookup

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
            TaxabilityCIS TaxabilityCISView = new TaxabilityCIS();
            TaxabilityCISView.Show();
        }

        #endregion

        #region DeleteLookup


        private ICommand _Delete { get; set; }
        public ICommand Delete
        {
            get
            {
                if (_Delete == null)
                {
                    _Delete = new DelegateCommand(Delete_Click);
                }
                return _Delete;
            }

        }

        public async void Delete_Click()
        {
            if ((selectedTaxabilityCIS == null) || (selectedTaxabilityCIS.TAXABLE_CIS_ID == 0))
            {
                MessageBox.Show("Please select a row to delete");
            }
            else
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                    var response = await client.PostAsJsonAsync("api/TaxibilityCISLookUpAPI/DeleteTaxibilityCISModelLookUp/", selectedTaxabilityCIS);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Taxable CIS deleted successfully");
                    }
                    //refresh grid
                    GetTaxableCISList();
                    NotifyPropertyChanged("ListGrid");

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

        }

        #endregion


    }
}
