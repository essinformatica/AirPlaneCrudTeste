using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirPlaneCrudTeste.Models;


namespace AirPlaneCrudTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AirPlanesController : ControllerBase
    {
        private readonly AirPlaneContex _context;

        public AirPlanesController(AirPlaneContex context)
        {
            _context = context;
        }

        // GET: api/AirPlanes
        [HttpGet]
        public IEnumerable<AirPlane> GetairPlane()
        {
            return _context.airPlane;
        }

        // GET: api/AirPlanes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAirPlane([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var airPlane = await _context.airPlane.FindAsync(id);

            if (airPlane == null)
            {
                return NotFound();
            }

            return Ok(airPlane);
        }

        // PUT: api/AirPlanes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirPlane([FromRoute] int id, [FromBody] AirPlane airPlane)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != airPlane.id)
            {
                return BadRequest();
            }

            _context.Entry(airPlane).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirPlaneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AirPlanes
        [HttpPost]
        public async Task<IActionResult> PostAirPlane([FromBody] AirPlane airPlane)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.airPlane.Add(airPlane);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirPlane", new { id = airPlane.id }, airPlane);
        }

        // DELETE: api/AirPlanes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirPlane([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var airPlane = await _context.airPlane.FindAsync(id);
            if (airPlane == null)
            {
                return NotFound();
            }

            _context.airPlane.Remove(airPlane);
            await _context.SaveChangesAsync();

            return Ok(airPlane);
        }

        private bool AirPlaneExists(int id)
        {
            return _context.airPlane.Any(e => e.id == id);
        }
    }
}