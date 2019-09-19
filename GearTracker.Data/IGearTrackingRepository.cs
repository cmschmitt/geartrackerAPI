using GearTrackerService.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GearTrackerService.Data
{
    public interface IGearTrackingRepository
    {
        Task<List<Item>> GetAllItemsByUserId(int userId);
        Task<Item> AddItem(Item item);
        Task<List<TrackingHistory>> GetTrackingHistoryByItemId(int itemId);
        Task<TrackingHistory> AddTrackingHistory(TrackingHistory trackingHistory);
    }
}
