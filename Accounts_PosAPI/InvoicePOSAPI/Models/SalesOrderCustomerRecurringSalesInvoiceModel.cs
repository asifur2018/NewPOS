using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class SalesOrderCustomerRecurringSalesInvoiceModel
    {
        public int RECURRING_SALES_INVOICE_ID { get; set; }
        public string INVOICE_TO { get; set; }
        public string DELIVERY_TO { get; set; }
        public string ORDER_REF { get; set; }
        public string ORDER_DESC { get; set; }
        public string SALES_PERSON { get; set; }
        public string MARKET_CODE { get; set; }
        public double FREQUENCY { get; set; }
        public string CURRENT_STATUS { get; set; }
        public DateTime LAST_POSTED { get; set; }
        public DateTime PROCESS_NEXT_OCCURENCE { get; set; }
        public int NUMBER_OF_TIME_POST { get; set; }
        public double ORDER_NET_AMOUNT { get; set; }
    }
}