using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Core.Utils;
using ETrade.Dto.Dtos.Order;
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
    public class OrderManager:ManagerBase<OrderEntity>,IOrderService
    {
        public OrderManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
        }

        private string GenereteOrderNo()
        {
            var str = "";
            var date=DateTime.Now;
            str += date.Year;
            str += date.Month;
            str += date.Day;
            str+= date.Hour;
            str += date.Minute;
            str += date.Second;
            str += ExtensionMethods.GenerateRandomNumber(3);
            return str;
        }

        public BusinessLayerResult<OrderListDto> AddOrder(OrderDto orderDto)
        {
            var response = new BusinessLayerResult<OrderListDto>();
            try
            {
                var entity = new OrderEntity
                {
                    BillingAddressId= orderDto.BillingAddressId,
                    DeliveryAddressId= orderDto.DeliveryAddressId,
                    DiscountAmount= orderDto.DiscountAmount,
                    OrderDate= orderDto.OrderDate,
                    OrderDetails= orderDto.OrderDetails,
                    OrderNo=GenereteOrderNo(),
                    UserId= orderDto.UserId,    

                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    isDeleted = false,
                    LastTransaction = "Order has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<OrderListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.OrderAddOrderValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.OrderAddOrderExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<OrderListDto> UpdateOrder(OrderDto orderDto)
        {
            var response = new BusinessLayerResult<OrderListDto>();

            try
            {
                var entity = GetById(orderDto.Id);
                if (entity != null)
                {
                    entity.BillingAddressId = orderDto.BillingAddressId;
                    entity.DeliveryAddressId = orderDto.DeliveryAddressId;
                    entity.DiscountAmount = orderDto.DiscountAmount;
                    entity.OrderDate = orderDto.OrderDate;
                    entity.OrderDetails = orderDto.OrderDetails;
                    //entity.OrderNo = GenereteOrderNo();
                    entity.UserId = orderDto.UserId;


                    entity.isDeleted = false;
                    entity.LastTransaction = "Order Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<OrderListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.OrderUpdateOrderValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.OrderUpdateOrderExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<OrderListDto> DeleteOrder(long orderId)
        {
            var response = new BusinessLayerResult<OrderListDto>();
            try
            {
                var entity = GetById(orderId);
                entity.isDeleted = true;
                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.OrderDeleteOrderExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<OrderListDto>> Filter(OrderFilter orderFilter)
        {
            var response = new BusinessLayerResult<List<OrderListDto>>();
            try
            {
                var query = "select * from Order where isDeleted=0 and ";

                if (orderFilter != null)
                {

                    if (!string.IsNullOrEmpty(orderFilter.OrderNo))
                    {
                        query += $"orderNo like '%{orderFilter.OrderNo}%' and ";
                    }
                    if (orderFilter.UserId != null)
                    {
                        query += $"userId like '%{orderFilter.UserId}%' and ";
                    }
                    if (orderFilter.BillingAddressId != null)
                    {
                        query += $"billingAddressId like '%{orderFilter.BillingAddressId}%' and ";
                    }
                    if (orderFilter.DeliveryAddressId != null)
                    {
                        query += $"deliveryAddressId like '%{orderFilter.DeliveryAddressId}%' and ";
                    }
                    if (orderFilter.MaxDiscountAmount != null)
                    {
                        query += $"discountAmount <={orderFilter.MaxDiscountAmount} and ";
                    }
                    if (orderFilter.MinDiscountAmount != null)
                    {
                        query += $"discountAmount  >={orderFilter.MinDiscountAmount} and ";
                    }
                    if (orderFilter.MaxOrderDate != null)
                    {
                        query += $"orderDate <={orderFilter.MaxOrderDate} and ";
                    }
                    if (orderFilter.MinOrderDate != null)
                    {
                        query += $"orderDate  >={orderFilter.MinOrderDate} and ";
                    }



                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<OrderListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.OrderFilterOrderExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<OrderLoadMoreDto> FilterOrderList(BaseLoadMoreFilter<OrderFilter> filter)
        {
            var response = new BusinessLayerResult<OrderLoadMoreDto>();
            try
            {
                var result = new OrderLoadMoreDto();
                List<OrderListDto> contentList = new List<OrderListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<OrderListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.OrderFilterOrderListError, "No more order");
                }
                else
                {
                    result.OrderListDtos = new List<OrderListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.OrderListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.OrderFilterOrderListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<OrderListDto> GetOrder(long id)
        {
            var response = new BusinessLayerResult<OrderListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<OrderListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.OrderGetOrderNotFoundExceptionError, "Order was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.OrderGetOrderExceptionError, ex.Message);
            }
            return response;
        }

    }
}
