using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Services.Description;

namespace LabFinal.Controllers
{
    public class MovieController : ApiController
    {

        [HttpGet]
        [Route("api/movie/all")]
        public HttpResponseMessage GetAllMovies()
        {
            var data = MovieService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/movie/all/{id}")]
        public HttpResponseMessage GetMovieById(int id)
        {
            var data = MovieService.Get(id);
            if (data == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Movie not found.");
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/movie/create")]
        public HttpResponseMessage CreateMovie(MovieDTO movie)
        {
            var data = MovieService.Create(movie);
            if (data)
                return Request.CreateResponse(HttpStatusCode.Created, "Movie added successfully.");
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to add movie.");
        }

        [HttpDelete]
        [Route("api/movie/delete/{id}")]
        public HttpResponseMessage DeleteMovie(int id)
        {
            var data = MovieService.Delete(id);
            if (data)
                return Request.CreateResponse(HttpStatusCode.OK, "Movie deleted successfully.");
            return Request.CreateResponse(HttpStatusCode.NotFound, "Movie not found.");
        }

        [HttpPut]
        [Route("api/movie/update/{id}")]
        public HttpResponseMessage Update(MovieDTO movie, int id)
        {
            movie.Id = id;
            var data = MovieService.Update(movie);
            if (data)
                return Request.CreateResponse(HttpStatusCode.OK, "Movie updated successfully.");
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/movie/serarchbytitle/{title}")]
        public HttpResponseMessage SerachByTitle(string title)
        {
            var data = MovieService.SearchByTitle(title);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/movie/searchbydirector/{director}")]
        public HttpResponseMessage SearchByDirector(string director)
        {
            var data = MovieService.SearchByDirector(director);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}