using System;
using System.Collections.Generic;
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
using Accounts_Pos.View.Company;
using Accounts_Pos.View.Customer;
using Accounts_Pos.View.Product;
using Accounts_Pos.ViewModel.Customer;
using Accounts_Pos.ViewModel.Product;
using Accounts_Pos.ViewModel.Supplier;

namespace Accounts_Pos.View.Supplier
{
    /// <summary>
    /// Interaction logic for SupplierListing.xaml
    /// </summary>
    public partial class SupplierListing : Window
    {
        SupplierViewModel _SVM;
        public SupplierListing()
        {
            InitializeComponent();
            _SVM = new SupplierViewModel();
            this.DataContext = _SVM;
        }

        private void CustomerListing_Click(object sender, RoutedEventArgs e)
        {
            CustomerViewModel cancel = new CustomerViewModel();
            cancel.Cancel_Customer();
            CustomerList _CL = new CustomerList();
            _CL.ShowDialog();
        }

        private void ProductListing_Click(object sender, RoutedEventArgs e)
        {
            //Cance_Supplier();
            ProductViewModel cancel = new ProductViewModel();
            cancel.Cancel_Product();
            Product_Listing _PL = new Product_Listing();
            _PL.ShowDialog();
        }

        private void SupplierListing_Click(object sender, RoutedEventArgs e)
        {
            SupplierViewModel cancel = new SupplierViewModel();
            cancel.Cancel_Supplier();
            SupplierListing _SL = new SupplierListing();
            _SL.ShowDialog();
        }

        private void AddSupplier_Click(object sender, RoutedEventArgs e)
        {
            SupplierViewModel cancel = new SupplierViewModel();
            cancel.Cancel_Supplier();
            AddSupplier _AS = new AddSupplier();
            _AS.ShowDialog();
        }

        private void Company_Click(object sender, RoutedEventArgs e)
        {
            CompanyList _CL = new CompanyList();
            _CL.ShowDialog();
        }


    }

}
