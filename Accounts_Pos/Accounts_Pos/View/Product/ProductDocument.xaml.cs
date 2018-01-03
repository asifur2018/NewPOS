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
using Accounts_Pos.ViewModel.Product;

namespace Accounts_Pos.View.Product
{
    /// <summary>
    /// Interaction logic for ProductDocument.xaml
    /// </summary>
    public partial class ProductDocument : Window
    {
        ProductDocumentViewModel _PDVM;
        public ProductDocument()
        {
            InitializeComponent();
            _PDVM = new ProductDocumentViewModel();
            this.DataContext = _PDVM;
        }
    }
}
