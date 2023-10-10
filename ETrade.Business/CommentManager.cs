using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.Comment;
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
    public class CommentManager:ManagerBase<CommentEntity>,ICommentService
    {
        public CommentManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
        }

        public BusinessLayerResult<CommentListDto> AddComment(CommentDto commentDto)
        {
            var response = new BusinessLayerResult<CommentListDto>();
            try
            {
                var entity = new CommentEntity
                {
                    Text= commentDto.Text,
                    CommentDate= commentDto.CommentDate,
                    Title= commentDto.Title,
                    UserId= commentDto.UserId,
                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress=IpAddress,
                    IsDeleted = false,
                    LastTransaction = "Comment has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<CommentListDto>(entity);        
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.CommentAddCommentValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CommentAddCommentExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<CommentListDto> UpdateComment(CommentDto commentDto)
        {
            var response = new BusinessLayerResult<CommentListDto>();

            try
            {
                var entity = GetById(commentDto.Id);
                if (entity != null)
                {
                    entity.Text = commentDto.Text;
                    entity.CommentDate = commentDto.CommentDate;
                    entity.UserId= commentDto.UserId;
                    entity.Title = commentDto.Title;


                    entity.IsDeleted = false;
                    entity.LastTransaction = "Comment Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<CommentListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.CommentUpdateCommentValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CommentUpdateCommentExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<CommentListDto> DeleteComment(long commentId)
        {
            var response = new BusinessLayerResult<CommentListDto>();
            try
            {
                var entity = GetById(commentId);
                entity.IsDeleted = true;
                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CommentDeleteCommentExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<CommentListDto>> Filter(CommentFilter commentFilter)
        {
            var response = new BusinessLayerResult<List<CommentListDto>>();
            try
            {
                var query = "select * from Comment where isDeleted=0 and ";

                if (commentFilter != null)
                {
                    if (commentFilter.UserId != null)
                    {
                        query += $"userId= {commentFilter.UserId} and ";
                    }
                    if (!string.IsNullOrEmpty(commentFilter.Text))
                    {
                        query += $"text like '%{commentFilter.Text}%' and ";
                    }
                    if (!string.IsNullOrEmpty(commentFilter.Title!))
                    {
                        query += $"title like '%{commentFilter.Title}%' and ";
                    }
                    if (commentFilter.FirstDate != null)
                    {
                        query += $"commentDate > '{commentFilter.FirstDate}' and ";
                    }
                    if (commentFilter.LastDate != null)
                    {
                        query += $"commentDate < '{commentFilter.LastDate}' and ";
                    }

                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<CommentListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CommentFilterCommentExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<CommentLoadMoreDto> FilterCommentList(BaseLoadMoreFilter<CommentFilter> filter)
        {
            var response = new BusinessLayerResult<CommentLoadMoreDto>();
            try
            {
                var result = new CommentLoadMoreDto();
                List<CommentListDto> contentList = new List<CommentListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<CommentListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.CommentFilterCommentListError, "No more comment");
                }
                else
                {
                    result.commentListDtos = new List<CommentListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.commentListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CommentFilterCommentListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<CommentListDto> GetComment(long id)
        {
            var response= new BusinessLayerResult<CommentListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result=mapper.Map<CommentListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.CommentGetCommentNotFoundExceptionError, "Comment was not found.");
                }
            }catch(Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CommentGetCommentExceptionError,ex.Message);
            }
            return response;
        }


    }
}
