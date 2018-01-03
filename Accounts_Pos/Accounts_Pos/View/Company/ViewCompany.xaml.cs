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
using Accounts_Pos.Model;
using Accounts_Pos.View.Company;
using Accounts_Pos.ViewModel.Company;

namespace Accounts_Pos.View.Company
{
    /// <summary>
    /// Interaction logic for ViewCompany.xaml
    /// </summary>
    public partial class ViewCompany : Window
    {
        ViewCompanyViewModel _VCVM;
        public ViewCompany()
        {
            InitializeComponent();
            _VCVM = new ViewCompanyViewModel();
            this.DataContext = _VCVM;
        }
    }
}
