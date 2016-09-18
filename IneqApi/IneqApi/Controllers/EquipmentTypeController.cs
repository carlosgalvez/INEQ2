using IneqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace IneqApi.Controllers
{
   
    public class EquipmentTypeController : ApiController
    {
         private IneqContext db = new IneqContext();
        // GET api/equipmenttype
        public List<EquipmentType> Get()
        {
            return db.EquipmentTypes.ToList();
        }

        // GET api/equipmenttype/5
        public List<EquipmentType> Get(int Id)
        {
            return db.EquipmentTypes.Where(e => e.Id == Id).ToList();
        }

        // POST api/equipmenttype
        public bool Post(int Id, string Description, string UsefulLife, string GuaranteeDuration, int Active)
        {

            var e = new EquipmentType
            {
                Id = Id,
                Description = Description,
                UsefulLife = UsefulLife,
                GuaranteeDuration = GuaranteeDuration,
                Active = Convert.ToBoolean(Active)


            };
            db.EquipmentTypes.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT api/equipmenttype/5
        public bool Put(string Description, string UsefulLife, string GuaranteeDuration, int Active){

            var EquipmentType = new EquipmentType
            {
                
                Description = Description,
                UsefulLife = UsefulLife,
                GuaranteeDuration = GuaranteeDuration,
                Active = Convert.ToBoolean(Active)
            };
            db.EquipmentTypes.Add(EquipmentType);
            return db.SaveChanges() > 0;
    }
        
        // DELETE api/equipmenttype/5
        public bool Delete(int Id)
        {
            var e = db.EquipmentTypes.Find(Id);
            db.EquipmentTypes.Attach(e);
            db.EquipmentTypes.Remove(e);
            return db.SaveChanges() > 0;
        }
    }
}
