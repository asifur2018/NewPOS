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
    public class GroupTypeLookUpAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();


        [HttpPost]
        public HttpResponseMessage CreateGroupTypeLookUp(GroupTypeLookUpModel _GroupTypeLookUpModel)
        {

            try
            {
                GROUP_TYPE_LOOKUP gtlu = new GROUP_TYPE_LOOKUP();

                gtlu.GROUP_TYPE_ID = _GroupTypeLookUpModel.GROUP_TYPE_ID;
                gtlu.GROUP_CODE = _GroupTypeLookUpModel.GROUP_CODE;
                gtlu.GROUP_TYPE_NAME = _GroupTypeLookUpModel.GROUP_TYPE_NAME;

                db.GROUP_TYPE_LOOKUP.Add(gtlu);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage GetGroupTypeLookUpList()
        {

            try
            {

                var str = (from a in db.GROUP_TYPE_LOOKUP
                           select new GroupTypeLookUpModel
                           {
                               GROUP_TYPE_ID = a.GROUP_TYPE_ID,
                               GROUP_CODE = a.GROUP_CODE,
                               GROUP_TYPE_NAME = a.GROUP_TYPE_NAME

                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateGroupTypeLookUp(GroupTypeLookUpModel _GroupTypeLookUpModel)
        {

            try
            {
                GROUP_TYPE_LOOKUP gtlm = new GROUP_TYPE_LOOKUP();

                gtlm.GROUP_TYPE_ID = _GroupTypeLookUpModel.GROUP_TYPE_ID;
                gtlm.GROUP_TYPE_NAME = _GroupTypeLookUpModel.GROUP_TYPE_NAME;
                gtlm.GROUP_CODE = _GroupTypeLookUpModel.GROUP_CODE;

                db.GROUP_TYPE_LOOKUP.Attach(gtlm);
                db.Entry(gtlm).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage DeleteGroupTypeLookUp(GroupTypeLookUpModel _GroupTypeLookUpModel)
        {

            try
            {
                GROUP_TYPE_LOOKUP gtlm = new GROUP_TYPE_LOOKUP();

                gtlm.GROUP_TYPE_ID = _GroupTypeLookUpModel.GROUP_TYPE_ID;
                gtlm.GROUP_TYPE_NAME = _GroupTypeLookUpModel.GROUP_TYPE_NAME;
                gtlm.GROUP_CODE = _GroupTypeLookUpModel.GROUP_CODE;

                db.GROUP_TYPE_LOOKUP.Attach(gtlm);
                db.GROUP_TYPE_LOOKUP.Remove(gtlm);
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
