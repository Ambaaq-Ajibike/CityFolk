using EventManagementSystem.Models.Dtos.RequestModels;
using EventManagementSystem.Models.Dtos.ResponseModels;
using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.Services.Interfaces
{
    public interface IEventService
    {
        Task<BaseResponse<int>> CreateAsync(EventRequestModel request);
        Task<BaseResponse<List<Event>>> GetEventsAsync();
    }
}
