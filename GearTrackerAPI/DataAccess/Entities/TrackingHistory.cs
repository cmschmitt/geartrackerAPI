using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearTrackerAPI.DataAccess.Entities
{
    public class TrackingHistory
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }
}