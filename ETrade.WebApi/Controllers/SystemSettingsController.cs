using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Business;
using ETrade.Dto.Dtos.SystemSettings;
using ETrade.Dto.Dtos.RoleMethod;
using ETrade.Dto.Errors;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Response;
using ETrade.Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETrade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemSettingsController : ControllerBase
    {

        public string UserName { get; set; }

        public IMapper mapper { get; set; }
        public string IpAddress { get; set; }


        private readonly ISystemSettingsService _systemsettingsManager;
        private readonly IAccountService _accountManager;


        private readonly List<RoleMethodListDto> _UserMethods;

        public SystemSettingsController(IHttpContextAccessor httpContextAccessor, IAccountService accountManager)
        {
            var token = httpContextAccessor.HttpContext.Request.Query["Authorization"];
            Debug.WriteLine(token);

            var path = httpContextAccessor.HttpContext.Request.Path.Value;
            Debug.WriteLine(path);

            //var callMethod = path.Substring(path.LastIndexOf('/')+1);

            //callMethod = path.Substring(0, path.Length - callMethod.Length-1).Substring(path.LastIndexOf('/', path.Length - callMethod.Length - 2) + 1) + callMethod;
            var paths = path.Split("/");

            var callMethod = paths[2] + paths[3];

            var test = Enum.GetName(typeof(MethodList), 1);
            Debug.WriteLine(test);

            Debug.WriteLine(callMethod);

            IpAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            var session = accountManager.GetActiveSessionByToken(token);
            if (session == null || session.ErrorMessages.Count > 0 || session.Result == null)
            {
                throw new Exception("you are not authorised");
            }

            
            UserName = session.Result.UserName;

            var roleMethodResult = (session.Result.UserId != null)
                ? accountManager.GetUserRoleMethods((long)session.Result.UserId)
                : accountManager.GetGuestRoleMethods();

            if (roleMethodResult == null || roleMethodResult.ErrorMessages.Count > 0)
            {
                throw new Exception();
            }

            _UserMethods = roleMethodResult.Result;

            if (_UserMethods.Where(x => Enum.GetName(typeof(MethodList), x.MethodKey).Equals(callMethod)).ToList().Count == 0)
            {
                throw new Exception();
            }




            _systemsettingsManager = new SystemSettingsManager(UserName, IpAddress);
            _accountManager = accountManager;
        }

        [HttpPost]
        [Route("GetAll")]
        public Response<SystemSettingsLoadMoreDto> GetAll([FromBody] BaseLoadMoreFilter<SystemSettingsFilter> filter, [FromQuery] string Authorization)
        {
            var response = new Response<SystemSettingsLoadMoreDto>();
            try
            {

                var result = _systemsettingsManager.FilterSystemSettingsList(filter);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message.AddRange(result.ErrorMessages);
                }
                else
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    response.Data = result.Result;
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.Message.Add(new ErrorMessageObj
                {
                    ErrorCode = ErrorMessageCode.SystemSettingsExceptionError,
                    Message = ex.Message
                });
            }

            return response;


        }

        [HttpPost]
        [Route("Add")]
        public Response<SystemSettingsListDto> Add([FromBody] SystemSettingsDto systemsettingsDto, [FromQuery] string Authorization)
        {
            var response = new Response<SystemSettingsListDto>();
            try
            {
                var result = _systemsettingsManager.AddSystemSettings(systemsettingsDto);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message.AddRange(result.ErrorMessages);
                }
                else
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    response.Data = result.Result;
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.Message.Add(new ErrorMessageObj
                {
                    ErrorCode = ErrorMessageCode.SystemSettingsExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }

        [HttpPut]
        [Route("Update")]
        public Response<SystemSettingsListDto> Update([FromBody] SystemSettingsDto systemsettingsDto, [FromQuery] string Authorization)
        {
            var response = new Response<SystemSettingsListDto>();
            try
            {
                var result = _systemsettingsManager.UpdateSystemSettings(systemsettingsDto);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message.AddRange(result.ErrorMessages);
                }
                else
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    response.Data = result.Result;
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.Message.Add(new ErrorMessageObj
                {
                    ErrorCode = ErrorMessageCode.SystemSettingsExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }



        [HttpDelete]
        [Route("Delete/{id:long}")]
        public Response<SystemSettingsListDto> Delete(long id, [FromQuery] string Authorization)
        {
            var response = new Response<SystemSettingsListDto>();
            try
            {
                var result = _systemsettingsManager.DeleteSystemSettings(id);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message.AddRange(result.ErrorMessages);
                }
                else
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    response.Data = result.Result;
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.Message.Add(new ErrorMessageObj
                {
                    ErrorCode = ErrorMessageCode.SystemSettingsExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }

        [HttpGet]
        [Route("Get/{id:long}")]
        public Response<SystemSettingsListDto> Get(long id, [FromQuery] string Authorization)
        {
            var response = new Response<SystemSettingsListDto>();
            try
            {
                var result = _systemsettingsManager.GetSystemSettings(id);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message.AddRange(result.ErrorMessages);
                }
                else
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    response.Data = result.Result;
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.Message.Add(new ErrorMessageObj
                {
                    ErrorCode = ErrorMessageCode.SystemSettingsExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }


    }
}

