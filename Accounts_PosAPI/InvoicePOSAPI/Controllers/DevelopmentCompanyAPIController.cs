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
    public class DevelopmentCompanyAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpGet]
        public HttpResponseMessage GetDevelopmentCompanyDetails(int id)
        {
            var str = (from a in db.DEVELOPMENT_COMPANY
                       where a.COMPANY_ID == id
                       select new DevelopmentCompanyModel
                       {
                           ADDRESS = a.ADDRESS,
                           EMAIL = a.EMAIL,
                           TELEPHONE = a.TELEPHONE,
                           WEBSITE = a.WEBSITE,
                           FAX = a.FAX
                       }).First();
            return Request.CreateResponse(HttpStatusCode.OK, str);
        }
    }
}
