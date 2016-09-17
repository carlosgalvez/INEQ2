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

            var e= new EquipmentType{
                Id = Id,
                Description=Description,
                UsefulLife=U

            }
        }

        // PUT api/equipmenttype/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/equipmenttype/5
        public void Delete(int id)
        {
        }
    }
}
