
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.DeliveryOption;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class DeliveryOptionLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="deliveryOptionListDtos")]
        public List<DeliveryOptionListDto> DeliveryOptionListDtos { get; set; }
            
        }
    }
    