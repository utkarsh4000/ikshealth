using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMovieApp.Business.Services;
using MyMovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieService _movieServices;

        public MovieController(MovieService movieServices)
        {
            _movieServices = movieServices;
        }

        [HttpGet("SelectMovie")]
        public IActionResult SelectMovie()
        {
            return Ok(_movieServices.SelectMovie());
        }

        [HttpPost("AddMovie")]
        public IActionResult AddMovie(MovieModel movieModel)
        {
            return Ok(_movieServices.AddMovie(movieModel));
        }
        [HttpPost("Login")]
        public IActionResult Login(MovieModel movieModel)
        {
            return Ok(_movieServices.Login(movieModel));
        }

        [HttpPut("Update")]
        public IActionResult Update(MovieModel movieModel)
        {
            return Ok(_movieServices.Update(movieModel));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_movieServices.Delete(id));
        }

        [HttpGet("SelectMovieById")]
        public IActionResult SelectMovieById(int id)
        {
            return Ok(_movieServices.SelectMovieById(id));
        }
    }
}
