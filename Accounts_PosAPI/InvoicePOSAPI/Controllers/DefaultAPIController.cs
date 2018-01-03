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
    public class DefaultAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();
        DefaultModel mm = new DefaultModel();

        [HttpPost]
        public HttpResponseMessage CreateDefault(DefaultModel _DefaultModel)
        {


            try
            {
                CUSTOMER_DEFAULT def = new CUSTOMER_DEFAULT();
                def.CURRENCY_CODE = _DefaultModel.CURRENCY_CODE;
                def.CUSTOMER_CODE = _DefaultModel.CUSTOMER_CODE;
                def.DEFAULT_NOMINAL_CODE = _DefaultModel.DEFAULT_NOMINAL_CODE;
                def.DEFAULT_TAX_CODE = _DefaultModel.DEFAULT_TAX_CODE;
                def.DEPARTMENT = _DefaultModel.DEPARTMENT;
                def.IS_NOMINALCODE_SALES = _DefaultModel.IS_NOMINALCODE_SALES;
                def.IS_TAXCODE_SALE = _DefaultModel.IS_TAXCODE_SALE;
                def.REPORTING_PASSWORD = _DefaultModel.REPORTING_PASSWORD;

                db.CUSTOMER_DEFAULT.Add(def);
                db.SaveChanges();




            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }
    }
}
