using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IneqApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

    }
}