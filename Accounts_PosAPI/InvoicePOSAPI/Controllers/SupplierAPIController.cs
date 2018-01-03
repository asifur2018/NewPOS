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
    public class SupplierAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();
        SupplierModel cm = new SupplierModel();


        [HttpGet]
        public HttpResponseMessage GetSuppliers(int id)
        {
            var str = (from a in db.SUPPLIERs
                       where a.COMPANY_ID == id && a.IS_DELETE == false
                       select new SupplierModel
                       {

                           SUPPLIER_CODE = a.SUPPLIER_CODE,
                           SUPPLIER_NAME = a.SUPPLIER_NAME,
                           ADDRESS = a.ADDRESS,
                           COUNTRY = a.COUNTRY,
                           POSTCODE = a.POSTCODE,
                           SUPPLIER_ID = a.SUPPLIER_ID,
                           //RETAIL_STANDARD = 0,
                           DATE_STARTED = System.DateTime.Now,
                           IS_CUSTOMER = a.IS_CUSTOMER,
                           DEF_PMT_DAY=0,

                       }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, str);
        }

        [HttpPost]
        public HttpResponseMessage CreateSupplier(SupplierModel _SupplierModel)
        {
            try
            {

                SUPPLIER sup = new SUPPLIER();
                sup.SUPPLIER_CODE = _SupplierModel.SUPPLIER_CODE;
                sup.SUPPLIER_NAME = _SupplierModel.SUPPLIER_NAME;
                sup.ADDRESS = _SupplierModel.ADDRESS;
                sup.VAT_NUMBER = _SupplierModel.VAT_NUMBER;
                sup.POSTCODE = _SupplierModel.POSTCODE;
                sup.COUNTRY = _SupplierModel.COUNTRY;
                sup.WEBSITE = _SupplierModel.WEBSITE;

                sup.VAT_TYPE = _SupplierModel.VAT_TYPE;

                sup.PRICE_TYPE = _SupplierModel.PRICE_TYPE;
                //sup.DATES_STARTED = _SupplierModel.DATE_STARTED;
                sup.DYNAMIC_DISC = _SupplierModel.DYNAMIC_DISC;
                sup.SEND_MAIL = _SupplierModel.SEND_MAIL;
                //sup.COMPANY_ID = _SupplierModel.COMPANY_ID;
                sup.SUPPLIER_INACTIVE = _SupplierModel.SUPPLIER_INACTIVE;
                sup.REGISTERED = _SupplierModel.REGISTERED;
                sup.DUNS_NO = _SupplierModel.DUNS_NO;
                sup.STATEMENT = _SupplierModel.STATEMENT;
                sup.IS_CUSTOMER = _SupplierModel.IS_CUSTOMER;

                sup.DATE_STARTED = _SupplierModel.DATE_STARTED;
                //sup.LAST_PAYMENT = _SupplierModel.LAST_PAYMENT;
                sup.CASH_ACC = _SupplierModel.CASH_ACC;
                //sup.AVG_PMT_DAY = _SupplierModel.AVG_PMT_DAY;
                sup.DEF_PMT_DAY = _SupplierModel.DEF_PMT_DAY;

                sup.GROUP = _SupplierModel.GROUP;
                sup.GROUP_DESC = _SupplierModel.GROUP_DESC;
                sup.SUB_CONTRACTOR = _SupplierModel.SUB_CONTRACTOR;
                
                sup.CONTACT_TYPE = _SupplierModel.CONTACT_TYPE;
                sup.CONTACT_NAME = _SupplierModel.CONTACT_NAME;
                sup.CONTACT_SALUTATION = _SupplierModel.CONTACT_SALUTATION;
                sup.CONTACT_PHONE_NO = _SupplierModel.CONTACT_PHONE_NO;
                sup.CONTACT_EXTN_NO = _SupplierModel.CONTACT_EXTN_NO;
                sup.CONTACT_MOBILE_NO = _SupplierModel.CONTACT_MOBILE_NO;
                sup.CONTACT_FAX = _SupplierModel.CONTACT_FAX;
                sup.EMAIL = _SupplierModel.EMAIL;
                sup.SKYPE = _SupplierModel.SKYPE;
                //sup.CREDIT_LIMIT = _SupplierModel.CREDIT_LIMIT;
                sup.IS_DELETE = false;
                sup.STATUS = "Un-Saved";
                db.SUPPLIERs.Add(sup);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage EditSuppliers(int id)
        {
            var str = (from a in db.SUPPLIERs
                       where a.SUPPLIER_ID == id && a.IS_DELETE == false
                       select new SupplierModel
                       {


                           SUPPLIER_CODE = a.SUPPLIER_CODE,
                           SUPPLIER_ID = a.SUPPLIER_ID,
                           SUPPLIER_NAME = a.SUPPLIER_NAME,
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
                           SUPPLIER_INACTIVE = a.SUPPLIER_INACTIVE,
                           REGISTERED = a.REGISTERED,
                           DUNS_NO = a.DUNS_NO,
                           STATEMENT = a.STATEMENT,
                           IS_CUSTOMER = a.IS_CUSTOMER,
                                                     
                           CASH_ACC = a.CASH_ACC,
                           DEF_PMT_DAY = a.DEF_PMT_DAY,
                           GROUP = a.GROUP,
                           GROUP_DESC = a.GROUP_DESC,
                           SUB_CONTRACTOR = a.SUB_CONTRACTOR,

                           CONTACT_TYPE = a.CONTACT_TYPE,
                           CONTACT_NAME = a.CONTACT_NAME,
                           CONTACT_SALUTATION = a.CONTACT_SALUTATION,
                           CONTACT_PHONE_NO = a.CONTACT_PHONE_NO,
                           CONTACT_EXTN_NO = a.CONTACT_EXTN_NO,
                           CONTACT_MOBILE_NO = a.CONTACT_MOBILE_NO,
                           CONTACT_FAX = a.CONTACT_FAX,
                           EMAIL = a.EMAIL,
                           SKYPE = a.SKYPE,
                           DATE_STARTED = a.DATE_STARTED,


                       }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, str);
        }

        [HttpPost]
        public HttpResponseMessage SupplierUpdate(SupplierModel _SupplierModel)
        {
            var ss = (from a in db.SUPPLIERs where a.SUPPLIER_ID == _SupplierModel.SUPPLIER_ID select a).FirstOrDefault();

            ss.SUPPLIER_CODE = _SupplierModel.SUPPLIER_CODE;
            ss.SUPPLIER_NAME = _SupplierModel.SUPPLIER_NAME;
            ss.ADDRESS = _SupplierModel.ADDRESS;
            ss.VAT_NUMBER = _SupplierModel.VAT_NUMBER;
            ss.POSTCODE = _SupplierModel.POSTCODE;
            ss.COUNTRY = _SupplierModel.COUNTRY;
            ss.WEBSITE = _SupplierModel.WEBSITE;

            ss.VAT_TYPE = _SupplierModel.VAT_TYPE;

            ss.PRICE_TYPE = _SupplierModel.PRICE_TYPE;
            //ss.DATES_STARTED = _SupplierModel.DATE_STARTED;
            ss.DYNAMIC_DISC = _SupplierModel.DYNAMIC_DISC;
            ss.SEND_MAIL = _SupplierModel.SEND_MAIL;
            //ss.COMPANY_ID = _SupplierModel.COMPANY_ID;
            ss.SUPPLIER_INACTIVE = _SupplierModel.SUPPLIER_INACTIVE;
            ss.REGISTERED = _SupplierModel.REGISTERED;
            ss.DUNS_NO = _SupplierModel.DUNS_NO;
            ss.STATEMENT = _SupplierModel.STATEMENT;
            ss.IS_CUSTOMER = _SupplierModel.IS_CUSTOMER;

            ss.CASH_ACC = _SupplierModel.CASH_ACC;
            ss.DEF_PMT_DAY = _SupplierModel.DEF_PMT_DAY;
            ss.GROUP = _SupplierModel.GROUP;
            ss.GROUP_DESC = _SupplierModel.GROUP_DESC;
            ss.SUB_CONTRACTOR = _SupplierModel.SUB_CONTRACTOR;

            ss.CONTACT_TYPE = _SupplierModel.CONTACT_TYPE;
            ss.CONTACT_NAME = _SupplierModel.CONTACT_NAME;
            ss.CONTACT_SALUTATION = _SupplierModel.CONTACT_SALUTATION;
            ss.CONTACT_PHONE_NO = _SupplierModel.CONTACT_PHONE_NO;
            ss.CONTACT_EXTN_NO = _SupplierModel.CONTACT_EXTN_NO;
            ss.CONTACT_MOBILE_NO = _SupplierModel.CONTACT_MOBILE_NO;
            ss.CONTACT_FAX = _SupplierModel.CONTACT_FAX;
            ss.EMAIL = _SupplierModel.EMAIL;
            ss.SKYPE = _SupplierModel.SKYPE;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }



        [HttpPost]
        public HttpResponseMessage CreateSettlement(SupplierModel _SupplierModel)
        {

            try
            {
                SUPPLIER_SETTLEMENT ss = new SUPPLIER_SETTLEMENT();
                ss.BACS_REF = _SupplierModel.BACS_REF;
                ss.COMPANY_ID = _SupplierModel.COMPANY_ID;
                ss.ACCOUNT_NAME = _SupplierModel.ACCOUNT_NAME;
                ss.BANK_NAME = _SupplierModel.BANK_NAME;
                ss.STREET = _SupplierModel.STREET;
                //ss.STREET2 = _SupplierModel.STREET2;
                ss.TOWN = _SupplierModel.TOWN;
                ss.COUNTRY = _SupplierModel.COUNTRY;
                ss.POSTCODE = _SupplierModel.POSTCODE;
                ss.SHORT_CODE = _SupplierModel.SHORT_CODE;
                ss.ACCOUNT_NUMBER = _SupplierModel.ACCOUNT_NUMBER;
                ss.PAYMENT_REF = _SupplierModel.PAYMENT_REF;
                ss.BIC_SWIFT = _SupplierModel.BIC_SWIFT;
                ss.IBAN = _SupplierModel.IBAN;
                ss.PAYMENT_METHOD = _SupplierModel.PAYMENT_METHOD;
                ss.SUPPLIER_CODE = _SupplierModel.SUPPLIER_CODE;



                //ss.LAST_DISC_PER = _SupplierModel.LAST_DISC_PER;
                //ss.LAST_DISC_DAYS = _SupplierModel.LAST_DISC_PER;
                ss.NOTES = _SupplierModel.NOTES;
                ss.USE_E_PAYMENT = _SupplierModel.USE_E_PAYMENT;
                ss.STANDARD_DISC_PER = _SupplierModel.STANDARD_DISC_PER;
                //ss.STANDARD_DISC_DAYS = _SupplierModel.STANDARD_DISC_DAYS;
                //ss.LAST_DISC_PER = _SupplierModel.LAST_DISC_PER;
                ss.BENEFICIARY = _SupplierModel.BENEFICIARY;
                //ss.LAST_DISC_DAYS = _SupplierModel.LAST_DISC_DAYS;
                ss.STANDARD_DISC_DAYS = _SupplierModel.STANDARD_DISC_DAYS;


                ss.STATUS = "Un-Saved";
                ss.IS_DELETE = false;
                db.SUPPLIER_SETTLEMENT.Add(ss);
                db.SaveChanges();




            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }



        [HttpPost]
        public HttpResponseMessage CreateSubContractor(SupplierModel _SupplierModel)
        
        {

            try
            {
                SUPPLIER_SUBCONTRACTOR sc = new SUPPLIER_SUBCONTRACTOR();
                sc.SUPPLIER_CODE=_SupplierModel.SUPPLIER_CODE;
                sc.BUSINESS_TYPE = _SupplierModel.BUSINESS_TYPE;
                sc.PARTNERSHIP_NAME = _SupplierModel.PARTNERSHIP_NAME;
                sc.PARTNERSHIP_UTR = _SupplierModel.PARTNERSHIP_UTR;
                sc.TRADING_NAME = _SupplierModel.TRADING_NAME;
                sc.LEGAL_NAME = _SupplierModel.LEGAL_NAME;
               // sc.USE_LEGAL_NAME = _SupplierModel.USE_LEGAL_NAME;
                sc.PRODUCE_STATEMENT = _SupplierModel.PRODUCE_STATEMENT;
                sc.CIS_TYPE = _SupplierModel.CIS_TYPE;
                sc.CIS_CETT = _SupplierModel.CIS_CETT;
                sc.CIS_CERT_NO = _SupplierModel.CIS_CERT_NO;
               // sc.DATE_LAST_VERIFIED = _SupplierModel.DATE_LAST_VERIFIED;
                sc.DATE_VALID_FROM = _SupplierModel.DATE_VALID_FROM;
                sc.DATE_VALID_TO = _SupplierModel.DATE_VALID_TO;
                sc.FORENAME = _SupplierModel.FORENAME;
                sc.MIDDLE_NAME = _SupplierModel.MIDDLE_NAME;
                sc.SURNAME = _SupplierModel.SURNAME;
                sc.UTR = _SupplierModel.UTR;
                sc.INSURANCE_NO = _SupplierModel.INSURANCE_NO;
                sc.CIS_CERT_NO = _SupplierModel.CIS_CERT_NO;
                sc.CO_REG_NO = _SupplierModel.CO_REG_NO;
                sc.STATUS_VERIFICATION = _SupplierModel.STATUS_VERIFICATION;
                sc.VERIFICATION_NO = _SupplierModel.VERIFICATION_NO;
                sc.TAX_TREATMENT = _SupplierModel.TAX_TREATMENT;
                sc.LEGAL_NAME = _SupplierModel.LEGAL_NAME;
                sc.STATUS = "Un-Saved";
                sc.IS_DELETE = false;
                db.SUPPLIER_SUBCONTRACTOR.Add(sc);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage DeleteSupplier(int id)
        {
            var str = (from a in db.SUPPLIERs
                       where a.SUPPLIER_ID == id
                       select a).FirstOrDefault();
            str.IS_DELETE = true;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

    }
}
