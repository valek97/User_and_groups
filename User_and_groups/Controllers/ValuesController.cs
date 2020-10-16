using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using User_and_groups.Models;

namespace User_and_groups.Controllers
{
    public class ValuesController : ApiController
    {
        AllDbContext db = new AllDbContext();
        // GET api/values
        public IEnumerable<Users> GetUsers()
        {
            return db.Users;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        public Users GetUsers(int id)
        {
            Users Users = db.Users.Find(id);
            return Users;
        }

        [HttpPost]
        public void CreateUsers([FromBody] Users users)
        {
            db.Users.Add(users);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditUsers(int id, [FromBody] Users users)
        {
            if (id == users.IdUsers)
            {
                db.Entry(users).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users != null)
            {
                db.Users.Remove(users);
                db.SaveChanges();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
