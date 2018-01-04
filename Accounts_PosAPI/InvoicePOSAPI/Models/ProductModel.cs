using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class ProductModel
    {

        public int? COMPANY_ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string DESCR { get; set; }
        public string BIN { get; set; }
        public string PRODUCT_TYPE1 { get; set; }
        public string PRODUCT_TYPE2 { get; set; }
        public string VAT_RATE { get; set; }
        public string GROUP { get; set; }
        public string DISCONTINUED { get; set; }
        public string COMMISSION { get; set; }
        public string BAR_CODE { get; set; }
        public string UNIT_DESC { get; set; }
        public string ALTERNATIVE { get; set; }
        public decimal? WEIGHT { get; set; }
        public decimal? QUANTITY { get; set; }
        public decimal? COST_PRICE { get; set; }
        public decimal? LAST_SALE { get; set; }
        public decimal? RETAIL_PRICE { get; set; }
        public decimal? RETAIL_STANDARD { get; set; }
        public decimal? TRADE { get; set; }
        public decimal? WHOLESALE { get; set; }
        public decimal? TRADE_DISC { get; set; }
        public decimal? WHOLESALE_DISC { get; set; }
        public decimal? RETAIL_MARGIN { get; set; }
        public decimal? TRADE_MARGIN { get; set; }
        public decimal? WHOLESALE_MARGIN { get; set; }
        public decimal? SELL_PRICE1 { get; set; }
        public decimal? SELL_PRICE2 { get; set; }
        public decimal? SELL_PRICE3 { get; set; }
        public decimal? SELL_PRICE4 { get; set; }
        public decimal? SELL_QTY2 { get; set; }
        public decimal? SELL_QTY3 { get; set; }
        public decimal? SELL_QTY4 { get; set; }
        public decimal? SELL_MARGIN2 { get; set; }
        public decimal? SELL_MARGIN3 { get; set; }
        public decimal? SELL_MARGIN4 { get; set; }
        public bool? IS_DELETE { get; set; }
        public int SLNO { get; set; }
        public int PRODUCT_ID { get; set; }


        public decimal SALES_AC1 { get; set; }
        public decimal SALES_AC2 { get; set; }
        public decimal SALES_AC3 { get; set; }
        public decimal SALES_AC4 { get; set; }
        public decimal SALES_AC5 { get; set; }
        public decimal PERCENT1 { get; set; }
        public decimal PERCENT2 { get; set; }
        public decimal PERCENT3 { get; set; }
        public decimal PERCENT4 { get; set; }
        public decimal PERCENT5 { get; set; }
        public decimal PERCENT1_CAL1 { get; set; }
        public decimal PERCENT1_CAL2 { get; set; }
        public decimal PERCENT1_CAL3 { get; set; }
        public string DESCRIPTION1 { get; set; }
        public string DESCRIPTION2 { get; set; }
        public string DESCRIPTION3 { get; set; }
        public string DESCRIPTION4 { get; set; }
        public string DESCRIPTION5 { get; set; }
        public string CODE { get; set; }
        public decimal MIN_ORDER { get; set; }
        public string DESC { get; set; }
        public decimal REORDER { get; set; }
        public decimal MS_QUANTITY { get; set; }
        public string SUPPLIER_CODE1 { get; set; }
        public string SUPPLIER_CODE2 { get; set; }
        public string GROUP1 { get; set; }
        public string GROUP2 { get; set; }
        public string GROUP3 { get; set; }
        public string GROUP4 { get; set; }
        public string GROUP5 { get; set; }
                
        public int PICTURE_ID { get; set; }
        public string PICTURE_NAME { get; set; }

        public string STATUS { get; set; }

    }
}