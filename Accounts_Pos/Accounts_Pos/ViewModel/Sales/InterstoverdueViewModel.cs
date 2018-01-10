using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Accounts_Pos.Helpers;
using Accounts_Pos.Model;
using Accounts_Pos.View.Customer;
using Accounts_Pos.View.Product;
using Accounts_Pos.View.Sales;
using Newtonsoft.Json;

namespace Accounts_Pos.ViewModel.Sales
{
    // class InterstoverdueViewModel: DependencyObject, INotifyPropertyChanged, IModalService
    class InterstoverdueViewModel
    {

        public HttpResponseMessage response;
        SalesModel[] data = null;
        ObservableCollection<SalesModel> _ListGrid_Temp = new ObservableCollection<SalesModel>();
        int comp = Convert.ToInt32(App.Current.Properties["Company_Id"].ToString());
        //int comp = 46;
        public InterstoverdueViewModel()
        {
            selectSales = new SalesModel();
            //CAL_DATE = System.DateTime.Now;


            //CreatVisible = "Visible";
            //UpdVisible = "Collapsed";
            //AddVisible = "Visible";

        }

        private SalesModel _selectSales;
        public SalesModel selectSales
        {
            get { return _selectSales; }
            set
            {
                if (_selectSales != value)
                {
                    _selectSales = value;
                    OnPropertyChanged("selectSales");
                }
            }
        }

        //private DateTime _CAL_DATE;
        //public DateTime CAL_DATE
        //{
        //    get
        //    {
        //        return selectSales.CAL_DATE;
        //    }
        //    set
        //    {
        //        selectSales.CAL_DATE = value;
        //        OnPropertyChanged("CAL_DATE");

        //    }
        //}


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
