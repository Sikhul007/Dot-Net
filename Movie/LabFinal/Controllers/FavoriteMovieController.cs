using BLL.DTOs;
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
    public class FavoriteMovieController : ApiController
    {
        [HttpPost]
        [Route("api/favorite-movies/add")]
        public HttpResponseMessage AddToFavorites(FavoriteMovieDTO favoriteMovieDTO)
        {
            if (FavoriteMovieService.AddToFavorites(favoriteMovieDTO))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Movie added to favorites.");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to add movie to favorites.");
        }

        [HttpDelete]
        //[Route("api/favorite-movies/remove?userId={id}&movieId={id}")]
        [Route("api/favorite-movies/remove/{userId}/{movieId}")]
        public HttpResponseMessage RemoveFromFavorites(int userId, int movieId)
        {
            if (FavoriteMovieService.RemoveFromFavorites(userId, movieId))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Movie removed from favorites.");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to remove movie from favorites.");
        }

        [HttpGet]
        [Route("api/favorite-movies/all")]
        public HttpResponseMessage GetAllFavoriteMovies()
        {
            var data = FavoriteMovieService.GetAllFavoriteMovies();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}