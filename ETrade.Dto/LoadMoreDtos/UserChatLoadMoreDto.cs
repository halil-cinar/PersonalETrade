using ETrade.Dto.Dtos.UserChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
{
    public class UserChatLoadMoreDto:BaseLoadMoreDto
    {
        public List<UserChatListDto> UserChatListDtos { get; set; }
    }
}
