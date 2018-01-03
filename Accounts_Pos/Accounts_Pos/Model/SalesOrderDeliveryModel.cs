using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    class SalesOrderDeliveryModel
    {
        public int SALESORDER_DELIVERY_ID { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public int SALESORDER_ID { get; set; }
        public int DELIVERY_ID { get; set; }
        public DateTime DELIVERY_DATE { get; set; }
        public DateTime TRANSACTION_DATE { get; set; }
        public bool DELIVERY_STATUS { get; set; }
        public string ORDER_NO { get; set; }
    }
}
