using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InvoicePOSAPI.Models;
using InvoicePOSDATA;

namespace InvoicePOSAPI.Controllers
{

        
        
    public class ProductAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();
        ProductModel pm = new ProductModel();

        [HttpGet]
        public HttpResponseMessage GetProducts(int id)
        {
            var str = (from a in db.PRODUCTs
                       where a.COMPANY_ID == id && a.IS_DELETE == false
                       select new ProductModel
                       {

                           PRODUCT_CODE = a.PRODUCT_CODE,
                           DESCRIPTION = a.DESCRIPTION,
                           BIN = a.BIN,
                           PRODUCT_TYPE1 = a.PRODUCT_TYPE1,
                           DISCONTINUED = a.DISCONTINUED,
                           PRODUCT_ID = a.PRODUCT_ID,
                           RETAIL_STANDARD=0,
                           WEIGHT=0,
                           QUANTITY=0,
                           COST_PRICE=0,
                           LAST_SALE=0,
                           RETAIL_PRICE=0,
                           TRADE=0,
                           WHOLESALE=0,
                           TRADE_DISC=0,
                           WHOLESALE_DISC=0,
                           RETAIL_MARGIN=0,
                           TRADE_MARGIN=0,
                           WHOLESALE_MARGIN=0,
                           SELL_PRICE1=0,
                           SELL_PRICE2=0,
                           SELL_PRICE3=0,
                           SELL_PRICE4=0,
                           SELL_QTY2=0,
                           SELL_QTY3=0,
                           SELL_QTY4=0,
                           SELL_MARGIN2=0,
                           SELL_MARGIN3=0,
                           SELL_MARGIN4=0,

                           
                           //POSTCODE = a.POSTCODE,
                           //PRODUCT_ID = a.PRODUCT_ID,
                           //FAX = a.FAX,

                       }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, str);
        }

        [HttpGet]
        public HttpResponseMessage GetProductsAssembled(int id, int pid)
        {
            var str = (from a in db.PRODUCTs
                       where a.COMPANY_ID == id && a.PRODUCT_ID==pid && a.IS_DELETE == false
                       select new ProductModel
                       {

                           PRODUCT_CODE = a.PRODUCT_CODE,
                           DESCRIPTION = a.DESCRIPTION,
                           BIN = a.BIN,
                           PRODUCT_TYPE1 = a.PRODUCT_TYPE1,
                           DISCONTINUED = a.DISCONTINUED,
                           PRODUCT_ID = a.PRODUCT_ID,
                           RETAIL_STANDARD = 0,
                           WEIGHT = 0,
                           QUANTITY = 0,
                           COST_PRICE = 0,
                           LAST_SALE = 0,
                           RETAIL_PRICE = 0,
                           TRADE = 0,
                           WHOLESALE = 0,
                           TRADE_DISC = 0,
                           WHOLESALE_DISC = 0,
                           RETAIL_MARGIN = 0,
                           TRADE_MARGIN = 0,
                           WHOLESALE_MARGIN = 0,
                           SELL_PRICE1 = 0,
                           SELL_PRICE2 = 0,
                           SELL_PRICE3 = 0,
                           SELL_PRICE4 = 0,
                           SELL_QTY2 = 0,
                           SELL_QTY3 = 0,
                           SELL_QTY4 = 0,
                           SELL_MARGIN2 = 0,
                           SELL_MARGIN3 = 0,
                           SELL_MARGIN4 = 0,


                           //POSTCODE = a.POSTCODE,
                           //PRODUCT_ID = a.PRODUCT_ID,
                           //FAX = a.FAX,

                       }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, str);
        }




        [HttpGet]
        public HttpResponseMessage GetProduct(int id)
        {
            var str = (from a in db.PRODUCTs
                       where a.PRODUCT_ID == id && a.IS_DELETE == false
                       select new ProductModel
                       {

                           PRODUCT_CODE = a.PRODUCT_CODE,
                           DESCRIPTION = a.DESCRIPTION,
                           BIN = a.BIN,
                           PRODUCT_TYPE1 = a.PRODUCT_TYPE1,
                           DISCONTINUED = a.DISCONTINUED,
                           PRODUCT_ID = a.PRODUCT_ID,
                           RETAIL_STANDARD = 0,
                           WEIGHT = 0,
                           QUANTITY = 0,
                           COST_PRICE = 0,
                           LAST_SALE = 0,
                           RETAIL_PRICE = 0,
                           TRADE = 0,
                           WHOLESALE = 0,
                           TRADE_DISC = 0,
                           WHOLESALE_DISC = 0,
                           RETAIL_MARGIN = 0,
                           TRADE_MARGIN = 0,
                           WHOLESALE_MARGIN = 0,
                           SELL_PRICE1 = 0,
                           SELL_PRICE2 = 0,
                           SELL_PRICE3 = 0,
                           SELL_PRICE4 = 0,
                           SELL_QTY2 = 0,
                           SELL_QTY3 = 0,
                           SELL_QTY4 = 0,
                           SELL_MARGIN2 = 0,
                           SELL_MARGIN3 = 0,
                           SELL_MARGIN4 = 0,


                           //POSTCODE = a.POSTCODE,
                           //PRODUCT_ID = a.PRODUCT_ID,
                           //FAX = a.FAX,

                       }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, str);
        }

        [HttpPost]
        public HttpResponseMessage CreateProduct(ProductModel _ProductModel)
        {

            try
            {

                PRODUCT pdt = new PRODUCT();
                pdt.PRODUCT_CODE = _ProductModel.PRODUCT_CODE;
                pdt.DESCRIPTION = _ProductModel.DESCR;
                pdt.BIN = _ProductModel.BIN;
                pdt.PRODUCT_TYPE1 = _ProductModel.PRODUCT_TYPE1;
                pdt.PRODUCT_TYPE2 = _ProductModel.PRODUCT_TYPE2;
                pdt.VAT_RATE = _ProductModel.VAT_RATE;
                pdt.GROUP= _ProductModel.GROUP;
                pdt.DISCONTINUED = _ProductModel.DISCONTINUED;
                pdt.COMMISSION = _ProductModel.COMMISSION;
                pdt.BAR_CODE = _ProductModel.BAR_CODE;
                pdt.UNIT_DESC = _ProductModel.UNIT_DESC;
                pdt.ALTERNATIVE = _ProductModel.ALTERNATIVE;
                pdt.WEIGHT = _ProductModel.WEIGHT;
                pdt.QUANTITY = _ProductModel.QUANTITY;
                pdt.COST_PRICE = _ProductModel.COST_PRICE;
                pdt.LAST_SALE = _ProductModel.LAST_SALE;
                pdt.RETAIL_PRICE = _ProductModel.RETAIL_PRICE;
                pdt.RETAIL_STANDARD = _ProductModel.RETAIL_STANDARD;
                pdt.TRADE = _ProductModel.TRADE;
                pdt.WHOLESALE = _ProductModel.WHOLESALE;
                pdt.TRADE_DISC = _ProductModel.TRADE_DISC;
                pdt.WHOLESALE_DISC = _ProductModel.WHOLESALE_DISC;
                pdt.RETAIL_MARGIN = _ProductModel.RETAIL_MARGIN;
                pdt.TRADE_MARGIN = _ProductModel.TRADE_MARGIN;
                pdt.WHOLESALE_MARGIN = _ProductModel.WHOLESALE_MARGIN;
                pdt.SELL_PRICE1 = _ProductModel.SELL_PRICE1;
                pdt.SELL_PRICE2 = _ProductModel.SELL_PRICE2;
                pdt.SELL_PRICE3 = _ProductModel.SELL_PRICE3;
                pdt.SELL_PRICE4 = _ProductModel.SELL_PRICE4;
                pdt.SELL_QTY2 = _ProductModel.SELL_QTY2;
                pdt.SELL_QTY3 = _ProductModel.SELL_QTY3;
                pdt.SELL_QTY4 = _ProductModel.SELL_QTY4;
                pdt.SELL_MARGIN2 = _ProductModel.SELL_MARGIN2;
                pdt.SELL_MARGIN3 = _ProductModel.SELL_MARGIN3;
                pdt.SELL_MARGIN4 = _ProductModel.SELL_MARGIN4;
                pdt.IS_DELETE = false;
                pdt.STATUS = "Un-Saved";
                db.PRODUCTs.Add(pdt);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage EditProducts(int id)
        {
            var str = (from a in db.PRODUCTs
                       where a.PRODUCT_ID == id && a.IS_DELETE == false
                       select new ProductModel
                       {
                           

                PRODUCT_CODE = a.PRODUCT_CODE,
                //DESCRIPTION = a.DESCRIPTION,
                DESCR = a.DESCRIPTION,
                BIN = a.BIN,
                PRODUCT_TYPE1 = a.PRODUCT_TYPE1,
                PRODUCT_TYPE2 = a.PRODUCT_TYPE2,
                VAT_RATE = a.VAT_RATE,
                GROUP= a.GROUP,
                DISCONTINUED = a.DISCONTINUED,
                COMMISSION = a.COMMISSION,
                BAR_CODE = a.BAR_CODE,
                UNIT_DESC = a.UNIT_DESC,
                ALTERNATIVE = a.ALTERNATIVE,
                WEIGHT = a.WEIGHT,
                QUANTITY = a.QUANTITY,
                COST_PRICE = a.COST_PRICE,
                LAST_SALE = a.LAST_SALE,
                RETAIL_PRICE = a.RETAIL_PRICE,
                RETAIL_STANDARD = a.RETAIL_STANDARD,
                TRADE = a.TRADE,
                WHOLESALE = a.WHOLESALE,
                TRADE_DISC = a.TRADE_DISC,
                WHOLESALE_DISC = a.WHOLESALE_DISC,
                RETAIL_MARGIN = a.RETAIL_MARGIN,
                TRADE_MARGIN = a.TRADE_MARGIN,
                WHOLESALE_MARGIN = a.WHOLESALE_MARGIN,
                SELL_PRICE1 = a.SELL_PRICE1,
                SELL_PRICE2 = a.SELL_PRICE2,
                SELL_PRICE3 = a.SELL_PRICE3,
                SELL_PRICE4 = a.SELL_PRICE4,
                SELL_QTY2 = a.SELL_QTY2,
                SELL_QTY3 = a.SELL_QTY3,
                SELL_QTY4 = a.SELL_QTY4,
                SELL_MARGIN2 = a.SELL_MARGIN2,
                SELL_MARGIN3 = a.SELL_MARGIN3,
                SELL_MARGIN4 = a.SELL_MARGIN4,

                                   }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, str);
        }

        [HttpPost]
        public HttpResponseMessage ProductUpdate(ProductModel _ProductModel)
        {
            var pdt = (from a in db.PRODUCTs where a.PRODUCT_ID == _ProductModel.PRODUCT_ID select a).FirstOrDefault();
            pdt.PRODUCT_CODE = _ProductModel.PRODUCT_CODE;
            pdt.DESCRIPTION = _ProductModel.DESCR;
            pdt.BIN = _ProductModel.BIN;
            pdt.PRODUCT_TYPE1 = _ProductModel.PRODUCT_TYPE1;
            pdt.PRODUCT_TYPE2 = _ProductModel.PRODUCT_TYPE2;
            pdt.VAT_RATE = _ProductModel.VAT_RATE;
            pdt.GROUP = _ProductModel.GROUP;
            pdt.DISCONTINUED = _ProductModel.DISCONTINUED;
            pdt.COMMISSION = _ProductModel.COMMISSION;
            pdt.BAR_CODE = _ProductModel.BAR_CODE;
            pdt.UNIT_DESC = _ProductModel.UNIT_DESC;
            pdt.ALTERNATIVE = _ProductModel.ALTERNATIVE;
            pdt.WEIGHT = _ProductModel.WEIGHT;
            pdt.QUANTITY = _ProductModel.QUANTITY;
            pdt.COST_PRICE = _ProductModel.COST_PRICE;
            pdt.LAST_SALE = _ProductModel.LAST_SALE;
            pdt.RETAIL_PRICE = _ProductModel.RETAIL_PRICE;
            pdt.RETAIL_STANDARD = _ProductModel.RETAIL_STANDARD;
            pdt.TRADE = _ProductModel.TRADE;
            pdt.WHOLESALE = _ProductModel.WHOLESALE;
            pdt.TRADE_DISC = _ProductModel.TRADE_DISC;
            pdt.WHOLESALE_DISC = _ProductModel.WHOLESALE_DISC;
            pdt.RETAIL_MARGIN = _ProductModel.RETAIL_MARGIN;
            pdt.TRADE_MARGIN = _ProductModel.TRADE_MARGIN;
            pdt.WHOLESALE_MARGIN = _ProductModel.WHOLESALE_MARGIN;
            pdt.SELL_PRICE1 = _ProductModel.SELL_PRICE1;
            pdt.SELL_PRICE2 = _ProductModel.SELL_PRICE2;
            pdt.SELL_PRICE3 = _ProductModel.SELL_PRICE3;
            pdt.SELL_PRICE4 = _ProductModel.SELL_PRICE4;
            pdt.SELL_QTY2 = _ProductModel.SELL_QTY2;
            pdt.SELL_QTY3 = _ProductModel.SELL_QTY3;
            pdt.SELL_QTY4 = _ProductModel.SELL_QTY4;
            pdt.SELL_MARGIN2 = _ProductModel.SELL_MARGIN2;
            pdt.SELL_MARGIN3 = _ProductModel.SELL_MARGIN3;
            pdt.SELL_MARGIN4 = _ProductModel.SELL_MARGIN4;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }



        [HttpPost]
        public HttpResponseMessage CreateMiscellaneous_Product(ProductModel _ProductModel)
        {

            try
            {

                PRODUCT_MISCELLANEOUS pd = new PRODUCT_MISCELLANEOUS();
                pd.PRODUCT_CODE = _ProductModel.PRODUCT_CODE;
                //pd.DESCRIPTION = _ProductModel.DESCRIPTION;
                //pd.BIN = _ProductModel.BIN;
                pd.SALES_AC1 = _ProductModel.SALES_AC1;
                pd.SALES_AC2 = _ProductModel.SALES_AC2;
                pd.SALES_AC3 = _ProductModel.SALES_AC3;
                pd.SALES_AC4 = _ProductModel.SALES_AC4;
                pd.SALES_AC5 = _ProductModel.SALES_AC5;

                pd.PERCENT1 = _ProductModel.PERCENT1;
                pd.PERCENT2 = _ProductModel.PERCENT2;
                pd.PERCENT3 = _ProductModel.PERCENT3;
                pd.PERCENT4 = _ProductModel.PERCENT4;
                pd.PERCENT5 = _ProductModel.PERCENT5;

                pd.PERCENT1_CAL1 = _ProductModel.PERCENT1_CAL1;
                pd.PERCENT1_CAL2 = _ProductModel.PERCENT1_CAL2;
                pd.PERCENT1_CAL3 = _ProductModel.PERCENT1_CAL3;



                pd.DESCRIPTION1 = _ProductModel.DESCRIPTION1;
                pd.DESCRIPTION2 = _ProductModel.DESCRIPTION2;
                pd.DESCRIPTION3 = _ProductModel.DESCRIPTION3;
                pd.DESCRIPTION4 = _ProductModel.DESCRIPTION4;
                pd.DESCRIPTION5 = _ProductModel.DESCRIPTION5;



                pd.REORDER = _ProductModel.REORDER;
                pd.MS_QUANTITY = _ProductModel.MS_QUANTITY;
                pd.SUPPLIER_CODE1 = _ProductModel.SUPPLIER_CODE1;
                pd.SUPPLIER_CODE2 = _ProductModel.SUPPLIER_CODE2;

                pd.CODE = _ProductModel.CODE;
                pd.MIN_ORDER = _ProductModel.MIN_ORDER;
                pd.DESC = _ProductModel.DESC;

                    
                
                pd.STATUS = "Un-Saved";
                db.PRODUCT_MISCELLANEOUS.Add(pd);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage CreateProductPicture(ProductModel _ProductModel)
        {

            try
            {
                PRODUCT_PICTURE pp = new PRODUCT_PICTURE();
               // pp.PICTURE_ID = _ProductPictureModel.PICTURE_ID;
                pm.PICTURE_NAME = _ProductModel.PICTURE_NAME;
                pm.PRODUCT_CODE = _ProductModel.PRODUCT_CODE;

                db.PRODUCT_PICTURE.Add(pp);
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage DeleteProduct(int id)
        {
            var str = (from a in db.PRODUCTs
                       where a.PRODUCT_ID == id
                       select a).FirstOrDefault();
            str.IS_DELETE = true;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage GetProduct(string _ProductCode)
        {

            try
            {

                var str = (from a in db.PRODUCTs
                           where ((a.PRODUCT_CODE.Equals(_ProductCode)) && (a.IS_DELETE == false))
                           select new ProductModel
                           {
                               PRODUCT_ID = a.PRODUCT_ID,
                               COMPANY_ID = a.COMPANY_ID,
                               PRODUCT_CODE = a.PRODUCT_CODE,
                               DESCRIPTION = a.DESCRIPTION,
                               BIN = a.BIN,
                               PRODUCT_TYPE1 = a.PRODUCT_TYPE1,
                               PRODUCT_TYPE2 = a.PRODUCT_TYPE2,
                               VAT_RATE = a.VAT_RATE,
                               GROUP = a.GROUP,
                               DISCONTINUED = a.DISCONTINUED,
                               COMMISSION = a.COMMISSION,
                               BAR_CODE = a.BAR_CODE,
                               UNIT_DESC = a.UNIT_DESC,
                               ALTERNATIVE = a.ALTERNATIVE,
                               WEIGHT = a.WEIGHT,
                               QUANTITY = a.QUANTITY,
                               COST_PRICE = a.COST_PRICE,
                               LAST_SALE = a.LAST_SALE,
                               RETAIL_PRICE = a.RETAIL_PRICE,
                               RETAIL_STANDARD = a.RETAIL_STANDARD,
                               TRADE = a.TRADE,
                               WHOLESALE = a.WHOLESALE,
                               TRADE_DISC = a.TRADE_DISC,
                               WHOLESALE_DISC = a.WHOLESALE_DISC,
                               RETAIL_MARGIN = a.RETAIL_MARGIN,
                               TRADE_MARGIN = a.TRADE_MARGIN,
                               WHOLESALE_MARGIN = a.WHOLESALE_MARGIN,
                               SELL_PRICE1 = a.SELL_PRICE1,
                               SELL_PRICE2 = a.SELL_PRICE2,
                               SELL_PRICE3 = a.SELL_PRICE3,
                               SELL_PRICE4 = a.SELL_PRICE4,
                               SELL_QTY2 = a.SELL_QTY2,
                               SELL_QTY3 = a.SELL_QTY3,
                               SELL_QTY4 = a.SELL_QTY4,
                               SELL_MARGIN2 = a.SELL_MARGIN2,
                               SELL_MARGIN3 = a.SELL_MARGIN3,
                               SELL_MARGIN4 = a.SELL_MARGIN4,
                               IS_DELETE = a.IS_DELETE,
                               STATUS = a.STATUS


                           }).FirstOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }

    }
}
