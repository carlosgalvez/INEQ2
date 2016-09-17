using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IneqApi.Models
{
    public class Equipment{
    
         public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public String Serie { get; set; }
        public String Softtekld { get; set; }
        public bool Active { get; set; }
        public int EquipmentTypeld  { get; set; }
        public int Modelld  { get; set; }
        public int Brandld  { get; set; }
        public int Statusld  { get; set; }
        public int Warehouseld  { get; set; }

        public virtual Warehouse Warehouses { get; set; }
        public virtual EquipmentType EquipmentTypes { get; set; }
        public virtual Model Models { get; set; }
        public virtual Brand Brands { get; set; }
        public virtual Status Statuses { get; set; }
        
    }
}