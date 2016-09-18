 using IneqApi.Models;
 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Net;
 using System.Net.Http;
 using System.Web.Http;
 
 namespace IneqApi.Controllers
 {
     public class StatusController : ApiController
     {
         private IneqContext db = new IneqContext();
 
         // GET api/Status
         public List<Status>Get()
         {
             return db.Statuses.ToList();
         }
 
         // GET api/Status/5
         public List<Status>Get(int Id)
         {
             return db.Statuses.Where(e=> e.Id==Id).ToList();
         }
 
         // POST api/Status
         public bool Post (int Id, string Description, int Active)
         {
             var e = new Status
             {
                 Id = Id,
                 Description = Description,
                 Active = Convert.ToBoolean(Active)
             };
             db.Statuses.Attach(e);
             db.Entry(e).State = System.Data.Entity.EntityState.Modified;
             db.Configuration.ValidateOnSaveEnabled = true;
             return db.SaveChanges() > 0;
         }
         
 
         // PUT api/Status/5
         public bool Put (string Description, int Active)
         {
             var Status = new Status
             {
                 Description = Description,               
                 Active = Convert.ToBoolean(Active)
             };
             db.Statuses.Add(Status);
             return db.SaveChanges() > 0;
         }
 
         // DELETE api/Status/5
         public bool Delete(int Id)
         {
             var e = db.Statuses.Find(Id);
             db.Statuses.Attach(e);
             db.Statuses.Remove(e);
             return db.SaveChanges() > 0;
         }
     }
 }