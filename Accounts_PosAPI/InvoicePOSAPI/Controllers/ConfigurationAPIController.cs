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
    public class ConfigurationAPIController : ApiController
    {

        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpGet]
        public HttpResponseMessage GetConfiguration(int id)
        {
            var str = (from a in db.CONFIGURATIONs
                       where a.CONFIGURATION_ID == id
                       select new ConfigurationModel
                       {
                           KEY_REMAP = a.KEY_REMAP,
                           LONG_TEMP_NAMES = a.LONG_TEMP_NAMES,
                           TRACE = a.TRACE,
                           PDF_LICENCE_LEVEL = a.PDF_LICENCE_LEVEL
                       }).First();
            return Request.CreateResponse(HttpStatusCode.OK, str);
        }
    }
}
