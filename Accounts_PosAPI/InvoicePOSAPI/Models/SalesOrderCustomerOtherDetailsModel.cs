using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class SalesOrderCustomerOtherDetailsModel
    {
        public int      OTHER_DETAILS_ID { get; set; }
        public int      NO_OF_COPIES { get; set; }
        public string   DEL { get; set; }
        public string   MODE { get; set; }
        public string   EXPECTED_SHIP { get; set; }
        public string   EXPECTED_PAYMENT { get; set; }
        public string   LAST_CHANGE_SYSTEM_DATE { get; set; }
        public string   ORDER_NO { get; set; }
    }
}