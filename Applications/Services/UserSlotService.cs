using Applications.Interfaces;
using Applications.ViewModels.Response;
using Applications.ViewModels.UserSlotViewModels;
using AutoMapper;
using Domain.EntitiesRelationship;
using Domain.Enum.AttendenceEnum;
using Domain.Enums.Status;
using System.Net;

namespace Applications.Services
{
    public class UserSlotService : IUserSlotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserSlotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> CheckAttendanceStatusAsync(int userId, int workingSlotId)
        {
            var userObj = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            var workingSlotObj = await _unitOfWork.WorkingSlotInAMonthRepository.GetByIdAsync(workingSlotId);

            if (workingSlotObj.startTime.AddMinutes(15) < DateTime.UtcNow || workingSlotObj.startTime.AddMinutes(-15) > DateTime.UtcNow)
            {
                return new Response(HttpStatusCode.BadRequest, "Slot out of time!");
            }

            var userSlotObj = await _unitOfWork.UserSlotRepository.GetUserSlot(userId, workingSlotId);

            if (userObj is null || workingSlotObj is null || userSlotObj is null)
            {
                return new Response(HttpStatusCode.NotFound, "User Or Working Slot Is Not Found!");
            }

            if (userObj is not null || workingSlotObj is not null || userSlotObj is not null)
            {
                userSlotObj.AttendanceStatus = Domain.Enum.AttendenceEnum.AttendenceStatus.Present;
                _unitOfWork.UserSlotRepository.Update(userSlotObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Check Attendance Success", userSlotObj.AttendanceStatus);
                }
            }

            return new Response(HttpStatusCode.BadRequest, "Check Attendance Fail");
        }

        public async Task<Response> CreateUserSlotAsync(int userId, int workingSlotId)
        {
            var userObj = await _unitOfWork.UserRepository.GetByIdAsync(userId);

            if (userObj is null)
            {
                return new Response(HttpStatusCode.NotFound, "Not Found");
            }

            var workingSlotObj = await _unitOfWork.WorkingSlotInAMonthRepository.GetByIdAsync(workingSlotId);

            if (workingSlotObj is null)
            {
                return new Response(HttpStatusCode.NotFound, "Not Found");
            }
            var checkobj = await _unitOfWork.UserSlotRepository.GetUserSlotBySlotId(workingSlotId);
            if(checkobj.Count >= 2)
            {
                return new Response(HttpStatusCode.BadRequest, "Add fail, already 2 staff in this slot");
            }
            var userSlotObj = new UserSlot()
            {
                Users = userObj,
                WorkingSlotInAMonth = workingSlotObj
            };

            await _unitOfWork.UserSlotRepository.CreateUserSlot(userSlotObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();

            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.OK, "Add success", _mapper.Map<UserSlotViewModel>(userSlotObj));
            }

            return new Response(HttpStatusCode.BadRequest, "Add fail");
        }

        public async Task<Response> DeleteUserSlotAsync(int userId)
        {
            var userSlotObj = await _unitOfWork.UserSlotRepository.GetUserSlotByUserId(userId);
            if (userSlotObj is not null)
            {
                _unitOfWork.UserSlotRepository.SoftRemove(userSlotObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Delete success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Delete fail");
        }

        public async Task<Response> GetAbsentCountAsync(int userId)
        {
            var userSlotObj = await _unitOfWork.UserSlotRepository.GetAbsentByUserId(userId);
            if (userSlotObj.Count < 1)
            {
                return new Response(HttpStatusCode.NotFound, "Not Found");
            }
            return new Response(HttpStatusCode.OK, "Success", userSlotObj.Count);
        }

        public async Task<Response> GetAllowAbsentCountAsync(int userId)
        {
            var userSlotObj = await _unitOfWork.UserSlotRepository.GetAllowAbsentByUserId(userId);
            if (userSlotObj.Count < 1)
            {
                return new Response(HttpStatusCode.NotFound, "Not Found");
            }
            return new Response(HttpStatusCode.OK, "Success", userSlotObj.Count);
        }

        public async Task<Response> GetAllUserSlotAsync(int pageNumber = 0, int pageSize = 10)
        {
            var result = await _unitOfWork.UserSlotRepository.ToPagination(pageNumber, pageSize);
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetAllUserSlotByUserId(int userId)
        {
            var result = await _unitOfWork.UserSlotRepository.GetAllUserSlotByUserId(userId);
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetPresentCountAsync(int userId)
        {
            var userSlotObj = await _unitOfWork.UserSlotRepository.GetPresentByUserId(userId);
            if (userSlotObj.Count < 1)
            {
                return new Response(HttpStatusCode.NotFound, "Not Found");
            }
            return new Response(HttpStatusCode.OK, "Success", userSlotObj.Count);
        }

        public async Task<Response> GetUserSlotByEmail(string email)
        {
            var userSlotObj = await _unitOfWork.UserSlotRepository.GetUserSlotByEmail(email);
            return new Response(HttpStatusCode.OK, "Success", userSlotObj);
        }

        public async Task<Response> GetUserSlotByUserId(int userId)
        {
            var userSlotObj = await _unitOfWork.UserSlotRepository.GetUserSlotByUserId(userId);
            return new Response(HttpStatusCode.OK, "Success", userSlotObj);
        }

        public async Task<Response> GetUserSlotByUserIdAndWorkingSlotId(int userId, int workingSlotId)
        {
            var userSlotObj = await _unitOfWork.UserSlotRepository.GetUserSlotByUserIdAndWorkingSlotId(userId, workingSlotId);
            return new Response(HttpStatusCode.OK, "Success", userSlotObj);
        }

        public async Task<Response> UpdateAttendanceStatusAsync(int userId, int workingSlotId, AttendenceStatus attendanceStatus)
        {
            var userObj = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            var workingSlotObj = await _unitOfWork.WorkingSlotInAMonthRepository.GetByIdAsync(workingSlotId);
            var userSlotObj = await _unitOfWork.UserSlotRepository.GetUserSlot(userId, workingSlotId);

            if (userObj is null || workingSlotObj is null || userSlotObj is null)
            {
                return new Response(HttpStatusCode.NotFound, "User Or Working Slot Is Not Found!");
            }

            if (userObj is not null || workingSlotObj is not null || userSlotObj is not null)
            {
                userSlotObj.AttendanceStatus = attendanceStatus;
                _unitOfWork.UserSlotRepository.Update(userSlotObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Update Attendance Success", userSlotObj.AttendanceStatus);
                }
            }

            return new Response(HttpStatusCode.BadRequest, "Update Attendance Fail!");
        }
    }
}
