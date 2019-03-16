using Dapper;
using GearTrackerAPI.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace GearTrackerAPI.DataAccess
{
    public class GearTrackingRepository
    {
        private string _dbConnection;
        public GearTrackingRepository(string dbConnection)
        {
            _dbConnection = dbConnection;
        }

        #region Queries

        public async Task<List<Item>> GetAllItemsByUserId(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            using (var db = new SqlConnection(_dbConnection))
            {
                var items = await db.QueryAsync<Item>("SELECT * FROM dbo.Item WHERE UserId = @UserId", parameters);
                return items?.ToList();
            }
        }

        public async Task<List<TrackingHistory>> GetTrackingHistoryByItemId(int itemId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ItemId", itemId);
            using (var db = new SqlConnection(_dbConnection))
            {
                var history = await db.QueryAsync<TrackingHistory>("SELECT * FROM dbo.TrackingHistory WHERE ItemId = @ItemId", parameters);
                return history?.ToList();
            }
        }

        #endregion
    }
}