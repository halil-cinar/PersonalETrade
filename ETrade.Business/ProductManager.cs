using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.Product;
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
    public class ProductManager:ManagerBase<ProductEntity>,IProductService
    {
        public ProductManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
        }

        public BusinessLayerResult<ProductListDto> AddProduct(ProductDto productDto)
        {
            var response = new BusinessLayerResult<ProductListDto>();
            try
            {
                var entity = new ProductEntity
                {
                    
                    StockStatusType= productDto.StockStatusType,
                    StatusType= productDto.StatusType,
                    Rating=5,
                    Price= productDto.Price,
                    IsSoldAbroad= productDto.IsSoldAbroad,
                    CurrencyId= productDto.CurrencyId,
                    OldPrice= productDto.Price,
                    Description= productDto.Description,
                    CategoryId= productDto.CategoryId,
                    BrandId=productDto.BrandId,   
                    Title = productDto.Title,
                    UserId = productDto.UserId,

                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    IsDeleted = false,
                    LastTransaction = "Product has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<ProductListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.ProductAddProductValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductAddProductExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<ProductListDto> UpdateProduct(ProductDto productDto)
        {
            var response = new BusinessLayerResult<ProductListDto>();

            try
            {
                var entity = GetById(productDto.Id);
                if (entity != null)
                {
                    entity.StockStatusType = productDto.StockStatusType;
                    entity.StatusType = productDto.StatusType;
                    entity.Rating = 5;
                    entity.Price = productDto.Price;
                    entity.IsSoldAbroad = productDto.IsSoldAbroad;
                    entity.CurrencyId = productDto.CurrencyId;
                    entity.OldPrice = productDto.Price;
                    entity.Description = productDto.Description;
                    entity.CategoryId = productDto.CategoryId;
                    entity.BrandId = productDto.BrandId  ;
                    entity.Title = productDto.Title;
                    entity.UserId = productDto.UserId;
                    


                    entity.IsDeleted = false;
                    entity.LastTransaction = "Product Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<ProductListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.ProductUpdateProductValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductUpdateProductExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<ProductListDto> DeleteProduct(long productId)
        {
            var response = new BusinessLayerResult<ProductListDto>();
            try
            {
                var entity = GetById(productId);
                entity.IsDeleted = true;
                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductDeleteProductExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<ProductListDto>> Filter(ProductFilter productFilter)
        {
            var response = new BusinessLayerResult<List<ProductListDto>>();
            try
            {
                var query = "select * from Product where isDeleted=0 and ";

                if (productFilter != null)
                {


                    if (!string.IsNullOrEmpty(productFilter.Title))
                    {
                        query += $"title like '%{productFilter.Title}%' and ";
                    }
                    if (!string.IsNullOrEmpty(productFilter.Description))
                    {
                        query += $"description like '%{productFilter.Description}%' and ";
                    }

                    if (productFilter.MinPrice != null)
                    {
                        query += $"minPrice > {productFilter.MinPrice} and ";
                    }
                    if (productFilter.MaxPrice != null)
                    {
                        query += $"maxPrice < '{productFilter.MaxPrice}' and ";
                    }
                    if (productFilter.MinRating != null)
                    {
                        query += $"minRating > {productFilter.MinRating} and ";
                    }
                    if (productFilter.MaxRating != null)
                    {
                        query += $"maxRating < '{productFilter.MaxRating}' and ";
                    }

                    if (productFilter.StatusType != null)
                    {
                        query += $"statusType= {productFilter.StatusType} and ";
                    }
                    if (productFilter.StockStatusType != null)
                    {
                        query += $"stockStatusType= {productFilter.StockStatusType} and ";
                    }
                    if (productFilter.BrandIds != null && productFilter.BrandIds.Length > 0)
                    {
                        query += $"branndId in ({string.Join(",", productFilter.BrandIds)}) and ";
                    }

                    if (productFilter.CategoryIds != null && productFilter.CategoryIds.Length > 0)
                    {
                        query += $"branndId in ({string.Join(",", productFilter.CategoryIds)}) and ";
                    }

                    if (productFilter.CurrencyId != null)
                    {
                        query += $"currencyId = {productFilter.CurrencyId}";
                    }
                    if (productFilter.IsSoldAbroad != null)
                    {
                        query += $"currencyId = {Convert.ToInt32( productFilter.IsSoldAbroad)}";
                    }
                   





                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<ProductListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductFilterProductExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<ProductLoadMoreDto> FilterProductList(BaseLoadMoreFilter<ProductFilter> filter)
        {
            var response = new BusinessLayerResult<ProductLoadMoreDto>();
            try
            {
                var result = new ProductLoadMoreDto();
                List<ProductListDto> contentList = new List<ProductListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<ProductListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.ProductFilterProductListError, "No more product");
                }
                else
                {
                    result.ProductListDtos = new List<ProductListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.ProductListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductFilterProductListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<ProductListDto> GetProduct(long id)
        {
            var response = new BusinessLayerResult<ProductListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<ProductListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.ProductGetProductNotFoundExceptionError, "Product was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductGetProductExceptionError, ex.Message);
            }
            return response;
        }

    }
}
