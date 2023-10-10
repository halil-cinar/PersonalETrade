using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.Account;
using ETrade.Dto.Dtos.Identity;
using ETrade.Dto.Dtos.Notify;
using ETrade.Dto.Dtos.Role;
using ETrade.Dto.Dtos.RoleMethod;
using ETrade.Dto.Dtos.Session;
using ETrade.Dto.Dtos.User;
using ETrade.Dto.Errors;
using ETrade.Dto.Result;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ETrade.Business
{
    public class AccountManager:IAccountService
    {
        private readonly ISessionService _sessionManager;
        private readonly IIdentityService _identityManager;
        private readonly IUserService _userService;
        private readonly INotifyService _notifyService;
        private readonly IRoleService _roleService;
        private readonly IRoleMethodService _roleMethodService;
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;
        private readonly string _IpAddress;

        public AccountManager(IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            var ipAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            _IpAddress = ipAddress;
            _sessionManager = new SessionManager("", _IpAddress);
            _identityManager = new IdentityManager("", _IpAddress);
            _userService = new UserManager("", ipAddress);
            _notifyService = new NotifyManager("", ipAddress);
            _roleService = new RoleManager("", ipAddress);
            _roleMethodService = new RoleMethodManager("", ipAddress);
            _userRoleService = new UserRoleManager("", ipAddress);
            _mapper = mapper;
        }



        public BusinessLayerResult<SessionListDto> Login(LogInDto logInDto)
        {
            var response = new BusinessLayerResult<SessionListDto>();
            using (var scope = new TransactionScope())
            {
                try
                {
                    var identityCheck = _identityManager.CheckPassword(new Dto.Dtos.Identity.IdentityDto
                    {
                        ConfirmPassword = logInDto.Password,
                        Password = logInDto.Password,
                        UserName = logInDto.UserName,


                    });
                    if (identityCheck.ErrorMessages.Count > 0)
                    {
                        scope.Dispose();
                        response.ErrorMessages.AddRange(identityCheck.ErrorMessages);
                        return response;
                    }

                    if (identityCheck.Result == null)
                    {
                        scope.Dispose();
                        response.AddErrorMessages(ErrorMessageCode.AccountLogInWrongUsernameOrPassword, "Username or password is incorrect");
                        return response;
                    }

                    var identity = identityCheck.Result;
                    var session = _sessionManager.AddSession(new SessionDto
                    {
                        DeviceType = logInDto.DeviceType,
                        ExpiryDate = DateTime.Now.AddDays(1), // Bir gun geçerli
                        IdentityId = identity.Id,
                        IpAddress = _IpAddress,
                        NotifyToken = logInDto.NotifyToken,
                        UserId = identity.UserId

                    });
                    if (session.ErrorMessages.Count > 0)
                    {
                        scope.Dispose();
                        response.ErrorMessages.AddRange(session.ErrorMessages);
                        return response;
                    }
                    response.Result = session.Result;
                    scope.Complete();

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.AccountLogInExceptionError, ex.Message);
                    return response;
                }
                return response;
            }
        }

        public BusinessLayerResult<SessionListDto> AnonymousLogin(AnonymousLogInDto loginDto)
        {
            var response = new BusinessLayerResult<SessionListDto>();
            try
            {
                var session = _sessionManager.GetSessionByIpAddress(_IpAddress);
                if (session.ErrorMessages.Any())
                {
                    response.ErrorMessages.AddRange(session.ErrorMessages);
                    return response;
                }
                if (session.Result == null)
                {
                    session = _sessionManager.AddSession(new SessionDto
                    {
                        DeviceType = loginDto.DeviceType,
                        NotifyToken = loginDto.NotifyToken,
                        IpAddress = _IpAddress
                    });

                }
                if (session.ErrorMessages.Any())
                {
                    response.ErrorMessages.AddRange(session.ErrorMessages);
                    return response;
                }
                response.Result = session.Result;

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AccountAnonymousLogInExceptionError, ex.Message);

            }
            return response;

        }

        public BusinessLayerResult<SessionListDto> Logout(string token)
        {
            var response = new BusinessLayerResult<SessionListDto>();
            try
            {
                var session = _sessionManager.GetSessionByToken(Guid.Parse(token));
                if (session.ErrorMessages.Any())
                {

                    response.ErrorMessages.AddRange(session.ErrorMessages);
                    return response;

                }
                if (session.Result != null)
                {
                    session.Result.IsActive = false;
                    var result = _sessionManager.UpdateSession(_mapper.Map<SessionDto>(session.Result));
                    if (result.ErrorMessages.Any())
                    {
                        response.ErrorMessages.AddRange(session.ErrorMessages);
                        return response;
                    }
                    response.Result = result.Result;
                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AccountLogoutExceptionError, ex.Message);

            }
            return response;
        }

        public BusinessLayerResult<SessionListDto> GetSessionFromIp()
        {
            var response = new BusinessLayerResult<SessionListDto>();
            try
            {
                var session = _sessionManager.GetSessionByIpAddress(_IpAddress);
                if (session.ErrorMessages.Any())
                {
                    response.ErrorMessages.AddRange(session.ErrorMessages);
                    return response;
                }
                response.Result = session.Result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AccountGetSessionByIpExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SessionListDto> ForgattenPassword(IdentityDto identity, string notifyToken)
        {
            var response = new BusinessLayerResult<SessionListDto>();
            using (var scope = new TransactionScope())
            {
                try
                {
                    var getNotify = _notifyService.GetNotifyByToken(notifyToken);
                    if (getNotify.ErrorMessages.Count > 0)
                    {
                        scope.Dispose();
                        response.ErrorMessages.AddRange(getNotify.ErrorMessages);
                        return response;
                    }

                    if (getNotify.Result == null)
                    {
                        scope.Dispose();
                        response.AddErrorMessages(ErrorMessageCode.AccountForgatenPasswordTokenNotFoundError, "the token specified is not valid");
                        return response;
                    }

                    var userResult = _userService.GetUser(getNotify.Result.UserId);

                    if (userResult.ErrorMessages.Count > 0)
                    {
                        scope.Dispose();
                        response.ErrorMessages.AddRange(userResult.ErrorMessages);
                        return response;
                    }

                    var identityResult = _identityManager.ChangePassword(identity);

                    if (identityResult.ErrorMessages.Count > 0)
                    {
                        scope.Dispose();
                        response.ErrorMessages.AddRange(identityResult.ErrorMessages);
                        return response;
                    }

                    var sessionResult = Login(new LogInDto
                    {
                        DeviceType = identity.DeviceType,
                        NotifyToken = notifyToken,
                        Password = identity.Password,
                        UserName = identity.UserName
                    });

                    if (sessionResult.ErrorMessages.Count > 0)
                    {
                        scope.Dispose();
                        response.ErrorMessages.AddRange(sessionResult.ErrorMessages);
                        return response;
                    }

                    response.Result = sessionResult.Result;
                    scope.Complete();
                    scope.Dispose();



                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.AccountForgatenPasswordExceptionError, ex.Message);
                }

            }
            return response;
        }

        public BusinessLayerResult<NotifyListDto> ForgattenPasswordAnonymous(string email)
        {
            var response = new BusinessLayerResult<NotifyListDto>();
            try
            {
                var userResult = _userService.Filter(new Dto.Filters.UserFilter
                {
                    Email = email
                });

                if (userResult.ErrorMessages.Count > 0)
                {
                    response.ErrorMessages.AddRange(userResult.ErrorMessages);
                    return response;
                }

                if (userResult.Result.FirstOrDefault() == null)
                {
                    response.AddErrorMessages(ErrorMessageCode.AccountForgatenPasswordAnonymousEmailNotFoundError, "specified email is not assigned to any user");
                    return response;
                }
                var user = userResult.Result.FirstOrDefault();
                var notifyDto = new NotifyDto
                {
                    ExpiryDate = DateTime.Now.AddDays(1),
                    IsActive = true,
                    UserId = user.Id,
                    NotifyType = Entities.Enum.NotifyType.ForgattenPassword,
                };
                var addNotify = _notifyService.AddNotify(notifyDto);

                if (addNotify.ErrorMessages.Count > 0)
                {
                    response.ErrorMessages.AddRange(addNotify.ErrorMessages);
                    return response;
                }

                response.Result = addNotify.Result;

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AccountForgatenPasswordAnonymousExceptionError, ex.Message);

            }
            return response;
        }

        public BusinessLayerResult<SessionListDto> GetActiveSessionByToken(string token)
        {
            var response = new BusinessLayerResult<SessionListDto>();
            try
            {
                var result = _sessionManager.GetSessionByToken(Guid.Parse(token));

                if (result.ErrorMessages.Count > 0)
                {
                    response.ErrorMessages.AddRange(result.ErrorMessages);
                    return response;
                }

                response.Result = result.Result;

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AccountGetActiveSessionByTokenExceptionError, ex.Message);

            }
            return response;
        }

        public BusinessLayerResult<List<RoleMethodListDto>> GetUserRoleMethods(long userId)
        {
            var response = new BusinessLayerResult<List<RoleMethodListDto>>();
            try
            {
                var userRoles = GetUserRoles(userId);
                if (userRoles.ErrorMessages.Count > 0)
                {
                    response.ErrorMessages.AddRange(userRoles.ErrorMessages);
                    return response;
                }
                var roles = userRoles.Result;
                var methodResult = _roleMethodService.Filter(new Dto.Filters.RoleMethodFilter
                {
                    RoleIds = roles.Select(x => x.Id).ToArray()
                }) ;
                if (methodResult.ErrorMessages.Count > 0)
                {
                    response.ErrorMessages.AddRange(methodResult.ErrorMessages);
                    return response;
                }
                response.Result = methodResult.Result;
            }catch(Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AccountGetUserRoleMethodExceptionError, ex.Message);

            }
            return response;

        }

        public BusinessLayerResult<List<RoleListDto>> GetUserRoles(long userId)
        {
            var response = new BusinessLayerResult<List<RoleListDto>>();
            try
            {
                var userRoles = _userRoleService.Filter(new Dto.Filters.UserRoleFilter
                {
                    UserId = userId
                });
                if (userRoles.ErrorMessages.Count > 0)
                {
                    response.ErrorMessages.AddRange(userRoles.ErrorMessages);
                    return response;
                }
                var roleIds = userRoles.Result.Select(x => x.RoleId).ToList();
                var roleList = _roleService.Filter(new Dto.Filters.RoleFilter
                {
                    Ids = roleIds.ToArray()
                });
                if (roleList.ErrorMessages.Count > 0)
                {
                    response.ErrorMessages.AddRange(roleList.ErrorMessages);
                    return response;
                }
                response.Result = roleList.Result;

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AccountGetUserRoleExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserListDto> SignUp(UserDto userDto)
        {
            var response = new BusinessLayerResult<UserListDto>();

            try
            {
                var adminRole = _roleService.Filter(new Dto.Filters.RoleFilter
                {
                    Name = "admin"
                });
                if (adminRole.ErrorMessages.Count > 0)
                {
                    response.ErrorMessages.AddRange(adminRole.ErrorMessages);
                    return response;
                }
                if (adminRole.Result != null &&
                    userDto.RoleIds.Contains(adminRole.Result.FirstOrDefault().Id)
                    )
                {
                    response.AddErrorMessages(ErrorMessageCode.AccountSignUpInsufficientAuthorisationError, "You are not authorised to add for that role.");
                    return response;
                }
                var result = _userService.AddUser(userDto);
                response = result;
            }
            catch (Exception ex)
            {

            }
            return response;


        }

        public BusinessLayerResult<SessionListDto> GetActiveSessionByIp(string ip)
        {
            var response = new BusinessLayerResult<SessionListDto>();
            try
            {
                var result = _sessionManager.Filter(new Dto.Filters.SessionFilter
                {
                    IpAddress = ip,
                    IsActive = true
                });

                if (result.ErrorMessages.Count > 0)
                {
                    response.ErrorMessages.AddRange(result.ErrorMessages);
                    return response;
                }

                response.Result = result.Result.FirstOrDefault();

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AccountGetActiveSessionByIpExceptionError, ex.Message);

            }
            return response;
        }





    }
}
