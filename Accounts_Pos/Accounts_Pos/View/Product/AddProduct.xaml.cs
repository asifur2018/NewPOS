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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        ProductViewModel _APVM; 
        public AddProduct()
        {
            InitializeComponent();
            _APVM = new ProductViewModel();
            this.DataContext = _APVM;
        }

        
    }
}
