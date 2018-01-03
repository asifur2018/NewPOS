using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using Accounts_Pos.View.Product;
using Microsoft.Win32;

namespace Accounts_Pos.ViewModel.Product
{
    class ProductPictureViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {

        FileInfo imageFile;
        int ProductId;

        #region FileName
        #endregion

        public ProductPictureViewModel()
        {
            selectProduct = new ProductModel();
            PRODUCT_CODE = App.Current.Properties["Product_Code"].ToString();
            DESCR = App.Current.Properties["Description"].ToString();
            BIN = App.Current.Properties["Bin"].ToString();
        }


        private ProductModel _selectProduct;
        public ProductModel selectProduct
        {
            get { return _selectProduct; }
            set
            {
                if (_selectProduct != value)
                {
                    _selectProduct = value;
                    OnPropertyChanged("selectProduct");
                }
            }
        }

        private string _FILE_NAME;
        public string FILE_NAME
        {
            get
            {
                return _FILE_NAME;
            }
            set
            {
                _FILE_NAME = value;
                OnPropertyChanged("FILE_NAME");

            }
        }

        private string _DESCR;
        public string DESCR
        {
            get
            {
                return selectProduct.DESCR;
            }
            set
            {
                selectProduct.DESCR = value;
                OnPropertyChanged("DESCR");

            }
        }

        private string _BIN;
        public string BIN
        {
            get
            {
                return selectProduct.BIN;
            }
            set
            {
                selectProduct.BIN = value;
                OnPropertyChanged("BIN");

            }
        }


        private string _PRODUCT_CODE;
        public string PRODUCT_CODE
        {
            get
            {
                return selectProduct.PRODUCT_CODE;
            }
            set
            {
                selectProduct.PRODUCT_CODE = value;
                OnPropertyChanged("PRODUCT_CODE");

            }
        }

        #region Browse
        public ICommand _Browse;
        public ICommand Browse
        {
            get
            {
                if (_Browse == null)
                {
                    _Browse = new DelegateCommand(Browse_Click);
                }
                return _Browse;
            }
        }

        public void Browse_Click()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Filter
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (openFileDialog.ShowDialog() == true)
            {

                if (File.Exists(openFileDialog.FileName))
                {
                    string imagefilepath = openFileDialog.FileName.ToString();
                    imageFile = new System.IO.FileInfo(imagefilepath);
                    FILE_NAME = imagefilepath;

                }
            }


        }
        #endregion


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


            //App.Current.Properties["Description"] = selectProduct.DESCR;
            //App.Current.Properties["Bin"] = selectProduct.BIN;



            //else if (selectProduct.DESCR == "" || selectProduct.DESCR == null)
            //{
            //    MessageBox.Show("DESCRIPTION Should not be blank..");
            //}

            //else if (selectProduct.BIN == "" || selectProduct.BIN == null)
            //{
            //    MessageBox.Show("BIN Should not be blank..");
            //}


            if (imageFile != null)
            {
                string file = imageFile.Name;
                var applicationPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);



                // get your 'Uploaded' folder

                var dir = new System.IO.DirectoryInfo(System.IO.Path.Combine(applicationPath, "uploaded\\Product"));
                if (!dir.Exists)
                {
                    dir.Create();
                }
                // Copy file to your folder
                imageFile.CopyTo(System.IO.Path.Combine(dir.FullName + "\\", file), true);

                //Prepare  ProductPicture Model
                ProductModel ppm = new ProductModel();
                ppm.PICTURE_NAME = file;
                ppm.PRODUCT_CODE = selectProduct.PRODUCT_CODE;
                if (PRODUCT_CODE == "" || PRODUCT_CODE == null)
                {
                    MessageBox.Show("PRODUCT CODE Should not be blank..");
                }
                else
                {
                    try
                    {
                        HttpClient client = new HttpClient();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                        var response = await client.PostAsJsonAsync("api/ProductAPI/CreateProductPicture/", ppm);
                        if (response.StatusCode.ToString() == "OK")
                        {
                            MessageBox.Show("Product Added Successfully");
                            Cancel_Product();
                            ProductDocument _PDVM = new ProductDocument();
                            _PDVM.ShowDialog();


                        }


                        //////
                        //Refresh List
                    }

                    catch (Exception)
                    {
                        throw;
                    }

                    MessageBox.Show("Picture saved successfully");
                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                    {
                        if (window.DataContext == this)
                        {
                            window.Close();
                        }
                    }

                }
            }
            else
                MessageBox.Show("Please Upload Image...");

        }

        #endregion


        public ICommand _Cancel;
        public ICommand Cancel
        {
            get
            {
                if (_Cancel == null)
                {
                    _Cancel = new DelegateCommand(Cancel_Product);
                }
                return _Cancel;
            }
        }



        public void Cancel_Product()
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
