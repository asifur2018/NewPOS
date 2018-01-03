using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    public class CreditControlModel
    {

        public decimal CREDIT_LIMIT { get; set; }
        public int SETTLEMENT_DUE { get; set; }
        public decimal SETTLEMENT_DISCOUNT { get; set; }
        public int PAYMENT_DUE { get; set; }
        public int AVG_TIME { get; set; }
        public string PAYMENT_FROM { get; set; }
        public string TREDING_TERMS { get; set; }
        public string CREDIT_REF { get; set; }
        public bool IS_PRIORITY { get; set; }
        public string BUREAU { get; set; }
        //public string PAYMENT_FROM { get; set; }
        public string CREDIT_POSITION { get; set; }
        public string ACCOUNT_STATUS { get; set; }
        public string DUNS_NUMBER { get; set; }
        public DateTime ACCOUNT_OPENED { get; set; }
        public string LAST_CREDIT { get; set; }
        public string NEXT_CREDIT { get; set; }
        public DateTime APPLICATION_DATE { get; set; }
        public DateTime DATE_RECEIVED { get; set; }
        public string MEMO { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public bool IS_CHANGE_CREDIT { get; set; }
        public bool IS_TERMS_AGREED { get; set; }
        public bool IS_RESTRICT_MAILING { get; set; }
        public bool IS_ACCOUNT_HOLD { get; set; }
          
    }
}
