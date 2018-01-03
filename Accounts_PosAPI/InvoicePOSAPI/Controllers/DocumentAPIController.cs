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
    public class DocumentAPIController : ApiController
    {

        ACCOUNTS_POSEntities db = new ACCOUNTS_POSEntities();
        DocumentModel da = new DocumentModel();
        [HttpGet]
        public HttpResponseMessage DocumentList(string customerCode)
        {

            try
            {

                var str = (from a in db.CUSTOMER_DOCUMENT
                           where a.CUSTOMER_CODE.Equals(customerCode)
                           select new DocumentModel
                           {

                               FILE_NAME = a.FILE_NAME,
                               DATE = a.DATE,
                               TYPE_ID_DOC = a.TYPE_ID_DOC,
                               SIZE = a.SIZE,
                               TAG = a.TAG,
                               CUSTOMER_CODE = a.CUSTOMER_CODE,
                               DOCUMENT_ID = a.DOCUMENT_ID,

                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "DatabaseException");
        }

        [HttpGet]
        public HttpResponseMessage ProductDocumentList(string ProductCode)
        {

            try
            {

                var str = (from a in db.PRODUCT_DOCUMENT
                           where a.PRODUCT_CODE.Equals(ProductCode)
                           select new DocumentModel
                           {

                               FILE_NAME = a.FILE_NAME,
                               DATE = a.DATE,
                               TYPE_ID_DOC = a.TYPE_ID_DOC,
                               SIZE = a.SIZE,
                               TAG = a.TAG,
                               PRODUCT_CODE = a.PRODUCT_CODE,
                               DOCUMENT_ID = a.DOCUMENT_ID,

                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "DatabaseException");
        }


        [HttpGet]
        public HttpResponseMessage SupplierDocumentList(string SupplierCode)
        {

            try
            {

                var str = (from a in db.SUPPLIER_DOCUMENT
                           where a.SUPPLIER_CODE.Equals(SupplierCode)
                           select new DocumentModel
                           {

                               FILE_NAME = a.FILE_NAME,
                               DATE = a.DATE,
                               TYPE_ID_DOC = a.TYPE_ID_DOC,
                               SIZE = a.SIZE,
                               TAG = a.TAG,
                               SUPPLIER_CODE = a.SUPPLIER_CODE,
                               DOCUMENT_ID = a.DOCUMENT_ID,

                           }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, str);
            }
            catch
            {
                throw;
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "DatabaseException");
        }

        [HttpPost]
        public HttpResponseMessage CreateDocument(DocumentModel _DocumentModel)
        {


            try
            {
                CUSTOMER_DOCUMENT def = new CUSTOMER_DOCUMENT();
                def.CUSTOMER_CODE = _DocumentModel.CUSTOMER_CODE;
                def.DATE = _DocumentModel.DATE;
                def.FILE_NAME = _DocumentModel.FILE_NAME;
                def.SIZE = _DocumentModel.SIZE;
                def.TAG = _DocumentModel.TAG;

                db.CUSTOMER_DOCUMENT.Add(def);
                db.SaveChanges();


            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpPost]
        public HttpResponseMessage CreateSupplierDocument(DocumentModel _DocumentModel)
        {


            try
            {
                SUPPLIER_DOCUMENT def = new SUPPLIER_DOCUMENT();
                def.SUPPLIER_CODE = _DocumentModel.SUPPLIER_CODE;
                def.DATE = _DocumentModel.DATE;
                def.FILE_NAME = _DocumentModel.FILE_NAME;
                def.SIZE = _DocumentModel.SIZE;
                def.TAG = _DocumentModel.TAG;

                db.SUPPLIER_DOCUMENT.Add(def);
                db.SaveChanges();


            }
            catch (Exception)
            {

                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }




        [HttpGet]
        public HttpResponseMessage DeleteDocument(int id)
        {
            try
            {
                CUSTOMER_DOCUMENT document = new CUSTOMER_DOCUMENT { DOCUMENT_ID = id };
                db.CUSTOMER_DOCUMENT.Attach(document);
                db.CUSTOMER_DOCUMENT.Remove(document);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpGet]
        public HttpResponseMessage DeleteProductDocument(int id)
        {
            try
            {
                PRODUCT_DOCUMENT document = new PRODUCT_DOCUMENT { DOCUMENT_ID = id };
                db.PRODUCT_DOCUMENT.Attach(document);
                db.PRODUCT_DOCUMENT.Remove(document);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }


        [HttpGet]
        public HttpResponseMessage DeleteSupplierDocument(int id)
        {
            try
            {
                SUPPLIER_DOCUMENT document = new SUPPLIER_DOCUMENT { DOCUMENT_ID = id };
                db.SUPPLIER_DOCUMENT.Attach(document);
                db.SUPPLIER_DOCUMENT.Remove(document);
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
