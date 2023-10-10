using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.Role;
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

namespace ETrade.Business
{
    public class RoleManager : ManagerBase<RoleEntity>,IRoleService
    {
        private readonly IUserRoleService _userRoleManager;

        public RoleManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
            _userRoleManager = new UserRoleManager(userName,ıpAddress);
        }

        public BusinessLayerResult<RoleListDto> AddRole(RoleDto roleDto)
        {
            var response = new BusinessLayerResult<RoleListDto>();
            try
            {
                var entity = new RoleEntity
                {
                    Description= roleDto.Description,
                    Name= roleDto.Name,

                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    IsDeleted = false,
                    LastTransaction = "Role has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<RoleListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.RoleAddRoleValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.RoleAddRoleExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<RoleListDto> UpdateRole(RoleDto roleDto)
        {
            var response = new BusinessLayerResult<RoleListDto>();

            try
            {
                var entity = GetById(roleDto.Id);
                if (entity != null)
                {
                    entity.Name = roleDto.Name;
                    entity.Description = roleDto.Description;


                    entity.IsDeleted = false;
                    entity.LastTransaction = "Role Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<RoleListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.RoleUpdateRoleValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.RoleUpdateRoleExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<RoleListDto> DeleteRole(long roleId)
        {
            var response = new BusinessLayerResult<RoleListDto>();
            try
            {
                var entity = GetById(roleId);
                if (entity != null)
                {
                    var userRoles = _userRoleManager.Filter(new UserRoleFilter
                    {
                        RoleId = roleId
                    }).Result;
                    foreach (var userRole in userRoles)
                    {
                        _userRoleManager.DeleteUserRole(userRole.Id);
                    }
                    entity.IsDeleted = true;
                    Update(entity);
                }
                
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.RoleDeleteRoleExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<RoleListDto>> Filter(RoleFilter roleFilter)
        {
            var response = new BusinessLayerResult<List<RoleListDto>>();
            try
            {
                var query = "select * from Role where isDeleted=0 and ";

                if (roleFilter != null)
                {
                    
                    if (!string.IsNullOrEmpty(roleFilter.Name))
                    {
                        query += $"name like '%{roleFilter.Name}%' and ";
                    }
                    if (!string.IsNullOrEmpty(roleFilter.Description!))
                    {
                        query += $"description like '%{roleFilter.Description}%' and ";
                    }
                    

                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<RoleListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.RoleFilterRoleExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<RoleLoadMoreDto> FilterRoleList(BaseLoadMoreFilter<RoleFilter> filter)
        {
            var response = new BusinessLayerResult<RoleLoadMoreDto>();
            try
            {
                var result = new RoleLoadMoreDto();
                List<RoleListDto> contentList = new List<RoleListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<RoleListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.RoleFilterRoleListError, "No more role");
                }
                else
                {
                    result.roleListDtos = new List<RoleListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.roleListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.RoleFilterRoleListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<RoleListDto> GetRole(long id)
        {
            var response = new BusinessLayerResult<RoleListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<RoleListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.RoleGetRoleNotFoundExceptionError, "Role was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.RoleGetRoleExceptionError, ex.Message);
            }
            return response;
        }





    }
}
