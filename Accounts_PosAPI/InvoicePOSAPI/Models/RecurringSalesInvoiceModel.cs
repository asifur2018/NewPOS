using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class RecurringSalesInvoiceModel
    {
        public int      RECURR_SALES_INVOICE_ID { get; set; }
        public string   INVOICE_TO { get; set; }
        public string   DELIVERY_TO { get; set; }
        public string   ORDER_DES { get; set; }
        public string   ORDER_REF { get; set; }
        public string   SALES_PERSON { get; set; }
        public string   MARKET_CODE { get; set; }
        public string   FREQUENCY { get; set; }
        public string   CURRENT_STATUS { get; set; }
        public DateTime LAST_POSTED { get; set; }
        public DateTime PROCESS_NEXT_OCCUR { get; set; }
        public int      NUM_OF_TIME_TO_POST { get; set; }
        public decimal  ORDER_NET_AMOUNT { get; set; }
    }
}