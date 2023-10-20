using ETrade.Dto.Dtos.Message;
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
    public interface IMessageService:IManager<MessageEntity>
    {
        public BusinessLayerResult<MessageListDto> AddMessage(MessageDto messageDto);
        public BusinessLayerResult<MessageListDto> UpdateMessage(MessageDto messageDto);
        public BusinessLayerResult<MessageListDto> DeleteMessage(long messageId);
        public BusinessLayerResult<MessageListDto> GetMessage(long id);

        public BusinessLayerResult<List<MessageListDto>> Filter(MessageFilter messageFilter);
        public BusinessLayerResult<MessageLoadMoreDto> FilterMessageList(BaseLoadMoreFilter<MessageFilter> filter);
    }
}
