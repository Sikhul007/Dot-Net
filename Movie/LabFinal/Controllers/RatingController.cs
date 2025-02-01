//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Net.Http;
//using System.Web.Http;
//using BLL.Services;
//using System.Net;

//namespace LabFinal.Controllers
//{
//    public class RatingController : ApiController
//    {
//        [HttpGet]
//        [Route("api/Watch-List/all")]
//        public HttpResponseMessage GetRating()
//        {
//            var data = RatingService.GetRating();
//            return Request.CreateResponse(HttpStatusCode.OK, data);
//        }
//    }
//}