﻿using System;
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
using Accounts_Pos.ViewModel.Supplier;

namespace Accounts_Pos.View.Supplier
{
    /// <summary>
    /// Interaction logic for AddSupplier.xaml
    /// </summary>
    public partial class AddSupplier : Window
    {
        SupplierViewModel _SVM;
        public AddSupplier()
        {
            InitializeComponent();
            _SVM = new SupplierViewModel();
            this.DataContext = _SVM;
        }
    }
}
