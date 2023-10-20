using FluentValidation;
using Newtonsoft.Json.Linq;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.Settings;
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
    public class SettingsManager:ManagerBase<SettingsEntity>,ISettingsService
    {
        public SettingsManager(string userName, string ýpAddress) : base(userName, ýpAddress)
        {
        }

        public BusinessLayerResult<SettingsListDto> AddSettings(SettingsDto settingsDto)
        {
            var response = new BusinessLayerResult<SettingsListDto>();
            try
            {
                var entity = new SettingsEntity
                {
                   
                    isDeletable= true,
                    DefaultValue= settingsDto.DefaultValue,
                    Description= settingsDto.Description,   
                    Key=settingsDto.Key,
                   
                   



                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "Settings has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<SettingsListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.SettingsAddSettingsValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SettingsAddSettingsExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SettingsListDto> UpdateSettings(SettingsDto settingsDto)
        {
            var response = new BusinessLayerResult<SettingsListDto>();

            try
            {
                var entity = GetById(settingsDto.Id);
                if (entity != null)
                {
                    entity.DefaultValue= settingsDto.DefaultValue;
                    entity.Description= settingsDto.Description ;
                    entity.Key = settingsDto.Key;
                    
                    
                    


                    entity.isDeleted = false;
                    entity.LastTransaction = "Settings Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<SettingsListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.SettingsUpdateSettingsValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SettingsUpdateSettingsExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SettingsListDto> DeleteSettings(long settingsId)
        {
            var response = new BusinessLayerResult<SettingsListDto>();
            try
            {
                var entity = GetById(settingsId);
                entity.isDeleted = true;

                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SettingsDeleteSettingsExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<SettingsListDto>> Filter(SettingsFilter settingsFilter)
        {
            var response = new BusinessLayerResult<List<SettingsListDto>>();
            try
            {
                var query = "select * from Settings where isDeleted=0 and ";

                if (settingsFilter != null)
                {


                    if (string.IsNullOrEmpty(settingsFilter.Description))
                    {
                        query += $"description like '%{settingsFilter.Description}%' and ";
                    }
                    if (string.IsNullOrEmpty(settingsFilter.Key))
                    {
                        query += $"key like '%{settingsFilter.Key}%' and ";
                    }



                    if (query.EndsWith(" and "))
                    {
                        query = query.Substring(0, query.Length - " and ".Length);
                    }

                    response.Result = GetAll(query).Select(x => mapper.Map<SettingsListDto>(x)).ToList();


                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SettingsFilterSettingsExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<SettingsLoadMoreDto> FilterSettingsList(BaseLoadMoreFilter<SettingsFilter> filter)
        {
            var response = new BusinessLayerResult<SettingsLoadMoreDto>();
            try
            {
                var result = new SettingsLoadMoreDto();
                List<SettingsListDto> contentList = new List<SettingsListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<SettingsListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.SettingsFilterSettingsListError, "No more settings");
                }
                else
                {
                    result.SettingsListDtos = new List<SettingsListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.SettingsListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SettingsFilterSettingsListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SettingsListDto> GetSettings(long id)
        {
            var response = new BusinessLayerResult<SettingsListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<SettingsListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.SettingsGetSettingsNotFoundExceptionError, "Settings was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SettingsGetSettingsExceptionError, ex.Message);
            }
            return response;
        }

        
    }
}


