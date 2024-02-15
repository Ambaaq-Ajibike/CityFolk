using EventManagementSystem.Models.Dtos.RequestModels;
using EventManagementSystem.Models.Dtos.ResponseModels;

namespace EventManagementSystem.Services.Interfaces
{
    public interface IRoleService
    {
        Task<BaseResponse<int>> AddAsync(RoleRequestModel roleRequestModel);
    }
}
