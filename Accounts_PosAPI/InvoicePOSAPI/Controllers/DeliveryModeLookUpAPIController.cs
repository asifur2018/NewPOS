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
    public class DeliveryModeLookUpAPIController : ApiController
    {

        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpPost]
        public HttpResponseMessage CreateDeliveryModeLookUp(DeliveryModeLookUpModel _DeliveryModeLookUpModel)
        {

            try
            {
                DELIVERY_MODE_LOOKUP dmlu = new DELIVERY_MODE_LOOKUP();

                dmlu.ID = _DeliveryModeLookUpModel.ID;
                dmlu.MODE_CODE = _DeliveryModeLookUpModel.MODE_CODE;
                dmlu.MODE_NAME = _DeliveryModeLookUpModel.MODE_NAME;

                if (!db.DELIVERY_MODE_LOOKUP.Any(a => a.ID == dmlu.ID))
                {
                    db.DELIVERY_MODE_LOOKUP.Add(dmlu);
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
        public HttpResponseMessage GetDeliveryModeLookUpList()
        {

            try
            {

                var str = (from a in db.DELIVERY_MODE_LOOKUP
                           select new DeliveryModeLookUpModel
                           {

                               ID = a.ID,
                               MODE_CODE = a.MODE_CODE,
                               MODE_NAME = a.MODE_NAME

                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }



        [HttpPost]
        public HttpResponseMessage UpdateDeliveryModeLookUp(DeliveryModeLookUpModel _DeliveryModeLookUpModel)
        {

            try
            {
                DELIVERY_MODE_LOOKUP dmlu = new DELIVERY_MODE_LOOKUP();

                dmlu.ID = _DeliveryModeLookUpModel.ID;
                dmlu.MODE_CODE = _DeliveryModeLookUpModel.MODE_CODE;
                dmlu.MODE_NAME = _DeliveryModeLookUpModel.MODE_NAME;

                db.DELIVERY_MODE_LOOKUP.Attach(dmlu);
                db.Entry(dmlu).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage DeleteDeliveryModeLookUp(DeliveryModeLookUpModel _DeliveryModeLookUpModel)
        {

            try
            {
                DELIVERY_MODE_LOOKUP dmlu = new DELIVERY_MODE_LOOKUP();

                dmlu.ID = _DeliveryModeLookUpModel.ID;
                dmlu.MODE_CODE = _DeliveryModeLookUpModel.MODE_CODE;
                dmlu.MODE_NAME = _DeliveryModeLookUpModel.MODE_NAME;

                db.DELIVERY_MODE_LOOKUP.Attach(dmlu);
                db.DELIVERY_MODE_LOOKUP.Remove(dmlu);
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
