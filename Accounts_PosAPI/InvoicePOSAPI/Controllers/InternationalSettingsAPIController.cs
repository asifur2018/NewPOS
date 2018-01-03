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
    public class InternationalSettingsAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpGet]
        public HttpResponseMessage GetInternationalSettings(int id)
        {
            var str = (from a in db.INTERNATIONAL_SETTINGS
                       where a.INTERNATIONAL_SETTINGS_ID == id
                       select new InternationalSettingsModel
                       {
                           SYSTEM_LOCALE = a.SYSTEM_LOCALE,
                           COUNTRY_CODE = a.COUNTRY_CODE,
                           COUNTRY_NAME = a.COUNTRY_NAME,
                           DATE_FORMAT = a.DATE_FORMAT,
                       }).First();
            return Request.CreateResponse(HttpStatusCode.OK, str);
        }
    }
}
