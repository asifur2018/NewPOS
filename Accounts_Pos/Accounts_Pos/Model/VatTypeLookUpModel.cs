using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_Pos.Model
{
    class VatTypeLookUpModel
    {
        public string VAT_TYPE_NAME { get; set; }
        public bool DELIVERY_TYPE_APPLICABLE { get; set; }
        public bool DELIVERY_MODE { get; set; }
        public int VAT_TYPE_ID { get; set; }
    }
}
