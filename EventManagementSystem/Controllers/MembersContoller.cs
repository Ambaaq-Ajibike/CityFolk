using EventManagementSystem.AuthService;
using EventManagementSystem.Models.Dtos.RequestModels;
using EventManagementSystem.Services.Implementations;
using EventManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersContoller : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IJWTAuthService _jWTAuthService;
        public MembersContoller(IMemberService memberService, IJWTAuthService jWTAuthService)
        {
            _memberService = memberService;
            _jWTAuthService = jWTAuthService;
        }
        [HttpPost("member")]
        public async Task<IActionResult> Add(MemberRequestModel memberRequest)
        {
            var response = await _memberService.AddAsync(memberRequest);
            return (response.Status) ? Ok(response) : BadRequest(response);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
        {
            var response = await _memberService.Login(loginRequestModel);
            if(response.Status)
            {
                response.Data.Token = _jWTAuthService.GenerateToken(response.Data.User);
                response.Data.User = null;
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
