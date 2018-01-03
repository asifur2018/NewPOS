using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class DocumentModel
    {
        public string FILE_NAME { get; set; }
        public DateTime? DATE { get; set; }
        public string TYPE_ID_DOC { get; set; }
        public string SIZE { get; set; }
        public string TAG { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public int DOCUMENT_ID { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string SUPPLIER_CODE { get; set; }
    }
}