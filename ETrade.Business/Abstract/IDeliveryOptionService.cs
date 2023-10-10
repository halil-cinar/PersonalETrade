using ETrade.Dto.Dtos.DeliveryOption;
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
    public interface IDeliveryOptionService:IManager<DeliveryOptionEntity>
    {
        public BusinessLayerResult<DeliveryOptionListDto> AddDeliveryOption(DeliveryOptionDto deliveryOptionDto);
        public BusinessLayerResult<DeliveryOptionListDto> UpdateDeliveryOption(DeliveryOptionDto deliveryOptionDto);
        public BusinessLayerResult<DeliveryOptionListDto> DeleteDeliveryOption(long deliveryOptionId);
        public BusinessLayerResult<DeliveryOptionListDto> GetDeliveryOption(long id);

        public BusinessLayerResult<List<DeliveryOptionListDto>> Filter(DeliveryOptionFilter deliveryOptionFilter);
        public BusinessLayerResult<DeliveryOptionLoadMoreDto> FilterDeliveryOptionList(BaseLoadMoreFilter<DeliveryOptionFilter> filter);
    }
}
