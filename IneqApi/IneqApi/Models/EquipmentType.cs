using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IneqApi.Models
{
    public class EquipmentType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string UsefulLife { get; set; }
        public string GuaranteeDuration { get; set; }
        public bool Active { get; set; }

      
    }
}