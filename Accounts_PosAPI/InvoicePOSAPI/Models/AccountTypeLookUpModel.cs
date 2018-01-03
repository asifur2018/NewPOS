using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class AccountTypeLookUpModel
    {
        public int ACC_TYPE_ID { get; set; }
        public string ACC_TYPE_DESC { get; set; }
        public string TYPE { get; set; }
        public bool? STATUS { get; set; }
    }
}