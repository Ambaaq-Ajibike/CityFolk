using EventManagementSystem.Models.Dtos.RequestModels;
using EventManagementSystem.Models.Dtos.ResponseModels;
using EventManagementSystem.Models.Entities;
using EventManagementSystem.Repositories.Implementations;
using EventManagementSystem.Repositories.Interfaces;
using EventManagementSystem.Services.Interfaces;

namespace EventManagementSystem.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<BaseResponse<int>> AddAsync(RoleRequestModel roleRequestModel)
        {
            var exist = await _roleRepository.ExistsAsync(x => x.Name == roleRequestModel.Name);
            if (exist)
            {
                return new BaseResponse<int>
                {
                    Message = "Role already exist",
                    Status = false
                };
            }
            var role = new Role
            {
                Name = roleRequestModel.Name,
            };
            int addedRole = await _roleRepository.AddAsync(role);
            return new BaseResponse<int>
            {
                Message = (addedRole == 0) ? "An error occured, Pls try again" : "Role added sucesfully",
                Status = (addedRole == 0),
                Data = addedRole
            };
        }
    }
}
