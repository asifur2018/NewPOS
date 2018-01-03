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
    public class DeliveryAddressAPIController : ApiController
    {
                ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();
                DeliveryAddressModel da = new DeliveryAddressModel();
                [HttpGet]
                public HttpResponseMessage AddressList(int id)
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
                                   FAX=a.FAX,
                               
                               }).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, str);
                }

        

                [HttpPost]
                public HttpResponseMessage CreateDelivery(DeliveryAddressModel _DeliveryAddressModel)
                {
                    try
                    {

                        CUSTOMER_DELIVERY_ADDRESS cus = new CUSTOMER_DELIVERY_ADDRESS();
                        cus.DELIVERY_CODE = _DeliveryAddressModel.DELIVERY_CODE;
                        cus.CUSTOMER_CODE = _DeliveryAddressModel.CUSTOMER_CODE;
                        cus.DELIVERY_COMPANY_NAME = _DeliveryAddressModel.DELIVERY_COMPANY_NAME;
                        cus.ADDRESS = _DeliveryAddressModel.ADDRESS;
                        cus.COUNTRY = _DeliveryAddressModel.COUNTRY;
                        //cus.COUNTRY = _DeliveryAddressModel.COUNTRY;
                        cus.CONTACTS = _DeliveryAddressModel.CONTACTS;
                        cus.POSTCODE = _DeliveryAddressModel.POSTCODE;
                        //cus.TELEPHONE = _DeliveryAddressModel.TELEPHONE;
                        //cus.FAX = _DeliveryAddressModel.FAX;
                        cus.TELEPHONE = _DeliveryAddressModel.TELEPHONE;
                        cus.FAX = _DeliveryAddressModel.FAX;
                        cus.CUSTOMER_CODE = _DeliveryAddressModel.CUSTOMER_CODE;
                        cus.IS_DELETE = false;
                        cus.STATUS = "UnSaved";
                        cus.COMPANY_ID = 1;
                        db.CUSTOMER_DELIVERY_ADDRESS.Add(cus);
                        db.SaveChanges();

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, "success");
                }


                [HttpGet]
                public HttpResponseMessage EditDelivery(int id)
                {
                    var str = (from a in db.CUSTOMER_DELIVERY_ADDRESS
                               where a.DELIVERY_ID == id && a.IS_DELETE == false
                               select new DeliveryAddressModel
                               {
                                   DELIVERY_CODE = a.DELIVERY_CODE,
                                   DELIVERY_COMPANY_NAME = a.DELIVERY_COMPANY_NAME,
                                   ADDRESS = a.ADDRESS,
                                   COUNTRY = a.COUNTRY,
                                   CONTACTS = a.CONTACTS,
                                   TELEPHONE = a.TELEPHONE,
                                   POSTCODE = a.POSTCODE,
                                   EC_COUNTRY = a.EC_COUNTRY,
                                   SAME_STATEMENT = a.SAME_STATEMENT,
                                   FAX = a.FAX,
                                   DELIVERY_MODE = a.DELIVERY_MODE,
                                   DELIVERY_TIME = a.DELIVERY_TIME,

                               }).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, str);
                }

                [HttpPost]
                public HttpResponseMessage AddressUpdate(DeliveryAddressModel _DeliveryAddressModel)
                {
                    var str = (from a in db.CUSTOMER_DELIVERY_ADDRESS where a.DELIVERY_ID == _DeliveryAddressModel.DELIVERY_ID select a).FirstOrDefault();
                    str.DELIVERY_CODE = _DeliveryAddressModel.DELIVERY_CODE;
                    str.DELIVERY_COMPANY_NAME = _DeliveryAddressModel.DELIVERY_COMPANY_NAME;
                    str.ADDRESS = _DeliveryAddressModel.ADDRESS;
                    str.COUNTRY = _DeliveryAddressModel.COUNTRY;
                    str.CONTACTS = _DeliveryAddressModel.CONTACTS;
                    str.TELEPHONE = _DeliveryAddressModel.TELEPHONE;
                    str.POSTCODE = _DeliveryAddressModel.POSTCODE;
                    str.FAX = _DeliveryAddressModel.FAX;
                    str.DELIVERY_MODE = _DeliveryAddressModel.DELIVERY_MODE;
                    str.DELIVERY_TIME = _DeliveryAddressModel.DELIVERY_TIME;
                    str.EC_COUNTRY = _DeliveryAddressModel.EC_COUNTRY;
                    str.SAME_STATEMENT = _DeliveryAddressModel.SAME_STATEMENT;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "success");
                }

                [HttpGet]
                public HttpResponseMessage DeleteAddress(int id)
                {
                    var str = (from a in db.CUSTOMER_DELIVERY_ADDRESS
                               where a.DELIVERY_ID == id
                               select a).FirstOrDefault();
                    str.IS_DELETE = true;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "success");
                }

        
    }
}
