using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using Accounts_Pos.View;
using Accounts_Pos.View.Customer;



namespace Accounts_Pos.Helpers
{
    public delegate void BackNavigationEventHandler(bool dialogReturn);

    public interface IModalService
    {
        void NavigateTo(Window uc, BackNavigationEventHandler backFromDialog);
        void GoBackward(bool dialogReturnValue);


        //void NavigateTo(View.Customer.AddCustomer addCustomer, BackNavigationEventHandler backNavigationEventHandler);
        //void GoBackward(bool dialogReturnValue);

        //void NavigateTo(AddCustomer addCustomer, BackNavigationEventHandler backNavigationEventHandler);

        //void NavigateTo(AddCustomer addCustomer, BackNavigationEventHandler backNavigationEventHandler);

        //void NavigateTo(View.Customer.AddCustomer addCustomer, BackNavigationEventHandler backNavigationEventHandler);
        //void GoBackward(bool dialogReturnValue);

        //void NavigateTo(View.Customer.AddCustomer addCustomer, BackNavigationEventHandler backNavigationEventHandler);

        //void NavigateTo(View.Customer.AddCustomer addCustomer, BackNavigationEventHandler backNavigationEventHandler);

        //void NavigateTo(AddCustomer addCustomer, BackNavigationEventHandler backNavigationEventHandler);

        //void NavigateTo(AddCustomer addCustomer, BackNavigationEventHandler backNavigationEventHandler);
    }
}
