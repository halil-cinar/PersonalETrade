using AutoMapper;
using ETrade.Business;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.Address;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Response;
using ETrade.Entities.Abstract;
using ETrade.Entities.Concrete;
using ETrade.Entities.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebApi.Controllers
{
    [Route("api/Address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public string UserName { get; set; }

        public IMapper mapper { get; set; }
        public string IpAddress { get; set; }

        public BaseEntityValidator<AddressEntity> Validator { get; set; }

        public IEntityDal<AddressEntity> repository { get; set; }

        private readonly AddressManager _addressManager;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddressController(BaseEntityValidator<AddressEntity> validator, IMapper mapper, IEntityDal<AddressEntity> repository, IHttpContextAccessor httpContextAccessor)
        {
            UserName = "admin";
            IpAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            Validator = validator;
            this.mapper = mapper;
            this.repository = repository;
            _addressManager = new AddressManager(validator, mapper, repository, UserName, IpAddress);
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("GetAll")]
        public Response<AddressLoadMoreDto> GetAll([FromBody] BaseLoadMoreFilter<AddressFilter> filter)
        {
            var response = new Response<AddressLoadMoreDto>();
            try
            {
                var result = _addressManager.FilterAddressList(filter);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message = result.ErrorMessages.Select(x => ((int)x.ErrorCode).ToString() + " - " + x.Message).ToList();
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
                response.Message.Add(ex.ToString());
            }

            return response;


        }

        [HttpPost]
        [Route("Add")]
        public Response<AddressListDto> Add([FromBody] AddressDto addressDto)
        {
            var response = new Response<AddressListDto>();
            try
            {
                var result = _addressManager.AddAddress(addressDto);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message = result.ErrorMessages.Select(x => x.Message).ToList();
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
                response.Message.Add(ex.ToString());
            }

            return response;
        }

        [HttpPut]
        [Route("Update")]
        public Response<AddressListDto> Update([FromBody] AddressDto addressDto)
        {
            var response = new Response<AddressListDto>();
            try
            {
                var result = _addressManager.UpdateAddress(addressDto);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message = result.ErrorMessages.Select(x => x.Message).ToList();
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
                response.Message.Add(ex.ToString());
            }

            return response;
        }



        [HttpDelete]
        [Route("Delete/{id:long}")]
        public Response<AddressListDto> Delete(long id)
        {
            var response = new Response<AddressListDto>();
            try
            {
                var result = _addressManager.DeleteAddress(id);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message = result.ErrorMessages.Select(x => x.Message).ToList();
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
                response.Message.Add(ex.ToString());
            }

            return response;
        }

        [HttpGet]
        [Route("Get/{id:long}")]
        public Response<AddressDetailListDto> Get(long id)
        {
            var response = new Response<AddressDetailListDto>();
            try
            {
                var result = _addressManager.GetAddress(id);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message = result.ErrorMessages.Select(x => x.Message).ToList();
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
                response.Message.Add(ex.ToString());
            }

            return response;
        }


    }
}
