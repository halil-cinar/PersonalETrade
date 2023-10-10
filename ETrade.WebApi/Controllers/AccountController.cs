using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.Account;
using ETrade.Dto.Dtos.Identity;
using ETrade.Dto.Dtos.Notify;
using ETrade.Dto.Dtos.Session;
using ETrade.Dto.Dtos.User;
using ETrade.Dto.Errors;
using ETrade.Dto.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult LogIn([FromBody] LogInDto loginDto)
        {
            var key = Request.Headers.Authorization;
            var response = new Response<SessionListDto>();
            try
            {
                var result = _accountService.Login(loginDto);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message.AddRange(result.ErrorMessages);
                }
                else
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    response.Data = result.Result;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.Message.Add(new ErrorMessageObj
                {
                    ErrorCode = ErrorMessageCode.AccountExceptionError,
                    Message = ex.Message
                });
            }
            return Ok(response);


        }
        [Route("SignUp")]
        [HttpPost]
        public IActionResult SignUp([FromBody] UserDto userDto)
        {

            var response = new Response<UserListDto>();
            try
            {
                var result = _accountService.SignUp(userDto);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message.AddRange(result.ErrorMessages);
                }
                else
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    response.Data = result.Result;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.Message.Add(new ErrorMessageObj
                {
                    ErrorCode = ErrorMessageCode.AccountLogInExceptionError,
                    Message = ex.Message
                });
            }
            return Ok(response);


        }

        [Route("ForgattenPassword/{token}")]
        [HttpPut]
        public IActionResult ForgattenPassword([FromBody] IdentityDto identity, string token)
        {

            var response = new Response<SessionListDto>();
            try
            {
                var result = _accountService.ForgattenPassword(identity, token);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message.AddRange(result.ErrorMessages);
                }
                else
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    response.Data = result.Result;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.Message.Add(new ErrorMessageObj
                {
                    ErrorCode = ErrorMessageCode.AccountLogInExceptionError,
                    Message = ex.Message
                });
            }
            return Ok(response);


        }
        [Route("ForgattenPasswordAnonymous/{email}")]
        [HttpGet]
        public IActionResult ForgattenPasswordAnonymous(string email)
        {

            var response = new Response<NotifyListDto>();
            try
            {
                var result = _accountService.ForgattenPasswordAnonymous(email);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message.AddRange(result.ErrorMessages);
                }
                else
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    response.Data = result.Result;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.Message.Add(new ErrorMessageObj
                {
                    ErrorCode = ErrorMessageCode.AccountLogInExceptionError,
                    Message = ex.Message
                });
            }
            return Ok(response);


        }


    }
}
