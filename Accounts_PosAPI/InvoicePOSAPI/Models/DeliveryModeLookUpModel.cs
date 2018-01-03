using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class DeliveryModeLookUpModel
    {
        public int ID { get; set; }
        public string MODE_CODE { get; set; }
        public string MODE_NAME { get; set; }
    }
}