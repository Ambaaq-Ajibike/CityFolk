using EventManagementSystem.Models.Dtos.RequestModels;
using EventManagementSystem.Models.Dtos.ResponseModels;

namespace EventManagementSystem.Services.Interfaces
{
    public interface IMemberService
    {
        Task<BaseResponse<int>> AddAsync(MemberRequestModel memberRequest);
        Task<BaseResponse<LoginResponse>> Login(LoginRequestModel loginRequestModel);
    }
}
