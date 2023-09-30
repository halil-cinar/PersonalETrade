
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.Chat;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class ChatLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="chatListDtos")]
        public List<ChatListDto> ChatListDtos { get; set; }
            
        }
    }
    