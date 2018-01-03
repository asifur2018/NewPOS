using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class InternationalSettingsModel
    {
        public string SYSTEM_LOCALE { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string COUNTRY_NAME { get; set; }
        public string DATE_FORMAT { get; set; }
    }
}