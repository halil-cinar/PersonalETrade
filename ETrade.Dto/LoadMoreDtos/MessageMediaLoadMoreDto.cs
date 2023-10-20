using ETrade.Dto.Dtos.MessageMedia;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
{
    public class MessageMediaLoadMoreDto:BaseLoadMoreDto
    {
        [JsonProperty("messageMediaListDtos")]
        public List<MessageMediaListDto> MessageMediaListDtos { get; set; }
    }
}
