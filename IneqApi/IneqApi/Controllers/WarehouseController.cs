using IneqApi.Models;
 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Net;
 using System.Net.Http;
 using System.Web.Http;
 
 namespace IneqApi.Controllers
 {
     public class WarehouseController : ApiController
     {
         private IneqContext db = new IneqContext();
 
         // GET api/Warehouse
         public List<Warehouse>Get()
         {
             return db.Warehouses.ToList();
         }
 
         // GET api/Warehouse/5
         public List<Warehouse>Get(int Id)
         {
             return db.Warehouses.Where(e=> e.Id==Id).ToList();
         }
 
         // POST api/Warehouse
         public bool Post (int Id, string Description, string IS, string Responsable, int Active)
         {
             var e = new Warehouse
             {
                 Id = Id,
                 Description = Description,
                 IS = IS,
                 Responsable = Responsable,
                 Active = Convert.ToBoolean(Active)
             };
             db.Warehouses.Attach(e);
             db.Entry(e).State = System.Data.Entity.EntityState.Modified;
             db.Configuration.ValidateOnSaveEnabled = true;
             return db.SaveChanges() > 0;
         }
         
 
         // PUT api/Warehouse/5
         public bool Put (string Description, string IS, string Responsable, int Active)
         {
             var Warehouse = new Warehouse
             {
                 Description = Description,
                 IS = IS,
                 Responsable = Responsable,
                 Active = Convert.ToBoolean(Active)
             };
             db.Warehouses.Add(Warehouse);
             return db.SaveChanges() > 0;
         }
 
         // DELETE api/Wareouse/5
         public bool Delete(int Id)
         {
             var e = db.Warehouses.Find(Id);
             db.Warehouses.Attach(e);
             db.Warehouses.Remove(e);
             return db.SaveChanges() > 0;
         }
     }
 }