using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class ProductGroupLookUpModel
    {
        public int PRODUCT_GROUP_ID { get; set; }
        public string GROUP_CODE { get; set; }
        public string GROUP_DESCRIPTION { get; set; }
    }
}