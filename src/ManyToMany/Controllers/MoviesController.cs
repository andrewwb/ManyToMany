using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManyToMany.Data;
using ManyToMany.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ManyToMany.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _db;
        public MoviesController(ApplicationDbContext db) {
            _db = db;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<object> Get()
        {
            var movies = _db.Movies.Select(m => new {
                Title = m.Title,
                Id = m.Id,
                Actors = m.Actors.Select(ma => ma.Actor).ToList()
            }).ToList();

            return movies;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPost("{id}")]
        public void Post(int id, [FromBody]Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();

            _db.MovieActors.Add(new MovieActor {
                MovieId = movie.Id,
                ActorId = id
            });
            _db.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
