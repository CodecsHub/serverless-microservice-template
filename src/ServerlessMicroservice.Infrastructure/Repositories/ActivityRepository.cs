using Dapper;
using ServerlessMicroservice.Domain.Entities;
using ServerlessMicroservice.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Infrastructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private static class SqlQueries
        {
            internal static string GetAll = "SELECT * FROM Activity";

            internal static string GetById = "SELECT Id,UserId,ActionId,ApplicationUrl FROM Activity WHERE Id = @id";

            internal static string Add = "EXEC V1Activity_Post @UserId, @ApplicationId, @ActionId" +
                     ", @ApplicationUrl, @ActivityRemarks, @DateTimeLog";

            internal static string Edit = "SELECT Id,UserId,ActionId,ApplicationUrl FROM Activity WHERE Id = @id";

            internal static string Delete = "SELECT Id,UserId,ActionId,ApplicationUrl FROM Activity WHERE Id = @id";
        }

        private readonly string _connectionString;
        //private readonly IDatabaseConnectionFactory _connectionFactory;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public ActivityRepository()
        {


            // _connectionString = "Server=DESKTOP-85SV1TI\\SQLEXPRESS;Database=RESTfulSampleDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            _connectionString = "Server=FABAYON;Database=TitleMicroservice0000TemplateDatabase;Trusted_Connection=True;";
           // _connectionFactory = _connectionString;
        }

        public async Task<Activity> AddAsync(Activity entity)
        {


            using (IDbConnection dbConnection = _connection)
            {



                 await dbConnection.ExecuteAsync(SqlQueries.Add, entity);
                //var output = await dbConnection.QueryAsync<Activity>(query, activity);

                return entity;
            }

        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            //var todoDictionary = new Dictionary<int, ToDoItem>();
            //TODO: Paging...
            using (IDbConnection dbConnection = _connection)
            {

                var output = await dbConnection.QueryAsync<Activity>(SqlQueries.GetAll);

                return output;
            }
        }

        public async Task<Activity> GetByIdAsync(long id)
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
                    new {
                        @id = id
                    });
                return output;
            }
        }

    }
}
