using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    class SalesOrderItemLineModel
    {
        public string DESCRIPTION { get; set; }
        public double ORDER_QTY { get; set; }
        public string PRODUCT_CODE { get; set; }
        public double UNIT_PRICE { get; set; }
        public double DISCOUNT { get; set; }
        public double LINE_AMOUNT { get; set; }
        public int NO { get; set; }
    }
}
