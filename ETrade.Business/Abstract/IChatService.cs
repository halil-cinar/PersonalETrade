using ETrade.Dto.Dtos.Chat;
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
    public  interface IChatService:IManager<ChatEntity>
    {
        public BusinessLayerResult<ChatListDto> AddChat(ChatDto chatDto);
        public BusinessLayerResult<ChatListDto> UpdateChat(ChatDto chatDto);
        public BusinessLayerResult<ChatListDto> DeleteChat(long chatId);
        public BusinessLayerResult<ChatListDto> GetChat(long id);

        public BusinessLayerResult<List<ChatListDto>> Filter(ChatFilter chatFilter);
        public BusinessLayerResult<ChatLoadMoreDto> FilterChatList(BaseLoadMoreFilter<ChatFilter> filter);
    }
}
