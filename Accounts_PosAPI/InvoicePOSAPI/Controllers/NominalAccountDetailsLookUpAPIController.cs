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
    public class NominalAccountDetailsLookUpAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpPost]
        public HttpResponseMessage CreateNominalAccountDetailsModeLookUp(NominalAccountDetailsLookUpModel _NominalAccountDetailsLookUpModel)
        {

            try
            {
                NOMINAL_ACCOUNT_DETAILS_LOOKUP nadlm = new NOMINAL_ACCOUNT_DETAILS_LOOKUP();

                nadlm.NOMINAL_GROUP_ID = _NominalAccountDetailsLookUpModel.NOMINAL_GROUP_ID;
                nadlm.NOMINAL_GROUP_CODE = _NominalAccountDetailsLookUpModel.NOMINAL_GROUP_CODE;
                nadlm.NOMINAL_GROUP_DESC = _NominalAccountDetailsLookUpModel.NOMINAL_GROUP_DESC;

                if (!db.NOMINAL_ACCOUNT_DETAILS_LOOKUP.Any(a => a.NOMINAL_GROUP_ID == nadlm.NOMINAL_GROUP_ID))
                {
                    db.NOMINAL_ACCOUNT_DETAILS_LOOKUP.Add(nadlm);
                    db.SaveChanges();
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "duplicate key");
                }

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpGet]
        public HttpResponseMessage GetNominalAccountDetailsLookUpList()
        {

            try
            {

                var str = (from a in db.NOMINAL_ACCOUNT_DETAILS_LOOKUP
                           select new NominalAccountDetailsLookUpModel
                           {
                               NOMINAL_GROUP_ID = a.NOMINAL_GROUP_ID,
                               NOMINAL_GROUP_CODE = a.NOMINAL_GROUP_CODE,
                               NOMINAL_GROUP_DESC = a.NOMINAL_GROUP_DESC
                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }


        [HttpPost]
        public HttpResponseMessage UpdateNominalAccountDetailsLookUp(NominalAccountDetailsLookUpModel _NominalAccountDetailsLookUpModel)
        {

            try
            {
                NOMINAL_ACCOUNT_DETAILS_LOOKUP nadlu = new NOMINAL_ACCOUNT_DETAILS_LOOKUP();

                nadlu.NOMINAL_GROUP_ID = _NominalAccountDetailsLookUpModel.NOMINAL_GROUP_ID;
                nadlu.NOMINAL_GROUP_CODE = _NominalAccountDetailsLookUpModel.NOMINAL_GROUP_CODE;
                nadlu.NOMINAL_GROUP_DESC = _NominalAccountDetailsLookUpModel.NOMINAL_GROUP_DESC;

                db.NOMINAL_ACCOUNT_DETAILS_LOOKUP.Attach(nadlu);
                db.Entry(nadlu).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage DeleteNominalAccountDetailsLookUp(NominalAccountDetailsLookUpModel _NominalAccountDetailsLookUpModel)
        {

            try
            {
                NOMINAL_ACCOUNT_DETAILS_LOOKUP nadlu = new NOMINAL_ACCOUNT_DETAILS_LOOKUP();

                nadlu.NOMINAL_GROUP_ID = _NominalAccountDetailsLookUpModel.NOMINAL_GROUP_ID;
                nadlu.NOMINAL_GROUP_CODE = _NominalAccountDetailsLookUpModel.NOMINAL_GROUP_CODE;
                nadlu.NOMINAL_GROUP_DESC = _NominalAccountDetailsLookUpModel.NOMINAL_GROUP_DESC;

                db.NOMINAL_ACCOUNT_DETAILS_LOOKUP.Attach(nadlu);
                db.NOMINAL_ACCOUNT_DETAILS_LOOKUP.Remove(nadlu);
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
