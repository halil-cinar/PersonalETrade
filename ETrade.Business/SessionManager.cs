using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.Session;
using ETrade.Dto.Errors;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using ETrade.Entities.Enums;
using ETrade.Entities.Validators;
using FluentValidation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business
{
    public class SessionManager:ManagerBase<SessionEntity>
    {

        public SessionManager(string userName, string ıpAddress, BaseEntityValidator<SessionEntity> validator, IMapper mapper, IEntityDal<SessionEntity> repository) : base(userName, ıpAddress, validator, mapper, repository)
        {
        }

        public BusinessLayerResult<SessionListDto> AddSession(SessionDto sessionDto)
        {
            var response = new BusinessLayerResult<SessionListDto>();
            try
            {
                var entity = new SessionEntity
                {
                    DeviceType= sessionDto.DeviceType,
                    ExpiryDate= sessionDto.ExpiryDate,
                    IdentityId= sessionDto.IdentityId,
                    IpAddress= sessionDto.IpAddress,
                    NotifyToken= sessionDto.NotifyToken,
                    IsActive=true,
                    UserId= sessionDto.UserId,
                    Token= Guid.NewGuid(),
                    

                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    IsDeleted = false,
                    LastTransaction = "Session has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<SessionListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.SessionAddSessionValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SessionAddSessionExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SessionListDto> UpdateSession(SessionDto sessionDto)
        {
            var response = new BusinessLayerResult<SessionListDto>();

            try
            {
                var entity = GetById(sessionDto.Id);
                if (entity != null)
                {
                    entity.DeviceType = sessionDto.DeviceType;
                    entity.ExpiryDate = sessionDto.ExpiryDate;
                    entity.IdentityId = sessionDto.IdentityId;
                    entity.IpAddress = sessionDto.IpAddress;
                    entity.NotifyToken = sessionDto.NotifyToken;
                    entity.UserId = sessionDto.UserId;
                    entity.Token = Guid.NewGuid();


                    entity.IsDeleted = false;
                    entity.LastTransaction = "Session Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<SessionListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.SessionUpdateSessionValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SessionUpdateSessionExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SessionListDto> DeleteSession(long sessionId)
        {
            var response = new BusinessLayerResult<SessionListDto>();
            try
            {
                var entity = GetById(sessionId);
                entity.IsDeleted = true;
                
                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SessionDeleteSessionExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<SessionListDto>> Filter(SessionFilter sessionFilter)
        {
            var response = new BusinessLayerResult<List<SessionListDto>>();
            try
            {
                var query = "select * from Session where isDeleted=0 and ";

                if (sessionFilter != null)
                {

                    if (!string.IsNullOrEmpty(sessionFilter.IpAddress))
                    {
                        query += $"ipAddress like '%{sessionFilter.IpAddress}%' and ";
                    }
                    if (!string.IsNullOrEmpty(sessionFilter.NotifyToken!))
                    {
                        query += $"notifyToken like '%{sessionFilter.NotifyToken}%' and ";
                    }
                    if (sessionFilter.DeviceType != null)
                    {
                        query += $"deviceType like '%{sessionFilter.DeviceType}%' and ";
                    }
                    if (sessionFilter.IdentityId != null)
                    {
                        query += $"identityId like '%{sessionFilter.IdentityId}%' and ";
                    }
                    if (sessionFilter.UserId != null)
                    {
                        query += $"userId like '%{sessionFilter.UserId}%' and ";
                    }


                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<SessionListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SessionFilterSessionExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<SessionLoadMoreDto> FilterSessionList(BaseLoadMoreFilter<SessionFilter> filter)
        {
            var response = new BusinessLayerResult<SessionLoadMoreDto>();
            try
            {
                var result = new SessionLoadMoreDto();
                List<SessionListDto> contentList = new List<SessionListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<SessionListDto>(x)).ToList();


                }
                else
                {
                    var filterResult = Filter(filter.Filter);
                    if (filterResult.ErrorMessages.Count > 0)
                    {
                        response.ErrorMessages.AddRange(filterResult.ErrorMessages.ToList());
                    }
                    else
                    {
                        contentList = filterResult.Result;
                    }

                }

                var contentCount = contentList.Count;
                var firstIndex = filter.PageCount * contentCount;
                var lastIndex = firstIndex + contentCount;

                if (contentCount < firstIndex)
                {
                    response.AddErrorMessages(ErrorMessageCode.SessionFilterSessionListError, "No more session");
                }
                else
                {
                    result.SessionListDtos = new List<SessionListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.SessionListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SessionFilterSessionListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SessionListDto> GetSession(long id)
        {
            var response = new BusinessLayerResult<SessionListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<SessionListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.SessionGetSessionNotFoundExceptionError, "Session was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SessionGetSessionExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SessionListDto> GetSessionByToken(Guid token)
        {
            var response = new BusinessLayerResult<SessionListDto>();
            try
            {
                var entity = Get(x => x.Token == token);
                if (entity != null)
                {
                    response.Result = mapper.Map<SessionListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.SessionGetSessionNotFoundExceptionError, "Session was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SessionGetSessionExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SessionListDto> GetSessionByIpAddress(string ipAdress)
        {
            var response = new BusinessLayerResult<SessionListDto>();
            try
            {
                var entity = Get(x => x.IpAddress.Equals(ipAdress)&&(x.ExpiryDate==null||x.ExpiryDate>DateTime.Now));
               
                    response.Result = mapper.Map<SessionListDto>(entity);

                
                
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SessionGetSessionExceptionError, ex.Message);
            }
            return response;
        }





    }
}

