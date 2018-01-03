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
    /// Interaction logic for SalesOrder.xaml
    /// </summary>
    public partial class SalesOrder : Window
    {
        public SalesOrder()
        {
            InitializeComponent();
            SalesOrderViewModel _SOVM = new SalesOrderViewModel();
            this.DataContext = _SOVM;
        }
    }
}
