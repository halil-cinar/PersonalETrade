
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.Message;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class MessageLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="messageListDtos")]
        public List<MessageListDto> MessageListDtos { get; set; }
            
        }
    }
    