using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class GroupLookUpModel
    {
        public string GROUP_CODE { get; set; }
        public string GROUP_TYPE_CODE { get; set; }
        public string GROUP_DESCRIPTION { get; set; }
        public int GROUP_ID { get; set; }
    }
}