namespace GearTrackerService.Core
{
    public class Item
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Rfid { get; set; }
    }
}