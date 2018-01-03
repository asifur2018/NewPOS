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
using Accounts_Pos.ViewModel;
using Accounts_Pos.ViewModel.LookUp;

namespace Accounts_Pos.View.Lookup
{
    /// <summary>
    /// Interaction logic for GroupType.xaml
    /// </summary>
    public partial class GroupType : Window
    {
        public GroupType()
        {
            InitializeComponent();

            GroupTypeViewModel gtvm = new GroupTypeViewModel();
            this.DataContext = gtvm;
        }
    }
}
