using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIApp.Model;

namespace WebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormUsersController : ControllerBase
    {
        private readonly FormUserContext _context;

        public FormUsersController(FormUserContext context)
        {
            _context = context;
        }

        // GET: api/FormUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormUser>>> GetFormUsers()
        {
            return await _context.FormUsers.ToListAsync();
        }

        // GET: api/FormUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormUser>> GetFormUser(int id)
        {
            var formUser = await _context.FormUsers.FindAsync(id);

            if (formUser == null)
            {
                return NotFound();
            }

            return formUser;
        }

        // PUT: api/FormUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormUser(int id, FormUser formUser)
        {
            if (id != formUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(formUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormUserExists(id))
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

        // POST: api/FormUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FormUser>> PostFormUser(FormUser formUser)
        {
            _context.FormUsers.Add(formUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormUser", new { id = formUser.Id }, formUser);
        }

        // DELETE: api/FormUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FormUser>> DeleteFormUser(int id)
        {
            var formUser = await _context.FormUsers.FindAsync(id);
            if (formUser == null)
            {
                return NotFound();
            }

            _context.FormUsers.Remove(formUser);
            await _context.SaveChangesAsync();

            return formUser;
        }

        private bool FormUserExists(int id)
        {
            return _context.FormUsers.Any(e => e.Id == id);
        }
    }
}
