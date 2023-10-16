using FluentValidation;
using Newtonsoft.Json.Linq;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.Notify;
using ETrade.Dto.Errors;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using ETrade.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business
{
    public class NotifyManager:ManagerBase<NotifyEntity>,INotifyService
    {
        public NotifyManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
        }

        public BusinessLayerResult<NotifyListDto> AddNotify(NotifyDto notifyDto)
        {
            var response = new BusinessLayerResult<NotifyListDto>();
            try
            {
                var entity = new NotifyEntity
                {
                   Data= notifyDto.Data,
                   ExpiryDate= notifyDto.ExpiryDate,
                   IsActive= notifyDto.IsActive,
                   NotifyType= notifyDto.NotifyType,
                   Token= Guid.NewGuid().ToString().ToUpper(),
                   UserId= notifyDto.UserId,    
                   
                   



                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "Notify has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<NotifyListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.NotifyAddNotifyValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.NotifyAddNotifyExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<NotifyListDto> UpdateNotify(NotifyDto notifyDto)
        {
            var response = new BusinessLayerResult<NotifyListDto>();

            try
            {
                var entity = GetById(notifyDto.Id);
                if (entity != null)
                {
                    entity.Data = notifyDto.Data;
                    entity.ExpiryDate = notifyDto.ExpiryDate;
                    entity.IsActive = notifyDto.IsActive;
                    entity.NotifyType = notifyDto.NotifyType;
                    entity.Token = Guid.NewGuid().ToString().ToUpper();
                    entity.UserId = notifyDto.UserId;


                    entity.isDeleted = false;
                    entity.LastTransaction = "Notify Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<NotifyListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.NotifyUpdateNotifyValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.NotifyUpdateNotifyExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<NotifyListDto> DeleteNotify(long notifyId)
        {
            var response = new BusinessLayerResult<NotifyListDto>();
            try
            {
                var entity = GetById(notifyId);
                entity.isDeleted = true;

                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.NotifyDeleteNotifyExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<NotifyListDto>> Filter(NotifyFilter notifyFilter)
        {
            var response = new BusinessLayerResult<List<NotifyListDto>>();
            try
            {
                var query = "select * from Notify where isDeleted=0 and ";

                if (notifyFilter != null)
                {


                    if (notifyFilter.IsActive != null)
                    {
                        query += $"isActive = {notifyFilter.IsActive} and ";
                    }
                    if (notifyFilter.MaxExpiryDate != null)
                    {
                        query += $"expiryDate = {notifyFilter.MaxExpiryDate} and ";
                    }
                    if (notifyFilter.MinExpiryDate != null)
                    {
                        query += $"expiryDate = {notifyFilter.MinExpiryDate} and ";
                    }
                    if (notifyFilter.NotifyType != null)
                    {
                        query += $"notifyType = {notifyFilter.NotifyType} and ";
                    }
                    if (notifyFilter.UserId != null)
                    {
                        query += $"userId = {notifyFilter.UserId} and ";
                    }
                    if (notifyFilter.MinExpiryDate != null)
                    {
                        query += $"secondUserId = {notifyFilter.MinExpiryDate} and ";







                    }
                    if (query.EndsWith(" and "))
                    {
                        query = query.Substring(0, query.Length - " and ".Length);
                    }

                    response.Result = GetAll(query).Select(x => mapper.Map<NotifyListDto>(x)).ToList();


                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.NotifyFilterNotifyExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<NotifyLoadMoreDto> FilterNotifyList(BaseLoadMoreFilter<NotifyFilter> filter)
        {
            var response = new BusinessLayerResult<NotifyLoadMoreDto>();
            try
            {
                var result = new NotifyLoadMoreDto();
                List<NotifyListDto> contentList = new List<NotifyListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<NotifyListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.NotifyFilterNotifyListError, "No more notify");
                }
                else
                {
                    result.NotifyListDtos = new List<NotifyListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.NotifyListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.NotifyFilterNotifyListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<NotifyListDto> GetNotify(long id)
        {
            var response = new BusinessLayerResult<NotifyListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<NotifyListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.NotifyGetNotifyNotFoundExceptionError, "Notify was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.NotifyGetNotifyExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<NotifyListDto> GetNotifyByToken(string token)
        {
            var response = new BusinessLayerResult<NotifyListDto>();
            try
            {
                var entity = Get(x=>x.Token.ToUpper()==token.ToUpper()&&x.IsActive==true);
                if (entity != null)
                {
                    response.Result = mapper.Map<NotifyListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.NotifyGetNotifyNotFoundExceptionError, "Notify was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.NotifyGetNotifyExceptionError, ex.Message);
            }
            return response;
        }
    }
}
