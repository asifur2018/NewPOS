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
using Accounts_Pos.Helpers;
using Accounts_Pos.Model;
using Accounts_Pos.View.Company;
using Accounts_Pos.View.Product;
using Accounts_Pos.View.Sales;
using Accounts_Pos.View.SalesOrder;
using Accounts_Pos.View.Supplier;
using Accounts_Pos.ViewModel;
using Accounts_Pos.ViewModel.Customer;

namespace Accounts_Pos.View.Customer
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class CustomerList : Window
    {
        CustomerViewModel _CVM;
        //public static DataGrid ListGridRef;
        //ObservableCollection<CustomerModel> ListGrid1 = new ObservableCollection<CustomerModel>();
        public CustomerList()
        {

            _CVM = new CustomerViewModel();
            InitializeComponent();

            this.DataContext = _CVM;
            //dataGrid1.ItemsSource = ListGrid1;
            //ListGridRef = dataGrid1;
        }

        private void Company_Click(object sender, RoutedEventArgs e)
        {
            CustomerViewModel cancel = new CustomerViewModel();
            cancel.Cancel_Customer();
            CompanyList _CL = new CompanyList();
            _CL.ShowDialog();
        }


        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            CustomerViewModel cancel = new CustomerViewModel();
            cancel.Cancel_Customer();
            AddProduct _AP = new AddProduct();
            _AP.ShowDialog();
        }

        private void AddSupplier_Click(object sender, RoutedEventArgs e)
        {
            CustomerViewModel cancel = new CustomerViewModel();
            cancel.Cancel_Customer();
            AddSupplier _AS = new AddSupplier();
            _AS.ShowDialog();
        }

        private void ProductListing_Click(object sender, RoutedEventArgs e)
        {
            CustomerViewModel cancel = new CustomerViewModel();
            cancel.Cancel_Customer();
            Product_Listing _PL = new Product_Listing();
            _PL.ShowDialog();
        }

        private void SupplierListing_Click(object sender, RoutedEventArgs e)
        {
            CustomerViewModel cancel = new CustomerViewModel();
            cancel.Cancel_Customer();
            SupplierListing _SL = new SupplierListing();
            _SL.ShowDialog();
        }

        private void CustomerJournal_Click(object sender, RoutedEventArgs e)
        {
            CustomerViewModel cancel = new CustomerViewModel();
            cancel.Cancel_Customer();
            CustomerJournalDebit _JD = new CustomerJournalDebit();
            _JD.ShowDialog();
        }

        private void SalesOrderListing_Click(object sender, RoutedEventArgs e)
        {
            CustomerViewModel cancel = new CustomerViewModel();
            cancel.Cancel_Customer();
            SalesOrderView _SOV = new SalesOrderView();
            _SOV.ShowDialog();
        }

        private void AddSalesOrder_Click(object sender, RoutedEventArgs e)
        {
            CustomerViewModel cancel = new CustomerViewModel();
            cancel.Cancel_Customer();
            AddSalesOrder _SO = new AddSalesOrder();
            _SO.ShowDialog();
        }


        //private void Miscellaneous_Click(object sender, RoutedEventArgs e)
        //{
        //    Product_Miscellaneous _PM = new Product_Miscellaneous();
        //    _PM.ShowDialog();
        //}

        //private void AssemblyBreakdown_Click(object sender, RoutedEventArgs e)
        //{
        //    AssemblyBreakdown _AB = new AssemblyBreakdown();
        //    _AB.ShowDialog();
        //}


    }
}
