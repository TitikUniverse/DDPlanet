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
    public class UserRequestsController : ControllerBase
    {
        private readonly UserRequestContext _context;

        public UserRequestsController(UserRequestContext context)
        {
            _context = context;
        }

        // GET: api/UserRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRequest>>> GetUserRequests()
        {
            return await _context.UserRequests.ToListAsync();
        }

        // GET: api/UserRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRequest>> GetUserRequest(int id)
        {
            var userRequest = await _context.UserRequests.FindAsync(id);

            if (userRequest == null)
            {
                return NotFound();
            }

            return userRequest;
        }

        // PUT: api/UserRequests/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRequest(int id, UserRequest userRequest)
        {
            if (id != userRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(userRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRequestExists(id))
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

        // POST: api/UserRequests
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserRequest>> PostUserRequest(UserRequest userRequest)
        {
            _context.UserRequests.Add(userRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRequest", new { id = userRequest.Id }, userRequest);
        }

        // DELETE: api/UserRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRequest>> DeleteUserRequest(int id)
        {
            var userRequest = await _context.UserRequests.FindAsync(id);
            if (userRequest == null)
            {
                return NotFound();
            }

            _context.UserRequests.Remove(userRequest);
            await _context.SaveChangesAsync();

            return userRequest;
        }

        private bool UserRequestExists(int id)
        {
            return _context.UserRequests.Any(e => e.Id == id);
        }
    }
}
