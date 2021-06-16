using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DataBaseWebAPI.Models;

namespace DataBaseWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _db;

        public UserController(UserContext userContext)
        {
            _db = userContext;

            if (_db.Users.Any() is false)
            {
                _db.Users.AddRange(DataSets.GetRandomUsers(10));
                _db.SaveChanges();
            }
        }

        //GET ~/api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get() => await _db.Users.ToListAsync();

        //GET ~/api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User selectedUser = await _db.Users.FirstOrDefaultAsync(user => user.Id == id);

            if (selectedUser is null) return NotFound();

            return new ObjectResult(selectedUser);
        }

        //POST ~/api/user
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user is null) return BadRequest();

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return Ok(user);
        }

        //PUT ~/api/user/
        [HttpPut]
        public async Task<ActionResult<User>> Put(User sendedUser)
        {
            if (sendedUser is null) return BadRequest();

            if (_db.Users.Any(user => user.Id == sendedUser.Id) is false) return NotFound();

            _db.Update(sendedUser);
            await _db.SaveChangesAsync();

            return Ok(sendedUser);
        }

        //DELETE ~/api/user/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = _db.Users.FirstOrDefault(user => user.Id == id);

            if (user is null) return NotFound();

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            return Ok(user);
        }
    }
}
