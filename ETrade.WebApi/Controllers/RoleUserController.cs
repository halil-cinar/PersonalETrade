﻿using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Business;
using ETrade.Dto.Dtos.UserRole;
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
    public class RoleUserController : ControllerBase
    {

        public string UserName { get; set; }

        public IMapper mapper { get; set; }
        public string IpAddress { get; set; }


        private readonly IUserRoleService _userRoleManager;
        private readonly IAccountService _accountManager;


        private readonly List<RoleMethodListDto> _UserMethods;

        public UserRoleController(IHttpContextAccessor httpContextAccessor, IAccountService accountManager)
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




            _userRoleManager = new UserRoleManager(UserName, IpAddress);
            _accountManager = accountManager;
        }

        [HttpPost]
        [Route("GetAll")]
        public Response<UserRoleLoadMoreDto> GetAll([FromBody] BaseLoadMoreFilter<UserRoleFilter> filter, [FromQuery] string Authorization)
        {
            var response = new Response<UserRoleLoadMoreDto>();
            try
            {

                var result = _userRoleManager.FilterUserRoleList(filter);
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
                    ErrorCode = ErrorMessageCode.UserRoleExceptionError,
                    Message = ex.Message
                });
            }

            return response;


        }

        [HttpPost]
        [Route("Add")]
        public Response<UserRoleListDto> Add([FromBody] UserRoleDto userRoleDto, [FromQuery] string Authorization)
        {
            var response = new Response<UserRoleListDto>();
            try
            {
                var result = _userRoleManager.AddUserRole(userRoleDto);
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
                    ErrorCode = ErrorMessageCode.UserRoleExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }

        [HttpPut]
        [Route("Update")]
        public Response<UserRoleListDto> Update([FromBody] UserRoleDto userRoleDto, [FromQuery] string Authorization)
        {
            var response = new Response<UserRoleListDto>();
            try
            {
                var result = _userRoleManager.UpdateUserRole(userRoleDto);
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
                    ErrorCode = ErrorMessageCode.UserRoleExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }



        [HttpDelete]
        [Route("Delete/{id:long}")]
        public Response<UserRoleListDto> Delete(long id, [FromQuery] string Authorization)
        {
            var response = new Response<UserRoleListDto>();
            try
            {
                var result = _userRoleManager.DeleteUserRole(id);
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
                    ErrorCode = ErrorMessageCode.UserRoleExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }

        [HttpGet]
        [Route("Get/{id:long}")]
        public Response<UserRoleListDto> Get(long id, [FromQuery] string Authorization)
        {
            var response = new Response<UserRoleListDto>();
            try
            {
                var result = _userRoleManager.GetUserRole(id);
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
                    ErrorCode = ErrorMessageCode.UserRoleExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }

    }
}