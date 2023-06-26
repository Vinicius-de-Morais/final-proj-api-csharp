using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_projeto_final;
using api_projeto_final.DataModels;
using api_projeto_final.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace api_projeto_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy= "login_token")]
    public class usersController : ControllerBase
    {

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<user>>> Getusers(
            [FromServices] DbConnect context
        )
        {
          if (context.users == null)
          {
              return NotFound();
          }
            return await context.users.ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<user>> Getuser(
            [FromServices] DbConnect context,
            [FromRoute] int id
        )
        {
            if (context.users == null)
            {
                return NotFound();
            }
            var user = findUser(context, id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putuser(
            [FromServices] DbConnect context,
            [FromRoute] int id, 
            [FromBody] user user
        )
        {

            var finded = findUser(context, id);

            if (finded == null)
            {
                return NotFound();
            }

            try
            {
                user.id = id;
                context.Update(user);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("");
            }

            return NoContent();
        }

        // POST: api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<user>> Postuser(
            [FromServices] DbConnect context,
            [FromBody] user user)
        {
            if (context.users == null)
            {
                return Problem("Entity set 'DbConnect.users'  is null.");
            }

            authService auth = new authService();

            try
            {
                await context.users.AddAsync(user);
                var res = await auth.setUserAuth(user);

                await context.SaveChangesAsync();

                return Ok(user);
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro ao salvar o user: "+ex.Message);
            }
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteuser(
            [FromServices] DbConnect context,
            [FromRoute] int id)
        {
            if (context.users == null)
            {
                return NotFound();
            }
            var user = await context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            context.users.Remove(user);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private user? findUser(DbConnect context, int id)
        {
            return context.users.AsNoTracking().FirstOrDefault(user => user.id == id);
        }

        private user? findUserByUserName(DbConnect context, string username)
        {
            return context.users.AsNoTracking().FirstOrDefault(user => user.username == username);
        }
    }
}
