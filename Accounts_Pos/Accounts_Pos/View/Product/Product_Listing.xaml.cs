using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Accounts_Pos.Model;
using Accounts_Pos.View.Company;
using Accounts_Pos.View.Customer;
using Accounts_Pos.View.Supplier;
using Accounts_Pos.ViewModel.Product;

namespace Accounts_Pos.View.Product
{
    /// <summary>
    /// Interaction logic for Product_Listing.xaml
    /// </summary>
    public partial class Product_Listing : Window
    {
        //public static Button BtnOk;
        ProductViewModel _PLVM;
        public Product_Listing()
        {
            _PLVM = new ProductViewModel();
            InitializeComponent();
            this.DataContext = _PLVM;

            
        }

        private void Company_Click(object sender, RoutedEventArgs e)
        {
            ProductViewModel cancel = new ProductViewModel();
            cancel.Cancel_Product();
            CompanyList _CL = new CompanyList();
            _CL.ShowDialog();
        }


        private void CustomerListing_Click(object sender, RoutedEventArgs e)
        {
            ProductViewModel cancel = new ProductViewModel();
            cancel.Cancel_Product();
            CustomerList _CL = new CustomerList();
            _CL.ShowDialog();
        }



        private void ProductListing_Click(object sender, RoutedEventArgs e)
        {
            ProductViewModel cancel = new ProductViewModel();
            cancel.Cancel_Product();
            Product_Listing _PL = new Product_Listing();
            _PL.ShowDialog();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductViewModel cancel = new ProductViewModel();
            cancel.Cancel_Product();
            AddProduct _AP = new AddProduct();
            _AP.ShowDialog();
        }

        private void SupplierListing_Click(object sender, RoutedEventArgs e)
        {
            ProductViewModel cancel = new ProductViewModel();
            cancel.Cancel_Product();
            SupplierListing _SL = new SupplierListing();
            _SL.ShowDialog();
        }

        private void AddSupplier_Click(object sender, RoutedEventArgs e)
        {
            ProductViewModel cancel = new ProductViewModel();
            cancel.Cancel_Product();
            AddSupplier _AS = new AddSupplier();
            _AS.ShowDialog();
        }



    }
}
