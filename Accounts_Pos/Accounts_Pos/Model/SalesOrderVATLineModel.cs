using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    class SalesOrderVATLineModel
    {
        public string DESCRIPTION { get; set; }
        public int VAT_LINE_ID { get; set; }
        public int ORDER_ID { get; set; }
        public double VAT_RATE { get; set; }
        public double NET_AMOUNT { get; set; }
        public double VAT_AMOUNT { get; set; }
        public double TOTAL { get; set; }
        public int NO { get; set; }
    }
}
