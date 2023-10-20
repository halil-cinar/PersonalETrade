using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
{
    public class UserChatFilter
    {
        [JsonProperty(PropertyName = "userId")]
        public long? UserId { get; set; }

        [JsonProperty(PropertyName = "chatId")]
        public long? ChatId { get; set; }
    }
}
