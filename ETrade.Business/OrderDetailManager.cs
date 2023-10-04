using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.OrderDetail;
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
    public class OrderDetailManager:ManagerBase<OrderDetailEntity>
    {
        public OrderDetailManager(string userName, string ıpAddress, BaseEntityValidator<OrderDetailEntity> validator, IMapper mapper, IEntityDal<OrderDetailEntity> repository) : base(userName, ıpAddress, validator, mapper, repository)
        {
        }

        public BusinessLayerResult<OrderDetailListDto> AddOrderDetail(OrderDetailDto orderDetailDto)
        {
            var response = new BusinessLayerResult<OrderDetailListDto>();
            try
            {
                var entity = new OrderDetailEntity
                {
                    
                    CurrencyId= orderDetailDto.CurrencyId,
                    OrderId= orderDetailDto.OrderId,
                    DeliveryOptionId= orderDetailDto.DeliveryOptionId,
                    DiscountAmount= orderDetailDto.DiscountAmount,
                    ProductId= orderDetailDto.ProductId,
                    Quantity= orderDetailDto.Quantity,
                    ShippedDate= orderDetailDto.ShippedDate,
                    TrackingNumber= orderDetailDto.TrackingNumber,
                    UnitPrice= orderDetailDto.UnitPrice,
                    

                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    IsDeleted = false,
                    LastTransaction = "OrderDetail has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<OrderDetailListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.OrderDetailAddOrderDetailValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.OrderDetailAddOrderDetailExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<OrderDetailListDto> UpdateOrderDetail(OrderDetailDto orderDetailDto)
        {
            var response = new BusinessLayerResult<OrderDetailListDto>();

            try
            {
                var entity = GetById(orderDetailDto.Id);
                if (entity != null)
                {
                    entity.CurrencyId = orderDetailDto.CurrencyId;
                    entity.OrderId = orderDetailDto.OrderId;
                    entity.DeliveryOptionId = orderDetailDto.DeliveryOptionId;
                    entity.DiscountAmount = orderDetailDto.DiscountAmount;
                    entity.ProductId = orderDetailDto.ProductId;
                    entity.Quantity = orderDetailDto.Quantity;
                    entity.ShippedDate = orderDetailDto.ShippedDate;
                    entity.TrackingNumber = orderDetailDto.TrackingNumber;
                    entity.UnitPrice = orderDetailDto.UnitPrice;


                    entity.IsDeleted = false;
                    entity.LastTransaction = "OrderDetail Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<OrderDetailListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.OrderDetailUpdateOrderDetailValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.OrderDetailUpdateOrderDetailExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<OrderDetailListDto> DeleteOrderDetail(long orderDetailId)
        {
            var response = new BusinessLayerResult<OrderDetailListDto>();
            try
            {
                var entity = GetById(orderDetailId);
                entity.IsDeleted = true;
                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.OrderDetailDeleteOrderDetailExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<OrderDetailListDto>> Filter(OrderDetailFilter orderDetailFilter)
        {
            var response = new BusinessLayerResult<List<OrderDetailListDto>>();
            try
            {
                var query = "select * from OrderDetail where isDeleted=0 and ";

                if (orderDetailFilter != null)
                {

                    if (!string.IsNullOrEmpty(orderDetailFilter.TrackingNumber))
                    {
                        query += $"trackingNumber like '%{orderDetailFilter.TrackingNumber}%' and ";
                    }
                    if (orderDetailFilter.OrderId != null)
                    {
                        query += $"orderId = {orderDetailFilter.OrderId} and ";
                    }
                    if (orderDetailFilter.ProductId != null)
                    {
                        query += $"productId = {orderDetailFilter.ProductId} and ";
                    }
                    



                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<OrderDetailListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.OrderDetailFilterOrderDetailExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<OrderDetailLoadMoreDto> FilterOrderDetailList(BaseLoadMoreFilter<OrderDetailFilter> filter)
        {
            var response = new BusinessLayerResult<OrderDetailLoadMoreDto>();
            try
            {
                var result = new OrderDetailLoadMoreDto();
                List<OrderDetailListDto> contentList = new List<OrderDetailListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<OrderDetailListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.OrderDetailFilterOrderDetailListError, "No more orderDetail");
                }
                else
                {
                    result.OrderDetailListDtos = new List<OrderDetailListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.OrderDetailListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.OrderDetailFilterOrderDetailListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<OrderDetailListDto> GetOrderDetail(long id)
        {
            var response = new BusinessLayerResult<OrderDetailListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<OrderDetailListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.OrderDetailGetOrderDetailNotFoundExceptionError, "OrderDetail was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.OrderDetailGetOrderDetailExceptionError, ex.Message);
            }
            return response;
        }

    }
}
