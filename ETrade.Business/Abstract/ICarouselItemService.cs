using ETrade.Dto.Dtos.CarouselItem;
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
    public interface ICarouselItemService:IManager<CarouselItemEntity>
    {
        public BusinessLayerResult<CarouselItemListDto> AddCarouselItem(CarouselItemDto carouselItemDto);
        public BusinessLayerResult<CarouselItemListDto> UpdateCarouselItem(CarouselItemDto carouselItemDto);
        public BusinessLayerResult<CarouselItemListDto> DeleteCarouselItem(long carouselItemId);
        public BusinessLayerResult<CarouselItemListDto> GetCarouselItem(long id);

        public BusinessLayerResult<List<CarouselItemListDto>> Filter(CarouselItemFilter carouselItemFilter);
        public BusinessLayerResult<CarouselItemLoadMoreDto> FilterCarouselItemList(BaseLoadMoreFilter<CarouselItemFilter> filter);
    }
}
