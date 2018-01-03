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
using Accounts_Pos.ViewModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Accounts_Pos.ViewModel.LookUp
{
    class GroupTypeViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public GroupTypeViewModel()
        {
            selectedGroupType = new GroupTypeLookUpModel();

            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Hidden;
            GROUP_BOX_TITLE = "Add Group Type";
        }



        private string _GROUP_CODE;
        public string GROUP_CODE
        {
            get
            {
                return _GROUP_CODE;
            }
            set
            {
                _GROUP_CODE = value;
                OnPropertyChanged("GROUP_CODE");

            }
        }

        private string _GROUP_TYPE_NAME;
        public string GROUP_TYPE_NAME
        {
            get
            {
                return _GROUP_TYPE_NAME;
            }
            set
            {
                _GROUP_TYPE_NAME = value;
                OnPropertyChanged("GROUP_TYPE_NAME");

            }
        }


        private ICommand _AddGroupType { get; set; }
        public ICommand AddGroupType
        {
            get
            {
                if (_AddGroupType == null)
                {
                    _AddGroupType = new DelegateCommand(AddGroupType_Click);
                }
                return _AddGroupType;
            }

        }



        public async void AddGroupType_Click()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/GroupTypeLookUpAPI/CreateGroupTypeLookUp/", selectedGroupType);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Group Type added successfully");
                }

                //close window
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddGroupType");
                if (win != null)
                {
                    win.Close();
                }

                //refresh parent window
                GetGroupTypeList();
                NotifyPropertyChanged("ListGrid");
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewGroupTypeWindow");
                if (winv != null)
                {
                    winv.DataContext = this;
                }
            }
            catch(Exception e)
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
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddGroupType");
            if (win != null)
            {
                win.Close();
            }
            //refresh parent window
            GetGroupTypeList();
            NotifyPropertyChanged("ListGrid");
            Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewGroupTypeWindow");
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


        public ObservableCollection<GroupTypeLookUpModel> _ListGrid { get; set; }
        public ObservableCollection<GroupTypeLookUpModel> ListGrid
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

        private GroupTypeLookUpModel _selectedGroupType;
        public GroupTypeLookUpModel selectedGroupType
        {
            get { return _selectedGroupType; }
            set
            {
                if (_selectedGroupType != value)
                {
                    _selectedGroupType = value;
                    OnPropertyChanged("selectedGroupType");
                }
            }
        }

        public async Task<ObservableCollection<GroupTypeLookUpModel>> GetGroupTypeList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/GroupTypeLookUpAPI/GetGroupTypeLookUpList/").Result;

                ObservableCollection<GroupTypeLookUpModel> _ListGrid_Temp = new ObservableCollection<GroupTypeLookUpModel>();

                if (response.IsSuccessStatusCode)
                {
                    GroupTypeLookUpModel[] data = JsonConvert.DeserializeObject<GroupTypeLookUpModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new GroupTypeLookUpModel
                        {

                            GROUP_CODE = data[i].GROUP_CODE,
                            GROUP_TYPE_NAME = data[i].GROUP_TYPE_NAME,
                            GROUP_TYPE_ID =  data[i].GROUP_TYPE_ID

                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<GroupTypeLookUpModel>(_ListGrid_Temp);
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
                var response = await client.PostAsJsonAsync("api/GroupTypeLookUpAPI/UpdateGroupTypeLookUp/", selectedGroupType);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Group Type edited successfully");
                }
                //refresh grid
                GetGroupTypeList();
                NotifyPropertyChanged("ListGrid");
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddGroupType");
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
            if ((selectedGroupType == null) || (selectedGroupType.GROUP_TYPE_ID == 0))
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                GroupType _AA = new GroupType();
                AddButtonVisibility = Visibility.Hidden;
                EditButtonVisibility = Visibility.Visible;
                GROUP_BOX_TITLE = "Edit Group Type";
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
            GroupType GroupTypeView = new GroupType();
            GroupTypeView.Show();
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
            if ((selectedGroupType == null) || (selectedGroupType.GROUP_TYPE_ID == 0))
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
                    var response = await client.PostAsJsonAsync("api/GroupTypeLookUpAPI/DeleteGroupTypeLookUp/", selectedGroupType);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Group Type deleted successfully");
                    }
                    //refresh grid
                    GetGroupTypeList();
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
