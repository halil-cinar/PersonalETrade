using FluentValidation;
using Newtonsoft.Json.Linq;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.UserSettings;
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
    public class UserSettingsManager:ManagerBase<UserSettingsEntity>,IUserSettingsService
    {
        public UserSettingsManager(string userName, string ýpAddress) : base(userName, ýpAddress)
        {
        }

        public BusinessLayerResult<UserSettingsListDto> AddUserSettings(UserSettingsDto usersettingsDto)
        {
            var response = new BusinessLayerResult<UserSettingsListDto>();
            try
            {
                var entity = new UserSettingsEntity
                {
                  isDeletable= true,
                  SettingId= usersettingsDto.SettingId,
                  Value= usersettingsDto.Value,
                  UserId= usersettingsDto.UserId,    
                   
                   



                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "UserSettings has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<UserSettingsListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.UserSettingsAddUserSettingsValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserSettingsAddUserSettingsExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserSettingsListDto> UpdateUserSettings(UserSettingsDto usersettingsDto)
        {
            var response = new BusinessLayerResult<UserSettingsListDto>();

            try
            {
                var entity = GetById(usersettingsDto.Id);
                if (entity != null)
                {
                    entity.SettingId= usersettingsDto.SettingId;
                    entity.Value= usersettingsDto.Value;
                    entity.UserId = usersettingsDto.UserId;
                    


                    entity.isDeleted = false;
                    entity.LastTransaction = "UserSettings Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<UserSettingsListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.UserSettingsUpdateUserSettingsValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserSettingsUpdateUserSettingsExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserSettingsListDto> DeleteUserSettings(long usersettingsId)
        {
            var response = new BusinessLayerResult<UserSettingsListDto>();
            try
            {
                var entity = GetById(usersettingsId);
                entity.isDeleted = true;

                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserSettingsDeleteUserSettingsExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<UserSettingsListDto>> Filter(UserSettingsFilter usersettingsFilter)
        {
            var response = new BusinessLayerResult<List<UserSettingsListDto>>();
            try
            {
                var query = "select * from UserSettings where isDeleted=0 and ";

                if (usersettingsFilter != null)
                {


                    if (usersettingsFilter.SettingId != null)
                    {
                        query += $"settingId = {usersettingsFilter.SettingId} and ";
                    }
                    if (usersettingsFilter.UserId != null)
                    {
                        query += $"userId = {usersettingsFilter.UserId} and ";
                    }




                    if (query.EndsWith(" and "))
                    {
                        query = query.Substring(0, query.Length - " and ".Length);
                    }

                    response.Result = GetAll(query).Select(x => mapper.Map<UserSettingsListDto>(x)).ToList();


                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserSettingsFilterUserSettingsExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<UserSettingsLoadMoreDto> FilterUserSettingsList(BaseLoadMoreFilter<UserSettingsFilter> filter)
        {
            var response = new BusinessLayerResult<UserSettingsLoadMoreDto>();
            try
            {
                var result = new UserSettingsLoadMoreDto();
                List<UserSettingsListDto> contentList = new List<UserSettingsListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<UserSettingsListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.UserSettingsFilterUserSettingsListError, "No more usersettings");
                }
                else
                {
                    result.UserSettingsListDtos = new List<UserSettingsListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.UserSettingsListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserSettingsFilterUserSettingsListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserSettingsListDto> GetUserSettings(long id)
        {
            var response = new BusinessLayerResult<UserSettingsListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<UserSettingsListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.UserSettingsGetUserSettingsNotFoundExceptionError, "UserSettings was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserSettingsGetUserSettingsExceptionError, ex.Message);
            }
            return response;
        }

      
    }
}


