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
    public class ProductGroupLookUpAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpPost]
        public HttpResponseMessage CreateProductGroupLookUp(ProductGroupLookUpModel _ProductGroupLookUpModel)
        {

            try
            {
                PRODUCT_GROUP_LOOKUP pglu = new PRODUCT_GROUP_LOOKUP();
                pglu.PRODUCT_GROUP_ID = _ProductGroupLookUpModel.PRODUCT_GROUP_ID;
                pglu.GROUP_CODE = _ProductGroupLookUpModel.GROUP_CODE;
                pglu.GROUP_DESCRIPTION = _ProductGroupLookUpModel.GROUP_DESCRIPTION;

                db.PRODUCT_GROUP_LOOKUP.Add(pglu);
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpGet]
        public HttpResponseMessage GetProductGroupLookUpList()
        {

            try
            {

                var str = (from a in db.PRODUCT_GROUP_LOOKUP
                           select new ProductGroupLookUpModel
                           {
                               PRODUCT_GROUP_ID = a.PRODUCT_GROUP_ID,
                               GROUP_CODE = a.GROUP_CODE,
                               GROUP_DESCRIPTION = a.GROUP_DESCRIPTION
                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }


        [HttpPost]
        public HttpResponseMessage UpdateProductGroupLookUp(ProductGroupLookUpModel _ProductGroupLookUpModel)
        {

            try
            {
                PRODUCT_GROUP_LOOKUP pglu = new PRODUCT_GROUP_LOOKUP();

                pglu.PRODUCT_GROUP_ID = _ProductGroupLookUpModel.PRODUCT_GROUP_ID;
                pglu.GROUP_DESCRIPTION = _ProductGroupLookUpModel.GROUP_DESCRIPTION;
                pglu.GROUP_CODE = _ProductGroupLookUpModel.GROUP_CODE;

                db.PRODUCT_GROUP_LOOKUP.Attach(pglu);
                db.Entry(pglu).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage DeleteProductGroupLookUp(ProductGroupLookUpModel _ProductGroupLookUpModel)
        {

            try
            {
                PRODUCT_GROUP_LOOKUP pglu = new PRODUCT_GROUP_LOOKUP();

                pglu.PRODUCT_GROUP_ID = _ProductGroupLookUpModel.PRODUCT_GROUP_ID;
                pglu.GROUP_DESCRIPTION = _ProductGroupLookUpModel.GROUP_DESCRIPTION;
                pglu.GROUP_CODE = _ProductGroupLookUpModel.GROUP_CODE;

                db.PRODUCT_GROUP_LOOKUP.Attach(pglu);
                db.PRODUCT_GROUP_LOOKUP.Remove(pglu);
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
