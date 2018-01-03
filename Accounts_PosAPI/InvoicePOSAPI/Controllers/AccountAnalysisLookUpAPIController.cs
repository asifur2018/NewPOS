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
    public class AccountAnalysisLookUpAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpPost]
        public HttpResponseMessage CreateAccountAnalysisModeLookUp(AccountAnalysisLookUpModel _AccountAnalysisLookUpModel)
        {

            try
            {
                ACCOUNT_ANALYSIS_LOOKUP aalu = new ACCOUNT_ANALYSIS_LOOKUP();

                aalu.ACC_ANALYSIS_ID = _AccountAnalysisLookUpModel.ACCOUNT_ANALYSIS_ID;
                aalu.ACC_ANALYSIS_DESC = _AccountAnalysisLookUpModel.ACCOUNT_ANALYSIS_DESC;
                aalu.TYPE = _AccountAnalysisLookUpModel.TYPE;

                db.ACCOUNT_ANALYSIS_LOOKUP.Add(aalu);
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage GetAccountAnalysisLookUpList()
        {

            try
            {

                var str = (from a in db.ACCOUNT_ANALYSIS_LOOKUP
                           select new AccountAnalysisLookUpModel
                           {

                               ACCOUNT_ANALYSIS_ID = a.ACC_ANALYSIS_ID,
                               ACCOUNT_ANALYSIS_DESC = a.ACC_ANALYSIS_DESC,
                               TYPE = a.TYPE

                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateAccountAnalysisModeLookUp(AccountAnalysisLookUpModel _AccountAnalysisLookUpModel)
        {

            try
            {
                ACCOUNT_ANALYSIS_LOOKUP aalu = new ACCOUNT_ANALYSIS_LOOKUP();

                aalu.ACC_ANALYSIS_ID = _AccountAnalysisLookUpModel.ACCOUNT_ANALYSIS_ID;
                aalu.ACC_ANALYSIS_DESC = _AccountAnalysisLookUpModel.ACCOUNT_ANALYSIS_DESC;
                aalu.TYPE = _AccountAnalysisLookUpModel.TYPE;

                db.ACCOUNT_ANALYSIS_LOOKUP.Attach(aalu);
                db.Entry(aalu).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage DeleteAccountAnalysisModeLookUp(AccountAnalysisLookUpModel _AccountAnalysisLookUpModel)
        {

            try
            {
                ACCOUNT_ANALYSIS_LOOKUP aalu = new ACCOUNT_ANALYSIS_LOOKUP();

                aalu.ACC_ANALYSIS_ID = _AccountAnalysisLookUpModel.ACCOUNT_ANALYSIS_ID;
                aalu.ACC_ANALYSIS_DESC = _AccountAnalysisLookUpModel.ACCOUNT_ANALYSIS_DESC;
                aalu.TYPE = _AccountAnalysisLookUpModel.TYPE;

                db.ACCOUNT_ANALYSIS_LOOKUP.Attach(aalu);
                db.ACCOUNT_ANALYSIS_LOOKUP.Remove(aalu);
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }
    }
}
