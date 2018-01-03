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
    class NominalAccountDetailsViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public NominalAccountDetailsViewModel()
        {
            selectedNominalAccountDetails = new NominalAccountDetailsLookUpModel();
            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Hidden;
            GROUP_BOX_TITLE = "Add Nature Of Product";
        }

        private string _NOMINAL_GROUP_ID;
        public string NOMINAL_GROUP_ID
        {
            get
            {
                return _NOMINAL_GROUP_ID;
            }
            set
            {
                _NOMINAL_GROUP_ID = value;
                OnPropertyChanged("NOMINAL_GROUP_ID");

            }
        }

        private string _NOMINAL_GROUP_CODE;
        public string NOMINAL_GROUP_CODE
        {
            get
            {
                return _NOMINAL_GROUP_CODE;
            }
            set
            {
                _NOMINAL_GROUP_CODE = value;
                OnPropertyChanged("NOMINAL_GROUP_CODE");

            }
        }

        private string _NOMINAL_GROUP_DESC;
        public string NOMINAL_GROUP_DESC
        {
            get
            {
                return _NOMINAL_GROUP_DESC;
            }
            set
            {
                _NOMINAL_GROUP_DESC = value;
                OnPropertyChanged("NOMINAL_GROUP_DESC");

            }
        }

        private ICommand _AddNominalAccountDetails { get; set; }
        public ICommand AddNominalAccountDetails
        {
            get
            {
                if (_AddNominalAccountDetails == null)
                {
                    _AddNominalAccountDetails = new DelegateCommand(AddNominalAccountDetails_Click);
                }
                return _AddNominalAccountDetails;
            }

        }

        public async void AddNominalAccountDetails_Click()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/NominalAccountDetailsLookUpAPI/CreateNominalAccountDetailsModeLookUp/", selectedNominalAccountDetails);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Nominal Account Details added successfully");
                }


                //close window
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddNominalAccountDetails");
                if (win != null)
                {
                    win.Close();
                }

                //refresh parent window
                GetNominalAccountDetailsList();
                NotifyPropertyChanged("ListGrid");
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewNominalAccountDetailsWindow");
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
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddNominalAccountDetails");
            if (win != null)
            {
                win.Close();
            }
            //refresh parent window
            GetNominalAccountDetailsList();
            NotifyPropertyChanged("ListGrid");
            Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewNominalAccountDetailsWindow");
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


        public ObservableCollection<NominalAccountDetailsLookUpModel> _ListGrid { get; set; }
        public ObservableCollection<NominalAccountDetailsLookUpModel> ListGrid
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

        private NominalAccountDetailsLookUpModel _selectedNominalAccountDetails;
        public NominalAccountDetailsLookUpModel selectedNominalAccountDetails
        {
            get { return _selectedNominalAccountDetails; }
            set
            {
                if (_selectedNominalAccountDetails != value)
                {
                    _selectedNominalAccountDetails = value;
                    OnPropertyChanged("selectedNominalAccountDetails");
                }
            }
        }

        public async Task<ObservableCollection<NominalAccountDetailsLookUpModel>> GetNominalAccountDetailsList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/NominalAccountDetailsLookUpAPI/GetNominalAccountDetailsLookUpList/").Result;

                ObservableCollection<NominalAccountDetailsLookUpModel> _ListGrid_Temp = new ObservableCollection<NominalAccountDetailsLookUpModel>();

                if (response.IsSuccessStatusCode)
                {
                    NominalAccountDetailsLookUpModel[] data = JsonConvert.DeserializeObject<NominalAccountDetailsLookUpModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new NominalAccountDetailsLookUpModel
                        {

                            NOMINAL_GROUP_ID = data[i].NOMINAL_GROUP_ID,
                            NOMINAL_GROUP_CODE = data[i].NOMINAL_GROUP_CODE,
                            NOMINAL_GROUP_DESC = data[i].NOMINAL_GROUP_DESC

                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<NominalAccountDetailsLookUpModel>(_ListGrid_Temp);
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
                var response = await client.PostAsJsonAsync("api/NominalAccountDetailsLookUpAPI/UpdateNominalAccountDetailsLookUp/", selectedNominalAccountDetails);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Nominal Account Details edited successfully");
                }
                //refresh grid
                GetNominalAccountDetailsList();
                NotifyPropertyChanged("ListGrid");
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddNominalAccountDetails");
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
            if ((selectedNominalAccountDetails == null) || (selectedNominalAccountDetails.NOMINAL_GROUP_ID == 0))
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                NomialAccountDetails _AA = new NomialAccountDetails();
                AddButtonVisibility = Visibility.Hidden;
                EditButtonVisibility = Visibility.Visible;
                GROUP_BOX_TITLE = "Edit Nominal Account Details";
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
            NomialAccountDetails NomialAccountDetailsView = new NomialAccountDetails();
            NomialAccountDetailsView.Show();
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
            if ((selectedNominalAccountDetails == null) || (selectedNominalAccountDetails.NOMINAL_GROUP_ID == 0))
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
                    var response = await client.PostAsJsonAsync("api/NominalAccountDetailsLookUpAPI/DeleteNominalAccountDetailsLookUp/", selectedNominalAccountDetails);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Nominal Account Details deleted successfully");
                    }
                    //refresh grid
                    GetNominalAccountDetailsList();
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
