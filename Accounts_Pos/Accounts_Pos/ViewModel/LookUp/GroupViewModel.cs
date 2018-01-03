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
using System.Printing;
using Newtonsoft.Json;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Accounts_Pos.ViewModel.LookUp
{
    class GroupViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {
        public GroupViewModel()
        {
            selectedGroup = new GroupLookUpModel();

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

        private string _GROUP_TYPE_CODE;
        public string GROUP_TYPE_CODE
        {
            get
            {
                return _GROUP_TYPE_CODE;
            }
            set
            {
                _GROUP_TYPE_CODE = value;
                OnPropertyChanged("GROUP_TYPE_CODE");

            }
        }

        private string _GROUP_DESCRIPTION;
        public string GROUP_DESCRIPTION
        {
            get
            {
                return _GROUP_DESCRIPTION;
            }
            set
            {
                _GROUP_DESCRIPTION = value;
                OnPropertyChanged("GROUP_DESCRIPTION");

            }
        }


        private ICommand _AddGroup { get; set; }
        public ICommand AddGroup
        {
            get
            {
                if (_AddGroup == null)
                {
                    _AddGroup = new DelegateCommand(AddGroup_Click);
                }
                return _AddGroup;
            }

        }

        /*private ICommand _PrintCommand { get; set; }
        public ICommand PrintCommand
        {
            get
            {
                if (_PrintCommand == null)
                {
                    this._PrintCommand = new SimpleCommand<Grid>
                    {
                        CanExecuteDelegate = execute => true,
                        ExecuteDelegate = grid =>
                        {
                            PrintCharts(grid);
                        }
                    };
                }
                return _PrintCommand;
            }

        }

        private void PrintCharts(Grid grid)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                PrintCapabilities capabilities = print.PrintQueue.GetPrintCapabilities(print.PrintTicket);

                double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / grid.ActualWidth,
                                        capabilities.PageImageableArea.ExtentHeight / grid.ActualHeight);

                Transform oldTransform = grid.LayoutTransform;

                grid.LayoutTransform = new ScaleTransform(scale, scale);

                Size oldSize = new Size(grid.ActualWidth, grid.ActualHeight);
                Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);
                grid.Measure(sz);
                ((UIElement)grid).Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight),
                    sz));

                print.PrintVisual(grid, "Print Results");
                grid.LayoutTransform = oldTransform;
                grid.Measure(oldSize);

                ((UIElement)grid).Arrange(new Rect(new Point(0, 0),
                    oldSize));
            }
        }*/


        public async void AddGroup_Click()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                var response = await client.PostAsJsonAsync("api/GroupLookUpAPI/CreateGroupLookUp/", selectedGroup);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Group added successfully");
                }

                //close window
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddGroup");
                if (win != null)
                {
                    win.Close();
                }

                //refresh parent window
                GetGroupList();
                NotifyPropertyChanged("ListGrid");
                Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewGroupWindow");
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
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddGroup");
            if (win != null)
            {
                win.Close();
            }
            //refresh parent window
            GetGroupList();
            NotifyPropertyChanged("ListGrid");
            Window winv = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "ViewGroupWindow");
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


        public ObservableCollection<GroupLookUpModel> _ListGrid { get; set; }
        public ObservableCollection<GroupLookUpModel> ListGrid
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

        private GroupLookUpModel _selectedGroup;
        public GroupLookUpModel selectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                if (_selectedGroup != value)
                {
                    _selectedGroup = value;
                    OnPropertyChanged("selectedGroup");
                }
            }
        }

        public async Task<ObservableCollection<GroupLookUpModel>> GetGroupList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/GroupLookUpAPI/GetGroupLookUpList/").Result;

                ObservableCollection<GroupLookUpModel> _ListGrid_Temp = new ObservableCollection<GroupLookUpModel>();

                if (response.IsSuccessStatusCode)
                {
                    GroupLookUpModel[] data = JsonConvert.DeserializeObject<GroupLookUpModel[]>(await response.Content.ReadAsStringAsync());


                    for (int i = 0; i < data.Length; i++)
                    {
                        _ListGrid_Temp.Add(new GroupLookUpModel
                        {

                            GROUP_CODE = data[i].GROUP_CODE,
                            GROUP_DESCRIPTION = data[i].GROUP_DESCRIPTION,
                            GROUP_TYPE_CODE = data[i].GROUP_TYPE_CODE,
                            GROUP_ID = data[i].GROUP_ID

                        });
                    }

                }

                ListGrid = _ListGrid_Temp;
                return new ObservableCollection<GroupLookUpModel>(_ListGrid_Temp);
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
                var response = await client.PostAsJsonAsync("api/GroupLookUpAPI/UpdateGroupLookUp/", selectedGroup);
                if (response.StatusCode.ToString() == "OK")
                {
                    MessageBox.Show("Group edited successfully");
                }
                //refresh grid
                GetGroupList();
                NotifyPropertyChanged("ListGrid");
                Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "AddGroup");
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
            if ((selectedGroup == null) || (selectedGroup.GROUP_ID == 0))
            {
                MessageBox.Show("Please select a row to edit");
            }
            else
            {
                Group _AA = new Group();
                AddButtonVisibility = Visibility.Hidden;
                EditButtonVisibility = Visibility.Visible;
                GROUP_BOX_TITLE = "Edit Group";
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
            Group GroupView = new Group();
            GroupView.Show();
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
            if ((selectedGroup == null) || (selectedGroup.GROUP_ID == 0))
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
                    var response = await client.PostAsJsonAsync("api/GroupLookUpAPI/DeleteGroupLookUp/", selectedGroup);
                    if (response.StatusCode.ToString() == "OK")
                    {
                        MessageBox.Show("Group deleted successfully");
                    }
                    //refresh grid
                    GetGroupList();
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
