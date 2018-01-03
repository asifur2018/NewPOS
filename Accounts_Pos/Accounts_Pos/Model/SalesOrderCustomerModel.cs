using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    class SalesOrderCustomerModel
    {
        public string DATE_STARTED { get; set; }
        public string OLD_INV_DATE { get; set; }
        public string LAST_SALE { get; set; }
        public string LAST_PMT { get; set; }
        public int? AVG_PMT_DAYS { get; set; }
    }
}
