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
    public class DeliveryTypeLookUpAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpPost]
        public HttpResponseMessage CreateDeliveryTypeLookUp(DeliveryTypeLookUpModel _DeliveryTypeLookUpModel)
        {

            try
            {
                DELIVERY_TYPE_LOOKUP dtlu = new DELIVERY_TYPE_LOOKUP();

                dtlu.ID = _DeliveryTypeLookUpModel.ID;
                dtlu.CODE = _DeliveryTypeLookUpModel.CODE;
                dtlu.NAME = _DeliveryTypeLookUpModel.NAME;

                if (!db.DELIVERY_TYPE_LOOKUP.Any(a => a.ID == dtlu.ID))
                {
                    db.DELIVERY_TYPE_LOOKUP.Add(dtlu);
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
        public HttpResponseMessage GetDeliveryTypeLookUpList()
        {

            try
            {

                var str = (from a in db.DELIVERY_TYPE_LOOKUP
                           select new DeliveryTypeLookUpModel
                           {

                               ID = a.ID,
                               CODE = a.CODE,
                               NAME = a.NAME

                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateDeliveryTypeLookUp(DeliveryTypeLookUpModel _DeliveryTypeLookUpModel)
        {

            try
            {
                DELIVERY_TYPE_LOOKUP dtlu = new DELIVERY_TYPE_LOOKUP();

                dtlu.ID = _DeliveryTypeLookUpModel.ID;
                dtlu.CODE = _DeliveryTypeLookUpModel.CODE;
                dtlu.NAME = _DeliveryTypeLookUpModel.NAME;

                db.DELIVERY_TYPE_LOOKUP.Attach(dtlu);
                db.Entry(dtlu).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage DeleteDeliveryTypeLookUp(DeliveryTypeLookUpModel _DeliveryTypeLookUpModel)
        {

            try
            {
                DELIVERY_TYPE_LOOKUP dtlu = new DELIVERY_TYPE_LOOKUP();

                dtlu.ID = _DeliveryTypeLookUpModel.ID;
                dtlu.CODE = _DeliveryTypeLookUpModel.CODE;
                dtlu.NAME = _DeliveryTypeLookUpModel.NAME;

                db.DELIVERY_TYPE_LOOKUP.Attach(dtlu);
                db.DELIVERY_TYPE_LOOKUP.Remove(dtlu);
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
