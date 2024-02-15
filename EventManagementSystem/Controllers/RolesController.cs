using EventManagementSystem.Models.Dtos.RequestModels;
using EventManagementSystem.Services.Implementations;
using EventManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost("role")]
        public async Task<IActionResult> Add(RoleRequestModel roleRequestModel)
        {
            var response = await _roleService.AddAsync(roleRequestModel);
            return (response.Status) ? Ok(response) : BadRequest(response);
        }
    }
}
