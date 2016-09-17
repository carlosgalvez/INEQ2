using IneqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IneqApi.Controllers
{
    public class ComponentController : ApiController
    {
        private IneqContext db = new IneqContext();
        // GET api/component
        public List<Component> Get()
        {
            return db.Components.ToList();
        }
        // GET api/component/5
        public List<Component> Get(int Id)
        {
            return db.Components.Where(e => e.Id == Id).ToList();
        }

        // POST api/component
        public bool Post(int Id,string Description, int Active,int ComponentTypeId,int Equipment_Id, int EquipmentType_Id)
        {
            var e = new Component
            {
                Id = Id,
                Description=Description,
                Active = Convert.ToBoolean(Active),
                ComponentTypeId=ComponentTypeId,
                EquipmentType_Id = EquipmentType_Id,
                Equipment_Id=Equipment_Id       
                            };
            db.Components.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;

        }

        // PUT api/component/5
        public bool Put(string Description, int Active, int ComponentTypeId, int Equipment_Id, int EquipmentType_Id)
        {
            var Component = new Component
            {

                Description = Description,
                Active = Convert.ToBoolean(Active),
                ComponentTypeId = ComponentTypeId,
                EquipmentType_Id = EquipmentType_Id,
                Equipment_Id = Equipment_Id
            };
             db.Components.Add(Component);
            return db.SaveChanges() > 0;
        }

        // DELETE api/component/5
        public bool Delete(int Id)
        {
            var e = db.Components.Find(Id);
            db.Components.Attach(e);
            db.Components.Remove(e);
            return db.SaveChanges() > 0;

        }
    }
}
