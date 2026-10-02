using Microsoft.AspNetCore.Mvc;
using prac2.Database;
using prac2.Database.Entity;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prac2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // 🟢 OUR CODE — Database object
        DatabaseContext db;

        // 🟢 OUR CODE — Connect to database
        public UserController()
        {
            db = new DatabaseContext();
        }

        // GET: api/<UserController>
        [HttpGet]

        // 🟢 OUR CODE — changed string to Users
        public IEnumerable<Users> Get()
        {
            // 🟢 OUR CODE — get all users from database
            return db.Users.ToList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]

        // 🟢 OUR CODE — changed string to Users
        public Users Get(int id)
        {
            // 🟢 OUR CODE — find user by ID
            return db.Users.Find(id);
        }

        // POST api/<UserController>
        [HttpPost]

        // 🟢 OUR CODE — changed string to Users
        public ActionResult Post([FromBody] Users obj)
        {
            // 🟢 OUR CODE — add user to database
            try
            {
                db.Users.Add(obj);
                db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, obj);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    e);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]

        // 🟢 OUR CODE — changed void/string to ActionResult/Users
        public ActionResult Put(int id, [FromBody] Users obj)
        {
            // 🟢 OUR CODE — find existing user
            var user = db.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            // 🟢 OUR CODE — update user details
            user.Name = obj.Name;
            user.Address = obj.Address;
            user.Contact = obj.Contact;

            db.SaveChanges();

            return Ok(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]

        // 🟢 OUR CODE — changed void to ActionResult
        public ActionResult Delete(int id)
        {
            // 🟢 OUR CODE — find user
            var user = db.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            // 🟢 OUR CODE — delete user
            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }
    }
}
