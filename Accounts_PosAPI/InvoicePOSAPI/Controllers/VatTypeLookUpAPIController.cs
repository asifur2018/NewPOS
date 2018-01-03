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
    public class VatTypeLookUpAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpPost]
        public HttpResponseMessage CreateVatTypeLookUp(VatTypeLookUpModel _VatTypeLookUpModel)
        {

            try
            {
                VAT_TYPE_LOOKUP vtlu = new VAT_TYPE_LOOKUP();

                vtlu.VAT_TYPE_NAME = _VatTypeLookUpModel.VAT_TYPE_NAME;
                vtlu.DELIVERY_TYPE_APPLICABLE = _VatTypeLookUpModel.DELIVERY_TYPE_APPLICABLE;
                vtlu.DELIVERY_MODE = _VatTypeLookUpModel.DELIVERY_MODE;
                vtlu.VAT_TYPE_ID = _VatTypeLookUpModel.VAT_TYPE_ID;


                if (!db.VAT_TYPE_LOOKUP.Any(a => a.VAT_TYPE_ID == vtlu.VAT_TYPE_ID))
                {
                    db.VAT_TYPE_LOOKUP.Add(vtlu);
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
        public HttpResponseMessage GetVatTypeLookUpList()
        {

            try
            {

                var str = (from a in db.VAT_TYPE_LOOKUP
                           select new VatTypeLookUpModel
                           {
                               VAT_TYPE_ID = a.VAT_TYPE_ID,
                               VAT_TYPE_NAME = a.VAT_TYPE_NAME,
                               DELIVERY_MODE = a.DELIVERY_MODE,
                               DELIVERY_TYPE_APPLICABLE = a.DELIVERY_TYPE_APPLICABLE
                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }


        [HttpPost]
        public HttpResponseMessage UpdateVatTypeLookUp(VatTypeLookUpModel _VatTypeLookUpModel)
        {

            try
            {
                VAT_TYPE_LOOKUP vtlu = new VAT_TYPE_LOOKUP();

                vtlu.VAT_TYPE_ID = _VatTypeLookUpModel.VAT_TYPE_ID;
                vtlu.VAT_TYPE_NAME = _VatTypeLookUpModel.VAT_TYPE_NAME;
                vtlu.DELIVERY_MODE = _VatTypeLookUpModel.DELIVERY_MODE;
                vtlu.DELIVERY_TYPE_APPLICABLE = _VatTypeLookUpModel.DELIVERY_TYPE_APPLICABLE;

                db.VAT_TYPE_LOOKUP.Attach(vtlu);
                db.Entry(vtlu).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage DeleteVatTypeLookUp(VatTypeLookUpModel _VatTypeLookUpModel)
        {

            try
            {
                VAT_TYPE_LOOKUP vtlu = new VAT_TYPE_LOOKUP();

                vtlu.VAT_TYPE_ID = _VatTypeLookUpModel.VAT_TYPE_ID;
                vtlu.VAT_TYPE_NAME = _VatTypeLookUpModel.VAT_TYPE_NAME;
                vtlu.DELIVERY_MODE = _VatTypeLookUpModel.DELIVERY_MODE;
                vtlu.DELIVERY_TYPE_APPLICABLE = _VatTypeLookUpModel.DELIVERY_TYPE_APPLICABLE;

                db.VAT_TYPE_LOOKUP.Attach(vtlu);
                db.VAT_TYPE_LOOKUP.Remove(vtlu);
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
