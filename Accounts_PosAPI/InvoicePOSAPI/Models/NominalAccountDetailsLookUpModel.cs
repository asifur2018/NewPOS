using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class NominalAccountDetailsLookUpModel
    {
        public int NOMINAL_GROUP_ID { get; set; }
        public string NOMINAL_GROUP_CODE { get; set; }
        public string NOMINAL_GROUP_DESC { get; set; }
    }
}