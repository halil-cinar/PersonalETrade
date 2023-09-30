using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.Country;
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
    public class CountryManager:ManagerBase<CountryEntity>
    {
        public CountryManager(string userName, string ıpAddress, BaseEntityValidator<CountryEntity> validator, IMapper mapper, IEntityDal<CountryEntity> repository) : base(userName, ıpAddress, validator, mapper, repository)
        {
        }

        public BusinessLayerResult<CountryListDto> AddCountry(CountryDto countryDto)
        {
            var response = new BusinessLayerResult<CountryListDto>();
            try
            {
                var entity = new CountryEntity
                {
                    Code= countryDto.Code,
                    Title= countryDto.Title,
                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    IsDeleted = false,
                    LastTransaction = "Country has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<CountryListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.CountryAddCountryValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CountryAddCountryExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<CountryListDto> UpdateCountry(CountryDto countryDto)
        {
            var response = new BusinessLayerResult<CountryListDto>();

            try
            {
                var entity = GetById(countryDto.Id);
                if (entity != null)
                {
                    entity.Code = countryDto.Code;
                    entity.Title = countryDto.Title;


                    entity.IsDeleted = false;
                    entity.LastTransaction = "Country Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<CountryListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.CountryUpdateCountryValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CountryUpdateCountryExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<CountryListDto> DeleteCountry(long countryId)
        {
            var response = new BusinessLayerResult<CountryListDto>();
            try
            {
                var entity = GetById(countryId);
                entity.IsDeleted = true;
                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CountryDeleteCountryExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<CountryListDto>> Filter(CountryFilter countryFilter)
        {
            var response = new BusinessLayerResult<List<CountryListDto>>();
            try
            {
                var query = "select * from Country where isDeleted=0 and ";

                if (countryFilter != null)
                {
                    
                    if (!string.IsNullOrEmpty(countryFilter.Code))
                    {
                        query += $"code like '%{countryFilter.Code}%' and ";
                    }
                    if (!string.IsNullOrEmpty(countryFilter.Title!))
                    {
                        query += $"title like '%{countryFilter.Title}%' and ";
                    }
                    

                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<CountryListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CountryFilterCountryExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<CountryLoadMoreDto> FilterCountryList(BaseLoadMoreFilter<CountryFilter> filter)
        {
            var response = new BusinessLayerResult<CountryLoadMoreDto>();
            try
            {
                var result = new CountryLoadMoreDto();
                List<CountryListDto> contentList = new List<CountryListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<CountryListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.CountryFilterCountryListError, "No more country");
                }
                else
                {
                    result.CountryListDtos = new List<CountryListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.CountryListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CountryFilterCountryListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<CountryListDto> GetCountry(long id)
        {
            var response = new BusinessLayerResult<CountryListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<CountryListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.CountryGetCountryNotFoundExceptionError, "Country was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CountryGetCountryExceptionError, ex.Message);
            }
            return response;
        }

    }
}
