﻿using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Business;
using ETrade.Dto.Dtos.Brand;
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
    public class BrandController : ControllerBase
    {

        public string UserName { get; set; }

        public IMapper mapper { get; set; }
        public string IpAddress { get; set; }


        private readonly IBrandService _brandManager;
        private readonly IAccountService _accountManager;


        private readonly List<RoleMethodListDto> _UserMethods;

        public BrandController(IHttpContextAccessor httpContextAccessor, IAccountService accountManager)
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




            _brandManager = new BrandManager(UserName, IpAddress);
            _accountManager = accountManager;
        }

        [HttpPost]
        [Route("GetAll")]
        public Response<BrandLoadMoreDto> GetAll([FromBody] BaseLoadMoreFilter<BrandFilter> filter, [FromQuery] string Authorization)
        {
            var response = new Response<BrandLoadMoreDto>();
            try
            {

                var result = _brandManager.FilterBrandList(filter);
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
                    ErrorCode = ErrorMessageCode.BrandExceptionError,
                    Message = ex.Message
                });
            }

            return response;


        }

        [HttpPost]
        [Route("Add")]
        public Response<BrandListDto> Add([FromBody] BrandDto brandDto, [FromQuery] string Authorization)
        {
            var response = new Response<BrandListDto>();
            try
            {
                var result = _brandManager.AddBrand(brandDto);
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
                    ErrorCode = ErrorMessageCode.BrandExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }

        [HttpPut]
        [Route("Update")]
        public Response<BrandListDto> Update([FromBody] BrandDto brandDto, [FromQuery] string Authorization)
        {
            var response = new Response<BrandListDto>();
            try
            {
                var result = _brandManager.UpdateBrand(brandDto);
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
                    ErrorCode = ErrorMessageCode.BrandExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }



        [HttpDelete]
        [Route("Delete/{id:long}")]
        public Response<BrandListDto> Delete(long id, [FromQuery] string Authorization)
        {
            var response = new Response<BrandListDto>();
            try
            {
                var result = _brandManager.DeleteBrand(id);
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
                    ErrorCode = ErrorMessageCode.BrandExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }

        [HttpGet]
        [Route("Get/{id:long}")]
        public Response<BrandListDto> Get(long id, [FromQuery] string Authorization)
        {
            var response = new Response<BrandListDto>();
            try
            {
                var result = _brandManager.GetBrand(id);
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
                    ErrorCode = ErrorMessageCode.BrandExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }


    }
}
