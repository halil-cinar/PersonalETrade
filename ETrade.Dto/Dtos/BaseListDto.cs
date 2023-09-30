using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos
{
    public class BaseListDto
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "createTime")]
        public DateTime CreateTime { get; set; }

        [JsonProperty(PropertyName = "updateTime")]
        public DateTime? UpdateTime { get; set; }
    }
}
