using EventManagementSystem.Models.Dtos.RequestModels;
using EventManagementSystem.Models.Dtos.ResponseModels;
using EventManagementSystem.Models.Entities;
using EventManagementSystem.Repositories.Implementations;
using EventManagementSystem.Repositories.Interfaces;
using EventManagementSystem.Services.Interfaces;

namespace EventManagementSystem.Services.Implementations
{
    public class MemberService : IMemberService
    {
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IUserRepository _userRepository;
        public MemberService(IRepository<Member> memberRepository, IRepository<Role> roleRepository, IUserRepository userRepository)
        {
            _memberRepository = memberRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }
        public async Task<BaseResponse<int>> AddAsync(MemberRequestModel memberRequest)
        {
            var userAlreadyexist = await _memberRepository.ExistsAsync(x => x.User.UserName == memberRequest.UserName);
            if (userAlreadyexist) return new BaseResponse<int>
            {
                Message = "User already exist",
                Status = false
            };
            var role = await _roleRepository.GetAsync(x => x.Name == memberRequest.RoleName);
            var user = new User
            {
                UserName = memberRequest.UserName,
                Password = memberRequest.LastName,
            };

            var userRole = new UserRole
            {
                User = user,
                RoleId = role.Id,
            };
            var member = new Member
            {
                User = user,
                FirstName = memberRequest.FirstName,
                LastName = memberRequest.LastName
            };
            int addUser = await _memberRepository.AddAsync(member);
            return new BaseResponse<int>
            {
                Message = (addUser == 0) ? "An error occured, pls try again ":"New member added sucesfully",
                Status = (addUser == 0),
                Data = addUser
            };
        }
    
        public async Task<BaseResponse<LoginResponse>> Login(LoginRequestModel loginRequestModel)
        {
            var user = await _userRepository.GetUser( x => x.User.UserName == loginRequestModel.UserName && x.User.Password == loginRequestModel.Password );
            return new BaseResponse<LoginResponse>
            {
                Message = (user == null) ? "Invalid credentials" : "Succesfully logged in",
                Status = (user != null),
                Data = (user == null) ? null : new LoginResponse
                {
                    UserName = loginRequestModel.UserName,
                    User = user.User
                }
            };
        }
    }
}
