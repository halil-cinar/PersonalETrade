using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Errors;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Abstract;
using ETrade.Entities.Concrete;
using ETrade.Entities.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ETrade.Business
{
    public class CategoryManager:ManagerBase<CategoryEntity>,ICategoryService
    {
        private readonly IMediaService _mediaManager;
        public CategoryManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
            _mediaManager = new MediaManager(userName,ıpAddress);
        }
        public BusinessLayerResult<CategoryListDto> AddCategory(CategoryDto categoryDto)
        {
            var response = new BusinessLayerResult<CategoryListDto>();
            using (var scope = new TransactionScope())
            {
                try
                {

                    long? imageId = categoryDto.ImageId;

                    if (imageId == null)
                    {
                        if (categoryDto.ImageDto == null)
                        {
                            //imageId is nullable in category entity
                            //scope.Dispose();
                            //response.AddErrorMessages(ErrorMessageCode.CategoryAddCategoryValidationError, "dto cannot be empty if id is null");
                            //return response;
                        }
                        else
                        {

                            var mediaResult = _mediaManager.AddMedia(categoryDto.ImageDto);

                            if (mediaResult.ErrorMessages.Count > 0)
                            {
                                scope.Dispose();
                                response.ErrorMessages.AddRange(mediaResult.ErrorMessages);
                                return response;
                            }
                            imageId = mediaResult.Result.Id;
                        }
                    }


                    var entity = new CategoryEntity
                    {
                        ImageId = (long)imageId,
                        Description= categoryDto.Description,
                        Link= categoryDto.Link,
                        Title= categoryDto.Title,
                        TopCategoryId= categoryDto.TopCategoryId,
                        
                        CreateIPAddress = IpAddress,
                        CreateTime = DateTime.Now,
                        CreateUserName = UserName,
                        isDeleted = false,
                        LastTransaction = "Category has been added"
                    };
                    var validationResult = Validator.Validate(entity);

                    if (validationResult.IsValid)
                    {

                        Add(entity);
                        response.Result = mapper.Map<CategoryListDto>(entity);
                        scope.Complete();
                        scope.Dispose();

                    }
                    if (validationResult.Errors.Count > 0)
                    {
                        scope.Dispose();
                        foreach (var error in validationResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.CategoryAddCategoryValidationError, error.ErrorMessage);
                        }

                    }

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.CategoryAddCategoryExceptionError, ex.Message);
                }
            }
            return response;
        }

        public BusinessLayerResult<CategoryListDto> UpdateCategory(CategoryDto categoryDto)
        {
            var response = new BusinessLayerResult<CategoryListDto>();
            using (var scope = new TransactionScope())
            {


                try
                {


                    long? imageId = categoryDto.ImageId;

                    if (imageId == null)
                    {
                        if (categoryDto.ImageDto == null)
                        {
                            //imageId is nullable in category entity
                            //scope.Dispose();
                            //response.AddErrorMessages(ErrorMessageCode.CategoryAddCategoryValidationError, "dto cannot be empty if id is null");
                            //return response;
                        }
                        else
                        {

                            var mediaResult = _mediaManager.AddMedia(categoryDto.ImageDto);

                            if (mediaResult.ErrorMessages.Count > 0)
                            {
                                scope.Dispose();
                                response.ErrorMessages.AddRange(mediaResult.ErrorMessages);
                                return response;
                            }
                            imageId = mediaResult.Result.Id;
                        }
                    }



                    var entity = GetById(categoryDto.Id);
                    if (entity != null)
                    {
                        entity.ImageId =(long) imageId;
                        entity.TopCategoryId = categoryDto.TopCategoryId;
                        entity.Title = categoryDto.Title;
                        entity.Description = categoryDto.Description;   
                        entity.Link = categoryDto.Link;
                        entity.isDeleted = false;
                        entity.LastTransaction = "Category Updated";
                        entity.UpdateIpAddress = IpAddress;
                        entity.UpdateTime = DateTime.Now;
                        entity.UpdateUserName = UserName;
                    }
                    var validatorResult = UpdateValidator.Validate(entity);

                    if (validatorResult.IsValid)
                    {
                        Update(entity);
                        response.Result = mapper.Map<CategoryListDto>(entity);
                    }
                    if (validatorResult.Errors.Count > 0)
                    {
                        scope.Dispose();
                        foreach (var error in validatorResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.CategoryUpdateCategoryValidationError, error.ErrorMessage);

                        }
                    }
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.CategoryUpdateCategoryExceptionError, ex.Message);
                }
            }
            return response;
        }

        public BusinessLayerResult<CategoryListDto> DeleteCategory(long categoryId)
        {
            var response = new BusinessLayerResult<CategoryListDto>();
            try
            {
                var entity = GetById(categoryId);
                entity.isDeleted = true;
                Update(entity);
                response.Result = mapper.Map<CategoryListDto>(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CategoryDeleteCategoryExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<CategoryListDto>> Filter(CategoryFilter categoryFilter)
        {
            var response = new BusinessLayerResult<List<CategoryListDto>>();
            try
            {
                var query = "select * from Category where isDeleted=0 and ";

                if (categoryFilter != null)
                {
                    if (!string.IsNullOrEmpty(categoryFilter.Description))
                    {
                        query += $"description like '%{categoryFilter.Description}%' and ";
                    }
                    if (!string.IsNullOrEmpty(categoryFilter.Title))
                    {
                        query += $"title like '%{categoryFilter.Title}%' and ";
                    }
                    if (!string.IsNullOrEmpty(categoryFilter.Link))
                    {
                        query += $"link like '%{categoryFilter.Link}%' and ";
                    }
                    if (categoryFilter.TopCategoryId!=null&&categoryFilter.TopCategoryId>0)
                    {
                        query += $"topCategoryId = {categoryFilter.TopCategoryId} and ";
                    }



                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<CategoryListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CategoryFilterCategoryExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<CategoryLoadMoreDto> FilterCategoryList(BaseLoadMoreFilter<CategoryFilter> filter)
        {
            var response = new BusinessLayerResult<CategoryLoadMoreDto>();
            try
            {
                var result = new CategoryLoadMoreDto();
                List<CategoryListDto> contentList = new List<CategoryListDto>();

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
                    response.AddErrorMessages(ErrorMessageCode.CategoryFilterCategoryListError, "No more category");
                }
                else
                {
                    result.CategoryListDtos = new List<CategoryListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i >= contentCount)
                        {
                            break;
                        }
                        result.CategoryListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CategoryFilterCategoryListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<CategoryListDto> GetCategory(long categoryId)
        {
            var response = new BusinessLayerResult<CategoryListDto>();
            try
            {
                var entity = GetById(categoryId);
                response.Result = mapper.Map<CategoryListDto>(entity);
                // response.Result.Country = entity.Country;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CategoryDeleteCategoryExceptionError, ex.Message);
            }
            return response;
        }




    }
}
