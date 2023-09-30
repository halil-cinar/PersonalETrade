
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.UserCart;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class UserCartLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="userCartListDtos")]
        public List<UserCartListDto> UserCartListDtos { get; set; }
            
        }
    }
    