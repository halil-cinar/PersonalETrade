using FluentValidation;
using Newtonsoft.Json.Linq;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.UserFavourite;
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
    public class UserFavouriteManager:ManagerBase<UserFavouriteEntity>,IUserFavouriteService
    {
        public UserFavouriteManager(string userName, string ýpAddress) : base(userName, ýpAddress)
        {
        }

        public BusinessLayerResult<UserFavouriteListDto> AddUserFavourite(UserFavouriteDto userfavouriteDto)
        {
            var response = new BusinessLayerResult<UserFavouriteListDto>();
            try
            {
                var entity = new UserFavouriteEntity
                {
                   isDeletable= true,
                   ProductId=userfavouriteDto.ProductId,
                   IsActive=userfavouriteDto.IsActive,
                   UserId= userfavouriteDto.UserId,    
                   
                   



                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "UserFavourite has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<UserFavouriteListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.UserFavouriteAddUserFavouriteValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserFavouriteAddUserFavouriteExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserFavouriteListDto> UpdateUserFavourite(UserFavouriteDto userfavouriteDto)
        {
            var response = new BusinessLayerResult<UserFavouriteListDto>();

            try
            {
                var entity = GetById(userfavouriteDto.Id);
                if (entity != null)
                {
                    entity.ProductId=userfavouriteDto.ProductId;
                    entity.IsActive=userfavouriteDto.IsActive;
                    entity.UserId = userfavouriteDto.UserId;
                   


                    entity.isDeleted = false;
                    entity.LastTransaction = "UserFavourite Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<UserFavouriteListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.UserFavouriteUpdateUserFavouriteValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserFavouriteUpdateUserFavouriteExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserFavouriteListDto> DeleteUserFavourite(long userfavouriteId)
        {
            var response = new BusinessLayerResult<UserFavouriteListDto>();
            try
            {
                var entity = GetById(userfavouriteId);
                entity.isDeleted = true;

                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserFavouriteDeleteUserFavouriteExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<UserFavouriteListDto>> Filter(UserFavouriteFilter userfavouriteFilter)
        {
            var response = new BusinessLayerResult<List<UserFavouriteListDto>>();
            try
            {
                var query = "select * from UserFavourite where isDeleted=0 and ";

                if (userfavouriteFilter != null)
                {


                    if (userfavouriteFilter.IsActive != null)
                    {
                        query += $"isActive = {userfavouriteFilter.IsActive} and ";
                    }
                    if (userfavouriteFilter.UserId != null)
                    {
                        query += $"userId = {userfavouriteFilter.UserId} and ";
                    }
                    if (userfavouriteFilter.ProductId != null)
                    {
                        query += $"productId = {userfavouriteFilter.ProductId} and ";
                    }
                   
                    
                    
                    
                    if (query.EndsWith(" and "))
                    {
                        query = query.Substring(0, query.Length - " and ".Length);
                    }

                    response.Result = GetAll(query).Select(x => mapper.Map<UserFavouriteListDto>(x)).ToList();


                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserFavouriteFilterUserFavouriteExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<UserFavouriteLoadMoreDto> FilterUserFavouriteList(BaseLoadMoreFilter<UserFavouriteFilter> filter)
        {
            var response = new BusinessLayerResult<UserFavouriteLoadMoreDto>();
            try
            {
                var result = new UserFavouriteLoadMoreDto();
                List<UserFavouriteListDto> contentList = new List<UserFavouriteListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<UserFavouriteListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.UserFavouriteFilterUserFavouriteListError, "No more userfavourite");
                }
                else
                {
                    result.UserFavouriteListDtos = new List<UserFavouriteListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.UserFavouriteListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserFavouriteFilterUserFavouriteListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserFavouriteListDto> GetUserFavourite(long id)
        {
            var response = new BusinessLayerResult<UserFavouriteListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<UserFavouriteListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.UserFavouriteGetUserFavouriteNotFoundExceptionError, "UserFavourite was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserFavouriteGetUserFavouriteExceptionError, ex.Message);
            }
            return response;
        }

       
    }
}


