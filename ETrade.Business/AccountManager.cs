using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.Account;
using ETrade.Dto.Dtos.Role;
using ETrade.Dto.Dtos.Session;
using ETrade.Dto.Errors;
using ETrade.Dto.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ETrade.Business
{
    public class AccountManager
    {
        private readonly UserManager _userManager;
        private readonly SessionManager _sessionManager;
        private readonly Mapper _mapper;

        public AccountManager(SessionManager sessionManager, IdentityManager identityManager, string ıpAddress, Mapper mapper)
        {
            _sessionManager = sessionManager;
            _identityManager = identityManager;
            _IpAddress = ıpAddress;
            _mapper = mapper;
        }

        private readonly IdentityManager _identityManager;
        private readonly string _IpAddress;

        public BusinessLayerResult<SessionListDto> LogIn(LogInDto logInDto)
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

        public BusinessLayerResult<SessionListDto> AnonymousLogin(AnonymousLoginDto loginDto)
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

       
    }
}
