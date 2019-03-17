using Autofac;
using GearTrackerAPI.DataAccess.Entities;
using GearTrackerAPI.Modules;
using GearTrackerAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GearTrackerAPI.Controllers
{
    public class GearTrackingController : ApiController
    {
        private static IContainer _container;
        private readonly GearTrackingService _gearTrackingService;
        public GearTrackingController()
        {
            BuildContainer();
            _gearTrackingService = _container.Resolve<GearTrackingService>();
        }

        private void BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new GearTrackerAPIAutofacModule(System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"]?.ConnectionString));
            _container = builder.Build();
        }

        /// <summary>
        /// Get all Items by UserID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("GearTracker/GetItems")]
        public async Task<IHttpActionResult> GetItems(int userId)
        {
            return Ok(await _gearTrackingService.GetItemsByUserId(userId));
        }
        /// <summary>
        /// Get all TrackingHistory records by ItemID.
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [Route("GearTracker/GetTrackingHistory")]
        public async Task<IHttpActionResult> GetItemTrackingHistory(int itemId)
        {
            return Ok(await _gearTrackingService.GetTrackingHistoryByItemId(itemId));
        }

        /// <summary>
        /// Add new Item to the GearTracking database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("GearTracker/Item"), HttpPost]
        public async Task<IHttpActionResult> AddItem([FromBody]Item item)
        {
            return Ok(await _gearTrackingService.AddItem(item));
        }

        /// <summary>
        /// Add a new TrackingHistory record to the database.
        /// </summary>
        /// <param name="trackingHistory"></param>
        /// <returns></returns>
        [Route("GearTracker/TrackingHistory"), HttpPost]
        public async Task<IHttpActionResult> AddTrackingHistory([FromBody]TrackingHistory trackingHistory)
        {
            return Ok(await _gearTrackingService.AddTrackingHistory(trackingHistory));
        }

    }
}