
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.Order;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class OrderLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="orderListDtos")]
        public List<OrderListDto> OrderListDtos { get; set; }
            
        }
    }
    