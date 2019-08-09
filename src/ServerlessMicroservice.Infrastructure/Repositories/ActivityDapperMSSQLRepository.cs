using Dapper;
using ServerlessMicroservice.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Infrastructure.Repositories
{
    //public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    public class ActivityDapperMSSQLRepository : IActivityDapperMSSQLRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }
        private readonly IActivityDapperMSSQLRepository _activityDapperMSSQLRepository;

        public ActivityDapperMSSQLRepository(IActivityDapperMSSQLRepository activityDapperMSSQLRepository)
        {
            _activityDapperMSSQLRepository = activityDapperMSSQLRepository;
            // _connectionString = "Server=DESKTOP-85SV1TI\\SQLEXPRESS;Database=RESTfulSampleDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            _connectionString = "Server=FABAYON;Database=TitleMicroservice0000TemplateDatabase;Trusted_Connection=True;";

        }
        public Task DeleteData<T>(T model, string sql)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllData<T>(T model, string sql)
        {
            using (IDbConnection connectionString = new SqlConnection(_connectionString))
            {
                var output = await connectionString.QueryAsync<T>(sql, new DynamicParameters());
                return output;
            }
            // throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetDataBy<T>(T model, string sql)
        {
            throw new NotImplementedException();
        }

        public Task InsertData<T>(T model, string sql)
        {
            throw new NotImplementedException();
        }

        public Task UpdateData<T>(T model, string sql)
        {
            throw new NotImplementedException();
        }
    }
}
