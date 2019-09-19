using System;

namespace GearTrackerService.Core
{
    public class TrackingHistory
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }
}