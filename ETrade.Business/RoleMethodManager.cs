using FluentValidation;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.RoleMethod;
using ETrade.Dto.Errors;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.DataAccess.EntityFrameworkCore;

namespace ETrade.Business
{
    public class RoleMethodManager : ManagerBase<RoleMethodEntity>, IRoleMethodService
    {
        public RoleMethodManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
        }

        public BusinessLayerResult<RoleMethodListDto> AddRoleMethod(RoleMethodDto roleMethodDto)
        {
            var response = new BusinessLayerResult<RoleMethodListDto>();
            try
            {
                var entity = new RoleMethodEntity
                {
                    ExpiryDate= null,
                    MethodId=roleMethodDto.MethodId,
                    RoleId=roleMethodDto.RoleId,
                    
                    



                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "RoleMethod has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<RoleMethodListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.RoleMethodAddRoleMethodValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.RoleMethodAddRoleMethodExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<RoleMethodListDto> UpdateRoleMethod(RoleMethodDto roleMethodDto)
        {
            var response = new BusinessLayerResult<RoleMethodListDto>();

            try
            {
                var entity = GetById(roleMethodDto.Id);
                if (entity != null)
                {
                    entity.ExpiryDate= null;
                    entity.MethodId=roleMethodDto.MethodId;
                    entity.RoleId = roleMethodDto.RoleId;



                    entity.isDeleted = false;
                    entity.LastTransaction = "RoleMethod Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<RoleMethodListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.RoleMethodUpdateRoleMethodValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.RoleMethodUpdateRoleMethodExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<RoleMethodListDto> DeleteRoleMethod(long roleMethodId)
        {
            var response = new BusinessLayerResult<RoleMethodListDto>();
            try
            {
                var entity = GetById(roleMethodId);
                entity.isDeleted = true;

                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.RoleMethodDeleteRoleMethodExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<RoleMethodListDto>> Filter(RoleMethodFilter roleMethodFilter)
        {
            var response = new BusinessLayerResult<List<RoleMethodListDto>>();
            try
            {
                var query = "select * from RoleMethodListView where isDeleted=0 and ";

                if (roleMethodFilter != null)
                {


                    if (roleMethodFilter.MethodIds != null)
                    {
                        query += $"methodId in ({string.Join(",",roleMethodFilter.MethodIds)}) and ";
                    }
                    if (roleMethodFilter.RoleIds != null)
                    {
                        query += $"roleId in ({string.Join(",",roleMethodFilter.RoleIds)}) and ";
                    }



                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }
                using(var db=new DatabaseContext())
                {
                    response.Result = db.RoleMethodLists.SqlQuery(query).Select(x => mapper.Map<RoleMethodListDto>(x)).ToList();
                }

                


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.RoleMethodFilterRoleMethodExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<RoleMethodLoadMoreDto> FilterRoleMethodList(BaseLoadMoreFilter<RoleMethodFilter> filter)
        {
            var response = new BusinessLayerResult<RoleMethodLoadMoreDto>();
            try
            {
                var result = new RoleMethodLoadMoreDto();
                List<RoleMethodListDto> contentList = new List<RoleMethodListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<RoleMethodListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.RoleMethodFilterRoleMethodListError, "No more roleMethod");
                }
                else
                {
                    result.RoleMethodListDtos = new List<RoleMethodListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.RoleMethodListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.RoleMethodFilterRoleMethodListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<RoleMethodListDto> GetRoleMethod(long id)
        {
            var response = new BusinessLayerResult<RoleMethodListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<RoleMethodListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.RoleMethodGetRoleMethodNotFoundExceptionError, "RoleMethod was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.RoleMethodGetRoleMethodExceptionError, ex.Message);
            }
            return response;
        }


    }
}
