using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Accounts_Pos.ViewModel.Product;

namespace Accounts_Pos.View.Product
{
    /// <summary>
    /// Interaction logic for AssemblyBreakdown.xaml
    /// </summary>
    public partial class AssemblyBreakdown : Window
    {
        public static DataGrid ListGridRef;
        AssemblyBreakdownViewModel _ABVM;
        public AssemblyBreakdown()
        {
            InitializeComponent();
            _ABVM = new AssemblyBreakdownViewModel();
            this.DataContext = _ABVM;
            ObservableCollection<ProductModel> ListGrid = new ObservableCollection<ProductModel>();

            dataGrid1.ItemsSource = ListGrid;
            ListGridRef = dataGrid1;

        }

        //private void dataGrid1_RowEditEnding_1(object sender, DataGridRowEditEndingEventArgs e)
        //{

        //    App.Current.Properties["AssembledPro"] = "1";
        //    Product_Listing PL = new Product_Listing();
        //    PL.Show();
        //    App.Current.Properties["AssembledPro"] = null;


        //}

        private void dataGrid1_RowEditEnding_1(object sender, DataGridRowEditEndingEventArgs e)
        {

            App.Current.Properties["AssembledPro"] = "1";
            Product_Listing PL = new Product_Listing();
            PL.Show();
            App.Current.Properties["AssembledPro"] = null;

        }



        //private void dataGrid1_MouseLeftButtonUp_1(object sender, MouseEventArgs e)
        //{
        //    App.Current.Properties["AssembledPro"] = "1";
        //    Product_Listing PL = new Product_Listing();
        //    PL.Show();
        //    App.Current.Properties["AssembledPro"] = null;
        //}


    }
}
