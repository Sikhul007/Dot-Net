using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;

namespace LabFinal.Controllers
{
    public class WatchlistController : ApiController
    {
        [HttpGet]
        [Route("api/Watch-List/all")]
        public HttpResponseMessage GetWatchList()
        {
            var data = WatchlistService.GetWatchList();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/Watch-List/user/{userId}")]
        public HttpResponseMessage GetWatchlistByUser(int userId)
        {
            var data = WatchlistService.GetWatchlistByUser(userId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}