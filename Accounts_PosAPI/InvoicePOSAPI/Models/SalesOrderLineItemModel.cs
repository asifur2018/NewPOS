using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class SalesOrderLineItemModel
    {
        public int      LINE_ITEM_ID { get; set; }
        public string   ORDER_NO { get; set; }
        public string   PRODUCT_CODE { get; set; }
        public string   DESCRIPTION { get; set; }
        public decimal ORDER_QTY { get; set; }
        public decimal UNIT_PRICE { get; set; }
        public decimal DISCOUNT { get; set; }
        public decimal LINE_AMOUNT { get; set; }
        public int?      VAT { get; set; }
    }
}