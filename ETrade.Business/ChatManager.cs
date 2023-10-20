using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.Chat;
using ETrade.Dto.Errors;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ETrade.Business
{
    public class ChatManager:ManagerBase<ChatEntity>,IChatService
    {
        private readonly IMediaService _mediaManager;
        public ChatManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
            _mediaManager = new MediaManager(userName, ıpAddress);
        }
        public BusinessLayerResult<ChatListDto> AddChat(ChatDto chatDto)
        {
            var response = new BusinessLayerResult<ChatListDto>();
            using (var scope = new TransactionScope())
            {
                try
                {

                    long? imageId = chatDto.IconImageId;

                    if (imageId == null)
                    {
                        if (chatDto.IconImage == null)
                        {
                            //imageId is nullable in chat entity
                            //scope.Dispose();
                            //response.AddErrorMessages(ErrorMessageCode.ChatAddChatValidationError, "dto cannot be empty if id is null");
                            //return response;
                        }
                        else
                        {

                            var mediaResult = _mediaManager.AddMedia(chatDto.IconImage);

                            if (mediaResult.ErrorMessages.Count > 0)
                            {
                                scope.Dispose();
                                response.ErrorMessages.AddRange(mediaResult.ErrorMessages);
                                return response;
                            }
                            imageId = mediaResult.Result.Id;
                        }
                    }


                    var entity = new ChatEntity
                    {
                        IconImageId = (long)imageId,
                        Description = chatDto.Description,
                        isDeletable=true,
                        Name= chatDto.Name,
                        
                        CreateIPAddress = IpAddress,
                        CreateTime = DateTime.Now,
                        CreateUserName = UserName,
                        isDeleted = false,
                        LastTransaction = "Chat has been added"
                    };
                    var validationResult = Validator.Validate(entity);

                    if (validationResult.IsValid)
                    {

                        Add(entity);
                        response.Result = mapper.Map<ChatListDto>(entity);
                        scope.Complete();
                        scope.Dispose();

                    }
                    if (validationResult.Errors.Count > 0)
                    {
                        scope.Dispose();
                        foreach (var error in validationResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.ChatAddChatValidationError, error.ErrorMessage);
                        }

                    }

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.ChatAddChatExceptionError, ex.Message);
                }
            }
            return response;
        }

        public BusinessLayerResult<ChatListDto> UpdateChat(ChatDto chatDto)
        {
            var response = new BusinessLayerResult<ChatListDto>();
            using (var scope = new TransactionScope())
            {


                try
                {


                    long? imageId = chatDto.IconImageId;

                    if (imageId == null)
                    {
                        if (chatDto.IconImage == null)
                        {
                            //imageId is nullable in chat entity
                            //scope.Dispose();
                            //response.AddErrorMessages(ErrorMessageCode.ChatAddChatValidationError, "dto cannot be empty if id is null");
                            //return response;
                        }
                        else
                        {

                            var mediaResult = _mediaManager.AddMedia(chatDto.IconImage);

                            if (mediaResult.ErrorMessages.Count > 0)
                            {
                                scope.Dispose();
                                response.ErrorMessages.AddRange(mediaResult.ErrorMessages);
                                return response;
                            }
                            imageId = mediaResult.Result.Id;
                        }
                    }



                    var entity = GetById(chatDto.Id);
                    if (entity != null)
                    {
                        entity.IconImageId = (long)imageId;
                        
                        
                        entity.Description = chatDto.Description;
                        entity.Name = chatDto.Name;
                        entity.isDeleted = false;
                        entity.LastTransaction = "Chat Updated";
                        entity.UpdateIpAddress = IpAddress;
                        entity.UpdateTime = DateTime.Now;
                        entity.UpdateUserName = UserName;
                    }
                    var validatorResult = UpdateValidator.Validate(entity);

                    if (validatorResult.IsValid)
                    {
                        Update(entity);
                        response.Result = mapper.Map<ChatListDto>(entity);
                    }
                    if (validatorResult.Errors.Count > 0)
                    {
                        scope.Dispose();
                        foreach (var error in validatorResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.ChatUpdateChatValidationError, error.ErrorMessage);

                        }
                    }
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.ChatUpdateChatExceptionError, ex.Message);
                }
            }
            return response;
        }

        public BusinessLayerResult<ChatListDto> DeleteChat(long chatId)
        {
            var response = new BusinessLayerResult<ChatListDto>();
            try
            {
                var entity = GetById(chatId);
                entity.isDeleted = true;
                Update(entity);
                response.Result = mapper.Map<ChatListDto>(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ChatDeleteChatExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<ChatListDto>> Filter(ChatFilter chatFilter)
        {
            var response = new BusinessLayerResult<List<ChatListDto>>();
            try
            {
                var query = "select * from Chat where isDeleted=0 and ";

                if (chatFilter != null)
                {
                    if (!string.IsNullOrEmpty(chatFilter.Description))
                    {
                        query += $"description like '%{chatFilter.Description}%' and ";
                    }
                    if (!string.IsNullOrEmpty(chatFilter.Name))
                    {
                        query += $"name like '%{chatFilter.Name}%' and ";
                    }
                   
                   


                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<ChatListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ChatFilterChatExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<ChatLoadMoreDto> FilterChatList(BaseLoadMoreFilter<ChatFilter> filter)
        {
            var response = new BusinessLayerResult<ChatLoadMoreDto>();
            try
            {
                var result = new ChatLoadMoreDto();
                List<ChatListDto> contentList = new List<ChatListDto>();

                var filterResult = Filter(filter.Filter);
                if (filterResult.ErrorMessages.Count > 0)
                {
                    response.ErrorMessages.AddRange(filterResult.ErrorMessages.ToList());
                }
                else
                {
                    contentList = filterResult.Result;
                }



                var contentCount = contentList.Count;
                var firstIndex = filter.PageCount * filter.ContentCount;
                var lastIndex = firstIndex + filter.ContentCount;

                if (contentCount <= firstIndex)
                {
                    response.AddErrorMessages(ErrorMessageCode.ChatFilterChatListError, "No more chat");
                }
                else
                {
                    result.ChatListDtos = new List<ChatListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i >= contentCount)
                        {
                            break;
                        }
                        result.ChatListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ChatFilterChatListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<ChatListDto> GetChat(long chatId)
        {
            var response = new BusinessLayerResult<ChatListDto>();
            try
            {
                var entity = GetById(chatId);
                response.Result = mapper.Map<ChatListDto>(entity);
                // response.Result.Country = entity.Country;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ChatDeleteChatExceptionError, ex.Message);
            }
            return response;
        }


    }
}
