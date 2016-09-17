using IneqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IneqApi.Controllers
{
    public class ModelController : ApiController
    {

        private IneqContext db = new IneqContext();
        // GET api/model
        public List<Model> Get()
        {
            return db.Models.ToList();
        }

        // GET api/model/5
        public List<Model> Get(int Id)
        {
            return db.Models.Where(e => e.Id == Id).ToList();    
        }

        // POST api/model
        public bool Post(int Id, string Description, int Active, int BrandId)
        {
            var e = new Model
            {
                Id = Id,
                Description = Description,
                Active = Convert.ToBoolean(Active),
                BrandId = BrandId
            };
            db.Models.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges()> 0;

        }

        // PUT api/model/5
        public bool Put(string Description, int Active, int BrandId)
        {
            var Model = new Model
            {
                Description = Description,
                Active = Convert.ToBoolean(Active),
                BrandId = BrandId

            };
            db.Models.Add(Model);
            return db.SaveChanges() > 0;
        }

        // DELETE api/model/5
        public bool Delete(int Id)
        {
            var e = db.Models.Find(Id);
            db.Models.Attach(e);
            db.Models.Remove(e);
            return db.SaveChanges() > 0;

        }
    }
}
