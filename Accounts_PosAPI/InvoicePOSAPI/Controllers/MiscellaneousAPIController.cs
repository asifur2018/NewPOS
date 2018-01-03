//using Accounts_PosApi.Models;
//using Accounts_PosDATA;
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
    public class MiscellaneousAPIController : ApiController
    {

        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();
        //CustomerModel mm = new CustomerModel();
        MiscellaneousModel mm= new MiscellaneousModel();



        [HttpPost]
        public HttpResponseMessage CreateMiscellaneous(MiscellaneousModel _MiscellaneousModel)
        {

            //[HttpPost]
            //public HttpResponseMessage CreateMiscellaneous(CustomerModel _CustomerModel)
            //{

            try
            {
                CUSTOMER_BANK_DETAILS cus = new CUSTOMER_BANK_DETAILS();
                cus.BACS_REF = _MiscellaneousModel.BACS_REF;
                cus.ACCOUNT_NAME = _MiscellaneousModel.ACCOUNT_NAME;
                cus.BANK_NAME = _MiscellaneousModel.BANK_NAME;
                cus.STREET1 = _MiscellaneousModel.STREET1;
                cus.STREET2 = _MiscellaneousModel.STREET2;
                //cus.TOWN = _MiscellaneousModel.TOWN;
                cus.COUNTRY = _MiscellaneousModel.COUNTRY;
                cus.POST_CODE = _MiscellaneousModel.POST_CODE;
                cus.SHORT_CODE = _MiscellaneousModel.SHORT_CODE;
                cus.ACCOUNT_NUMBER = _MiscellaneousModel.ACCOUNT_NUMBER;
                cus.PAYMENT_REF = _MiscellaneousModel.ADDITIONAL_REFERENCE;
                cus.BIC_SWIFT = _MiscellaneousModel.BIC_SWIFT;
                cus.IBAN = _MiscellaneousModel.IBAN;
                cus.ROLL_NO = _MiscellaneousModel.ROLL_NUMBER;
                cus.PAYMENT_METHOD = _MiscellaneousModel.PAYMENT_METHOD;
                // cus.ONLINE_RECEIPT = _MiscellaneousModel.ONLINE_RECEIPT;
                //cus.NOTES = _MiscellaneousModel.NOTES;
                cus.CUSTOMER_CODE = _MiscellaneousModel.CUSTOMER_CODE;
                cus.IS_DELETE = false;
                //cus.STATUS = false;
                db.CUSTOMER_BANK_DETAILS.Add(cus);
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
