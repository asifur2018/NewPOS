using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class SalesOrderModel 
    {
        public int          SALESORDER_ID { get; set; }
        public string       INVOICE_TO { get; set; }
        public string       DELIVERY_TO { get; set; }
        public string       ORDER_NO { get; set; }
        public string       ORDER_REF { get; set; }
        public DateTime?       ORDER_DATE { get; set; }
        public string       SALES_PERSON { get; set; }
        public string       MARKET_CODE { get; set; }
        public decimal?     OVERALL_DISC_PER { get; set; }
        public decimal?     ORDER_VALUE { get; set; }
        public decimal?     STANDARD_DISCOUNT { get; set; }
        public decimal?     TOTAL_VAT { get; set; }
        public decimal?     TOTAL_ORDER_VALUE { get; set; }
        public string       COST { get; set; }
        public string       MARGIN { get; set; }
        public string       MARGIN_PERCENT { get; set; }
        public decimal?     NET_VALUE { get; set; }
    }
}
