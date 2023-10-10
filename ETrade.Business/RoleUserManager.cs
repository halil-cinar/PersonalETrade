using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.UserRole;
using ETrade.Dto.Errors;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using ETrade.Entities.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ETrade.Business
{
    public class UserRoleManager : ManagerBase<UserRoleEntity>,IUserRoleService
    {
        public UserRoleManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
        }
        public BusinessLayerResult<UserRoleListDto> AddUserRole(UserRoleDto userRoleDto)
        {
            var response = new BusinessLayerResult<UserRoleListDto>();
            try
            {
                var entity = new UserRoleEntity
                {
                    RoleId= userRoleDto.RoleId,
                    IsActive=userRoleDto.IsActive,
                    UserId = userRoleDto.UserId,

                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    IsDeleted = false,
                    LastTransaction = "UserRole has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<UserRoleListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.UserRoleAddUserRoleValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserRoleAddUserRoleExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserRoleListDto> UpdateUserRole(UserRoleDto userRoleDto)
        {
            var response = new BusinessLayerResult<UserRoleListDto>();

            try
            {
                var entity = GetById(userRoleDto.Id);
                if (entity != null)
                {
                    
                    entity.UserId = userRoleDto.UserId;
                    entity.RoleId = userRoleDto.RoleId;
                    entity.IsActive= userRoleDto.IsActive;

                    entity.IsDeleted = false;
                    entity.LastTransaction = "UserRole Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<UserRoleListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.UserRoleUpdateUserRoleValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserRoleUpdateUserRoleExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserRoleListDto> DeleteUserRole(long userRoleId)
        {
            var response = new BusinessLayerResult<UserRoleListDto>();
            try
            {
                var entity = GetById(userRoleId);
                entity.IsDeleted = true;
                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserRoleDeleteUserRoleExceptionError, ex.Message);
            }
            return response;
        }
        public BusinessLayerResult<UserRoleListDto> DeleteUserRoleByUserId(long userId)
        {
            var response = new BusinessLayerResult<UserRoleListDto>();
            using (var scope = new TransactionScope())
            {
                try
                {
                    var userRoles = Filter(new UserRoleFilter
                    {
                        UserId = userId
                    });
                    if (userRoles.ErrorMessages.Count > 0)//Eğer filter methodunda hata olursa
                    {
                        scope.Dispose();
                        response.ErrorMessages.AddRange(userRoles.ErrorMessages.ToList());
                        return response;
                    }
                    foreach(var userRole in userRoles.Result)
                    {
                        var entity = GetById(userRole.Id);
                        entity.IsDeleted = true;
                        Update(entity);
                    }


                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.UserRoleDeleteUserRoleExceptionError, ex.Message);
                }
            }
           
            return response;
        }

        public BusinessLayerResult<List<UserRoleListDto>> Filter(UserRoleFilter userRoleFilter)
        {
            var response = new BusinessLayerResult<List<UserRoleListDto>>();
            try
            {
                var query = "select * from UserRole where isDeleted=0 and ";

                if (userRoleFilter != null)
                {
                    if (userRoleFilter.UserId != null)
                    {
                        query += $"userId= {userRoleFilter.UserId} and ";
                    }
                    if (userRoleFilter.RoleId != null)
                    {
                        query += $"roleId= {userRoleFilter.RoleId} and ";
                    }
                    if (userRoleFilter.IsActive != null)
                    {
                        query += $"isActive= {userRoleFilter.IsActive} and ";
                    }


                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<UserRoleListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserRoleFilterUserRoleExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<UserRoleLoadMoreDto> FilterUserRoleList(BaseLoadMoreFilter<UserRoleFilter> filter)
        {
            var response = new BusinessLayerResult<UserRoleLoadMoreDto>();
            try
            {
                var result = new UserRoleLoadMoreDto();
                List<UserRoleListDto> contentList = new List<UserRoleListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<UserRoleListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.UserRoleFilterUserRoleListError, "No more userRole");
                }
                else
                {
                    result.roleUserListDtos = new List<UserRoleListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.roleUserListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserRoleFilterUserRoleListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserRoleListDto> GetUserRole(long id)
        {
            var response = new BusinessLayerResult<UserRoleListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<UserRoleListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.UserRoleGetUserRoleNotFoundExceptionError, "UserRole was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserRoleGetUserRoleExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserRoleListDto> GetRole(long id)
        {
            var response = new BusinessLayerResult<UserRoleListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<UserRoleListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.UserRoleGetUserRoleNotFoundExceptionError, "UserRole was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserRoleGetUserRoleExceptionError, ex.Message);
            }
            return response;
        }




    }
}
