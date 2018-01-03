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
    /// Interaction logic for Defaults.xaml
    /// </summary>
    public partial class Defaults : Window
    {
        DefaultsViewModel _DFVM;
        public Defaults()
        {
            InitializeComponent();
            _DFVM = new DefaultsViewModel();
            this.DataContext = _DFVM;
        }
    }
}
