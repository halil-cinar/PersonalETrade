using ETrade.Dto.Dtos.Media;
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
    public interface IMediaService:IManager<MediaEntity>
    {
        public BusinessLayerResult<MediaListDto> AddMedia(MediaDto mediaDto);
        public BusinessLayerResult<MediaListDto> UpdateMedia(MediaDto mediaDto);
        public BusinessLayerResult<MediaListDto> DeleteMedia(long mediaId);
        public BusinessLayerResult<MediaListDto> GetMedia(long id);

        public BusinessLayerResult<List<MediaListDto>> Filter(MediaFilter mediaFilter);
        public BusinessLayerResult<MediaLoadMoreDto> FilterMediaList(BaseLoadMoreFilter<MediaFilter> filter);

    }
}
