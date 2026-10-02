using prac2DB.Database;
using prac2DB.Database.Entity;
using Microsoft.AspNetCore.Mvc;

namespace prac2DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DatabaseContext db;

        public UserController()
        {
            db = new DatabaseContext();
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return db.Users.ToList();
        }

        // GET: api/User/1
        [HttpGet("{id}")]
        public Users? Get(int id)
        {
            return db.Users.Find(id);
        }

        // POST: api/User
        [HttpPost]
        public ActionResult Post([FromBody] Users obj)
        {
            try
            {
                db.Users.Add(obj);
                db.SaveChanges();

                return StatusCode(
                    StatusCodes.Status201Created,
                    obj);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    e);
            }
        }

        // PUT: api/User/1
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Users obj)
        {
            var user = db.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = obj.Name;
            user.Address = obj.Address;
            user.Contact = obj.Contact;

            db.SaveChanges();

            return Ok(user);
        }

        // DELETE: api/User/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = db.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }
    }
}