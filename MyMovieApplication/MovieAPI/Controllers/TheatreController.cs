
using System;
using Microsoft.AspNetCore.Mvc;
using MyMovieApp.Business.Services;
using MyMovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TheatreController : ControllerBase
    {
        TheatreService _theatreService;

        public TheatreController(TheatreService theatreService)
        {
            _theatreService = theatreService;
        }

        [HttpGet("AllTheatre")]
        public IActionResult AllTheatre()
        {
            return Ok(_theatreService.AllTheatre());
        }

        [HttpPost("SearchTheatre")]
        public IActionResult SearchTheatre(TheatreModel thetreModel)
        {
            return Ok(_theatreService.SearchTheatre(thetreModel));
        }

        [HttpPost("InsertData")]
        public IActionResult InsertData(TheatreModel thetreModel)
        {
            return Ok(_theatreService.InsertData(thetreModel));
        }

        [HttpPost("Login")]
        public IActionResult Login(TheatreModel thetreModel)
        {
            return Ok(_theatreService.Login(thetreModel));
        }

        [HttpPut("Update")]
        public IActionResult Update(TheatreModel thetreModel)
        {
            return Ok(_theatreService.Update(thetreModel));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_theatreService.Delete(id));
        }

        [HttpGet("SelectTheatreById")]
        public IActionResult SelectTheatreById(int id)
        {
            return Ok(_theatreService.SelectTheatreById(id));
        }

    }
}
