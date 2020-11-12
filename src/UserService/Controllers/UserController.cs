using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Database;
using UserService.Database.Entities;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase 
    {
        private readonly DatabaseContext db;

        public UserController(DatabaseContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<User> Get() 
        {
            return this.db.Users.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name="Get")]
        public User Get(int id) 
        {
            return this.db.Users.Find(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            try
            {
                db.Users.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }
    }
}