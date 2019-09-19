using GearTrackerService.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GearTrackerService.Domain
{
    public interface IGearTrackingProcessor
    {
        Task<List<Item>> GetItemsByUserId(int userId);

        Task<List<TrackingHistory>> GetTrackingHistoryByItemId(int itemId);

        Task<Item> AddItem(Item item);

        Task<TrackingHistory> AddTrackingHistory(TrackingHistory trackingHistory);
    }
}
