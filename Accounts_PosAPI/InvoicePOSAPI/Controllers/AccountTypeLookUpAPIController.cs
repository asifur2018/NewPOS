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
    public class AccountTypeLookUpAPIController : ApiController
    {

        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpPost]
        public HttpResponseMessage CreateAccountTypeModeLookUp(AccountTypeLookUpModel _AccountTypeLookUpModel)
        {

            try
            {
                ACCOUNT_TYPE_LOOKUP atlu = new ACCOUNT_TYPE_LOOKUP();

                atlu.ACC_TYPE_ID = _AccountTypeLookUpModel.ACC_TYPE_ID;
                atlu.ACC_TYPE_DESC = _AccountTypeLookUpModel.ACC_TYPE_DESC;
                atlu.STATUS = _AccountTypeLookUpModel.STATUS;
                atlu.TYPE = _AccountTypeLookUpModel.TYPE;

                db.ACCOUNT_TYPE_LOOKUP.Add(atlu);
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpGet]
        public HttpResponseMessage GetAccountTypeLookUpList()
        {

            try
            {

                var str = (from a in db.ACCOUNT_TYPE_LOOKUP
                           select new AccountTypeLookUpModel
                           {

                               ACC_TYPE_ID = a.ACC_TYPE_ID,
                               ACC_TYPE_DESC = a.ACC_TYPE_DESC,
                               TYPE = a.TYPE,
                               STATUS = a.STATUS

                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateAccountTypeModeLookUp(AccountTypeLookUpModel _AccountTypeLookUpModel)
        {

            try
            {
                ACCOUNT_TYPE_LOOKUP atlu = new ACCOUNT_TYPE_LOOKUP();

                atlu.ACC_TYPE_ID = _AccountTypeLookUpModel.ACC_TYPE_ID;
                atlu.ACC_TYPE_DESC = _AccountTypeLookUpModel.ACC_TYPE_DESC;
                atlu.TYPE = _AccountTypeLookUpModel.TYPE;
                atlu.STATUS = _AccountTypeLookUpModel.STATUS;

                db.ACCOUNT_TYPE_LOOKUP.Attach(atlu);
                db.Entry(atlu).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage DeleteAccountTypeModeLookUp(AccountTypeLookUpModel _AccountTypeLookUpModel)
        {

            try
            {
                ACCOUNT_TYPE_LOOKUP atlu = new ACCOUNT_TYPE_LOOKUP();

                atlu.ACC_TYPE_ID = _AccountTypeLookUpModel.ACC_TYPE_ID;
                atlu.ACC_TYPE_DESC = _AccountTypeLookUpModel.ACC_TYPE_DESC;
                atlu.TYPE = _AccountTypeLookUpModel.TYPE;
                atlu.STATUS = _AccountTypeLookUpModel.STATUS;

                db.ACCOUNT_TYPE_LOOKUP.Attach(atlu);
                db.ACCOUNT_TYPE_LOOKUP.Remove(atlu);
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
