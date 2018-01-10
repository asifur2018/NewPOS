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
    public class SalesAPIController : ApiController
    {

        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();
        SalesModel sm = new SalesModel();

        [HttpPost]
        public HttpResponseMessage CreateCustomerJournal(SalesModel _SalesModel)
        {

            try
            {

                SALES_JOURNAL_DEBIT sl = new SALES_JOURNAL_DEBIT();
                sl.LEDGER = _SalesModel.LEDGER;
                sl.TRX_TYPE = _SalesModel.TRX_TYPE;
                sl.POSTING_NO = _SalesModel.POSTING_NO;
                 sl.POSTING_TYPE = _SalesModel.POSTING_TYPE;
                sl.DEF_DIST = _SalesModel.DEF_DIST;
                sl.GENERAL_CODE = _SalesModel.GENERAL_CODE;
                sl.GENERAL_NAME = _SalesModel.GENERAL_NAME;
                sl.REF_NO = _SalesModel.REF_NO;
                //sl.POSINGT_DATE = _SalesModel.POSTING_DATE;
                sl.INV_DATE = _SalesModel.INV_DATE;
                sl.INV_EXP_DATE = _SalesModel.INV_EXP_DATE;
                sl.DESCRIPTION = _SalesModel.DESCRIPTION;
                sl.PROJECT = _SalesModel.PROJECT;
                sl.OS_BAL = _SalesModel.OS_BAL;
                sl.CREDIT_REMAINING = _SalesModel.CREDIT_REMAINING;
                sl.NET_BAL = _SalesModel.NET_BAL;
                sl.TAX_AMT = _SalesModel.TAX_AMT;
                sl.TOTAL_AMT = _SalesModel.TOTAL_AMT;
                sl.COST = _SalesModel.COST;

                sl.IS_DELETE = false;
                sl.STATUS = "Un-Saved";
                db.SALES_JOURNAL_DEBIT.Add(sl);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage CreateQuickJournal(SalesModel _SalesModel)
        {

            try
            {

                SALES_QUICK_JOURNAL qj = new SALES_QUICK_JOURNAL();
                qj.QUICKJOURNAL_CODE = _SalesModel.QUICKJOURNAL_CODE;
                qj.JOURNAL_DATE = _SalesModel.JOURNAL_DATE;
                qj.CUSTOMER = _SalesModel.CUSTOMER;
                qj.REFERENCE = _SalesModel.REFERENCE;
                qj.JOURNAL_DESC = _SalesModel.JOURNAL_DESC;
                qj.NL_ACC1 = _SalesModel.NL_ACC1;
                qj.NL_ACC2 = _SalesModel.NL_ACC2;
                qj.VAT_PER = _SalesModel.VAT_PER;
                qj.TOTAL_VAT = _SalesModel.TOTAL_VAT;
                qj.NET_AMOUNT = _SalesModel.NET_AMOUNT;
                qj.TOTAL_AMOUNT = _SalesModel.TOTAL_AMOUNT;


                qj.IS_DELETE = false;
                qj.STATUS = "Un-Saved";
                db.SALES_QUICK_JOURNAL.Add(qj);
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
