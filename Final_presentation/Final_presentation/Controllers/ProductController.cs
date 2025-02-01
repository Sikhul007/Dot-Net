using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Final_presentation.Controllers
{
    public class ProductController : ApiController
    {

        [HttpGet]
        [Route("api/product/all")]
        public HttpResponseMessage GetAll()
        {
            var data = ProductService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/product/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = ProductService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}