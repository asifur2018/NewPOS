using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    class SalesOrderCreditInformationModel
    {
        public decimal? CREDIT_LIMIT { get; set; }
        public string OS_BALANCE { get; set; }
        public string OS_ORDERS { get; set; }
        public decimal? CREDIT { get; set; }
        public string CREDIT_STOP { get; set; }
        public string STOPPED_BY { get; set; }
        public string STOP_DATE { get; set; }
    }
}
