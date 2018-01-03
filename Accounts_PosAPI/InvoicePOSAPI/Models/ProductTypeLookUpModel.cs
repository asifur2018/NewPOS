using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class ProductTypeLookUpModel
    {
        public int PRODUCT_TYPE_ID { get; set; }
        public string PRODUCT_TYPE_NAME { get; set; }
        public string PRODUCT_TYPE_DESCRIPTION { get; set; }
    }
}