using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IneqApi.Models
{
    public class Component
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int ComponentTypeId { get; set; }
        public int Equipment_Id { get; set; }
        public int EquipmentType_Id { get; set; }

        public virtual ComponentType ComponentTypes { get; set; }
        public virtual Equipment Equipments { get; set; }
        public virtual EquipmentType EquipmentTypes { get; set; }
 
    }
}