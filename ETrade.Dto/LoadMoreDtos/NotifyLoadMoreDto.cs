using Newtonsoft.Json;
using ETrade.Dto.Dtos.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
{
    public class NotifyLoadMoreDto:BaseLoadMoreDto
    {
        [JsonProperty(PropertyName = "notifyListDtos")]
        public List<NotifyListDto> NotifyListDtos { get; set; }
    }
}
