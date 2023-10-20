using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.MessageMedia;
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

namespace ETrade.Business
{
    public class MessageMediaManager : ManagerBase<MessageMediaEntity>, IMessageMediaService
    {
        public MessageMediaManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
        }


        public BusinessLayerResult<MessageMediaListDto> AddMessageMedia(MessageMediaDto messageMediaDto)
        {
            var response = new BusinessLayerResult<MessageMediaListDto>();
            try
            {
                var entity = new MessageMediaEntity
                {
                    Description= messageMediaDto.Description,
                    MediaId= messageMediaDto.MediaId,
                    MessageId= messageMediaDto.MessageId,
                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "MessageMedia has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<MessageMediaListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.MessageMediaAddMessageMediaValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MessageMediaAddMessageMediaExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<MessageMediaListDto> UpdateMessageMedia(MessageMediaDto messageMediaDto)
        {
            var response = new BusinessLayerResult<MessageMediaListDto>();

            try
            {
                var entity = GetById(messageMediaDto.Id);
                if (entity != null)
                {
                    entity.Description= messageMediaDto.Description;
                    entity.MediaId= messageMediaDto.MediaId;
                    entity.MessageId = messageMediaDto.MessageId;


                    entity.isDeleted = false;
                    entity.LastTransaction = "MessageMedia Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<MessageMediaListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.MessageMediaUpdateMessageMediaValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MessageMediaUpdateMessageMediaExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<MessageMediaListDto> DeleteMessageMedia(long messageMediaId)
        {
            var response = new BusinessLayerResult<MessageMediaListDto>();
            try
            {
                var entity = GetById(messageMediaId);
                entity.isDeleted = true;
                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MessageMediaDeleteMessageMediaExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<MessageMediaListDto>> Filter(MessageMediaFilter messageMediaFilter)
        {
            var response = new BusinessLayerResult<List<MessageMediaListDto>>();
            try
            {
                var query = "select * from MessageMedia where isDeleted=0 and ";

                if (messageMediaFilter != null)
                {
                    if (messageMediaFilter.MediaId != null)
                    {
                        query += $"mediaId= {messageMediaFilter.MediaId} and ";
                    }
                    if (messageMediaFilter.MessageId != null)
                    {
                        query += $"messageId= {messageMediaFilter.MessageId} and ";
                    }

                    if (!string.IsNullOrEmpty(messageMediaFilter.Description))
                    {
                        query += $"description like '%{messageMediaFilter.Description}%' and ";
                    }
                   
                   

                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<MessageMediaListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MessageMediaFilterMessageMediaExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<MessageMediaLoadMoreDto> FilterMessageMediaList(BaseLoadMoreFilter<MessageMediaFilter> filter)
        {
            var response = new BusinessLayerResult<MessageMediaLoadMoreDto>();
            try
            {
                var result = new MessageMediaLoadMoreDto();
                List<MessageMediaListDto> contentList = new List<MessageMediaListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<MessageMediaListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.MessageMediaFilterMessageMediaListError, "No more messageMedia");
                }
                else
                {
                    result.MessageMediaListDtos = new List<MessageMediaListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.MessageMediaListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MessageMediaFilterMessageMediaListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<MessageMediaListDto> GetMessageMedia(long id)
        {
            var response = new BusinessLayerResult<MessageMediaListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<MessageMediaListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.MessageMediaGetMessageMediaNotFoundExceptionError, "MessageMedia was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MessageMediaGetMessageMediaExceptionError, ex.Message);
            }
            return response;
        }
    }
}
