using GearTrackerService.Core;
using GearTrackerService.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GearTrackerService.Domain
{
    public class GearTrackingProcessor : IGearTrackingProcessor
    {
        private readonly IGearTrackingRepository _gearTrackingRepository;
        public GearTrackingProcessor(IGearTrackingRepository gearTrackingRepository)
        {
            _gearTrackingRepository = gearTrackingRepository;
        }

        public async Task<List<Item>> GetItemsByUserId(int userId)
        {
            return await _gearTrackingRepository.GetAllItemsByUserId(userId);
        }

        public async Task<List<TrackingHistory>> GetTrackingHistoryByItemId(int itemId)
        {
            return await _gearTrackingRepository.GetTrackingHistoryByItemId(itemId);
        }

        public async Task<Item> AddItem(Item item)
        {
            return await _gearTrackingRepository.AddItem(item);
        }

        public async Task<TrackingHistory> AddTrackingHistory(TrackingHistory trackingHistory)
        {
            return await _gearTrackingRepository.AddTrackingHistory(trackingHistory);
        }
    }
}

