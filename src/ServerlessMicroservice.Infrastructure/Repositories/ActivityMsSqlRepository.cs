using Dapper;
using ServerlessMicroservice.Domain.Entities;
using ServerlessMicroservice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Infrastructure.Repositories
{
    public class ActivityMsSqlRepository : IActivityRepository
    {
        private static class SqlQueries
        {
            internal static string GetAll = "SELECT * FROM Activity";

            internal static string GetById = "SELECT Id,UserId,ActionId,ApplicationUrl FROM Activity WHERE Id = @id";

            internal static string Add = "EXEC V1Activity_Post @UserId, @ApplicationId, @ActionId" +
                     ", @ApplicationUrl, @ActivityRemarks, @DateCreated";

            internal static string Edit = "SELECT Id,UserId,ActionId,ApplicationUrl FROM Activity WHERE Id = @id";

            internal static string Delete = "SELECT Id,UserId,ActionId,ApplicationUrl FROM Activity WHERE Id = @id";
        }

        private readonly string _connectionString;
        //private readonly IDatabaseConnectionFactory _connectionFactory;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public ActivityMsSqlRepository()
        {
            // _connectionString = "Server=DESKTOP-85SV1TI\\SQLEXPRESS;Database=RESTfulSampleDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            _connectionString = "Server=FABAYON;Database=TitleMicroservice0000TemplateDatabase;Trusted_Connection=True;";
            // _connectionFactory = _connectionString;
        }

        public Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public Task<Activity> DeleteData(Activity model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Activity>> GetAllData()
        {
            //var todoDictionary = new Dictionary<int, ToDoItem>();
            //TODO: Paging...
            using (IDbConnection dbConnection = _connection)
            {
                //var sellerOffers = await connection.QueryAsync<Offer>(GetSellerOffers, new { id });
                //var seller = await connection.QuerySingleAsync<Seller>(GetSeller, new { id });

                //seller.Offers = sellerOffers.ToList();

                //return seller;
                var output = await dbConnection.QueryAsync<Activity>(SqlQueries.GetAll)
                    .ConfigureAwait(false);

                return output;
            }
        }

        public Task<IEnumerable<Activity>> GetDataBy(Activity model)
        {
            throw new NotImplementedException();
        }

        public async Task<Activity> InsertData(Activity model)
        {
            using (IDbConnection dbConnection = _connection)
            {



                await dbConnection.QueryAsync(SqlQueries.Add, model)
                   .ConfigureAwait(false);
                //var output = await dbConnection.QueryAsync<Activity>(query, activity);

                return model;
            }
        }

        public Task<Activity> UpdateData(Activity model)
        {
            throw new NotImplementedException();
        }

        public async Task<Activity> GetByIdData(long id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                //const string query = "SELECT * FROM Activity WHERE Id = @id";
                //var output = await dbConnection.QuerySingleOrDefaultAsync<Activity>(query,
                //    new
                //    {
                //        id
                //    });

                //return output;
                var output = await dbConnection.QuerySingleOrDefaultAsync<Activity>(SqlQueries.GetById,
                    new
                    {
                        @id = id
                    })
                    .ConfigureAwait(false);
                return output;
            }
        }
    }
}
