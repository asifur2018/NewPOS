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
using Accounts_Pos.View.Customer;
using Accounts_Pos.ViewModel.SalesOrder;

namespace Accounts_Pos.View.SalesOrder
{
    /// <summary>
    /// Interaction logic for RecurringSalesInvoice.xaml
    /// </summary>
    public partial class RecurringSalesInvoice : Window
    {
        public RecurringSalesInvoice()
        {
            InitializeComponent();
            RecurringSalesInvoiceViewModel _RSIVM = new RecurringSalesInvoiceViewModel();
            this.DataContext = _RSIVM;
        }

        private void Customerlink_Click(object sender, RoutedEventArgs e)
        {
            CustomerLookup _SOL = new CustomerLookup();
            _SOL.Show();
        }

        private void ItemCode_PreviewMouseDown(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            RecurringSalesInvoiceViewModel _SOVM = (RecurringSalesInvoiceViewModel)this.DataContext;
            _SOVM.SelectProductCodeCommand.Execute(my_param);
        }
        private void ItemDescription_PreviewMouseDown(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            RecurringSalesInvoiceViewModel _SOVM = (RecurringSalesInvoiceViewModel)this.DataContext;
            _SOVM.SelectProductDescriptionCommand.Execute(my_param);
        }
        private void ItemOrderQty_PreviewMouseDown(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            RecurringSalesInvoiceViewModel _SOVM = (RecurringSalesInvoiceViewModel)this.DataContext;
            _SOVM.SelectProductQtyCommand.Execute(my_param);
        }
        private void ItemUnitPrice_PreviewMouseDown(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            RecurringSalesInvoiceViewModel _SOVM = (RecurringSalesInvoiceViewModel)this.DataContext;
            _SOVM.SelectProductPriceCommand.Execute(my_param);
        }
        private void ItemDiscount_PreviewMouseDown(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            RecurringSalesInvoiceViewModel _SOVM = (RecurringSalesInvoiceViewModel)this.DataContext;
            _SOVM.SelectProductDiscountCommand.Execute(my_param);
        }
       
        private void ItemLineAmount_PreviewMouseDown(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            RecurringSalesInvoiceViewModel _SOVM = (RecurringSalesInvoiceViewModel)this.DataContext;
            _SOVM.SelectProductAmountCommand.Execute(my_param);
        }

        private void TextBox_TextChanged(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            RecurringSalesInvoiceViewModel _SOVM = (RecurringSalesInvoiceViewModel)this.DataContext;
            _SOVM.LineAmountChanged.Execute(my_param);
        }

        private void ItemCode_LostFocus(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            RecurringSalesInvoiceViewModel _SOVM = (RecurringSalesInvoiceViewModel)this.DataContext;
            Type t1 = (((DataGridCell)sender).Content).GetType();
            TextBox txt = new TextBox();
            Type t2 = txt.GetType();
            if (t1 == t2)
            {
                TextBox t = (TextBox)((DataGridCell)sender).Content;
                _SOVM.SelectedRecurringSalesLine.PRODUCT_CODE = Convert.ToString(t.Text);
            }

            _SOVM.ProductCodeLostFocusCommand.Execute(my_param);
        }

        
    }
}
