
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.SellerAddress;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class SellerAddressLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="sellerAddressListDtos")]
        public List<SellerAddressListDto> SellerAddressListDtos { get; set; }
            
        }
    }
    