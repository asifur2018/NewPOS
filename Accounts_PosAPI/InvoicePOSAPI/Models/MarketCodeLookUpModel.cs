using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class MarketCodeLookUpModel
    {
        public string CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public DateTime? DATE_ENTERED { get; set; }
        public int MARKET_CODE_ID { get; set; }
    }
}