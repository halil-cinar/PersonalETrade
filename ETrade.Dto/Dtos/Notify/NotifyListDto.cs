using Newtonsoft.Json;
using ETrade.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.Notify
{
    public class NotifyListDto:BaseListDto
    {
        [JsonProperty(PropertyName = "expiryDate")]
        public DateTime ExpiryDate { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "notifyType")]
        public NotifyType NotifyType { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public long UserId { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string? Data { get; set; }
    }
}
