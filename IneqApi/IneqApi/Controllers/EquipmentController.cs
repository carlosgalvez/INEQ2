using IneqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IneqApi.Controllers
{
    public class EquipmentController : ApiController
    {
        private IneqContext db = new IneqContext();
        // GET api/equipment
        public List<Equipment> Get()
        {
            return db.Equipments.ToList();
        }



        // GET api/equipment/5
        public List<Equipment> Get(int Id)
        {
            return db.Equipments.Where(e => e.Id == Id).ToList();
        }

        // POST api/equipment
        public bool Post(int Id, string EntryDate,string Serie,string SofttekId,int Active, int EquipmentTypeId, int ModelId, int BrandId, int StatusId, int WarehouseId)
        {
            var e = new Equipment
            {
                Id = Id,
                EntryDate = Convert.ToDateTime(EntryDate),
                Serie = Serie,
                Softtekld = SofttekId,
                Active = Convert.ToBoolean(Active),
                EquipmentTypeld = EquipmentTypeId,
                Modelld = ModelId,
                Brandld = BrandId,
                Statusld = StatusId,
                Warehouseld = WarehouseId,
                
            };
            db.Equipments.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;

        }

        // PUT api/equipment/5
        public bool Put(string EntryDate, string Serie, string SofttekId, int Active, int EquipmentTypeId, int ModelId, int BrandId, int StatusId, int WarehouseId)
        {
            var Equipment = new Equipment
            {
               
                EntryDate = Convert.ToDateTime(EntryDate),
                Serie = Serie,
                Softtekld = SofttekId,
                Active = Convert.ToBoolean(Active),
                EquipmentTypeld = EquipmentTypeId,
                Modelld = ModelId,
                Brandld = BrandId,
                Statusld = StatusId,
                Warehouseld = WarehouseId,

            };
            db.Equipments.Add(Equipment);
            return db.SaveChanges() > 0;
        }

        // DELETE api/equipment/5
        public bool Delete(int Id)
        {
            var e = db.Equipments.Find(Id);
            db.Equipments.Attach(e);
            db.Equipments.Remove(e);
            return db.SaveChanges() > 0;

        }

    }
}
