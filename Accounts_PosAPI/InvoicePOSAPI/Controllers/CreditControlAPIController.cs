using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InvoicePOSDATA;
using InvoicePOSAPI.Models;

namespace InvoicePOSAPI.Controllers
{
    public class CreditControlAPIController : ApiController
    {

        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();
        CreditControlModel cm = new CreditControlModel();

        [HttpPost]
        public HttpResponseMessage CreateCreditControl(CreditControlModel _CreditControlModel)
        {

            try
            {
                CUSTOMER_CREDIT_CONTROL cm = new CUSTOMER_CREDIT_CONTROL();
                cm.CREDIT_LIMIT = _CreditControlModel.CREDIT_LIMIT;
                cm.SETTLEMENT_DUE_DAYS = _CreditControlModel.SETTLEMENT_DUE;
                cm.SETTLEMENT_DISCOUNT = _CreditControlModel.SETTLEMENT_DISCOUNT;
                cm.PAYMENT_DUE_DAYS = _CreditControlModel.PAYMENT_DUE;
                cm.AVG_TIME = _CreditControlModel.AVG_TIME;
                cm.PAYMENT_DUE_FROM = _CreditControlModel.PAYMENT_FROM;
                cm.TRADING_TERMS = _CreditControlModel.TREDING_TERMS;
                cm.CREDIT_REF = _CreditControlModel.CREDIT_REF;
                cm.PRIORITY_CUSTOMER = _CreditControlModel.IS_PRIORITY;
                cm.BUREAU = _CreditControlModel.BUREAU;
                cm.CREDIT_POSITION = _CreditControlModel.CREDIT_POSITION;
                cm.ACCOUNT_STATES = _CreditControlModel.ACCOUNT_STATUS;
                cm.DUNS_NUMBER = _CreditControlModel.DUNS_NUMBER;
                cm.ACCOUNT_OPENED = _CreditControlModel.ACCOUNT_OPENED;

                cm.LAST_CREDIT_REVIEW = _CreditControlModel.LAST_CREDIT;
                cm.NEXT_CREDIT_REVIEW = _CreditControlModel.NEXT_CREDIT;
                cm.APPLICATION_DATE = _CreditControlModel.APPLICATION_DATE;
                cm.DATE_RECEIVED = _CreditControlModel.DATE_RECEIVED;
                cm.DUNS_NUMBER = _CreditControlModel.DUNS_NUMBER;
                cm.MEMO = _CreditControlModel.MEMO;


                cm.CUSTOMER_CODE = _CreditControlModel.CUSTOMER_CODE;
                cm.IS_CHANGE_CREDIT = _CreditControlModel.IS_CHANGE_CREDIT;
                cm.IS_TERMS_AGREED = _CreditControlModel.IS_TERMS_AGREED;
                cm.IS_RESTRICT_MAILING = _CreditControlModel.IS_RESTRICT_MAILING;
                cm.IS_ACCOUNT_HOLD = _CreditControlModel.IS_ACCOUNT_HOLD;
                cm.IS_DELETE = false;
                db.CUSTOMER_CREDIT_CONTROL.Add(cm);
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
