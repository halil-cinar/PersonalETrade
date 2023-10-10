using FluentValidation;
 
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.Method;
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
using System.Xml.Linq;

namespace ETrade.Business
{
    public class MethodManager : ManagerBase<MethodEntity>,IMethodService
    {
        public MethodManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
        }

        public BusinessLayerResult<MethodListDto> AddMethod(MethodDto methodDto)
        {
            var response = new BusinessLayerResult<MethodListDto>();
            try
            {
                var entity = new MethodEntity
                {
                    Description= methodDto.Description,
                    Key= methodDto.Key,
                    Name= methodDto.Name,
                    


                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    IsDeleted = false,
                    LastTransaction = "Method has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<MethodListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.MethodAddMethodValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MethodAddMethodExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<MethodListDto> UpdateMethod(MethodDto methodDto)
        {
            var response = new BusinessLayerResult<MethodListDto>();

            try
            {
                var entity = GetById(methodDto.Id);
                if (entity != null)
                {
                    entity.Description = methodDto.Description;
                    entity. Key = methodDto.Key;
                    entity.Name = methodDto.Name;



                    entity.IsDeleted = false;
                    entity.LastTransaction = "Method Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<MethodListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.MethodUpdateMethodValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MethodUpdateMethodExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<MethodListDto> DeleteMethod(long methodId)
        {
            var response = new BusinessLayerResult<MethodListDto>();
            try
            {
                var entity = GetById(methodId);
                entity.IsDeleted = true;

                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MethodDeleteMethodExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<MethodListDto>> Filter(MethodFilter methodFilter)
        {
            var response = new BusinessLayerResult<List<MethodListDto>>();
            try
            {
                var query = "select * from Method where isDeleted=0 and ";

                if (methodFilter != null)
                {

                    if (!string.IsNullOrEmpty(methodFilter.Description))
                    {
                        query += $"description like '%{methodFilter.Description}%' and ";
                    }
                    if (!string.IsNullOrEmpty(methodFilter.Name!))
                    {
                        query += $"name like '%{methodFilter.Name}%' and ";
                    }
                    if (methodFilter.Key != null)
                    {
                        query += $"key = {methodFilter.Key} and ";
                    }



                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<MethodListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MethodFilterMethodExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<MethodLoadMoreDto> FilterMethodList(BaseLoadMoreFilter<MethodFilter> filter)
        {
            var response = new BusinessLayerResult<MethodLoadMoreDto>();
            try
            {
                var result = new MethodLoadMoreDto();
                List<MethodListDto> contentList = new List<MethodListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<MethodListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.MethodFilterMethodListError, "No more method");
                }
                else
                {
                    result.MethodListDtos = new List<MethodListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.MethodListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MethodFilterMethodListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<MethodListDto> GetMethod(long id)
        {
            var response = new BusinessLayerResult<MethodListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<MethodListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.MethodGetMethodNotFoundExceptionError, "Method was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MethodGetMethodExceptionError, ex.Message);
            }
            return response;
        }
    }
}
