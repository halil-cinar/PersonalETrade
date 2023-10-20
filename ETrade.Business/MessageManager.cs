using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.Message;
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
using static System.Net.Mime.MediaTypeNames;

namespace ETrade.Business
{
    public class MessageManager:ManagerBase<MessageEntity>,IMessageService
    {
        private readonly IMediaService _mediaManager;
        private readonly IMessageMediaService _messageMediaService;
        public MessageManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
            _mediaManager = new MediaManager(userName, ıpAddress);
            _messageMediaService = new MessageMediaManager(userName, ıpAddress);
        }
        public BusinessLayerResult<MessageListDto> AddMessage(MessageDto messageDto)
        {
            var response = new BusinessLayerResult<MessageListDto>();
            using (var scope = new TransactionScope())
            {
                try
                {

                    var entity = new MessageEntity
                    {
                        AnsweredMessageId= messageDto.AnsweredMessageId,
                        ChatId= messageDto.ChatId,
                        IsContainsImages= messageDto.IsContainsImages,
                        isDeletable=true,
                        SendingTime= messageDto.SendingTime,
                        SentUserId= messageDto.SentUserId,
                        Message= messageDto.Message,
                        

                        CreateIPAddress = IpAddress,
                        CreateTime = DateTime.Now,
                        CreateUserName = UserName,
                        isDeleted = false,
                        LastTransaction = "Message has been added"
                    };
                    var validationResult = Validator.Validate(entity);

                    if (validationResult.IsValid)
                    {

                        Add(entity);
                        response.Result = mapper.Map<MessageListDto>(entity);
                        scope.Complete();
                        scope.Dispose();

                    }
                    if (validationResult.Errors.Count > 0)
                    {
                        scope.Dispose();
                        foreach (var error in validationResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.MessageAddMessageValidationError, error.ErrorMessage);
                        }

                    }


                    if (messageDto.IsContainsImages == true && messageDto.Medias != null && messageDto.Medias.Count() > 0)
                    {
                        foreach (var media in messageDto.Medias)
                        {
                            var mediaResult = _mediaManager.AddMedia(media);

                            if (mediaResult.ErrorMessages.Count > 0)
                            {
                                scope.Dispose();
                                response.ErrorMessages.AddRange(mediaResult.ErrorMessages);
                                return response;
                            }

                            //Todo: MessageMedia içerisine Descripton ataması için yontem bulunacak
                            var messageMediaResult = _messageMediaService.AddMessageMedia(new Dto.Dtos.MessageMedia.MessageMediaDto
                            {
                                MediaId = mediaResult.Result.Id,
                                MessageId = entity.ID,
                                Description = ""
                            });
                            if (messageMediaResult.ErrorMessages.Count > 0)
                            {
                                scope.Dispose();
                                response.ErrorMessages.AddRange(messageMediaResult.ErrorMessages);
                                return response;
                            }

                        }

                    }

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.MessageAddMessageExceptionError, ex.Message);
                }
            }
            return response;
        }

        public BusinessLayerResult<MessageListDto> UpdateMessage(MessageDto messageDto)
        {
            var response = new BusinessLayerResult<MessageListDto>();
            using (var scope = new TransactionScope())
            {

                try
                {
                    //Todo: Message güncelleme için media guncelleme eklenecek
                    var entity = GetById(messageDto.Id);
                    if (entity != null)
                    {
                        entity.AnsweredMessageId = messageDto.AnsweredMessageId;
                        entity.ChatId = messageDto.ChatId;
                        entity.IsContainsImages = messageDto.IsContainsImages;
                        entity.SendingTime = messageDto.SendingTime;
                        entity.SentUserId = messageDto.SentUserId;
                        entity.Message = messageDto.Message;
                        
                        entity.isDeleted = false;
                        entity.LastTransaction = "Message Updated";
                        entity.UpdateIpAddress = IpAddress;
                        entity.UpdateTime = DateTime.Now;
                        entity.UpdateUserName = UserName;
                    }
                    var validatorResult = UpdateValidator.Validate(entity);

                    if (validatorResult.IsValid)
                    {
                        Update(entity);
                        response.Result = mapper.Map<MessageListDto>(entity);
                    }
                    if (validatorResult.Errors.Count > 0)
                    {
                        scope.Dispose();
                        foreach (var error in validatorResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.MessageUpdateMessageValidationError, error.ErrorMessage);

                        }
                    }
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.MessageUpdateMessageExceptionError, ex.Message);
                }
            }
            return response;
        }

        public BusinessLayerResult<MessageListDto> DeleteMessage(long messageId)
        {
            var response = new BusinessLayerResult<MessageListDto>();
            try
            {
                var entity = GetById(messageId);
                entity.isDeleted = true;
                Update(entity);
                response.Result = mapper.Map<MessageListDto>(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MessageDeleteMessageExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<MessageListDto>> Filter(MessageFilter messageFilter)
        {
            var response = new BusinessLayerResult<List<MessageListDto>>();
            try
            {
                var query = "select * from Message where isDeleted=0 and ";

                if (messageFilter != null)
                {
                    if (!string.IsNullOrEmpty(messageFilter.Message))
                    {
                        query += $"message like '%{messageFilter.Message}%' and ";
                    }
                    if (messageFilter.IsContainsImages == true)
                    {
                        query += $"isContainsImages = {Convert.ToInt32(messageFilter.IsContainsImages)} and ";
                    }
                    if (messageFilter.AnsweredMessageId != null)
                    {
                        query += $"answeredMessageId = {messageFilter.AnsweredMessageId} and ";
                    }
                    if (messageFilter.ChatId != null)
                    {
                        query += $"chatId = {messageFilter.ChatId} and ";
                    }
                    if (messageFilter.SentUserId != null)
                    {
                        query += $"sentUserId = {messageFilter.SentUserId} and ";
                    }
                    if (messageFilter.MaxSendingTime != null)
                    {
                        query += $"sendingTime <= '{messageFilter.MaxSendingTime.Value.ToString("yyyy-MM-dd HH-mm-ss")}' and ";
                    }
                    if (messageFilter.MinSendingTime != null)
                    {
                        query += $"sendingTime >= '{messageFilter.MinSendingTime.Value.ToString("yyyy-MM-dd HH-mm-ss")}' and ";
                    }









                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<MessageListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MessageFilterMessageExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<MessageLoadMoreDto> FilterMessageList(BaseLoadMoreFilter<MessageFilter> filter)
        {
            var response = new BusinessLayerResult<MessageLoadMoreDto>();
            try
            {
                var result = new MessageLoadMoreDto();
                List<MessageListDto> contentList = new List<MessageListDto>();

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
                    response.AddErrorMessages(ErrorMessageCode.MessageFilterMessageListError, "No more message");
                }
                else
                {
                    result.MessageListDtos = new List<MessageListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i >= contentCount)
                        {
                            break;
                        }
                        result.MessageListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MessageFilterMessageListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<MessageListDto> GetMessage(long messageId)
        {
            var response = new BusinessLayerResult<MessageListDto>();
            try
            {
                var entity = GetById(messageId);
                response.Result = mapper.Map<MessageListDto>(entity);
                // response.Result.Country = entity.Country;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MessageDeleteMessageExceptionError, ex.Message);
            }
            return response;
        }

    }
}
