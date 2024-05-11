using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RecogniseDesign.Todo.API.Model;
using RecogniseDesign.Todo.Application;
using RecogniseDesign.Todo.Domain.Entities;

namespace RecogniseDesign.Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoitemsController : ControllerBase
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoitemsController(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Username == "demo" && model.Password == "pass")
            {
            }
            else
            {
                return Unauthorized("Invalid credentials");

            }
            var token = GenerateAccessToken(model.Username);
            return Ok(new { AccessToken = new JwtSecurityTokenHandler().WriteToken(token) });
        }
        private JwtSecurityToken GenerateAccessToken(string userName)
        {
            // Create user claims
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName),
            // Add additional claims as needed (e.g., roles, etc.)
        };

            // Create a JWT
            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1), // Token expiration time
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("averylongsecretkeythatisrequiredtobeused")),
                    SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        // GET: api/Todoitems
        [HttpGet]
        [Authorize]
        public  ActionResult<IEnumerable<Todoitem>> GetTodoitems()
        {
            return _todoItemRepository.GetAllTodoItems();
        }

        // GET: api/Todoitems/5
        [HttpGet("{id}")]
        [Authorize]
        public  ActionResult<Todoitem> GetTodoitem(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var todoitem =  _todoItemRepository.GetTodoitem(id);
            if (todoitem == null)
            {
                return NotFound();
            }

            return todoitem;
        }



        // PUT: api/Todoitems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutTodoitem(int id, Todoitem todoitem)
        {
            if (id != todoitem.Id)
            {
                return BadRequest();
            }

            var item =  _todoItemRepository.PutTodoitem(id, todoitem);

            return Ok(item);
        }

        // POST: api/Todoitems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Todoitem>> PostTodoitem(Todoitem todoitem)
        {
            if (todoitem == null)
            {
                return Problem("Entity set 'TODOContext.Todoitems'  is null.");
            }
          var todoitem2=  _todoItemRepository.PostTodoitem(todoitem);

            return CreatedAtAction("GetTodoitem", new { id = todoitem2.Id }, todoitem2);
        }

        // DELETE: api/Todoitems/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTodoitem(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            bool val=   _todoItemRepository.DeleteTodoitem(id);

            return Ok();
        }


    }
}
