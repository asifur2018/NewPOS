using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InvoicePOSAPI.Models;
using InvoicePOSDATA;
using System.Globalization;
using System.Data.Objects.SqlClient;

namespace InvoicePOSAPI.Controllers
{
    public class SalesOrderAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpPost]
        public HttpResponseMessage CreateSalesOrder(SalesOrderModel _SalesOrderModel)
        {

            try
            {

                SALES_ORDER so = new SALES_ORDER();
                so.INVOICE_TO = _SalesOrderModel.INVOICE_TO;
                so.DELIVERY_TO = _SalesOrderModel.DELIVERY_TO;
                so.ORDER_NO = _SalesOrderModel.ORDER_NO;
                so.ORDER_REF = _SalesOrderModel.ORDER_REF;
                so.ORDER_DATE = Convert.ToDateTime(_SalesOrderModel.ORDER_DATE);
                so.SALES_PERSON = _SalesOrderModel.SALES_PERSON;
                so.MARKET_CODE = _SalesOrderModel.MARKET_CODE;
                so.OVERALL_DISC_PER = _SalesOrderModel.OVERALL_DISC_PER;
                so.ORDER_VALUE = _SalesOrderModel.ORDER_VALUE;
                so.STANDARD_DISCOUNT = _SalesOrderModel.STANDARD_DISCOUNT;
                so.TOTAL_VAT = _SalesOrderModel.TOTAL_VAT;
                so.TOTAL_ORDER_VALUE = _SalesOrderModel.TOTAL_ORDER_VALUE;
                so.NET_VALUE = _SalesOrderModel.NET_VALUE;
                if (_SalesOrderModel.MARGIN == "*N/A*")
                {
                    so.MARGIN = 0;
                }
                else
                {
                    so.MARGIN = Convert.ToDecimal(_SalesOrderModel.MARGIN);
                }

                if (_SalesOrderModel.MARGIN_PERCENT == "*N/A*")
                {
                    so.MARGIN_PERCENT = 0;
                }
                else
                {
                    so.MARGIN_PERCENT = Convert.ToDecimal(_SalesOrderModel.MARGIN_PERCENT);
                }

                if (_SalesOrderModel.COST == "*N/A*")
                {
                    so.COST = 0;
                }
                else
                {
                    so.COST = Convert.ToDecimal(_SalesOrderModel.COST);
                }
                db.SALES_ORDER.Add(so);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage GetSalesOrderLineItem(string OrderNo)
        {
            var str = (from a in db.SALES_ORDER_LINE_ITEM
                       where (a.ORDER_NO.Equals(OrderNo))
                       select new SalesOrderLineItemModel
                       {
                           LINE_ITEM_ID = a.LINE_ITEM_ID,
                           ORDER_NO = a.ORDER_NO,
                           PRODUCT_CODE = a.PRODUCT_CODE,
                           DESCRIPTION = a.DESCRIPTION,
                           ORDER_QTY = a.ORDER_QTY??0,
                           UNIT_PRICE = a.UNIT_PRICE ??0,
                           DISCOUNT = a.DISCOUNT ??0,
                           LINE_AMOUNT = a.LINE_AMOUNT??0,
                           VAT = a.VAT
                       }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, str);
            
        }

        [HttpPost]
        public HttpResponseMessage CreateSalesOrderLineItem(SalesOrderLineItemModel _SalesOrderLineItemModel)
        {

            try
            {

                SALES_ORDER_LINE_ITEM solm = new SALES_ORDER_LINE_ITEM();
                solm.ORDER_NO = _SalesOrderLineItemModel.ORDER_NO;
                solm.PRODUCT_CODE = _SalesOrderLineItemModel.PRODUCT_CODE;
                solm.DESCRIPTION = _SalesOrderLineItemModel.DESCRIPTION;
                solm.ORDER_QTY = _SalesOrderLineItemModel.ORDER_QTY;
                solm.UNIT_PRICE = _SalesOrderLineItemModel.UNIT_PRICE;
                solm.DISCOUNT = _SalesOrderLineItemModel.DISCOUNT;
                solm.LINE_AMOUNT = _SalesOrderLineItemModel.LINE_AMOUNT;
                solm.VAT = _SalesOrderLineItemModel.VAT;

                db.SALES_ORDER_LINE_ITEM.Add(solm);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpPost]
        public HttpResponseMessage DeleteSalesOrderLineItems(SalesOrderModel pSalesOrder)
        {

            try
            {
                IEnumerable<SALES_ORDER_LINE_ITEM> salesOrderLineItemList = db.SALES_ORDER_LINE_ITEM.Where(a => a.ORDER_NO.Equals(pSalesOrder.ORDER_NO));

                foreach (SALES_ORDER_LINE_ITEM salesOrderLineItem in salesOrderLineItemList)
                {
                    db.SALES_ORDER_LINE_ITEM.Remove(salesOrderLineItem);
                }
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpPost]
        public HttpResponseMessage CreateSalesOrderVATLine(SalesVatLineModel _SalesVatLineModel)
        {

            try
            {

                SALES_VAT_LINE svl = new SALES_VAT_LINE();
                svl.ORDER_NO = _SalesVatLineModel.ORDER_NO;
                svl.VAT_RATE = _SalesVatLineModel.VAT_RATE;
                svl.DESCRIPTION = _SalesVatLineModel.DESCRIPTION;
                svl.NET_AMOUNT = _SalesVatLineModel.NET_AMOUNT;
                svl.VAT_AMOUNT = _SalesVatLineModel.VAT_AMOUNT;
                svl.TOTAL  = _SalesVatLineModel.TOTAL;
                

                db.SALES_VAT_LINE.Add(svl);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpPost]
        public HttpResponseMessage DeleteSalesOrderVATLineItems(SalesOrderModel pSalesOrder)
        {

            try
            {
                IEnumerable<SALES_VAT_LINE> salesOrderVATLineItemList = db.SALES_VAT_LINE.Where(a => a.ORDER_NO.Equals(pSalesOrder.ORDER_NO));

                foreach (SALES_VAT_LINE salesOrderVATLineItem in salesOrderVATLineItemList)
                {
                    db.SALES_VAT_LINE.Remove(salesOrderVATLineItem);
                }
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage GetSalesOrderVATLine(string OrderNo)
        {
            var str = (from a in db.SALES_VAT_LINE
                       where (a.ORDER_NO.Equals(OrderNo))
                       select new SalesVatLineModel
                       {
                           VAT_LINE_ID = a.LINE_ITEM_ID,
                           ORDER_NO = a.ORDER_NO,
                           VAT_RATE = a.VAT_RATE,
                           DESCRIPTION = a.DESCRIPTION,
                           NET_AMOUNT = a.NET_AMOUNT,
                           VAT_AMOUNT = a.VAT_AMOUNT,
                           TOTAL = a.TOTAL
                       }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, str);

        }

        [HttpPost]
        public HttpResponseMessage CreateSalesOrderCustomerOtherDetails(SalesOrderCustomerOtherDetailsModel _SalesOrderCustomerOtherDetailsModel)
        {

            try
            {

                SALESORDER_CUSTOMER_OTHER_DETAILS socod = new SALESORDER_CUSTOMER_OTHER_DETAILS();

                socod.NO_OF_COPIES = _SalesOrderCustomerOtherDetailsModel.NO_OF_COPIES;
                socod.DEL = _SalesOrderCustomerOtherDetailsModel.DEL;
                socod.MODE = _SalesOrderCustomerOtherDetailsModel.MODE;
                if (_SalesOrderCustomerOtherDetailsModel.EXPECTED_SHIP != null)
                {
                    //socod.EXPECTED_SHIP = DateTime.ParseExact(_SalesOrderCustomerOtherDetailsModel.EXPECTED_SHIP, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                if (_SalesOrderCustomerOtherDetailsModel.EXPECTED_PAYMENT != null)
                {
                    //socod.EXPECTED_PAYMENT = DateTime.ParseExact(_SalesOrderCustomerOtherDetailsModel.EXPECTED_PAYMENT, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (_SalesOrderCustomerOtherDetailsModel.LAST_CHANGE_SYSTEM_DATE != null)
                {
                    //socod.LAST_CHANGE_SYSTEM_DATE = DateTime.ParseExact(_SalesOrderCustomerOtherDetailsModel.LAST_CHANGE_SYSTEM_DATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                socod.EXPECTED_SHIP = _SalesOrderCustomerOtherDetailsModel.EXPECTED_SHIP;
                socod.EXPECTED_PAYMENT = _SalesOrderCustomerOtherDetailsModel.EXPECTED_PAYMENT;
                socod.LAST_CHANGE_SYSTEM_DATE = _SalesOrderCustomerOtherDetailsModel.LAST_CHANGE_SYSTEM_DATE;
                socod.ORDER_NO = _SalesOrderCustomerOtherDetailsModel.ORDER_NO;

                db.SALESORDER_CUSTOMER_OTHER_DETAILS.Add(socod);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage GetSalesOrderCustomerOtherDetails(string OrderNo)
        {
            var str = (from a in db.SALESORDER_CUSTOMER_OTHER_DETAILS
                       where (a.ORDER_NO.Equals(OrderNo))
                       select new SalesOrderCustomerOtherDetailsModel
                       {
                           OTHER_DETAILS_ID = a.OTHER_DETAILS_ID,
                           NO_OF_COPIES = (int)a.NO_OF_COPIES,
                           DEL = a.DEL,
                           MODE = a.MODE,
                          // EXPECTED_SHIP = SqlFunctions.DateName("day",a.EXPECTED_SHIP) + "/" 
                          // + SqlFunctions.DateName("month",a.EXPECTED_SHIP) + "/" + SqlFunctions.DateName("year", a.EXPECTED_SHIP),
                          // EXPECTED_PAYMENT = SqlFunctions.DateName("day", a.EXPECTED_PAYMENT) + "/"
                          // + SqlFunctions.DateName("month", a.EXPECTED_PAYMENT) + "/" + SqlFunctions.DateName("year", a.EXPECTED_PAYMENT),
                           //LAST_CHANGE_SYSTEM_DATE = SqlFunctions.DateName("day", a.LAST_CHANGE_SYSTEM_DATE) + "/"
                           //+ SqlFunctions.DateName("month", a.LAST_CHANGE_SYSTEM_DATE) + "/" + SqlFunctions.DateName("year", a.LAST_CHANGE_SYSTEM_DATE),
                           EXPECTED_SHIP = a.EXPECTED_SHIP,
                           EXPECTED_PAYMENT = a.EXPECTED_PAYMENT,
                           LAST_CHANGE_SYSTEM_DATE = a.LAST_CHANGE_SYSTEM_DATE,
                           ORDER_NO = a.ORDER_NO
                           
                       }).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, str);

        }

        [HttpPost]
        public HttpResponseMessage DeleteSalesOrderCustomerOtherDetails(SalesOrderModel pSalesOrder)
        {

            try
            {
                IEnumerable<SALESORDER_CUSTOMER_OTHER_DETAILS> salesOrderCustomerOtherDetailsList = db.SALESORDER_CUSTOMER_OTHER_DETAILS.Where(a => a.ORDER_NO.Equals(pSalesOrder.ORDER_NO));

                foreach (SALESORDER_CUSTOMER_OTHER_DETAILS salesOrderCustomerOtherDetails in salesOrderCustomerOtherDetailsList)
                {
                    db.SALESORDER_CUSTOMER_OTHER_DETAILS.Remove(salesOrderCustomerOtherDetails);
                }
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpPost]
        public HttpResponseMessage CreateSalesOrderCustomerInvoiceTo(SalesOrderCustomerInvoiceToModel _SalesOrderCustomerInvoiceToModel)
        {

            try
            {

                SALESORDER_CUSTOMER_INVOICE_TO socit = new SALESORDER_CUSTOMER_INVOICE_TO();
                socit.CODE = _SalesOrderCustomerInvoiceToModel.CODE;
                socit.NAME = _SalesOrderCustomerInvoiceToModel.NAME;
                socit.ADDRESS = _SalesOrderCustomerInvoiceToModel.ADDRESS;
                socit.POSTCODE = _SalesOrderCustomerInvoiceToModel.POSTCODE;
                socit.COUNTRY = _SalesOrderCustomerInvoiceToModel.COUNTRY;
                socit.CONTACT = _SalesOrderCustomerInvoiceToModel.CONTACT;
                socit.EC = _SalesOrderCustomerInvoiceToModel.EC;
                socit.ORDER_NO = _SalesOrderCustomerInvoiceToModel.ORDER_NO;
                

                db.SALESORDER_CUSTOMER_INVOICE_TO.Add(socit);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage GetSalesOrderCustomerInvoiceTo(string OrderNo)
        {
            var str = (from a in db.SALESORDER_CUSTOMER_INVOICE_TO
                       where (a.ORDER_NO.Equals(OrderNo))
                       select new SalesOrderCustomerInvoiceToModel
                       {
                            SALESORDER_CUSTOMER_INVOICE_TO_ID = a.SALESORDER_CUSTOMER_INVOICE_TO_ID,
                            CODE = a.CODE,
                            NAME = a.NAME,
                            ADDRESS = a.ADDRESS,
                            POSTCODE = a.POSTCODE,
                            COUNTRY = a.COUNTRY,
                            CONTACT = a.CONTACT,
                            EC = a.EC,
                            ORDER_NO = a.ORDER_NO
                           

                       }).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, str);

        }


        [HttpPost]
        public HttpResponseMessage DeleteSalesOrderCustomerInvoiceTo(SalesOrderModel pSalesOrder)
        {

            try
            {
                IEnumerable<SALESORDER_CUSTOMER_INVOICE_TO> salesOrderCustomerInvoiceToList = db.SALESORDER_CUSTOMER_INVOICE_TO.Where(a => a.ORDER_NO.Equals(pSalesOrder.ORDER_NO));

                foreach (SALESORDER_CUSTOMER_INVOICE_TO salesOrderCustomerInvoiceTo in salesOrderCustomerInvoiceToList)
                {
                    db.SALESORDER_CUSTOMER_INVOICE_TO.Remove(salesOrderCustomerInvoiceTo);
                }
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage CreateSalesOrderCustomerDeliveryTo(SalesOrderCustomerDeliveryToModel _SalesOrderCustomerDeliveryToModel)
        {

            try
            {

                SALESORDER_CUSTOMER_DELIVERY_TO socdt = new SALESORDER_CUSTOMER_DELIVERY_TO();
                socdt.CODE = _SalesOrderCustomerDeliveryToModel.CODE;
                socdt.NAME = _SalesOrderCustomerDeliveryToModel.NAME;
                socdt.ADDRESS = _SalesOrderCustomerDeliveryToModel.ADDRESS;
                socdt.POSTCODE = _SalesOrderCustomerDeliveryToModel.POSTCODE;
                socdt.COUNTRY = _SalesOrderCustomerDeliveryToModel.COUNTRY;
                socdt.CONTACT = _SalesOrderCustomerDeliveryToModel.CONTACT;
                socdt.ORDER_NO = _SalesOrderCustomerDeliveryToModel.ORDER_NO;

                db.SALESORDER_CUSTOMER_DELIVERY_TO.Add(socdt);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpGet]
        public HttpResponseMessage GetSalesOrderCustomerDeliveryTo(string OrderNo)
        {
            var str = (from a in db.SALESORDER_CUSTOMER_DELIVERY_TO
                       where (a.ORDER_NO.Equals(OrderNo))
                       select new SalesOrderCustomerDeliveryToModel
                       {
                           SALESORDER_CUSTOMER_DELIVERY_TO_ID = a.SALESORDER_CUSTOMER_DELIVERY_TO_ID,
                           CODE = a.CODE,
                           NAME = a.NAME,
                           ADDRESS = a.ADDRESS,
                           POSTCODE = a.POSTCODE,
                           COUNTRY = a.COUNTRY,
                           CONTACT = a.CONTACT,
                           ORDER_NO = a.ORDER_NO


                       }).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, str);

        }

        [HttpPost]
        public HttpResponseMessage DeleteSalesOrderCustomerDeliveryTo(SalesOrderModel pSalesOrder)
        {

            try
            {
                IEnumerable<SALESORDER_CUSTOMER_DELIVERY_TO> salesOrderCustomerDeliveryToList = db.SALESORDER_CUSTOMER_DELIVERY_TO.Where(a => a.ORDER_NO.Equals(pSalesOrder.ORDER_NO));

                foreach (SALESORDER_CUSTOMER_DELIVERY_TO salesOrderCustomerDeliveryTo in salesOrderCustomerDeliveryToList)
                {
                    db.SALESORDER_CUSTOMER_DELIVERY_TO.Remove(salesOrderCustomerDeliveryTo);
                }
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage GetSalesOrderList()
        {

            try
            {

                var str = (from a in db.SALES_ORDER
                           select new SalesOrderModel
                           {
                               SALESORDER_ID = a.SALESORDER_ID,
                               INVOICE_TO = a.INVOICE_TO,
                               DELIVERY_TO = a.DELIVERY_TO,
                               ORDER_NO = a.ORDER_NO,
                               ORDER_REF = a.ORDER_REF,
                               ORDER_DATE = a.ORDER_DATE??new DateTime(),
                               SALES_PERSON = a.SALES_PERSON,
                               MARKET_CODE = a.MARKET_CODE,
                               OVERALL_DISC_PER = a.OVERALL_DISC_PER??0,
                               ORDER_VALUE = a.ORDER_VALUE??0,
                               STANDARD_DISCOUNT = a.STANDARD_DISCOUNT??0,
                               TOTAL_VAT = a.TOTAL_VAT??0,
                               TOTAL_ORDER_VALUE = a.TOTAL_ORDER_VALUE??0,
                               COST = SqlFunctions.StringConvert((double)a.COST),
                               MARGIN = SqlFunctions.StringConvert((double)a.MARGIN),
                               MARGIN_PERCENT = SqlFunctions.StringConvert((double)a.MARGIN_PERCENT),
                               NET_VALUE = a.NET_VALUE??0
                               

                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public HttpResponseMessage GetSalesOrderListForCustomer(string pCustCode)
        {

            try
            {

                var str = (from a in db.SALES_ORDER
                           where (a.INVOICE_TO.Equals(pCustCode))
                           select new SalesOrderModel
                           {
                               SALESORDER_ID = a.SALESORDER_ID,
                               INVOICE_TO = a.INVOICE_TO,
                               DELIVERY_TO = a.DELIVERY_TO,
                               ORDER_NO = a.ORDER_NO,
                               ORDER_REF = a.ORDER_REF,
                               ORDER_DATE = a.ORDER_DATE ?? new DateTime(),
                               SALES_PERSON = a.SALES_PERSON,
                               MARKET_CODE = a.MARKET_CODE,
                               OVERALL_DISC_PER = a.OVERALL_DISC_PER ?? 0,
                               ORDER_VALUE = a.ORDER_VALUE ?? 0,
                               STANDARD_DISCOUNT = a.STANDARD_DISCOUNT ?? 0,
                               TOTAL_VAT = a.TOTAL_VAT ?? 0,
                               TOTAL_ORDER_VALUE = a.TOTAL_ORDER_VALUE ?? 0,
                               COST = SqlFunctions.StringConvert((double)a.COST),
                               MARGIN = SqlFunctions.StringConvert((double)a.MARGIN),
                               MARGIN_PERCENT = SqlFunctions.StringConvert((double)a.MARGIN_PERCENT),
                               NET_VALUE = a.NET_VALUE ?? 0


                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }


        [HttpPost]
        public HttpResponseMessage DeleteSalesOrder(SalesOrderModel pSalesOrder)
        {

            try
            {
                IEnumerable<SALES_ORDER> salesOrderList = db.SALES_ORDER.Where(a => a.ORDER_NO.Equals(pSalesOrder.ORDER_NO));

                foreach (SALES_ORDER salesOrder in salesOrderList)
                {
                    db.SALES_ORDER.Remove(salesOrder);
                }
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

    }
}
