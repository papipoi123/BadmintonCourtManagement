using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels.Response;
using Applications.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public UserService(IUnitOfWork unitOfWork,
            IMapper mapper, 
            ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<Response> AddStaff(CreateUserViewModel createUserViewModel)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmail(createUserViewModel.email);
            if (user != null) return new Response(HttpStatusCode.BadRequest, "double email!!");
            var entity = new User();
            createUserViewModel.password = PasswordConfig.Hash(createUserViewModel.password);     // hash password
            entity.role = Domain.Enums.Role.Role.Customer;                                          // set role default is customer
            _mapper.Map(createUserViewModel, entity);
            await _unitOfWork.UserRepository.CreateStaff(entity);
            return await _unitOfWork.SaveChangeAsync() > 0
                ? new Response(HttpStatusCode.OK, "success")
                : new Response(HttpStatusCode.InternalServerError, "update Database fail");
        }

        public async Task<Response> AddUser(CreateUserViewModel createUserViewModel)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmail(createUserViewModel.email);
            if (user != null) return new Response(HttpStatusCode.BadRequest, "double email!!");
            var entity = new User();
            createUserViewModel.password = PasswordConfig.Hash(createUserViewModel.password);     // hash password
            entity.role = Domain.Enums.Role.Role.Customer;                                          // set role default is customer
            _mapper.Map(createUserViewModel, entity);
            await _unitOfWork.UserRepository.AddAsync(entity);
            return await _unitOfWork.SaveChangeAsync() > 0 
                ? new Response(HttpStatusCode.OK, "success") 
                : new Response(HttpStatusCode.InternalServerError, "update Database fail");
        }

        public async Task<Response> DeleteUser(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user is null) return new Response(HttpStatusCode.BadRequest, "Not found User");
            _unitOfWork.UserRepository.SoftRemove(user);
            return await _unitOfWork.SaveChangeAsync() > 0
                ? new Response(HttpStatusCode.OK, "success")
                : new Response(HttpStatusCode.BadRequest, "delete fail");
        }

        public Task<Response> FilterStaff()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> GetAllStaff(int pageIndex = 0, int pageSize = 10)
        {
            var result = await _unitOfWork.UserRepository.GetAllStaff(pageIndex, pageSize);
            return new Response(HttpStatusCode.OK, "fetch success", _mapper.Map<Pagination<UserViewModel>>(result));
        }

        public async Task<Response> Login(LoginRequest loginRequest)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmail(loginRequest.Email);
            if(user is null)  return new Response(HttpStatusCode.BadRequest, "Wrong Email");
            if (!PasswordConfig.Verify(loginRequest.Password, user.password))
                return new Response(HttpStatusCode.BadRequest, "Invalid Password");
            var token = await _tokenService.GetToken(user);
            var loginResponse = new LoginResponse
            {
                Id = user.Id,
                email = user.email,
                userName = user.userName,
                role = user.role,
                Token = token,
                TokenExpiredAt = DateTime.UtcNow.AddMinutes(40),
            };
            return new Response(HttpStatusCode.OK, "success",loginResponse);
        }

        

    }
}
