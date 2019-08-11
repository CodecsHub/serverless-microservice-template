using ServerlessMicroservice.Domain.Entities;


namespace ServerlessMicroservice.Domain.Interfaces
{
    public interface IActivityRepository : IBaseRepositories<Activity>
    {
        // comment for referrences on previous usage
        //Task<IEnumerable<Activity>> GetByIdAsync(long id);
        //Task<Activity> AddAsync(Activity entity);
    }
}
