using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicePOSAPI.Models
{
    public class ConfigurationModel
    {
        //
        // GET: /ConfigurationModel/

        public string KEY_REMAP { get; set; }
        public string LONG_TEMP_NAMES { get; set; }
        public string TRACE { get; set; }
        public string PDF_LICENCE_LEVEL { get; set; }
    }
}
