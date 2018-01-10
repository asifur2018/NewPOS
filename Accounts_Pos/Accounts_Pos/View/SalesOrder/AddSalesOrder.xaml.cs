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
using Accounts_Pos.ViewModel.SalesOrder;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Accounts_Pos.View.SalesOrder
{
    /// <summary>
    /// Interaction logic for SalesOrder.xaml
    /// </summary>
    public partial class AddSalesOrder : Window
    {
        public AddSalesOrder()
        {

            InitializeComponent();
            SalesOrderViewModel _SOVM = new SalesOrderViewModel();
            this.DataContext = _SOVM;
        }

        private void textBoxDecimal_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            int count = 0;
            foreach (Char c in textBox.Text.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c) || (c == '.' && count == 0))
                {
                    newText += c;
                    if (c == '.')
                        count += 1;
                }
            }
            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OnVATTypeChange(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = ((sender as ComboBox).SelectedItem as ComboBoxItem);
            if (cbi.Content.ToString() == "EC")
            {
                DelCombo.IsEnabled = true;
                ModeCombo.IsEnabled = true;
            }
            else
            {
                DelCombo.IsEnabled = false;
                ModeCombo.IsEnabled = false;
            }
        }

        private void ItemCode_PreviewMouseDown(object sender, RoutedEventArgs args) 
        {
            object my_param = sender;
            SalesOrderViewModel _SOVM = (SalesOrderViewModel) this.DataContext;
            _SOVM.SelectProductCodeCommand.Execute(my_param);
        }
        private void ItemDescription_PreviewMouseDown(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            SalesOrderViewModel _SOVM = (SalesOrderViewModel)this.DataContext;
            _SOVM.SelectProductDescriptionCommand.Execute(my_param);
        }
        private void ItemOrderQty_PreviewMouseDown(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            SalesOrderViewModel _SOVM = (SalesOrderViewModel)this.DataContext;
            _SOVM.SelectProductQtyCommand.Execute(my_param);
        }
        private void ItemUnitPrice_PreviewMouseDown(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            SalesOrderViewModel _SOVM = (SalesOrderViewModel)this.DataContext;
            _SOVM.SelectProductPriceCommand.Execute(my_param);
        }
        private void ItemDiscount_PreviewMouseDown(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            SalesOrderViewModel _SOVM = (SalesOrderViewModel)this.DataContext;
            _SOVM.SelectProductDiscountCommand.Execute(my_param);
        }
        private void ItemVAT_PreviewMouseDown(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            SalesOrderViewModel _SOVM = (SalesOrderViewModel)this.DataContext;
            _SOVM.SelectProductVATCommand.Execute(my_param);
        }
        private void ItemLineAmount_PreviewMouseDown(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            SalesOrderViewModel _SOVM = (SalesOrderViewModel)this.DataContext;
            _SOVM.SelectProductAmountCommand.Execute(my_param);
        }

        private void ItemCode_LostFocus(object sender, RoutedEventArgs args)
        {
            object my_param = sender;
            SalesOrderViewModel _SOVM = (SalesOrderViewModel)this.DataContext;
            Type t1 = (((DataGridCell)sender).Content).GetType();
            TextBox txt = new TextBox();
            Type t2 = txt.GetType();
            if (t1 == t2)
            {
                TextBox t = (TextBox)((DataGridCell)sender).Content;
                _SOVM.SelectedSalesOrderLineItem.PRODUCT_CODE = Convert.ToString(t.Text);
            }
            
            _SOVM.ProductCodeLostFocusCommand.Execute(my_param);
        }
       
    }
}
