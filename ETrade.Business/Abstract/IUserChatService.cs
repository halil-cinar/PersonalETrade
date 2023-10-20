using ETrade.Dto.Dtos.UserChat;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business.Abstract
{
    public interface IUserChatService:IManager<UserChatEntity>
    {
        public BusinessLayerResult<UserChatListDto> AddUserChat(UserChatDto userchatDto);
        public BusinessLayerResult<UserChatListDto> UpdateUserChat(UserChatDto userchatDto);
        public BusinessLayerResult<UserChatListDto> DeleteUserChat(long userchatId);
        public BusinessLayerResult<UserChatListDto> GetUserChat(long id);

        public BusinessLayerResult<List<UserChatListDto>> Filter(UserChatFilter userchatFilter);
        public BusinessLayerResult<UserChatLoadMoreDto> FilterUserChatList(BaseLoadMoreFilter<UserChatFilter> filter);
    }
}

