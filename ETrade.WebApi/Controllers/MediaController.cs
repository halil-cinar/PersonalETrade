using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Business;
using ETrade.Dto.Dtos.Media;
using ETrade.Dto.Dtos.RoleMethod;
using ETrade.Dto.Errors;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Response;
using ETrade.Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ETrade.Core.Utils;

namespace ETrade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {

        public string UserName { get; set; }

        public IMapper mapper { get; set; }
        public string IpAddress { get; set; }


        private readonly IMediaService _mediaManager;
        private readonly IAccountService _accountManager;


        private readonly List<RoleMethodListDto> _UserMethods;

        public MediaController(IHttpContextAccessor httpContextAccessor, IAccountService accountManager)
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




            _mediaManager = new MediaManager(UserName, IpAddress);
            _accountManager = accountManager;
        }

        //[HttpPost]
        //[Route("GetAll")]
        //public Response<MediaLoadMoreDto> GetAll([FromBody] BaseLoadMoreFilter<MediaFilter> filter, [FromQuery] string Authorization)
        //{
        //    var response = new Response<MediaLoadMoreDto>();
        //    try
        //    {

        //        var result = _mediaManager.FilterMediaList(filter);
        //        if (result.ErrorMessages.Count > 0)
        //        {
        //            response.StatusCode = ResponseStatusCode.Error;
        //            response.Message.AddRange(result.ErrorMessages);
        //        }
        //        else
        //        {
        //            response.StatusCode = ResponseStatusCode.Success;
        //            response.Data = result.Result;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        response.StatusCode = ResponseStatusCode.Error;
        //        response.Message.Add(new ErrorMessageObj
        //        {
        //            ErrorCode = ErrorMessageCode.MediaExceptionError,
        //            Message = ex.Message
        //        });
        //    }

        //    return response;


        //}

        [HttpPost]
        [Route("add2")]
        public IActionResult Add2([FromBody] Microsoft.AspNetCore.Http.IFormFile file)
        {
            return Ok(file.Name);
        }


        [HttpPost]
        [Route("Add")]

        public async Task<Response<MediaListDto>> Add( IFormFile file, [FromQuery] string Authorization)
        {
            var response = new Response<MediaListDto>();
            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);

                    var result = _mediaManager.AddMedia(new MediaDto
                    {
                        FileName = file.FileName,
                        FileType = Enum.Parse<FileType>(ExtensionMethods.ToPascalCase(file.ContentType.Split("/")[0])),
                        Content =stream.ToArray(),
                        ContentType= file.ContentType,
                        
                    });
                    if (result.ErrorMessages.Count > 0)
                    {
                        response.StatusCode = ResponseStatusCode.Error;
                        response.Message.AddRange(result.ErrorMessages);
                    }
                    else
                    {
                        response.StatusCode = ResponseStatusCode.Success;
                        response.Data = result.Result;
                        response.Data.Content = null;
                    }
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.Message.Add(new ErrorMessageObj
                {
                    ErrorCode = ErrorMessageCode.MediaExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }

        [HttpPut]
        [Route("Update")]
        public Response<MediaListDto> Update([FromBody] MediaDto mediaDto, [FromQuery] string Authorization)
        {
            var response = new Response<MediaListDto>();
            try
            {
                var result = _mediaManager.UpdateMedia(mediaDto);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message.AddRange(result.ErrorMessages);
                }
                else
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    response.Data = result.Result;
                    response.Data.Content = null;
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.Message.Add(new ErrorMessageObj
                {
                    ErrorCode = ErrorMessageCode.MediaExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }



        [HttpDelete]
        [Route("Delete/{id:long}")]
        public Response<MediaListDto> Delete(long id, [FromQuery] string Authorization)
        {
            var response = new Response<MediaListDto>();
            try
            {
                var result = _mediaManager.DeleteMedia(id);
                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message.AddRange(result.ErrorMessages);
                }
                else
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    response.Data = result.Result;
                    result.Result.Content = null;
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.Message.Add(new ErrorMessageObj
                {
                    ErrorCode = ErrorMessageCode.MediaExceptionError,
                    Message = ex.Message
                });
            }

            return response;
        }

        [HttpGet]
        [Route("Get/{id:long}")]
        public IActionResult Get(long id, [FromQuery] string Authorization)
        {
            var response = new Response<FileStreamResult>();
            try
            {
                var result = _mediaManager.GetMedia(id);

                if (result.ErrorMessages.Count > 0)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.Message.AddRange(result.ErrorMessages);
                }
                else
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    var stream = new MemoryStream(result.Result.Content);
                    
                     return File(stream, result.Result.ContentType,result.Result.FileName);
                    
                    
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.Message.Add(new ErrorMessageObj
                {
                    ErrorCode = ErrorMessageCode.MediaExceptionError,
                    Message = ex.Message
                });
            }

            return BadRequest(response);
        }

    }
}
