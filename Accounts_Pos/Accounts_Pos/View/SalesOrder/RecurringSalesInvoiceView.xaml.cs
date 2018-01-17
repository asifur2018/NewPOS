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

namespace Accounts_Pos.View.SalesOrder
{
    /// <summary>
    /// Interaction logic for RecurringSalesInvoiceView.xaml
    /// </summary>
    public partial class RecurringSalesInvoiceView : Window
    {
        public RecurringSalesInvoiceView()
        {
            InitializeComponent();
            RecurringSalesInvoiceViewModel _RSIVM = new RecurringSalesInvoiceViewModel();
            this.DataContext = _RSIVM;
        }
    }
}
