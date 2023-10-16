using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.Media;
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
    public class MediaManager : ManagerBase<MediaEntity>,IMediaService
    {
        public MediaManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
        }

        public BusinessLayerResult<MediaListDto> AddMedia(MediaDto mediaDto)
        {
            var response = new BusinessLayerResult<MediaListDto>();
            try
            {
                var entity = new MediaEntity
                {
                    Content=mediaDto.Content,
                    EntityId=mediaDto.EntityId,
                    EntityType=mediaDto.EntityType,
                    FileName=mediaDto.FileName,
                    FileType=mediaDto.FileType,
                    
                    CreateIPAddress=IpAddress,
                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    isDeleted = false,
                    LastTransaction = "Media has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<MediaListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.MediaAddMediaValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MediaAddMediaExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<MediaListDto> UpdateMedia(MediaDto mediaDto)
        {
            var response = new BusinessLayerResult<MediaListDto>();

            try
            {
                var entity = GetById(mediaDto.Id);
                if (entity != null)
                {
                    entity.Content = mediaDto.Content;
                    entity.EntityId = mediaDto.EntityId;
                    entity.EntityType = mediaDto.EntityType;   
                    entity.FileName = mediaDto.FileName;
                    entity.FileType = mediaDto.FileType;

                    entity.isDeleted = false;
                    entity.LastTransaction = "Media Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<MediaListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.MediaUpdateMediaValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MediaUpdateMediaExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<MediaListDto> DeleteMedia(long mediaId)
        {
            var response = new BusinessLayerResult<MediaListDto>();
            try
            {
                var entity = GetById(mediaId);
                entity.isDeleted = true;
                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MediaDeleteMediaExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<MediaListDto>> Filter(MediaFilter mediaFilter)
        {
            var response = new BusinessLayerResult<List<MediaListDto>>();
            try
            {
                var query = "select * from Media where isDeleted=0 and ";

                if (mediaFilter != null)
                {
                    if (mediaFilter.FileType != null)
                    {
                        query += $"fileType= {mediaFilter.FileType} and ";
                    }
                    if (mediaFilter.EntityType != null)
                    {
                        query += $"entityType= {mediaFilter.EntityType} and ";
                    }

                    if (!string.IsNullOrEmpty(mediaFilter.FileName))
                    {
                        query += $"fileName like '%{mediaFilter.FileName}%' and ";
                    }
                   

                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<MediaListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MediaFilterMediaExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<MediaLoadMoreDto> FilterMediaList(BaseLoadMoreFilter<MediaFilter> filter)
        {
            var response = new BusinessLayerResult<MediaLoadMoreDto>();
            try
            {
                var result = new MediaLoadMoreDto();
                List<MediaListDto> contentList = new List<MediaListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<MediaListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.MediaFilterMediaListError, "No more media");
                }
                else
                {
                    result.mediaListDtos = new List<MediaListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.mediaListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MediaFilterMediaListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<MediaListDto> GetMedia(long id)
        {
            var response = new BusinessLayerResult<MediaListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<MediaListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.MediaGetMediaNotFoundExceptionError, "Media was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.MediaGetMediaExceptionError, ex.Message);
            }
            return response;
        }


    }
}
