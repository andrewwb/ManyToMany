﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManyToMany.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ManyToMany.Controllers
{
    [Route("api/[controller]")]
    public class ActorsController : Controller
    {
        private ApplicationDbContext _db;
        public ActorsController(ApplicationDbContext db) {
            _db = db;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<object> Get()
        {
            var actors = _db.Actors.Select(m => new {
                FirstName = m.FirstName,
                LastName = m.LastName,
                Id = m.Id,
                Movies = m.Movies.Select(ma => ma.Movie).ToList()
            }).ToList();

            return actors;
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
