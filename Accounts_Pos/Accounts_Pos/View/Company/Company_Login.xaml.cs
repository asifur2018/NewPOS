using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Accounts_Pos.ViewModel.Company;
using System.Windows.Input;

namespace Accounts_Pos.View.Company
{
    /// <summary>
    /// Interaction logic for Company_Login.xaml
    /// </summary>
    public partial class Company_Login : Window
    {
        Company_LoginViewModel _CVM;
        public Company_Login()
        {
            InitializeComponent();
            _CVM = new Company_LoginViewModel();
            this.DataContext = _CVM;
        }

        private void Navigate_Click(object sender, RoutedEventArgs e)//By Prince Jain 
        {
            LoginCredential _CL = new LoginCredential();
            _CL.ShowDialog();
        }
    }
}
