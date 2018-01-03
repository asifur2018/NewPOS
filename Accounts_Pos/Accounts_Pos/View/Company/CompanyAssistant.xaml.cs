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
    /// Interaction logic for CompanyAssistant.xaml
    /// </summary>
    public partial class CompanyAssistant : Window
    {
        public CompanyAssistant()
        {
            CompanyAssistantViewModel _CAVM;
            InitializeComponent();
            _CAVM = new CompanyAssistantViewModel();
            this.DataContext = _CAVM;

        }
    }
}
