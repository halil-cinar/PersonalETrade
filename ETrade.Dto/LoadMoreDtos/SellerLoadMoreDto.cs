
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.Seller;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class SellerLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="sellerListDtos")]
        public List<SellerListDto> SellerListDtos { get; set; }
            
        }
    }
    