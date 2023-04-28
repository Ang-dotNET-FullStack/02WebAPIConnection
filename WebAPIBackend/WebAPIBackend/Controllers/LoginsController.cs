using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIBackend.Data;
using WebAPIBackend.Model;

namespace WebAPIBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly WebAPIDbContext _context;

        public LoginsController(WebAPIDbContext context)
        {
            _context = context;
        }

        // GET: api/Logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogins()
        {
          if (_context.Logins == null)
          {
              return NotFound();
          }
            return await _context.Logins.ToListAsync();
        }

        // GET: api/Logins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLogin(int id)
        {
          if (_context.Logins == null)
          {
              return NotFound();
          }
            var login = await _context.Logins.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return login;
        }

        // PUT: api/Logins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin(int id, Login login)
        {
            if (id != login.Id)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
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

        // POST: api/Logins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Login>> PostLogin(Login login)
        {
          if (_context.Logins == null)
          {
              return Problem("Entity set 'WebAPIDbContext.Logins'  is null.");
          }
            _context.Logins.Add(login);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogin", new { id = login.Id }, login);
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin(int id)
        {
            if (_context.Logins == null)
            {
                return NotFound();
            }
            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Logins.Remove(login);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginExists(int id)
        {
            return (_context.Logins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
