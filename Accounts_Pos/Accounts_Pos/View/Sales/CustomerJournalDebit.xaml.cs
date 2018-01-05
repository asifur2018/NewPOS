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
using Accounts_Pos.Model;
using Accounts_Pos.ViewModel.Sales;
namespace Accounts_Pos.View.Sales
{
    /// <summary>
    /// Interaction logic for CustomerJournalDebit.xaml
    /// </summary>
    public partial class CustomerJournalDebit : Window
    {
        CustomerJournalDebitViewModel _CJDVM;
        public CustomerJournalDebit()
        {
            InitializeComponent();
            _CJDVM = new CustomerJournalDebitViewModel();
            this.DataContext = _CJDVM;
        }
    }
}
