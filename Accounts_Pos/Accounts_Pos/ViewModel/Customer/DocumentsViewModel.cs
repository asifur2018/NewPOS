using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Accounts_Pos.Helpers;
using Accounts_Pos.View.Customer;

namespace Accounts_Pos.ViewModel.Customer
{
    class DocumentsViewModel
    {
        #region Insert Data
        public ICommand _InsertData;
        public ICommand InsertData
        {
            get
            {
                if (_InsertData == null)
                {
                    _InsertData = new DelegateCommand(Insert_Data);
                }
                return _InsertData;
            }
        }

        //private string _DESIGNATION_NAME;
        //public string DESIGNATION_NAME
        //{
        //    get
        //    {
        //        return selectDesignation.DESIGNATION_NAME;
        //    }
        //    set
        //    {
        //        selectDesignation.DESIGNATION_NAME = value;
        //        OnPropertyChanged("DESIGNATION_NAME");

        //    }
        //}
        //private long _COMPANY_ID;
        //public long COMPANY_ID
        //{
        //    get
        //    {
        //        return _COMPANY_ID;
        //    }
        //    set
        //    {
        //        _COMPANY_ID = value;
        //        OnPropertyChanged("COMPANY_ID");

        //    }
        //}
        //private DateTime _CREATED_DATE;
        //public DateTime CREATED_DATE
        //{
        //    get
        //    {
        //        return _CREATED_DATE;
        //    }
        //    set
        //    {
        //        _CREATED_DATE = value;
        //        OnPropertyChanged("CREATED_DATE");

        //    }
        //}

        public async void Insert_Data()
        {
            try
            {
                //{
                //    HttpClient client = new HttpClient();
                //    client.DefaultRequestHeaders.Accept.Add(
                //        new MediaTypeWithQualityHeaderValue("application/json"));
                //    client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                //    var response = await client.PostAsJsonAsync("api/ItemAPI/CreateItem/", SelectedItem);
                //    if (response.StatusCode.ToString() == "OK")
                //    {

                //        MessageBox.Show("Item Added Successfully");
                //        Cancel_Item();
                //        App.Current.Properties["SelectCat"] = null;
                //        App.Current.Properties["itemName"] = null;
                //        App.Current.Properties["barcode"] = null;
                //        App.Current.Properties["BussLocation"] = null;
                //        App.Current.Properties["Qunt"] = null;
                //        App.Current.Properties["Godown"] = null;
                //        ModalService.NavigateTo(new Items(), delegate(bool returnValue) { });
                //    }
                //}  


                foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.DataContext == this)
                    {
                        window.Close();
                    }
                }

                NLDistribution _NL = new NLDistribution();
                _NL.ShowDialog();

            }
            catch
            {

            }

        }

        #endregion
    }
}
