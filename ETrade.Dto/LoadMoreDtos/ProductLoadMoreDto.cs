
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.Product;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class ProductLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="productListDtos")]
        public List<ProductListDto> ProductListDtos { get; set; }
            
        }
    }
    