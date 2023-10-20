using FluentValidation;
using Newtonsoft.Json.Linq;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.UserCart;
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
    public class UserCartManager:ManagerBase<UserCartEntity>,IUserCartService
    {
        public UserCartManager(string userName, string ýpAddress) : base(userName, ýpAddress)
        {
        }

        public BusinessLayerResult<UserCartListDto> AddUserCart(UserCartDto usercartDto)
        {
            var response = new BusinessLayerResult<UserCartListDto>();
            try
            {
                var entity = new UserCartEntity
                {
                   isDeletable=true,
                   UserId=usercartDto.UserId,
                   ProductId=usercartDto.ProductId,
                   IsActive=usercartDto.IsActive,
                   Count=usercartDto.Count,
                   
                   
                   
                   



                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "UserCart has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<UserCartListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.UserCartAddUserCartValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserCartAddUserCartExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserCartListDto> UpdateUserCart(UserCartDto usercartDto)
        {
            var response = new BusinessLayerResult<UserCartListDto>();

            try
            {
                var entity = GetById(usercartDto.Id);
                if (entity != null)
                {
                    entity. UserId=usercartDto.UserId;
                    entity. ProductId=usercartDto.ProductId;
                    entity. IsActive=usercartDto.IsActive;
                    entity.Count = usercartDto.Count;
                   


                    entity.isDeleted = false;
                    entity.LastTransaction = "UserCart Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<UserCartListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.UserCartUpdateUserCartValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserCartUpdateUserCartExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserCartListDto> DeleteUserCart(long usercartId)
        {
            var response = new BusinessLayerResult<UserCartListDto>();
            try
            {
                var entity = GetById(usercartId);
                entity.isDeleted = true;

                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserCartDeleteUserCartExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<UserCartListDto>> Filter(UserCartFilter usercartFilter)
        {
            var response = new BusinessLayerResult<List<UserCartListDto>>();
            try
            {
                var query = "select * from UserCart where isDeleted=0 and ";

                if (usercartFilter != null)
                {


                    if (usercartFilter.IsActive != null)
                    {
                        query += $"isActive = {usercartFilter.IsActive} and ";
                    }
                    if (usercartFilter.UserId != null)
                    {
                        query += $"userId = {usercartFilter.UserId} and ";
                    }
                    if (usercartFilter.ProductId != null)
                    {
                        query += $"productId = {usercartFilter.ProductId} and ";
                    }
                    if (usercartFilter.MaxCount != null)
                    {
                        query += $"count <= {usercartFilter.MaxCount} and ";
                    }
                    if (usercartFilter.MinCount != null)
                    {
                        query += $"count >= {usercartFilter.MinCount} and ";
                    }





                    if (query.EndsWith(" and "))
                    {
                        query = query.Substring(0, query.Length - " and ".Length);
                    }

                    response.Result = GetAll(query).Select(x => mapper.Map<UserCartListDto>(x)).ToList();


                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserCartFilterUserCartExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<UserCartLoadMoreDto> FilterUserCartList(BaseLoadMoreFilter<UserCartFilter> filter)
        {
            var response = new BusinessLayerResult<UserCartLoadMoreDto>();
            try
            {
                var result = new UserCartLoadMoreDto();
                List<UserCartListDto> contentList = new List<UserCartListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<UserCartListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.UserCartFilterUserCartListError, "No more usercart");
                }
                else
                {
                    result.UserCartListDtos = new List<UserCartListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.UserCartListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserCartFilterUserCartListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserCartListDto> GetUserCart(long id)
        {
            var response = new BusinessLayerResult<UserCartListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<UserCartListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.UserCartGetUserCartNotFoundExceptionError, "UserCart was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserCartGetUserCartExceptionError, ex.Message);
            }
            return response;
        }

        
    }
}


