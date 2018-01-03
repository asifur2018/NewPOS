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
using Accounts_Pos.ViewModel.Customer;


namespace Accounts_Pos.View.Customer
{
    /// <summary>
    /// Interaction logic for DeliveryAddress.xaml
    /// </summary>
    public partial class DeliveryAddress : Window
    {
        DeliveryAddressViewModel _CVM;
        public static DataGrid ListGridRef;
        ObservableCollection<DeliveryAddressModel> ListGrid = new ObservableCollection<DeliveryAddressModel>();
        public DeliveryAddress()
        {
            InitializeComponent();
            _CVM = new DeliveryAddressViewModel();
            this.DataContext = _CVM;

            
            dataGrid1.ItemsSource = ListGrid;
            ListGridRef = dataGrid1;
        }


    }
}
