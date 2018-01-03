using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    class SalesOrderModel
    {
        public string INVOICE_TO { get; set; }
        public string DELIVERY_TO { get; set; }
        public string ORDER_NO { get; set; }
        public string ORDER_REF { get; set; }
        public string ORDER_DATE { get; set; }
        public string SALES_PERSON { get; set; }
        public string MARKET_CODE { get; set; }
        public double OVERALL_DISC_PER { get; set; }
        public double ORDER_VALUE { get; set; }
        public double STANDARD_DISCOUNT { get; set; }
        public double TOTAL_VAT { get; set; }
        public double TOTAL_ORDER_VALUE { get; set; }
        public double COST { get; set; }
        public double MARGIN { get; set; }
        public double MARGIN_PERCENT { get; set; }
        public double NET_VALUE { get; set; }
        public int SALESORDER_ID { get; set; }
    }
}
