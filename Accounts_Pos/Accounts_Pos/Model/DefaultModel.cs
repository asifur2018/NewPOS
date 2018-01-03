using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    class DefaultModel
    {
        public string DEFAULT_NOMINAL_CODE { get; set; }
        public bool IS_NOMINALCODE_SALES { get; set; }
        public string DEFAULT_TAX_CODE { get; set; }
        public bool IS_TAXCODE_SALE { get; set; }
        public string CURRENCY_CODE { get; set; }
        public string DEPARTMENT { get; set; }
        public string REPORTING_PASSWORD { get; set; }
        //public int DEFAULT_ID { get; set; }
        public string CUSTOMER_CODE { get; set; }
    }
}
