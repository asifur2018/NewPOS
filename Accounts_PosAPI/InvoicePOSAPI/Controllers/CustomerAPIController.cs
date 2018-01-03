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
    public class CustomerAPIController : ApiController
    {
        

        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();
        CustomerModel cm = new CustomerModel();


        [HttpGet]
        public HttpResponseMessage GetCustomers(int id)
        {
            var str = (from a in db.CUSTOMERs
                       where a.COMPANY_ID == id && a.IS_DELETE == false
                       select new CustomerModel
                       {

                           CUSTOMER_CODE = a.CUSTOMER_CODE,
                           CUSTOMER_NAME = a.CUSTOMER_NAME,
                           ADDRESS = a.ADDRESS,
                           COUNTRY = a.COUNTRY,
                           POSTCODE = a.POSTCODE,
                           CUSTOMER_ID = a.CUSTOMER_ID,
                           //RETAIL_STANDARD = 0,
                           DATE_STARTED = System.DateTime.Now,
                           IS_SUPPLIER=false,
                           
                       }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, str);
        }

        
        [HttpPost]
        public HttpResponseMessage CreateCustomer(CustomerModel _CustomerModel)
        {
                    try
            {

                CUSTOMER cus = new CUSTOMER();
                cus.CUSTOMER_CODE = _CustomerModel.CUSTOMER_CODE;
                cus.CUSTOMER_NAME = _CustomerModel.CUSTOMER_NAME;
                cus.ADDRESS = _CustomerModel.ADDRESS;
                cus.VAT_NUMBER = _CustomerModel.VAT_NUMBER;
                cus.POSTCODE = _CustomerModel.POSTCODE;
                cus.COUNTRY = _CustomerModel.COUNTRY;
                cus.WEBSITE = _CustomerModel.WEBSITE;

                cus.VAT_TYPE = _CustomerModel.VAT_TYPE;

                cus.PRICE_TYPE = _CustomerModel.PRICE_TYPE;
                //cus.DATES_STARTED = _CustomerModel.DATE_STARTED;
                cus.DYNAMIC_DISC = _CustomerModel.DYNAMIC_DISC;
                cus.SEND_MAIL = _CustomerModel.SEND_MAIL;
                //cus.COMPANY_ID = _CustomerModel.COMPANY_ID;
                cus.CUSTOMER_STATUS = _CustomerModel.CUSTOMER_INACTIVE;
                cus.REGISTERED = _CustomerModel.REGISTERED;
                cus.DUNS_NO = _CustomerModel.DUNS_NO;
                cus.STATEMENT = _CustomerModel.STATEMENT;
                cus.IS_SUPPLIER = _CustomerModel.IS_SUPPLIER;

                cus.CONTACT_TYPE = _CustomerModel.CONTACT_TYPE;
                cus.CONTACT_NAME = _CustomerModel.CONTACT_NAME;
                cus.CONTACT_SALUTATION = _CustomerModel.CONTACT_SALUTATION;
                cus.CONTACT_PHONE_NO = _CustomerModel.CONTACT_PHONE_NO;
                cus.CONTACT_EXTN_NO = _CustomerModel.CONTACT_EXTN_NO;
                cus.CONTACT_MOBILE_NO = _CustomerModel.CONTACT_MOBILE_NO;
                cus.CONTACT_FAX = _CustomerModel.CONTACT_FAX;
                cus.EMAIL = _CustomerModel.EMAIL;
                cus.SKYPE = _CustomerModel.SKYPE;

                cus.IS_DELETE = false;
                cus.STATUS = "UnSaved";
                db.CUSTOMERs.Add(cus);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage EditCustomers(int id)
        {
            var str = (from a in db.CUSTOMERs
                       where a.CUSTOMER_ID == id && a.IS_DELETE == false
                       select new CustomerModel
                       {


                CUSTOMER_CODE = a.CUSTOMER_CODE,
                CUSTOMER_ID=a.CUSTOMER_ID,
                CUSTOMER_NAME = a.CUSTOMER_NAME,
                ADDRESS = a.ADDRESS,
                VAT_NUMBER = a.VAT_NUMBER,
                POSTCODE = a.POSTCODE,
                COUNTRY = a.COUNTRY,
                WEBSITE = a.WEBSITE,

                VAT_TYPE = a.VAT_TYPE,

                PRICE_TYPE = a.PRICE_TYPE,
                //DATES_STARTED = a.DATE_STARTED,
                DYNAMIC_DISC = a.DYNAMIC_DISC,
                SEND_MAIL = a.SEND_MAIL,
                //COMPANY_ID = a.COMPANY_ID,
                CUSTOMER_INACTIVE = a.CUSTOMER_STATUS,
                REGISTERED = a.REGISTERED,
                DUNS_NO = a.DUNS_NO,
                STATEMENT = a.STATEMENT,
                IS_SUPPLIER = a.IS_SUPPLIER,

                CONTACT_TYPE = a.CONTACT_TYPE,
                CONTACT_NAME = a.CONTACT_NAME,
                CONTACT_SALUTATION = a.CONTACT_SALUTATION,
                CONTACT_PHONE_NO = a.CONTACT_PHONE_NO,
                CONTACT_EXTN_NO = a.CONTACT_EXTN_NO,
                CONTACT_MOBILE_NO = a.CONTACT_MOBILE_NO,
                CONTACT_FAX = a.CONTACT_FAX,
                EMAIL = a.EMAIL,
                SKYPE = a.SKYPE,
                DATE_STARTED=a.DATES_STARTED,


                       }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, str);
        }

        [HttpPost]
        public HttpResponseMessage CustomerUpdate(CustomerModel _CustomerModel)
        {
            var cus = (from a in db.CUSTOMERs where a.CUSTOMER_ID == _CustomerModel.CUSTOMER_ID select a).FirstOrDefault();

            cus.CUSTOMER_CODE = _CustomerModel.CUSTOMER_CODE;
            cus.CUSTOMER_NAME = _CustomerModel.CUSTOMER_NAME;
            cus.ADDRESS = _CustomerModel.ADDRESS;
            cus.VAT_NUMBER = _CustomerModel.VAT_NUMBER;
            cus.POSTCODE = _CustomerModel.POSTCODE;
            cus.COUNTRY = _CustomerModel.COUNTRY;
            cus.WEBSITE = _CustomerModel.WEBSITE;

            cus.VAT_TYPE = _CustomerModel.VAT_TYPE;

            cus.PRICE_TYPE = _CustomerModel.PRICE_TYPE;
            //cus.DATES_STARTED = _CustomerModel.DATE_STARTED;
            cus.DYNAMIC_DISC = _CustomerModel.DYNAMIC_DISC;
            cus.SEND_MAIL = _CustomerModel.SEND_MAIL;
            //cus.COMPANY_ID = _CustomerModel.COMPANY_ID;
            cus.CUSTOMER_STATUS = _CustomerModel.CUSTOMER_INACTIVE;
            cus.REGISTERED = _CustomerModel.REGISTERED;
            cus.DUNS_NO = _CustomerModel.DUNS_NO;
            cus.STATEMENT = _CustomerModel.STATEMENT;
            cus.IS_SUPPLIER = _CustomerModel.IS_SUPPLIER;

            cus.CONTACT_TYPE = _CustomerModel.CONTACT_TYPE;
            cus.CONTACT_NAME = _CustomerModel.CONTACT_NAME;
            cus.CONTACT_SALUTATION = _CustomerModel.CONTACT_SALUTATION;
            cus.CONTACT_PHONE_NO = _CustomerModel.CONTACT_PHONE_NO;
            cus.CONTACT_EXTN_NO = _CustomerModel.CONTACT_EXTN_NO;
            cus.CONTACT_MOBILE_NO = _CustomerModel.CONTACT_MOBILE_NO;
            cus.CONTACT_FAX = _CustomerModel.CONTACT_FAX;
            cus.EMAIL = _CustomerModel.EMAIL;
            cus.SKYPE = _CustomerModel.SKYPE;

            //cus.ON_CREDIT_STOP = _CustomerModel.ON_CREDIT_STOP;
            //cus.OLDEST_INV_DATE = _CustomerModel.OLDEST_INV_DATE;
            //cus.AVG_PMT_DATE = _CustomerModel.AVG_PMT_DATE;
            //cus.OS_BALANCE = _CustomerModel.OS_BALANCE;
            //cus.OS_ORDERS = _CustomerModel.OS_ORDERS;
            //cus.CR_REMAIN = _CustomerModel.CR_REMAIN;



            //cus.CREDIT_LIMIT = _CustomerModel.CREDIT_LIMIT;
            //cus.STOPPED_ON = _CustomerModel.STOPPED_ON;
            //cus.ON_STOP_AFTER = _CustomerModel.ON_STOP_AFTER;
            //cus.PUT_ON_STOP_BY = _CustomerModel.PUT_ON_STOP_BY;

            cus.LAST_SALE = _CustomerModel.LAST_SALE;
            cus.LAST_PAYMENT = _CustomerModel.LAST_PAYMENT;
            
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage DeleteCustomer(int id)
        {
            var str = (from a in db.CUSTOMERs
                       where a.CUSTOMER_ID == id
                       select a).FirstOrDefault();
            str.IS_DELETE = true;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


    }
}
