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
    public class CompanyAPIController : ApiController
    {
        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();
        CompanyModel mm = new CompanyModel();

        [HttpGet]
        public HttpResponseMessage GetCompanies()
        {
            var str = (from a in db.COMPANies
                       where  a.IS_DELETE == false
                       select new CompanyModel
                       {

                           //DELIVERY_CODE = a.DELIVERY_CODE,
                           COMPANY_NAME = a.COMPANY_NAME,
                           //ADDRESS = a.ADDRESS,
                           //COUNTRY = a.COUNTRY,
                           //CONTACTS = a.CONTACTS,
                           //TELEPHONE = a.TELEPHONE,
                           //POSTCODE = a.POSTCODE,
                           COMPANY_ID = a.COMPANY_ID,
                           FAX = a.FAX,

                       }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, str);
        }



        [HttpPost]
        public HttpResponseMessage CreateCompany(CompanyModel _CompanyModel)
        {

            try
            {
                COMPANY com = new COMPANY();
                com.CREATION_TYPE = _CompanyModel.CREATION_TYPE;
                com.CREATION_DATE = _CompanyModel.CREATED_DATE;
                com.COMPANY_NAME = _CompanyModel.COMPANY_NAME;
                com.ADDRESS = _CompanyModel.ADDRESS;
                com.COUNTRY = _CompanyModel.COUNTRY;
                com.POSTCODE = _CompanyModel.POSTCODE;
                com.TELEPHONE = _CompanyModel.TELEPHONE;
                com.FAX = _CompanyModel.FAX;
                com.WEBSITE = _CompanyModel.WEBSITE;
                //com.COMPANY_STATUS = _CompanyModel.COMPANY_STATUS;
                //com.COMPANY_TYPE = _CompanyModel.COMPANY_TYPE;
                //com.START_YEAR = _CompanyModel.START_YEAR;
                //com.START_FIN_YEAR = _CompanyModel.START_FIN_YEAR;
                //com.END_FIN_YEAR = _CompanyModel.END_FIN_YEAR;
                com.IS_DELETE = false;
                db.COMPANies.Add(com);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpPost]
        public HttpResponseMessage CreateLogin(CompanyModel _CompanyModel)
        {

            try
            {
                COMPANY_LOGIN com = new COMPANY_LOGIN();
                com.USER_NAME = _CompanyModel.USER_NAME;
                com.PASSWORD = _CompanyModel.PASSWORD;
                com.COMPANY_ID = _CompanyModel.COMPANY_ID;
                com.CREATED_DATE = _CompanyModel.CREATED_DATE;
                com.IS_DELETE = false;
                db.COMPANY_LOGIN.Add(com);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpGet]
        public HttpResponseMessage CompanyLogin(string id, string password, int comp)
        {
            try
            {
                var str = (from a in db.COMPANY_LOGIN
                           where a.USER_NAME == id && a.PASSWORD == password && a.COMPANY_ID==comp
                           select new CompanyModel
                           {
                               COMPANY_ID = a.COMPANY_ID,
                               LOGIN_ID=a.LOGIN_ID,
                               //CREATED_DATE = a.CREATED_DATE,
                               PASSWORD = a.PASSWORD,
                               USER_NAME = a.USER_NAME,
                           }).FirstOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpPost]
        public HttpResponseMessage UpdateLogin(CompanyModel _CompanyModel)
        {
            var str = (from a in db.COMPANY_LOGIN where a.COMPANY_ID == _CompanyModel.COMPANY_ID && a.LOGIN_ID==_CompanyModel.LOGIN_ID select a).FirstOrDefault();
            str.LAST_LOGIN = _CompanyModel.CREATE_DATE_TIME;
            
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpPost]
        public HttpResponseMessage CreateCompanyAssistant(CompanyModel _CompanyModel)
        {

            try
            {
                COMPANY cm = new COMPANY();

                cm.CREATION_TYPE = _CompanyModel.CREATION_TYPE;
                cm.CREATION_DATE = _CompanyModel.CREATED_DATE;
                cm.COMPANY_NAME = _CompanyModel.COMPANY_NAME;
                cm.ADDRESS = _CompanyModel.ADDRESS;
                cm.COUNTRY = _CompanyModel.COUNTRY;
                cm.POSTCODE = _CompanyModel.POSTCODE;
                cm.TELEPHONE = _CompanyModel.TELEPHONE;
                cm.FAX = _CompanyModel.FAX;
                cm.WEBSITE = _CompanyModel.WEBSITE;

                cm.COMPANY_STATUS = _CompanyModel.COMPANY_STATUS;
                cm.COMPANY_TYPE = _CompanyModel.COMPANY_TYPE;
                cm.START_YEAR = _CompanyModel.START_YEAR;
                cm.START_FIN_YEAR = _CompanyModel.START_FIN_YEAR;
                cm.END_FIN_YEAR = _CompanyModel.END_FIN_YEAR;
                //cm.POSTCODE = _CompanyModel.POSTCODE;
                //cm.TELEPHONE = _CompanyModel.TELEPHONE;
                //cm.FAX = _CompanyModel.FAX;
                //cm.WEBSITE = _CompanyModel.WEBSITE;
                //com.COMPANY_STATUS = _CompanyModel.COMPANY_STATUS;
                //com.COMPANY_TYPE = _CompanyModel.COMPANY_TYPE;
                //com.START_YEAR = _CompanyModel.START_YEAR;
                //com.START_FIN_YEAR = _CompanyModel.START_FIN_YEAR;
                //com.END_FIN_YEAR = _CompanyModel.END_FIN_YEAR;
                cm.IS_DELETE = false;
                db.COMPANies.Add(cm);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpGet]
        public HttpResponseMessage ShowData(int id)
        {
            var str = (from a in db.CUSTOMER_DELIVERY_ADDRESS
                       where a.COMPANY_ID == id && a.IS_DELETE == false
                       select new DeliveryAddressModel
                       {

                           DELIVERY_CODE = a.DELIVERY_CODE,
                           DELIVERY_COMPANY_NAME = a.DELIVERY_COMPANY_NAME,
                           ADDRESS = a.ADDRESS,
                           COUNTRY = a.COUNTRY,
                           CONTACTS = a.CONTACTS,
                           TELEPHONE = a.TELEPHONE,
                           POSTCODE = a.POSTCODE,
                           DELIVERY_ID = a.DELIVERY_ID,
                           FAX = a.FAX,

                       }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, str);
        }




    }
}
