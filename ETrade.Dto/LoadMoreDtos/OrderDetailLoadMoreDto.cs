
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.OrderDetail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class OrderDetailLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="orderDetailListDtos")]
        public List<OrderDetailListDto> OrderDetailListDtos { get; set; }
            
        }
    }
    