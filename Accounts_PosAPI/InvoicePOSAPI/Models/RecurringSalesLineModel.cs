using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class RecurringSalesLineModel
    {
        public int      RECURRING_SALES_LINE_ID { get; set; }
        public string   PRODUCT_CODE { get; set; }
        public string   DESCRIPTION { get; set; }
        public decimal  ORDER_QTY { get; set; }
        public decimal  UNIT_PRICE { get; set; }
        public decimal  DISCOUNT_PERCENT { get; set; }
        public decimal  LINE_AMOUNT { get; set; }
        public int      RECURRING_SALES_INVOICE_ID { get; set; }
    }
}