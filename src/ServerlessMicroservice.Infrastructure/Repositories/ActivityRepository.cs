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
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public ActivityRepository()
        {
            // _connectionString = "Server=DESKTOP-85SV1TI\\SQLEXPRESS;Database=RESTfulSampleDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            _connectionString = "Server=FABAYON;Database=TitleMicroservice0000TemplateDatabase;Trusted_Connection=True;";
        }

        public async Task AddAsync(Activity activity)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = "EXEC V1Activity_Post @UserId, @ApplicationId, @ActionId" +
                     ", @ApplicationUrl, @ActivityRemarks, @DateTimeLog";

                await dbConnection.ExecuteAsync(query, activity);
            }

        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            //TODO: Paging...
            using (IDbConnection dbConnection = _connection)
            {
                string query = "SELECT * FROM Activity";
                var output = await dbConnection.QueryAsync<Activity>(query);

                return output;
            }
        }

        public Task<Activity> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
