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
using Accounts_Pos.ViewModel.Company;


namespace Accounts_Pos.View.Company
{
    /// <summary>
    /// Interaction logic for Company.xaml
    /// </summary>
    public partial class CompanyList : Window
    {
        CompanyViewModel _CVM;
        public CompanyList()
        {
            InitializeComponent();
            _CVM = new CompanyViewModel();
            this.DataContext = _CVM;
        }
    }
}


 