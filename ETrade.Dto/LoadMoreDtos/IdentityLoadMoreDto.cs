using ETrade.Dto.Dtos.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
{
    public class IdentityLoadMoreDto:BaseLoadMoreDto
    {
        public List<IdentityListDto> identityListDtos { get; set; }
    }
}
