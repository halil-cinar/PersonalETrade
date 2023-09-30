using ETrade.Dto.Dtos.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
{
    public class MediaLoadMoreDto:BaseLoadMoreDto
    {
        public List<MediaListDto> mediaListDtos { get; set; }
    }
}
