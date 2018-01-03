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
using Accounts_Pos.ViewModel.Company;

namespace Accounts_Pos.View.Company
{
    /// <summary>
    /// Interaction logic for LoginCredential.xaml
    /// </summary>
    public partial class LoginCredential : Window
    {
        LoginCredentialsViewModel _LVM;
        public static TextBox UserName;
        public LoginCredential()
        {
            InitializeComponent();
            _LVM = new LoginCredentialsViewModel();
            this.DataContext = _LVM;


            textUser.Text = "";
            UserName = textUser;

        }

       
    }
}
