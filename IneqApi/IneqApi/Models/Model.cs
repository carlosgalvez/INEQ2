using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IneqApi.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brands { get; set; }

    }
}