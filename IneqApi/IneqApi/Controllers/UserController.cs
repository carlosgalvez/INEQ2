using IneqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IneqApi.Controllers
{

    public class UserController : ApiController
    {
        private IneqContext db = new IneqContext();
        // GET api/user
        public List<User> Get()
        {
            return db.Users.ToList();
        }

        // GET api/user/5
        public List<User> Get(int Id)
        {
            return db.Users.Where(e => e.Id == Id).ToList();
        }

        // POST api/user
        public bool Post(int Id, string Name,string LastName, string Username,string Password,int Active)
        {
            var e = new User
            {
                Id = Id,                
                Active = Convert.ToBoolean(Active),
                Name=Name,
                LastName=LastName,
                Username=Username,
                Password=Password

            };
            db.Users.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;

        }

        // PUT api/user/5
        public bool Put( string Name, string LastName, string Username, string Password, int Active)
        {
            var User = new User
            {
               
                Active = Convert.ToBoolean(Active),
                Name = Name,
                LastName = LastName,
                Username = Username,
                Password = Password

            };
            db.Users.Add(User);
            return db.SaveChanges() > 0;
        }

        // DELETE api/user/5
        public bool Delete(int Id)
        {
            var e = db.Users.Find(Id);
            db.Users.Attach(e);
            db.Users.Remove(e);
            return db.SaveChanges() > 0;

        }
    }
}
