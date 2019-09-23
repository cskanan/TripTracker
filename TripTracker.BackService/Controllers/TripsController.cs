using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private Repository _repository;

        public TripsController(Repository repository)
        {
            _repository = repository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_repository.GetTrips());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Trip> Get(int id)
        {
            return Ok(value: _repository.GetTrip(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Trip value)
        {
            _repository.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Trip value)
        {
            _repository.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}