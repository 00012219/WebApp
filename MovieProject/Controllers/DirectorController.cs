using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;
using MovieProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Controllers
{
    // Director controller
    [ApiController]
    [Route("directors")]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorsService;
      

        public DirectorsController(IDirectorService directorsService)
        {
            _directorsService = directorsService;
        }

        [HttpGet]
        public ActionResult<List<Director>> GetDirectors()
        {
            var directors = _directorsService.GetAll();
            return Ok(directors);
        }

        [HttpGet("{id}")]
        public ActionResult<Director> GetDirectorById(int id)
        {
            var director = _directorsService.GetById(id);
            if (director == null)
            {
                return NotFound();
            }
            return Ok(director);
        }

        [HttpPost]
        public ActionResult<Director> CreateDirector(Director director)
        {
            _directorsService.Create(director);
            return CreatedAtAction(nameof(GetDirectorById), new { id = director.Id }, director);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, Director director)
        {
            _directorsService.Update(id, director);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            _directorsService.Delete(id);
            return NoContent();
        }
    }
}
