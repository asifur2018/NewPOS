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
using System.Windows.Navigation;
using Accounts_Pos.View.Customer;
using Accounts_Pos.ViewModel.SalesOrder;

namespace Accounts_Pos.View.SalesOrder
{
    /// <summary>
    /// Interaction logic for SalesOrderEnquiryForm.xaml
    /// </summary>
    public partial class SalesOrderEnquiryForm : Window
    {
        public SalesOrderEnquiryForm()
        {
            InitializeComponent();
            SalesOrderEnquiryViewModel _SOEVM = new SalesOrderEnquiryViewModel();
            this.DataContext = _SOEVM;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            SalesOrderLookup _SOL = new SalesOrderLookup();
            _SOL.Show();
        }

        private void Customerlink_Click(object sender, RoutedEventArgs e)
        {
            CustomerLookup _SOL = new CustomerLookup();
            _SOL.Show();
        }
    }
}
