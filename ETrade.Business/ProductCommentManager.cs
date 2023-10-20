using FluentValidation;
using Newtonsoft.Json.Linq;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.ProductComment;
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
    public class ProductCommentManager:ManagerBase<ProductCommentEntity>,IProductCommentService
    {
        public ProductCommentManager(string userName, string ýpAddress) : base(userName, ýpAddress)
        {
        }

        public BusinessLayerResult<ProductCommentListDto> AddProductComment(ProductCommentDto productcommentDto)
        {
            var response = new BusinessLayerResult<ProductCommentListDto>();
            try
            {
                var entity = new ProductCommentEntity
                {
                  IsActive= productcommentDto.IsActive,
                  ProductId= productcommentDto.ProductId,
                  CommentId= productcommentDto.CommentId,
                  isDeletable=true,
                  
                   
                   



                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "ProductComment has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<ProductCommentListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.ProductCommentAddProductCommentValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductCommentAddProductCommentExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<ProductCommentListDto> UpdateProductComment(ProductCommentDto productcommentDto)
        {
            var response = new BusinessLayerResult<ProductCommentListDto>();

            try
            {
                var entity = GetById(productcommentDto.Id);
                if (entity != null)
                {
                    entity. IsActive= productcommentDto.IsActive;
                    entity. ProductId= productcommentDto.ProductId;
                    entity. CommentId= productcommentDto.CommentId;
                    entity.isDeletable = true;
                    
                    


                    entity.isDeleted = false;
                    entity.LastTransaction = "ProductComment Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<ProductCommentListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.ProductCommentUpdateProductCommentValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductCommentUpdateProductCommentExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<ProductCommentListDto> DeleteProductComment(long productcommentId)
        {
            var response = new BusinessLayerResult<ProductCommentListDto>();
            try
            {
                var entity = GetById(productcommentId);
                entity.isDeleted = true;

                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductCommentDeleteProductCommentExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<ProductCommentListDto>> Filter(ProductCommentFilter productcommentFilter)
        {
            var response = new BusinessLayerResult<List<ProductCommentListDto>>();
            try
            {
                var query = "select * from ProductComment where isDeleted=0 and ";

                if (productcommentFilter != null)
                {


                    if (productcommentFilter.IsActive != null)
                    {
                        query += $"isActive = {productcommentFilter.IsActive} and ";
                    }
                    if (productcommentFilter.ProductId != null)
                    {
                        query += $"productId = {productcommentFilter.ProductId} and ";
                    }
                    if (productcommentFilter.CommentId != null)
                    {
                        query += $"commentId = {productcommentFilter.CommentId} and ";
                    }



                    if (query.EndsWith(" and "))
                    {
                        query = query.Substring(0, query.Length - " and ".Length);
                    }

                    response.Result = GetAll(query).Select(x => mapper.Map<ProductCommentListDto>(x)).ToList();


                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductCommentFilterProductCommentExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<ProductCommentLoadMoreDto> FilterProductCommentList(BaseLoadMoreFilter<ProductCommentFilter> filter)
        {
            var response = new BusinessLayerResult<ProductCommentLoadMoreDto>();
            try
            {
                var result = new ProductCommentLoadMoreDto();
                List<ProductCommentListDto> contentList = new List<ProductCommentListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<ProductCommentListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.ProductCommentFilterProductCommentListError, "No more productcomment");
                }
                else
                {
                    result.ProductCommentListDtos = new List<ProductCommentListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.ProductCommentListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductCommentFilterProductCommentListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<ProductCommentListDto> GetProductComment(long id)
        {
            var response = new BusinessLayerResult<ProductCommentListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<ProductCommentListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.ProductCommentGetProductCommentNotFoundExceptionError, "ProductComment was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductCommentGetProductCommentExceptionError, ex.Message);
            }
            return response;
        }

        
    }
}


