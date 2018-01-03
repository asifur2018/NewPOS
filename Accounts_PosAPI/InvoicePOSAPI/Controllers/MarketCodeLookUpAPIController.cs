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
    public class MarketCodeLookUpAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();

        [HttpPost]
        public HttpResponseMessage CreateMarketCodeLookUp(MarketCodeLookUpModel _MarketCodeLookUpModel)
        {

            try
            {
                MARKET_CODE_LOOKUP mcl = new MARKET_CODE_LOOKUP();

                mcl.MARKET_CODE_ID = _MarketCodeLookUpModel.MARKET_CODE_ID;
                mcl.CODE = _MarketCodeLookUpModel.CODE;
                mcl.DESCRIPTION = _MarketCodeLookUpModel.DESCRIPTION;
                mcl.DATE_ENTERED = _MarketCodeLookUpModel.DATE_ENTERED;

                db.MARKET_CODE_LOOKUP.Add(mcl);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }




        [HttpGet]
        public HttpResponseMessage GetMarketCodeLookUpList()
        {

            try
            {

                var str = (from a in db.MARKET_CODE_LOOKUP
                           select new MarketCodeLookUpModel
                           {
                               MARKET_CODE_ID = a.MARKET_CODE_ID,
                               CODE = a.CODE,
                               DESCRIPTION = a.DESCRIPTION,
                               DATE_ENTERED = a.DATE_ENTERED
                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
        }


        [HttpPost]
        public HttpResponseMessage UpdateMarketCodeLookUp(MarketCodeLookUpModel _MarketCodeLookUpModel)
        {

            try
            {
                MARKET_CODE_LOOKUP mclm = new MARKET_CODE_LOOKUP();

                mclm.MARKET_CODE_ID = _MarketCodeLookUpModel.MARKET_CODE_ID;
                mclm.CODE = _MarketCodeLookUpModel.CODE;
                mclm.DATE_ENTERED = _MarketCodeLookUpModel.DATE_ENTERED;
                mclm.DESCRIPTION = _MarketCodeLookUpModel.DESCRIPTION;

                db.MARKET_CODE_LOOKUP.Attach(mclm);
                db.Entry(mclm).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            catch
            {
                throw;

            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpPost]
        public HttpResponseMessage DeleteMarketCodeLookUp(MarketCodeLookUpModel _MarketCodeLookUpModel)
        {

            try
            {
                MARKET_CODE_LOOKUP mclm = new MARKET_CODE_LOOKUP();

                mclm.MARKET_CODE_ID = _MarketCodeLookUpModel.MARKET_CODE_ID;
                mclm.CODE = _MarketCodeLookUpModel.CODE;
                mclm.DATE_ENTERED = _MarketCodeLookUpModel.DATE_ENTERED;
                mclm.DESCRIPTION = _MarketCodeLookUpModel.DESCRIPTION;

                db.MARKET_CODE_LOOKUP.Attach(mclm);
                db.MARKET_CODE_LOOKUP.Remove(mclm);
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
