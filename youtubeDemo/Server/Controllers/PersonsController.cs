using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using youtubeDemo.Server;
using youtubeDemo.Shared.Model;

namespace youtubeDemo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersondbContext _context;

        public PersonsController(PersondbContext context)
        {
            _context = context;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persons>>> GetExperience()
        {
            return await _context.Experience.ToListAsync();
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persons>> GetPersons(int id)
        {
            var persons = await _context.Experience.FindAsync(id);

            if (persons == null)
            {
                return NotFound();
            }

            return persons;
        }

        // PUT: api/Persons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersons(int id, Persons persons)
        {
            if (id != persons.ID)
            {
                return BadRequest();
            }

            _context.Entry(persons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonsExists(id))
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

        // POST: api/Persons
        [HttpPost]
        public async Task<ActionResult<Persons>> PostPersons(Persons persons)
        {
            _context.Experience.Add(persons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersons", new { id = persons.ID }, persons);
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Persons>> DeletePersons(int id)
        {
            var persons = await _context.Experience.FindAsync(id);
            if (persons == null)
            {
                return NotFound();
            }

            _context.Experience.Remove(persons);
            await _context.SaveChangesAsync();

            return persons;
        }

        private bool PersonsExists(int id)
        {
            return _context.Experience.Any(e => e.ID == id);
        }
    }
}
