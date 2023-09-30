using ETrade.Dto.Dtos.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
{
    public class UserRoleLoadMoreDto:BaseLoadMoreDto
    {
        public List<UserRoleListDto> roleUserListDtos { get; set; }
    }
}
