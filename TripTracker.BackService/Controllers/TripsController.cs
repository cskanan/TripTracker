using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TripTracker.BackService.Data;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private TripContext _context;

        public TripsController(TripContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; // This is good approach for
                                                                                             // these kind of scenario as 
                                                                                             // it doesnt require to track
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Trips.ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(value: _context.Trips.FirstOrDefault(t => t.Id == id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Trip value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Trips.Add(value);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Trip value)
        {

            if (!_context.Trips.Any(t => t.Id == id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Trips.Update(value);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var trip = await  _context.Trips.FirstOrDefaultAsync(t=>t.Id ==id);
            if (trip == null)
            {
                return NotFound();
            }
            _context.Trips.Remove(trip);
            //delete from trips where id = id
            _context.SaveChanges();
            return NoContent();
        }
    }
}