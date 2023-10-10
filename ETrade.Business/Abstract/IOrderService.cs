using ETrade.Dto.Dtos.Order;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business.Abstract
{
    public interface IOrderService:IManager<OrderEntity>
    {
        public BusinessLayerResult<OrderListDto> AddOrder(OrderDto orderDto);
        public BusinessLayerResult<OrderListDto> UpdateOrder(OrderDto orderDto);
        public BusinessLayerResult<OrderListDto> DeleteOrder(long orderId);
        public BusinessLayerResult<OrderListDto> GetOrder(long id);

        public BusinessLayerResult<List<OrderListDto>> Filter(OrderFilter orderFilter);
        public BusinessLayerResult<OrderLoadMoreDto> FilterOrderList(BaseLoadMoreFilter<OrderFilter> filter);

    }
}
