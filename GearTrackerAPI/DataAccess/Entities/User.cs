using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearTrackerAPI.DataAccess.Entities
{
    public class User
    {
        public User()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}