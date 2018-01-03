using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class DeliveryAddressModel
    {

        public string DELIVERY_CODE { get; set; }
        public string DELIVERY_COMPANY_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string COUNTRY { get; set; }
        public string POSTCODE { get; set; }
        public string SAME_STATEMENT { get; set; }
        public string CONTACTS { get; set; }
        public string TELEPHONE { get; set; }
        public string FAX { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public string STATUS { get; set; }
        public string EC_COUNTRY { get; set; }
        public string DELIVERY_TIME { get; set; }
        public string DELIVERY_MODE { get; set; }
        public int SLNO { get; set; }
        public DateTime FIRST_DATE { get; set; }
        public DateTime LAST_DATE { get; set; }
        public int TIMES { get; set; }
        public int DELIVERY_ID { get; set; }
        public int COMPANY_ID { get; set; }
    }
}