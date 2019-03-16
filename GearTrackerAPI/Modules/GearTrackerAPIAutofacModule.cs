using Autofac;
using GearTrackerAPI.DataAccess;
using GearTrackerAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearTrackerAPI.Modules
{
    public class GearTrackerAPIAutofacModule : Autofac.Module
    {
        private string _dataSource;
        public GearTrackerAPIAutofacModule(string dbConnection)
        {
            _dataSource = dbConnection;
        }
        /// <summary>
        /// Register the data context, repository, service classes.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            //TODO:Get database connection string.
            builder.RegisterType<GearTrackingRepository>().WithParameter(new TypedParameter(typeof(string), _dataSource));
            builder.RegisterType<GearTrackingService>().SingleInstance();
        }
    }
}