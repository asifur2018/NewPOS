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
        public HttpResponseMessage GetCustomer(string _CustomerCode)
        {

            try
            {

                var str = (from a in db.CUSTOMERs
                           where ((a.CUSTOMER_CODE.Equals(_CustomerCode)) && (a.IS_DELETE == false))
                           select new CustomerModel
                           {

                               CUSTOMER_NAME = a.CUSTOMER_NAME,
                               CUSTOMER_CODE = a.CUSTOMER_CODE,
                               ADDRESS = a.ADDRESS,
                               POSTCODE = a.POSTCODE,
                               COUNTRY = a.COUNTRY,
                               WEBSITE = a.WEBSITE,
                               DATES_STARTED = a.DATES_STARTED,
                               STATEMENT = a.STATEMENT,
                               SEND_MAIL = a.SEND_MAIL,
                               VAT_TYPE = a.VAT_TYPE,
                               VAT_NUMBER = a.VAT_NUMBER,
                               DUNS_NO = a.DUNS_NO,
                               DYNAMIC_DISC = a.DYNAMIC_DISC,
                               REGISTERED = a.REGISTERED,
                               OLDEST_INV_DATE = a.OLDEST_INV_DATE,
                               LAST_SALE = a.LAST_SALE,
                               LAST_PAYMENT = a.LAST_PAYMENT,
                               AVG_PMT_DAYS = a.AVG_PMT_DAYS,
                               CREDIT_LIMIT = a.CREDIT_LIMIT,
                               OS_BALANCE = a.OS_BALANCE,
                               OS_ORDERS = a.OS_ORDERS,
                               CR_REMAIN = a.CR_REMAIN,
                               ON_CREDIT_STOP = a.ON_CREDIT_STOP,
                               STOPPED_ON = a.STOPPED_ON,
                               ON_STOP_AFTER = a.ON_STOP_AFTER,
                               PUT_ON_STOP_BY = a.PUT_ON_STOP_BY,
                               CONTACT_TYPE = a.CONTACT_TYPE,
                               CONTACT_NAME = a.CONTACT_NAME,
                               CONTACT_SALUTATION = a.CONTACT_SALUTATION,
                               CONTACT_PHONE_NO = a.CONTACT_PHONE_NO,
                               CONTACT_EXTN_NO = a.CONTACT_EXTN_NO,
                               CONTACT_MOBILE_NO = a.CONTACT_MOBILE_NO,
                               CONTACT_FAX = a.CONTACT_FAX,
                               EMAIL = a.EMAIL,
                               SKYPE = a.SKYPE,
                               PRICE_TYPE = a.PRICE_TYPE,
                               COMPANY_ID = a.COMPANY_ID,
                               CUSTOMER_MAIL = a.CUSTOMER_MAIL,
                               IS_DELETE = a.IS_DELETE,
                               CUSTOMER_INACTIVE = a.CUSTOMER_STATUS,
                               STATUS = a.STATUS,
                               IS_SUPPLIER = a.IS_SUPPLIER

                           }).FirstOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }


        [HttpGet]
        public HttpResponseMessage GetCustomers()
        {

            try
            {

                var str = (from a in db.CUSTOMERs
                           where (a.IS_DELETE == false)
                           select new CustomerModel
                           {

                               CUSTOMER_NAME = a.CUSTOMER_NAME,
                               CUSTOMER_CODE = a.CUSTOMER_CODE,
                               ADDRESS = a.ADDRESS,
                               POSTCODE = a.POSTCODE,
                               COUNTRY = a.COUNTRY,
                               WEBSITE = a.WEBSITE,
                               DATES_STARTED = a.DATES_STARTED,
                               STATEMENT = a.STATEMENT,
                               SEND_MAIL = a.SEND_MAIL,
                               VAT_TYPE = a.VAT_TYPE,
                               VAT_NUMBER = a.VAT_NUMBER,
                               DUNS_NO = a.DUNS_NO,
                               DYNAMIC_DISC = a.DYNAMIC_DISC,
                               REGISTERED = a.REGISTERED,
                               OLDEST_INV_DATE = a.OLDEST_INV_DATE,
                               LAST_SALE = a.LAST_SALE,
                               LAST_PAYMENT = a.LAST_PAYMENT,
                               AVG_PMT_DAYS = a.AVG_PMT_DAYS,
                               CREDIT_LIMIT = a.CREDIT_LIMIT,
                               OS_BALANCE = a.OS_BALANCE,
                               OS_ORDERS = a.OS_ORDERS,
                               CR_REMAIN = a.CR_REMAIN,
                               ON_CREDIT_STOP = a.ON_CREDIT_STOP,
                               STOPPED_ON = a.STOPPED_ON,
                               ON_STOP_AFTER = a.ON_STOP_AFTER,
                               PUT_ON_STOP_BY = a.PUT_ON_STOP_BY,
                               CONTACT_TYPE = a.CONTACT_TYPE,
                               CONTACT_NAME = a.CONTACT_NAME,
                               CONTACT_SALUTATION = a.CONTACT_SALUTATION,
                               CONTACT_PHONE_NO = a.CONTACT_PHONE_NO,
                               CONTACT_EXTN_NO = a.CONTACT_EXTN_NO,
                               CONTACT_MOBILE_NO = a.CONTACT_MOBILE_NO,
                               CONTACT_FAX = a.CONTACT_FAX,
                               EMAIL = a.EMAIL,
                               SKYPE = a.SKYPE,
                               PRICE_TYPE = a.PRICE_TYPE,
                               COMPANY_ID = a.COMPANY_ID,
                               CUSTOMER_MAIL = a.CUSTOMER_MAIL,
                               IS_DELETE = a.IS_DELETE,
                               CUSTOMER_INACTIVE = a.CUSTOMER_STATUS,
                               STATUS = a.STATUS,
                               IS_SUPPLIER = a.IS_SUPPLIER

                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }

        //[HttpGet]
        //public HttpResponseMessage GetCustomerBankDetails(string _CustomerCode)
        //{

        //    try
        //    {

        //        var str = (from a in db.CUSTOMER_BANK_DETAILS
        //                   where ((a.CUSTOMER_CODE.Equals(_CustomerCode)) && (a.IS_DELETE == false))
        //                   select new CustomerBankDetailsModel
        //                   {

        //                       BANK_ID = a.BANK_ID,
        //                       BACS_REF = a.BACS_REF,
        //                       ACCOUNT_NAME = a.ACCOUNT_NAME,
        //                       BANK_NAME = a.BANK_NAME,
        //                       STREET1 = a.STREET1,
        //                       STREET2 = a.STREET2,
        //                       TOWN = a.TOWN,
        //                       COUNTRY = a.COUNTRY,
        //                       POST_CODE = a.POST_CODE,
        //                       SHORT_CODE = a.SHORT_CODE,
        //                       ACCOUNT_NUMBER = a.ACCOUNT_NUMBER,
        //                       PAYMENT_REF = a.PAYMENT_REF,
        //                       BIC_SWIFT = a.BIC_SWIFT,
        //                       IBAN = a.IBAN,
        //                       ROLL_NO = a.ROLL_NO,
        //                       PAYMENT_METHOD = a.PAYMENT_METHOD,
        //                       ONLINE_RECEIPT = a.ONLINE_RECEIPT,
        //                       NOTES = a.NOTES,
        //                       CUSTOMER_CODE = a.CUSTOMER_CODE,
        //                       IS_DELETE = a.IS_DELETE,
        //                       STATUS = a.STATUS,
        //                       STANDARD_DISC_PER = a.STANDARD_DISC_PER,
        //                       STANDART_DISC_DAYS = a.STANDART_DISC_DAYS

        //                   }).FirstOrDefault();
        //        return Request.CreateResponse(HttpStatusCode.OK, str);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

    }
}
