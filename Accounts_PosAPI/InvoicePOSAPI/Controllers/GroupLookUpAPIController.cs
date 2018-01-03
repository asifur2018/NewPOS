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
    public class GroupLookUpAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpPost]
        public HttpResponseMessage CreateGroupLookUp(GroupLookUpModel _GroupLookUpModel)
        {

            try
            {
                GROUP_LOOKUP glu = new GROUP_LOOKUP();

                glu.GROUP_CODE = _GroupLookUpModel.GROUP_CODE;
                glu.GROUP_TYPE_CODE = _GroupLookUpModel.GROUP_TYPE_CODE;
                glu.GROUP_DESCRIPTION = _GroupLookUpModel.GROUP_DESCRIPTION;

                db.GROUP_LOOKUP.Add(glu);
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpGet]
        public HttpResponseMessage GetGroupLookUpList()
        {

            try
            {

                var str = (from a in db.GROUP_LOOKUP
                           select new GroupLookUpModel
                           {
                               GROUP_ID = a.GROUP_ID,
                               GROUP_CODE = a.GROUP_CODE,
                               GROUP_DESCRIPTION = a.GROUP_DESCRIPTION,
                               GROUP_TYPE_CODE = a.GROUP_TYPE_CODE

                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateGroupLookUp(GroupLookUpModel _GroupLookUpModel)
        {

            try
            {
                GROUP_LOOKUP glu = new GROUP_LOOKUP();

                glu.GROUP_ID = _GroupLookUpModel.GROUP_ID;
                glu.GROUP_CODE = _GroupLookUpModel.GROUP_CODE;
                glu.GROUP_DESCRIPTION = _GroupLookUpModel.GROUP_DESCRIPTION;
                glu.GROUP_TYPE_CODE = _GroupLookUpModel.GROUP_TYPE_CODE;

                db.GROUP_LOOKUP.Attach(glu);
                db.Entry(glu).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage DeleteGroupLookUp(GroupLookUpModel _GroupLookUpModel)
        {

            try
            {
                GROUP_LOOKUP glu = new GROUP_LOOKUP();

                glu.GROUP_ID = _GroupLookUpModel.GROUP_ID;
                glu.GROUP_CODE = _GroupLookUpModel.GROUP_CODE;
                glu.GROUP_DESCRIPTION = _GroupLookUpModel.GROUP_DESCRIPTION;
                glu.GROUP_TYPE_CODE = _GroupLookUpModel.GROUP_TYPE_CODE;

                db.GROUP_LOOKUP.Attach(glu);
                db.GROUP_LOOKUP.Remove(glu);
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
