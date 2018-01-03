using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    class SalesOrderCustomerRecurringSalesLinesModel
    {
        public int RECURRING_SALES_LINES_ID { get; set; }
        public string PRODUCT { get; set; }
        public string DESCRIPTION { get; set; }
        public double ORDER_QTY { get; set; }
        public double UNIT_PRICE { get; set; }
        public double DISC_PERCENT { get; set; }
        public double LINE_AMOUNT { get; set; }
    }
}
