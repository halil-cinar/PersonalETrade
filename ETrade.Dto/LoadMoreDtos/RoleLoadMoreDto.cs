using ETrade.Dto.Dtos.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
{
    public class RoleLoadMoreDto:BaseLoadMoreDto
    {
        public List<RoleListDto> roleListDtos { get; set; }
    }
}
