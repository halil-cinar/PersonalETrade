
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.ProductChat;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class ProductChatLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="productChatListDtos")]
        public List<ProductChatListDto> ProductChatListDtos { get; set; }
            
        }
    }
    