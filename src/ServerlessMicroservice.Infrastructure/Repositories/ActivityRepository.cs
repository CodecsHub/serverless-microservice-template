using ServerlessMicroservice.Domain.Entities;
using ServerlessMicroservice.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Infrastructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        //private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public ActivityRepository()
        {
                
        }
       
        public Task AddAsync(Activity product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Activity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Activity> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
