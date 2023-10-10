using ETrade.Dto.Dtos.OrderDetail;
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
    public interface IOrderDetailService:IManager<OrderDetailEntity>
    {
        public BusinessLayerResult<OrderDetailListDto> AddOrderDetail(OrderDetailDto orderDetailDto);
        public BusinessLayerResult<OrderDetailListDto> UpdateOrderDetail(OrderDetailDto orderDetailDto);
        public BusinessLayerResult<OrderDetailListDto> DeleteOrderDetail(long orderDetailId);
        public BusinessLayerResult<OrderDetailListDto> GetOrderDetail(long id);

        public BusinessLayerResult<List<OrderDetailListDto>> Filter(OrderDetailFilter orderDetailFilter);
        public BusinessLayerResult<OrderDetailLoadMoreDto> FilterOrderDetailList(BaseLoadMoreFilter<OrderDetailFilter> filter);
    }
}
