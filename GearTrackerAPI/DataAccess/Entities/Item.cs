using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearTrackerAPI.DataAccess.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Rfid { get; set; }
    }
}