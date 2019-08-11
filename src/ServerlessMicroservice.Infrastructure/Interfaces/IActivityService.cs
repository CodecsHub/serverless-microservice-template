using ServerlessMicroservice.Domain.Contracts;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Infrastructure.Interfaces
{
    public interface IActivityService
    {
        Task<ActivityResponse> GetByIdAsync(long id);
        Task<ActivityResponse> GetAllAsync();
        Task AddAsync(ActivityRequest activityRequest);
    }
}
