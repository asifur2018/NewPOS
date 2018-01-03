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
using Accounts_Pos.ViewModel.Customer;

namespace Accounts_Pos.View.Customer
{
    /// <summary>
    /// Interaction logic for SalesSummery.xaml
    /// </summary>
    public partial class SalesSummery : Window
    {
        SalesSummeryViewModel _CVM = new SalesSummeryViewModel();
        public SalesSummery()
        {
            InitializeComponent();
            _CVM = new SalesSummeryViewModel();
            this.DataContext = _CVM;
        }
    }
}
