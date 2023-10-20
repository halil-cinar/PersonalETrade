using FluentValidation;
using Newtonsoft.Json.Linq;
using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.ProductChat;
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
    public class ProductChatManager:ManagerBase<ProductChatEntity>,IProductChatService
    {
        public ProductChatManager(string userName, string ýpAddress) : base(userName, ýpAddress)
        {
        }

        public BusinessLayerResult<ProductChatListDto> AddProductChat(ProductChatDto productchatDto)
        {
            var response = new BusinessLayerResult<ProductChatListDto>();
            try
            {
                var entity = new ProductChatEntity
                {
                    ChatId= productchatDto.ChatId,  
                    IsActive=productchatDto.IsActive,
                    isDeletable=true,
                    ProductId= productchatDto.ProductId,
                    
                   
                   



                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "ProductChat has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<ProductChatListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.ProductChatAddProductChatValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductChatAddProductChatExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<ProductChatListDto> UpdateProductChat(ProductChatDto productchatDto)
        {
            var response = new BusinessLayerResult<ProductChatListDto>();

            try
            {
                var entity = GetById(productchatDto.Id);
                if (entity != null)
                {
                    entity.ChatId= productchatDto.ChatId;
                    entity.IsActive=productchatDto.IsActive;
                    entity.isDeletable=true;
                    entity.ProductId = productchatDto.ProductId;
                  


                    entity.isDeleted = false;
                    entity.LastTransaction = "ProductChat Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<ProductChatListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.ProductChatUpdateProductChatValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductChatUpdateProductChatExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<ProductChatListDto> DeleteProductChat(long productchatId)
        {
            var response = new BusinessLayerResult<ProductChatListDto>();
            try
            {
                var entity = GetById(productchatId);
                entity.isDeleted = true;

                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductChatDeleteProductChatExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<ProductChatListDto>> Filter(ProductChatFilter productchatFilter)
        {
            var response = new BusinessLayerResult<List<ProductChatListDto>>();
            try
            {
                var query = "select * from ProductChat where isDeleted=0 and ";

                if (productchatFilter != null)
                {


                    if (productchatFilter.IsActive != null)
                    {
                        query += $"isActive = {productchatFilter.IsActive} and ";
                    }
                    if (productchatFilter.ProductId != null)
                    {
                        query += $"productId = {productchatFilter.ProductId} and ";
                    }
                    if (productchatFilter.ChatId != null)
                    {
                        query += $"chatId = {productchatFilter.ChatId} and ";
                    }
                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<ProductChatListDto>(x)).ToList();



            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductChatFilterProductChatExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<ProductChatLoadMoreDto> FilterProductChatList(BaseLoadMoreFilter<ProductChatFilter> filter)
        {
            var response = new BusinessLayerResult<ProductChatLoadMoreDto>();
            try
            {
                var result = new ProductChatLoadMoreDto();
                List<ProductChatListDto> contentList = new List<ProductChatListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<ProductChatListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.ProductChatFilterProductChatListError, "No more productchat");
                }
                else
                {
                    result.ProductChatListDtos = new List<ProductChatListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.ProductChatListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductChatFilterProductChatListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<ProductChatListDto> GetProductChat(long id)
        {
            var response = new BusinessLayerResult<ProductChatListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<ProductChatListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.ProductChatGetProductChatNotFoundExceptionError, "ProductChat was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.ProductChatGetProductChatExceptionError, ex.Message);
            }
            return response;
        }

       
    }
}


