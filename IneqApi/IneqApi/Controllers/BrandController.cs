using IneqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IneqApi.Controllers
{
    public class BrandController : ApiController
    {
        private IneqContext db = new IneqContext();

        // GET api/brand
        public List<Brand>Get()
        {
            return db.Brands.ToList();
        }

        // GET api/brand/5
        public List<Brand>Get(int Id)
        {
            return db.Brands.Where(e=> e.Id==Id).ToList();
        }

        // POST api/brand
        public bool Post (int Id, string Description,int Active)
        {
            var e = new Brand
            {
                Id = Id,
                Description = Description,
                Active = Convert.ToBoolean(Active)
            };
            db.Brands.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }
        

        // PUT api/brand/5
        public bool Put (string Description,int Active)
        {
            var Brand = new Brand
            {
                Description = Description,
                Active = Convert.ToBoolean(Active)
            };
            db.Brands.Add(Brand);
            return db.SaveChanges() > 0;
        }

        // DELETE api/brand/5
        public bool Delete(int Id)
        {
            var e = db.Brands.Find(Id);
            db.Brands.Attach(e);
            db.Brands.Remove(e);
            return db.SaveChanges() > 0;
        }
    }
}
