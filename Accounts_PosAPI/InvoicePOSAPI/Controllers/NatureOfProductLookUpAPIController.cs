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
    public class NatureOfProductLookUpAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpPost]
        public HttpResponseMessage CreateNatureOfProductLookUp(NatureOfProductLookUpModel _NatureOfProductLookUpModel)
        {

            try
            {
                NATURE_OF_PRODUCT_LOOKUP nplu = new NATURE_OF_PRODUCT_LOOKUP();
                nplu.NATURE_OF_PRODUCT_ID = _NatureOfProductLookUpModel.NATURE_OF_PRODUCT_ID;
                nplu.NATURE_OF_PRODUCT_NAME = _NatureOfProductLookUpModel.NATURE_OF_PRODUCT_NAME;
                nplu.NATURE_OF_PRODUCT_DESC = _NatureOfProductLookUpModel.NATURE_OF_PRODUCT_DESC;

                db.NATURE_OF_PRODUCT_LOOKUP.Add(nplu);
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpGet]
        public HttpResponseMessage GetNatureOfProductLookUpList()
        {

            try
            {

                var str = (from a in db.NATURE_OF_PRODUCT_LOOKUP
                           select new NatureOfProductLookUpModel
                           {
                               NATURE_OF_PRODUCT_ID = a.NATURE_OF_PRODUCT_ID,
                               NATURE_OF_PRODUCT_NAME = a.NATURE_OF_PRODUCT_NAME,
                               NATURE_OF_PRODUCT_DESC = a.NATURE_OF_PRODUCT_DESC
                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }


        [HttpPost]
        public HttpResponseMessage UpdateNatureOfProductLookUp(NatureOfProductLookUpModel _NatureOfProductLookUpModel)
        {

            try
            {
                NATURE_OF_PRODUCT_LOOKUP nplu = new NATURE_OF_PRODUCT_LOOKUP();

                nplu.NATURE_OF_PRODUCT_ID = _NatureOfProductLookUpModel.NATURE_OF_PRODUCT_ID;
                nplu.NATURE_OF_PRODUCT_NAME = _NatureOfProductLookUpModel.NATURE_OF_PRODUCT_NAME;
                nplu.NATURE_OF_PRODUCT_DESC = _NatureOfProductLookUpModel.NATURE_OF_PRODUCT_DESC;

                db.NATURE_OF_PRODUCT_LOOKUP.Attach(nplu);
                db.Entry(nplu).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage DeleteNatureOfProductLookUp(NatureOfProductLookUpModel _NatureOfProductLookUpModel)
        {

            try
            {
                NATURE_OF_PRODUCT_LOOKUP nplu = new NATURE_OF_PRODUCT_LOOKUP();

                nplu.NATURE_OF_PRODUCT_ID = _NatureOfProductLookUpModel.NATURE_OF_PRODUCT_ID;
                nplu.NATURE_OF_PRODUCT_NAME = _NatureOfProductLookUpModel.NATURE_OF_PRODUCT_NAME;
                nplu.NATURE_OF_PRODUCT_DESC = _NatureOfProductLookUpModel.NATURE_OF_PRODUCT_DESC;

                db.NATURE_OF_PRODUCT_LOOKUP.Attach(nplu);
                db.NATURE_OF_PRODUCT_LOOKUP.Remove(nplu);
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
