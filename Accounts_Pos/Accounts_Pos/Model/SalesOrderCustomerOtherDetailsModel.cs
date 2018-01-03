using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    class SalesOrderCustomerOtherDetailsModel
    {
        public int OTHER_DETAILS_ID { get; set; }
        public int NO_OF_COPIES { get; set; }
        public string DEL { get; set; }
        public string MODE { get; set; }
        public string EXPECTED_SHIP { get; set; }
        public string EXPECTED_PAYMENT { get; set; }
        public string LAST_CHANGE_SYSTEM_DATE { get; set; }
        public decimal? STANDARD_DISC_PER { get; set; }
        public int? STANDART_DISC_DAYS { get; set; }
        public string ORDER_NO { get; set; }
    }
}
