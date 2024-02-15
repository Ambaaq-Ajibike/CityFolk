using EventManagementSystem.Models.Dtos.RequestModels;
using EventManagementSystem.Services.Implementations;
using EventManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpPost("event")]
        public async Task<IActionResult> Add(EventRequestModel requestModel)
        {
            var response = await _eventService.CreateAsync(requestModel);
            return (response.Status) ? Ok(response) : BadRequest(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _eventService.GetEventsAsync();
            return Ok(response);
        }
    }
}
