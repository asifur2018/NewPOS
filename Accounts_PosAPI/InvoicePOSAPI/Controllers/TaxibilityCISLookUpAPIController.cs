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
    public class TaxibilityCISLookUpAPIController : ApiController
    {

        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpPost]
        public HttpResponseMessage CreateTaxibilityCISModelLookUp(TaxibilityCISLookUpModel _TaxibilityCISLookUpModel)
        {

            try
            {
                TAXABILITY_CIS_LOOKUP tclu = new TAXABILITY_CIS_LOOKUP();

                tclu.TAXABLE_CIS_ID = _TaxibilityCISLookUpModel.TAXABLE_CIS_ID;
                tclu.TAXABLE_CIS_DESC = _TaxibilityCISLookUpModel.TAXABLE_CIS_DESC;

                if (!db.TAXABILITY_CIS_LOOKUP.Any(a => a.TAXABLE_CIS_ID == tclu.TAXABLE_CIS_ID))
                {
                    db.TAXABILITY_CIS_LOOKUP.Add(tclu);
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
        public HttpResponseMessage GetTaxabilityCISLookUpList()
        {

            try
            {

                var str = (from a in db.TAXABILITY_CIS_LOOKUP
                           select new TaxibilityCISLookUpModel
                           {
                               TAXABLE_CIS_ID = a.TAXABLE_CIS_ID,
                               TAXABLE_CIS_DESC = a.TAXABLE_CIS_DESC
                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }


        [HttpPost]
        public HttpResponseMessage UpdateTaxibilityCISModelLookUp(TaxibilityCISLookUpModel _TaxibilityCISLookUpModel)
        {

            try
            {
                TAXABILITY_CIS_LOOKUP tclu = new TAXABILITY_CIS_LOOKUP();

                tclu.TAXABLE_CIS_ID = _TaxibilityCISLookUpModel.TAXABLE_CIS_ID;
                tclu.TAXABLE_CIS_DESC = _TaxibilityCISLookUpModel.TAXABLE_CIS_DESC;

                db.TAXABILITY_CIS_LOOKUP.Attach(tclu);
                db.Entry(tclu).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage DeleteTaxibilityCISModelLookUp(TaxibilityCISLookUpModel _TaxibilityCISLookUpModel)
        {

            try
            {
                TAXABILITY_CIS_LOOKUP tclu = new TAXABILITY_CIS_LOOKUP();

                tclu.TAXABLE_CIS_ID = _TaxibilityCISLookUpModel.TAXABLE_CIS_ID;
                tclu.TAXABLE_CIS_DESC = _TaxibilityCISLookUpModel.TAXABLE_CIS_DESC;

                db.TAXABILITY_CIS_LOOKUP.Attach(tclu);
                db.TAXABILITY_CIS_LOOKUP.Remove(tclu);
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
