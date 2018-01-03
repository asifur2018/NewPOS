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
using Accounts_Pos.ViewModel.Supplier;

namespace Accounts_Pos.View.Supplier
{
    /// <summary>
    /// Interaction logic for SupplierDocuments.xaml
    /// </summary>
    public partial class SupplierDocuments : Window
    {
        SupplierDocumentViewModel _SCVM;
        public SupplierDocuments()
        {
            InitializeComponent();
            _SCVM = new SupplierDocumentViewModel();
            this.DataContext = _SCVM;
        }
    }

}
