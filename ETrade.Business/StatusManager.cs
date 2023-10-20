using FluentValidation;
using Newtonsoft.Json.Linq;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.Status;
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
    public class StatusManager:ManagerBase<StatusEntity>,IStatusService
    {
        public StatusManager(string userName, string ýpAddress) : base(userName, ýpAddress)
        {
        }

        public BusinessLayerResult<StatusListDto> AddStatus(StatusDto statusDto)
        {
            var response = new BusinessLayerResult<StatusListDto>();
            try
            {
                var entity = new StatusEntity
                {
                   Color= statusDto.Color,
                   Description= statusDto.Description,
                   isDeletable=true,
                   Title= statusDto.Title,
                   
                    
                   



                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "Status has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<StatusListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.StatusAddStatusValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.StatusAddStatusExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<StatusListDto> UpdateStatus(StatusDto statusDto)
        {
            var response = new BusinessLayerResult<StatusListDto>();

            try
            {
                var entity = GetById(statusDto.Id);
                if (entity != null)
                {
                    entity.Color= statusDto.Color;
                    entity.Description= statusDto.Description;
                    entity.isDeletable=true;
                    entity.Title = statusDto.Title;
                   


                    entity.isDeleted = false;
                    entity.LastTransaction = "Status Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<StatusListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.StatusUpdateStatusValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.StatusUpdateStatusExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<StatusListDto> DeleteStatus(long statusId)
        {
            var response = new BusinessLayerResult<StatusListDto>();
            try
            {
                var entity = GetById(statusId);
                entity.isDeleted = true;

                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.StatusDeleteStatusExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<StatusListDto>> Filter(StatusFilter statusFilter)
        {
            var response = new BusinessLayerResult<List<StatusListDto>>();
            try
            {
                var query = "select * from Status where isDeleted=0 and ";

                if (statusFilter != null)
                {


                    if (string.IsNullOrEmpty(statusFilter.Description))
                    {
                        query += $"description like '%{statusFilter.Description}%' and ";
                    }
                    if (string.IsNullOrEmpty(statusFilter.Color))
                    {
                        query += $"color like '%{statusFilter.Color}%' and ";
                    }
                    if (string.IsNullOrEmpty(statusFilter.Title))
                    {
                        query += $"title like '%{statusFilter.Title}%' and ";
                    }





                    if (query.EndsWith(" and "))
                    {
                        query = query.Substring(0, query.Length - " and ".Length);
                    }

                    response.Result = GetAll(query).Select(x => mapper.Map<StatusListDto>(x)).ToList();


                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.StatusFilterStatusExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<StatusLoadMoreDto> FilterStatusList(BaseLoadMoreFilter<StatusFilter> filter)
        {
            var response = new BusinessLayerResult<StatusLoadMoreDto>();
            try
            {
                var result = new StatusLoadMoreDto();
                List<StatusListDto> contentList = new List<StatusListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<StatusListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.StatusFilterStatusListError, "No more status");
                }
                else
                {
                    result.StatusListDtos = new List<StatusListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.StatusListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.StatusFilterStatusListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<StatusListDto> GetStatus(long id)
        {
            var response = new BusinessLayerResult<StatusListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<StatusListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.StatusGetStatusNotFoundExceptionError, "Status was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.StatusGetStatusExceptionError, ex.Message);
            }
            return response;
        }

        
    }
}


