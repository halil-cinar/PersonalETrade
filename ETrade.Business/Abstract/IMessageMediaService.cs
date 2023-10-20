using ETrade.Dto.Dtos.MessageMedia;
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
    public interface IMessageMediaService:IManager<MessageMediaEntity>
    {
        public BusinessLayerResult<MessageMediaListDto> AddMessageMedia(MessageMediaDto messageMediaDto);
        public BusinessLayerResult<MessageMediaListDto> UpdateMessageMedia(MessageMediaDto messageMediaDto);
        public BusinessLayerResult<MessageMediaListDto> DeleteMessageMedia(long messageMediaId);
        public BusinessLayerResult<MessageMediaListDto> GetMessageMedia(long id);

        public BusinessLayerResult<List<MessageMediaListDto>> Filter(MessageMediaFilter messageMediaFilter);
        public BusinessLayerResult<MessageMediaLoadMoreDto> FilterMessageMediaList(BaseLoadMoreFilter<MessageMediaFilter> filter);
    }
}
