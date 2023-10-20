using FluentValidation;
using Newtonsoft.Json.Linq;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.UserChat;
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
    public class UserChatManager:ManagerBase<UserChatEntity>,IUserChatService
    {
        public UserChatManager(string userName, string ýpAddress) : base(userName, ýpAddress)
        {
        }

        public BusinessLayerResult<UserChatListDto> AddUserChat(UserChatDto userchatDto)
        {
            var response = new BusinessLayerResult<UserChatListDto>();
            try
            {
                var entity = new UserChatEntity
                {
                   isDeletable= true,
                   ChatId=userchatDto.ChatId,
                   DepartureDate=userchatDto.DepartureDate,
                   isActive=userchatDto.isActive,
                   IsSeller=userchatDto.IsSeller,
                   JoinDate=userchatDto.JoinDate,
                   UserId= userchatDto.UserId,    
                   
                   



                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "UserChat has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<UserChatListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.UserChatAddUserChatValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserChatAddUserChatExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserChatListDto> UpdateUserChat(UserChatDto userchatDto)
        {
            var response = new BusinessLayerResult<UserChatListDto>();

            try
            {
                var entity = GetById(userchatDto.Id);
                if (entity != null)
                {
                    entity.ChatId=userchatDto.ChatId;
                    entity.DepartureDate=userchatDto.DepartureDate;
                    entity.isActive=userchatDto.isActive;
                    entity.IsSeller=userchatDto.IsSeller;
                    entity.JoinDate=userchatDto.JoinDate;
                    entity.UserId = userchatDto.UserId;


                    entity.isDeleted = false;
                    entity.LastTransaction = "UserChat Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<UserChatListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.UserChatUpdateUserChatValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserChatUpdateUserChatExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserChatListDto> DeleteUserChat(long userchatId)
        {
            var response = new BusinessLayerResult<UserChatListDto>();
            try
            {
                var entity = GetById(userchatId);
                entity.isDeleted = true;

                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserChatDeleteUserChatExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<UserChatListDto>> Filter(UserChatFilter userchatFilter)
        {
            var response = new BusinessLayerResult<List<UserChatListDto>>();
            try
            {
                var query = "select * from UserChat where isDeleted=0 and ";

                if (userchatFilter != null)
                {


                    if (userchatFilter.UserId != null)
                    {
                        query += $"userId = {userchatFilter.UserId} and ";
                    }
                    if (userchatFilter.ChatId != null)
                    {
                        query += $"chatId = {userchatFilter.ChatId} and ";
                    }



                    if (query.EndsWith(" and "))
                    {
                        query = query.Substring(0, query.Length - " and ".Length);
                    }

                    response.Result = GetAll(query).Select(x => mapper.Map<UserChatListDto>(x)).ToList();


                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserChatFilterUserChatExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<UserChatLoadMoreDto> FilterUserChatList(BaseLoadMoreFilter<UserChatFilter> filter)
        {
            var response = new BusinessLayerResult<UserChatLoadMoreDto>();
            try
            {
                var result = new UserChatLoadMoreDto();
                List<UserChatListDto> contentList = new List<UserChatListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<UserChatListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.UserChatFilterUserChatListError, "No more userchat");
                }
                else
                {
                    result.UserChatListDtos = new List<UserChatListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.UserChatListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserChatFilterUserChatListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserChatListDto> GetUserChat(long id)
        {
            var response = new BusinessLayerResult<UserChatListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<UserChatListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.UserChatGetUserChatNotFoundExceptionError, "UserChat was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserChatGetUserChatExceptionError, ex.Message);
            }
            return response;
        }

       
    }
}


