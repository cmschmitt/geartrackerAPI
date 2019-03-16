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

        // GET api/<controller>
        /// <summary>
        /// Returns a list of Items for a specified user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("GearTracker/GetItems")]
        public async Task<IHttpActionResult> GetItems(int userId)
        {
            return Ok(await _gearTrackingService.GetItemsByUserId(userId));
        }

        // GET api/<controller>
        [Route("GearTracker/GetItemTrackingHistory")]
        public async Task<IHttpActionResult> GetItemTrackingHistory(int itemId)
        {
            return Ok(await _gearTrackingService.GetTrackingHistoryByItemId(itemId));
        }

        // POST api/<controller>
        [Route("GearTracker/Item"), HttpPost]
        public async Task<IHttpActionResult> AddItem([FromBody]Item item)
        {
            return Ok(await _gearTrackingService.AddItem(item));
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}