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
    public class ProductTypeLookUpAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpPost]
        public HttpResponseMessage CreateProductTypeLookUp(ProductTypeLookUpModel _ProductTypeLookUpModel)
        {

            try
            {
                PRODUCT_TYPE_LOOKUP ptlu = new PRODUCT_TYPE_LOOKUP();

                ptlu.PRODUCT_TYPE_ID = _ProductTypeLookUpModel.PRODUCT_TYPE_ID;
                ptlu.PRODUCT_TYPE_NAME = _ProductTypeLookUpModel.PRODUCT_TYPE_NAME;
                ptlu.PRODUCT_TYPE_DESCRIPTION = _ProductTypeLookUpModel.PRODUCT_TYPE_DESCRIPTION;

                db.PRODUCT_TYPE_LOOKUP.Add(ptlu);
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpGet]
        public HttpResponseMessage GetProductTypeLookUpList()
        {

            try
            {

                var str = (from a in db.PRODUCT_TYPE_LOOKUP
                           select new ProductTypeLookUpModel
                           {
                               PRODUCT_TYPE_ID = a.PRODUCT_TYPE_ID,
                               PRODUCT_TYPE_NAME = a.PRODUCT_TYPE_NAME,
                               PRODUCT_TYPE_DESCRIPTION = a.PRODUCT_TYPE_DESCRIPTION
                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }


        [HttpPost]
        public HttpResponseMessage UpdateProductTypeLookUp(ProductTypeLookUpModel _ProductTypeLookUpModel)
        {

            try
            {
                PRODUCT_TYPE_LOOKUP ptlu = new PRODUCT_TYPE_LOOKUP();

                ptlu.PRODUCT_TYPE_ID = _ProductTypeLookUpModel.PRODUCT_TYPE_ID;
                ptlu.PRODUCT_TYPE_NAME = _ProductTypeLookUpModel.PRODUCT_TYPE_NAME;
                ptlu.PRODUCT_TYPE_DESCRIPTION = _ProductTypeLookUpModel.PRODUCT_TYPE_DESCRIPTION;

                db.PRODUCT_TYPE_LOOKUP.Attach(ptlu);
                db.Entry(ptlu).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage DeleteProductTypeLookUp(ProductTypeLookUpModel _ProductTypeLookUpModel)
        {

            try
            {
                PRODUCT_TYPE_LOOKUP ptlu = new PRODUCT_TYPE_LOOKUP();

                ptlu.PRODUCT_TYPE_ID = _ProductTypeLookUpModel.PRODUCT_TYPE_ID;
                ptlu.PRODUCT_TYPE_NAME = _ProductTypeLookUpModel.PRODUCT_TYPE_NAME;
                ptlu.PRODUCT_TYPE_DESCRIPTION = _ProductTypeLookUpModel.PRODUCT_TYPE_DESCRIPTION;

                db.PRODUCT_TYPE_LOOKUP.Attach(ptlu);
                db.PRODUCT_TYPE_LOOKUP.Remove(ptlu);
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
