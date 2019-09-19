using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GearTrackerService.Core;
using GearTrackerService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GearTrackerService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GearTrackingController : ControllerBase
    {
        private readonly IGearTrackingProcessor _gearTrackingProcessor;
        public GearTrackingController(IGearTrackingProcessor gearTrackingProcessor)
        {
            _gearTrackingProcessor = gearTrackingProcessor;
        }

        /// <summary>
        /// Get all Items by UserID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("GearTracking/GetItems")]
        public async Task<ActionResult> GetItems(int userId)
        {
            return Ok(await _gearTrackingProcessor.GetItemsByUserId(userId));
        }
        /// <summary>
        /// Get all TrackingHistory records by ItemID.
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [Route("GearTracking/GetTrackingHistory")]
        public async Task<ActionResult> GetItemTrackingHistory(int itemId)
        {
            return Ok(await _gearTrackingProcessor.GetTrackingHistoryByItemId(itemId));
        }

        /// <summary>
        /// Add new Item to the GearTracking database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("GearTracking/Item"), HttpPost]
        public async Task<ActionResult> AddItem([FromBody]Item item)
        {
            return Ok(await _gearTrackingProcessor.AddItem(item));
        }

        /// <summary>
        /// Add a new TrackingHistory record to the database.
        /// </summary>
        /// <param name="trackingHistory"></param>
        /// <returns></returns>
        [Route("GearTracking/TrackingHistory"), HttpPost]
        public async Task<ActionResult> AddTrackingHistory([FromBody]TrackingHistory trackingHistory)
        {
            return Ok(await _gearTrackingProcessor.AddTrackingHistory(trackingHistory));
        }

    }
}
