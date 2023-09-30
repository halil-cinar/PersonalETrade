using ETrade.Dto.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
{
    public class UserLoadMoreDto:BaseLoadMoreDto
    {
        public List<UserListDto> userListDtos { get; set; }
    }
}
