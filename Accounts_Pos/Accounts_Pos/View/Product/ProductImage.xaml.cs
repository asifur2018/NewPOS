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
    /// Interaction logic for ProductImage.xaml
    /// </summary>
    public partial class ProductImage : Window
    {
        ProductPictureViewModel _PPVM;
        public ProductImage()
        {
            InitializeComponent();

             _PPVM = new ProductPictureViewModel();
            this.DataContext = _PPVM;
        }
    }
}
