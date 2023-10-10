using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.Currency;
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
    public class CurrencyManager : ManagerBase<CurrencyEntity>,ICurrencyService
    {
        public CurrencyManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
        }

        public BusinessLayerResult<CurrencyListDto> AddCurrency(CurrencyDto currencyDto)
        {
            var response = new BusinessLayerResult<CurrencyListDto>();
            try
            {
                var entity = new CurrencyEntity
                {
                    Code=currencyDto.Code,
                    Symbol=currencyDto.Symbol,
                    Title = currencyDto.Title,
                   
                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    IsDeleted = false,
                    LastTransaction = "Currency has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<CurrencyListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.CurrencyAddCurrencyValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CurrencyAddCurrencyExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<CurrencyListDto> UpdateCurrency(CurrencyDto currencyDto)
        {
            var response = new BusinessLayerResult<CurrencyListDto>();

            try
            {
                var entity = GetById(currencyDto.Id);
                if (entity != null)
                {
                    
                    entity.Title = currencyDto.Title;
                    entity.Code = currencyDto.Code;
                    entity.Symbol= currencyDto.Symbol;

                    entity.IsDeleted = false;
                    entity.LastTransaction = "Currency Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<CurrencyListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.CurrencyUpdateCurrencyValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CurrencyUpdateCurrencyExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<CurrencyListDto> DeleteCurrency(long currencyId)
        {
            var response = new BusinessLayerResult<CurrencyListDto>();
            try
            {
                var entity = GetById(currencyId);
                entity.IsDeleted = true;
                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CurrencyDeleteCurrencyExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<CurrencyListDto>> Filter(CurrencyFilter currencyFilter)
        {
            var response = new BusinessLayerResult<List<CurrencyListDto>>();
            try
            {
                var query = "select * from Currency where isDeleted=0 and ";

                if (currencyFilter != null)
                {
                    
                    if (!string.IsNullOrEmpty(currencyFilter.Code))
                    {
                        query += $"code like '%{currencyFilter.Code}%' and ";
                    }
                    if (!string.IsNullOrEmpty(currencyFilter.Title))
                    {
                        query += $"title like '%{currencyFilter.Title}%' and ";
                    }
                    if (!string.IsNullOrEmpty(currencyFilter.Symbol))
                    {
                        query += $"symbol like '%{currencyFilter.Symbol}%' and ";
                    }

                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<CurrencyListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CurrencyFilterCurrencyExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<CurrencyLoadMoreDto> FilterCurrencyList(BaseLoadMoreFilter<CurrencyFilter> filter)
        {
            var response = new BusinessLayerResult<CurrencyLoadMoreDto>();
            try
            {
                var result = new CurrencyLoadMoreDto();
                List<CurrencyListDto> contentList = new List<CurrencyListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<CurrencyListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.CurrencyFilterCurrencyListError, "No more currency");
                }
                else
                {
                    result.currencyListDtos = new List<CurrencyListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.currencyListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CurrencyFilterCurrencyListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<CurrencyListDto> GetCurrency(long id)
        {
            var response = new BusinessLayerResult<CurrencyListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<CurrencyListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.CurrencyGetCurrencyNotFoundExceptionError, "Currency was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CurrencyGetCurrencyExceptionError, ex.Message);
            }
            return response;
        }

    }
}
