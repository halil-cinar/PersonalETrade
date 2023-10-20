using FluentValidation;
using Newtonsoft.Json.Linq;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.SystemSettings;
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
    public class SystemSettingsManager:ManagerBase<SystemSettingsEntity>,ISystemSettingsService
    {
        public SystemSettingsManager(string userName, string ýpAddress) : base(userName, ýpAddress)
        {
        }

        public BusinessLayerResult<SystemSettingsListDto> AddSystemSettings(SystemSettingsDto systemsettingsDto)
        {
            var response = new BusinessLayerResult<SystemSettingsListDto>();
            try
            {
                var entity = new SystemSettingsEntity
                {
                      
                   
                   



                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "SystemSettings has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<SystemSettingsListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.SystemSettingsAddSystemSettingsValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SystemSettingsAddSystemSettingsExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SystemSettingsListDto> UpdateSystemSettings(SystemSettingsDto systemsettingsDto)
        {
            var response = new BusinessLayerResult<SystemSettingsListDto>();

            try
            {
                var entity = GetById(systemsettingsDto.Id);
                if (entity != null)
                {
                    


                    entity.isDeleted = false;
                    entity.LastTransaction = "SystemSettings Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<SystemSettingsListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.SystemSettingsUpdateSystemSettingsValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SystemSettingsUpdateSystemSettingsExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SystemSettingsListDto> DeleteSystemSettings(long systemsettingsId)
        {
            var response = new BusinessLayerResult<SystemSettingsListDto>();
            try
            {
                var entity = GetById(systemsettingsId);
                entity.isDeleted = true;

                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SystemSettingsDeleteSystemSettingsExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<SystemSettingsListDto>> Filter(SystemSettingsFilter systemsettingsFilter)
        {
            var response = new BusinessLayerResult<List<SystemSettingsListDto>>();
            try
            {
                var query = "select * from SystemSettings where isDeleted=0 and ";

                if (systemsettingsFilter != null)
                {


                    //if (systemsettingsFilter.IsActive != null)
                    //{
                    //    query += $"isActive = {systemsettingsFilter.IsActive} and ";
                    //}
                    //if (systemsettingsFilter.MaxExpiryDate != null)
                    //{
                    //    query += $"expiryDate = {systemsettingsFilter.MaxExpiryDate} and ";
                    //}
                    //if (systemsettingsFilter.MinExpiryDate != null)
                    //{
                    //    query += $"expiryDate = {systemsettingsFilter.MinExpiryDate} and ";
                    //}
                    //if (systemsettingsFilter.SystemSettingsType != null)
                    //{
                    //    query += $"systemsettingsType = {systemsettingsFilter.SystemSettingsType} and ";
                    //}
                    //if (systemsettingsFilter.UserId != null)
                    //{
                    //    query += $"userId = {systemsettingsFilter.UserId} and ";
                    //}
                    //if (systemsettingsFilter.MinExpiryDate != null)
                    //{
                    //    query += $"secondUserId = {systemsettingsFilter.MinExpiryDate} and ";







                    
                    if (query.EndsWith(" and "))
                    {
                        query = query.Substring(0, query.Length - " and ".Length);
                    }

                    response.Result = GetAll(query).Select(x => mapper.Map<SystemSettingsListDto>(x)).ToList();


                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SystemSettingsFilterSystemSettingsExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<SystemSettingsLoadMoreDto> FilterSystemSettingsList(BaseLoadMoreFilter<SystemSettingsFilter> filter)
        {
            var response = new BusinessLayerResult<SystemSettingsLoadMoreDto>();
            try
            {
                var result = new SystemSettingsLoadMoreDto();
                List<SystemSettingsListDto> contentList = new List<SystemSettingsListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<SystemSettingsListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.SystemSettingsFilterSystemSettingsListError, "No more systemsettings");
                }
                else
                {
                    result.SystemSettingsListDtos = new List<SystemSettingsListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.SystemSettingsListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SystemSettingsFilterSystemSettingsListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SystemSettingsListDto> GetSystemSettings(long id)
        {
            var response = new BusinessLayerResult<SystemSettingsListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<SystemSettingsListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.SystemSettingsGetSystemSettingsNotFoundExceptionError, "SystemSettings was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SystemSettingsGetSystemSettingsExceptionError, ex.Message);
            }
            return response;
        }

       
    }
}


