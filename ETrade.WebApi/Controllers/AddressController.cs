
using AutoMapper;
using ETrade.Business;
using ETrade.Business.Abstract;

using ETrade.Core.Abstract.DataAccess;

using ETrade.Dto.Dtos.Address;
using ETrade.Dto.Dtos.RoleMethod;
using ETrade.Dto.Errors;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Response;
using ETrade.Entities.Abstract;
using ETrade.Entities.Concrete;
using ETrade.Entities.Enums;
using ETrade.Entities.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace ETrade.WebApi.Controllers
{
    [Route("api/Address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private  string UserName { get; set; }

        public IMapper mapper { get; set; }
        private  string IpAddress { get; set; }

       
        private readonly AddressManager _addressManager;
        private readonly IAccountService _accountManager;


        private readonly List<RoleMethodListDto> _UserMethods;

        public AddressController(IHttpContextAccessor httpContextAccessor, IAccountService accountManager)
        
        {
           var  token = httpContextAccessor.HttpContext.Request.Query["Authorization"];
            Debug.WriteLine(token);

            var path = httpContextAccessor.HttpContext.Request.Path.Value;
            Debug.WriteLine(path);

            var paths = path.Split("/");

            var callMethod = paths[2] + paths[3];
            //var callMethod=path.Substring(path.LastIndexOf('/') + 1);

            //callMethod=path.Substring(path.LastIndexOf("/",callMethod.Length) + 1,callMethod.Length+1)+callMethod;

            var test= Enum.GetName(typeof(MethodList), 1);
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
            
            if(roleMethodResult== null||roleMethodResult.ErrorMessages.Count>0)
            {
                throw new Exception();
            }

            _UserMethods = roleMethodResult.Result;

            if (_UserMethods.Where(x => Enum.GetName(typeof(MethodList), x.MethodKey).Equals(callMethod)).ToList().Count == 0)
            {
                throw new Exception();
            }




            _addressManager = new AddressManager(UserName, IpAddress);
            _accountManager = accountManager;
        }

        [HttpPost]
        [Route("GetAll")] 
        public Response<AddressLoadMoreDto> GetAll([FromBody] BaseLoadMoreFilter<AddressFilter> filter, [FromQuery] string Authorization)
        {
            var response = new Response<AddressLoadMoreDto>();
            try
            {

                var result = _addressManager.FilterAddressList(filter);
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
                    ErrorCode = ErrorMessageCode.AddressExceptionError,
                    Message = ex.Message
                });
            }

            return response;


        }

        [HttpPost]
        [Route("Add")]
        public Response<AddressListDto> Add([FromBody] AddressDto addressDto, [FromQuery] string Authorization)
        {
            var response = new Response<AddressListDto>();
            try
            {
                var result = _addressManager.AddAddress(addressDto);
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
                    ErrorCode = ErrorMessageCode.AddressExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }

        [HttpPut]
        [Route("Update")]
        public Response<AddressListDto> Update([FromBody] AddressDto addressDto, [FromQuery] string Authorization)
        {
            var response = new Response<AddressListDto>();
            try
            {
                var result = _addressManager.UpdateAddress(addressDto);
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
                    ErrorCode = ErrorMessageCode.AddressExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }



        [HttpDelete]
        [Route("Delete/{id:long}")]
        public Response<AddressListDto> Delete(long id, [FromQuery] string Authorization)
        {
            var response = new Response<AddressListDto>();
            try
            {
                var result = _addressManager.DeleteAddress(id);
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
                    ErrorCode = ErrorMessageCode.AddressExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }

        [HttpGet]
        [Route("Get/{id:long}")]
        public Response<AddressListDto> Get(long id, [FromQuery] string Authorization)
        {
            var response = new Response<AddressListDto>();
            try
            {
                var result = _addressManager.GetAddress(id);
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
                    ErrorCode = ErrorMessageCode.AddressExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }


    }
}
