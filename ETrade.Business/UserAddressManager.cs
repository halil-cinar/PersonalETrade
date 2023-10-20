using FluentValidation;
using Newtonsoft.Json.Linq;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.UserAddress;
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
    public class UserAddressManager:ManagerBase<UserAddressEntity>,IUserAddressService
    {
        public UserAddressManager(string userName, string ýpAddress) : base(userName, ýpAddress)
        {
        }

        public BusinessLayerResult<UserAddressListDto> AddUserAddress(UserAddressDto useraddressDto)
        {
            var response = new BusinessLayerResult<UserAddressListDto>();
            try
            {
                var entity = new UserAddressEntity
                {
                   isDeletable= true,
                   AddressId=useraddressDto.AddressId,
                   UserId=useraddressDto.UserId,
                   IsActive=true,
                   
                   
                   



                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "UserAddress has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<UserAddressListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.UserAddressAddUserAddressValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserAddressAddUserAddressExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserAddressListDto> UpdateUserAddress(UserAddressDto useraddressDto)
        {
            var response = new BusinessLayerResult<UserAddressListDto>();

            try
            {
                var entity = GetById(useraddressDto.Id);
                if (entity != null)
                {
                    entity.AddressId=useraddressDto.AddressId;
                    entity.UserId=useraddressDto.UserId;
                    entity.IsActive = true;
                    
                    


                    entity.isDeleted = false;
                    entity.LastTransaction = "UserAddress Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<UserAddressListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.UserAddressUpdateUserAddressValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserAddressUpdateUserAddressExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserAddressListDto> DeleteUserAddress(long useraddressId)
        {
            var response = new BusinessLayerResult<UserAddressListDto>();
            try
            {
                var entity = GetById(useraddressId);
                entity.isDeleted = true;

                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserAddressDeleteUserAddressExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<UserAddressListDto>> Filter(UserAddressFilter useraddressFilter)
        {
            var response = new BusinessLayerResult<List<UserAddressListDto>>();
            try
            {
                var query = "select * from UserAddress where isDeleted=0 and ";

                if (useraddressFilter != null)
                {


                    if (useraddressFilter.IsActive != null)
                    {
                        query += $"isActive = {useraddressFilter.IsActive} and ";
                    }
                    if (useraddressFilter.UserId != null)
                    {
                        query += $"userId = {useraddressFilter.UserId} and ";
                    }
                    if (useraddressFilter.AddressId != null)
                    {
                        query += $"addressId = {useraddressFilter.AddressId} and ";
                    }








                    if (query.EndsWith(" and "))
                    {
                        query = query.Substring(0, query.Length - " and ".Length);
                    }

                    response.Result = GetAll(query).Select(x => mapper.Map<UserAddressListDto>(x)).ToList();


                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserAddressFilterUserAddressExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<UserAddressLoadMoreDto> FilterUserAddressList(BaseLoadMoreFilter<UserAddressFilter> filter)
        {
            var response = new BusinessLayerResult<UserAddressLoadMoreDto>();
            try
            {
                var result = new UserAddressLoadMoreDto();
                List<UserAddressListDto> contentList = new List<UserAddressListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<UserAddressListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.UserAddressFilterUserAddressListError, "No more useraddress");
                }
                else
                {
                    result.UserAddressListDtos = new List<UserAddressListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.UserAddressListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserAddressFilterUserAddressListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserAddressListDto> GetUserAddress(long id)
        {
            var response = new BusinessLayerResult<UserAddressListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<UserAddressListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.UserAddressGetUserAddressNotFoundExceptionError, "UserAddress was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserAddressGetUserAddressExceptionError, ex.Message);
            }
            return response;
        }

       
    }
}


