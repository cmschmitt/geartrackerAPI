using GearTrackerAPI.DataAccess;
using GearTrackerAPI.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GearTrackerAPI.Services
{
    public class GearTrackingService
    {
        private GearTrackingRepository _gearTrackingRepository;
        public GearTrackingService(GearTrackingRepository gearTrackingRepository)
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

    }
}