using Newtonsoft.Json;
using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.UserChat
{
    public class UserChatDto:BaseDto
    {
        [JsonProperty(PropertyName="userId")]
        public long UserId { get; set; }

        [JsonProperty(PropertyName="chatId")]
        public long ChatId { get; set; }

        [JsonProperty(PropertyName="isActive")]
        public bool isActive { get; set; }

        [JsonProperty(PropertyName="joinDate")]
        public DateTime JoinDate { get; set; }

        [JsonProperty(PropertyName="DepartureDate")]
        public DateTime? DepartureDate { get; set; }

        [JsonProperty(PropertyName="isSeller")]
        public bool IsSeller { get; set; }
    }
}
