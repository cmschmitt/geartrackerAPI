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

        internal async Task<List<Item>> GetAllItemsByUserId(int userId)
        {
            IEnumerable<Item> items = null;
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            using (var db = new SqlConnection(_dbConnection))
            {
                items = await db.QueryAsync<Item>("SELECT [Id], [UserId], [Name], [Rfid] FROM [dbo].[Item] WHERE [UserId] = @UserId", parameters);
            }
            return items?.ToList();
        }

        internal async Task<Item> AddItem(Item item)
        {
            Item addedItem = null;
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", item.UserId);
            parameters.Add("@Name", item.Name);
            parameters.Add("@Rfid", item.Rfid);
            using (var db = new SqlConnection(_dbConnection))
            {
                addedItem = await db.QuerySingleAsync<Item>(@"INSERT INTO [dbo].[Item]
                                                                            ( [Name]
                                                                            , [Rfid]
                                                                            , [UserId] )
                                                                        VALUES
                                                                            ( @Name
                                                                            , @Rfid
                                                                            , @UserId )
                                                                       SELECT [Id], [UserId], [Name], [Rfid] 
                                                                         FROM dbo.Item 
                                                                        WHERE Id = SCOPE_IDENTITY()", parameters);

            }
            return addedItem;
        }

        internal async Task<List<TrackingHistory>> GetTrackingHistoryByItemId(int itemId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ItemId", itemId);
            using (var db = new SqlConnection(_dbConnection))
            {
                var history = await db.QueryAsync<TrackingHistory>("SELECT * FROM dbo.TrackingHistory WHERE ItemId = @ItemId", parameters);
                return history?.ToList();
            }
        }

        internal async Task<TrackingHistory> AddTrackingHistory(TrackingHistory trackingHistory)
        {
            TrackingHistory addedHistory = null;
            var parameters = new DynamicParameters();
            parameters.Add("@ItemId", trackingHistory.ItemId);
            parameters.Add("@Date", trackingHistory.Date);
            parameters.Add("@Location", trackingHistory.Location);
            using (var db = new SqlConnection(_dbConnection))
            {
                addedHistory = await db.QuerySingleAsync<TrackingHistory>(@"INSERT INTO [dbo].[TrackingHistory]
                                                                                           ( [ItemId]
                                                                                           , [Date]
                                                                                           , [Location])
                                                                                     VALUES
                                                                                           ( @ItemId
		                                                                                   , @Date
		                                                                                   , @Location )
	                                                                                SELECT [Id], [ItemId], [Date], [Location] 
	                                                                                  FROM [dbo].[TrackingHistory]
	                                                                                 WHERE Id = SCOPE_IDENTITY()", parameters);

            }
            return addedHistory;
        }

        #endregion
    }
}