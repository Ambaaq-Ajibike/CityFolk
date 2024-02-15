using EventManagementSystem.Models.Dtos.RequestModels;
using EventManagementSystem.Models.Dtos.ResponseModels;
using EventManagementSystem.Models.Entities;
using EventManagementSystem.Repositories.Implementations;
using EventManagementSystem.Repositories.Interfaces;
using EventManagementSystem.Services.Interfaces;

namespace EventManagementSystem.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventRepository;
        public EventService(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<BaseResponse<int>> CreateAsync(EventRequestModel eventRequestModel)
        {
            var exist = await _eventRepository.ExistsAsync(x => x.Name == eventRequestModel.Name && x.EventDate == eventRequestModel.EventDate);
            if (exist)
            {
                return new BaseResponse<int>
                {
                    Message = "Event already exist",
                    Status = false
                };
            }
            var @event = new Event
            {
                Name = eventRequestModel.Name,
                EventDate = eventRequestModel.EventDate,
                Description = eventRequestModel.Description,
            };
            int addedEvent = await _eventRepository.AddAsync(@event);
            return new BaseResponse<int>
            {
                Message = (addedEvent == 0) ? "An error occured, Pls try again" : "Event added sucesfully",
                Status = (addedEvent == 0),
                Data = addedEvent
            };
        }
        public async Task<BaseResponse<List<Event>>> GetEventsAsync()
        {
            var events = await _eventRepository.GetListAsync(x => true);
            return new BaseResponse<List<Event>>
            {
                Message = "List of events retrieved",
                Status = true,
                Data = events.ToList()
            };
        }
    }
}
