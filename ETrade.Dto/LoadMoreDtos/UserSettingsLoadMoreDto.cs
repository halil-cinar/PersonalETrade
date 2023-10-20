using ETrade.Dto.Dtos.UserSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
{
    public class UserSettingsLoadMoreDto:BaseLoadMoreDto
    {
        public List<UserSettingsListDto> UserSettingsListDtos { get; set; }
    }
}
