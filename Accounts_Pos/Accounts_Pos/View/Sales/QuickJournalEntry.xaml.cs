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
using System.Windows.Shapes;
using Accounts_Pos.ViewModel.Sales;

namespace Accounts_Pos.View.Sales
{
    /// <summary>
    /// Interaction logic for QuickJournalEntry.xaml
    /// </summary>
    public partial class QuickJournalEntry : Window
    {
        QuickJournalEntryViewModel _QJEM;
        public QuickJournalEntry()
        {
            InitializeComponent();
            _QJEM = new QuickJournalEntryViewModel();
            this.DataContext = _QJEM;
        }
    }
}
