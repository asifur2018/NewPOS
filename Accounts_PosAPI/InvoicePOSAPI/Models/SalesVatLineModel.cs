using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class SalesVatLineModel
    {
        public int      VAT_LINE_ID { get; set; }
        public string   ORDER_NO { get; set; }
        public decimal? VAT_RATE { get; set; }
        public string   DESCRIPTION { get; set; }
        public decimal? NET_AMOUNT { get; set; }
        public decimal? VAT_AMOUNT { get; set; }
        public decimal? TOTAL { get; set; }
    }
}