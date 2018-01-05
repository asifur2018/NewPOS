using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    class SalesOrderVATLineModel
    {
        public int VAT_LINE_ID { get; set; }
        public string ORDER_NO { get; set; }
        public decimal? VAT_RATE { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal? NET_AMOUNT { get; set; }
        public decimal? VAT_AMOUNT { get; set; }
        public decimal? TOTAL { get; set; }
        public int NO { get; set; }
    }
}
