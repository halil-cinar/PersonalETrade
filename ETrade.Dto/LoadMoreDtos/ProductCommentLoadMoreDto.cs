
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.ProductComment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class ProductCommentLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="productCommentListDtos")]
        public List<ProductCommentListDto> ProductCommentListDtos { get; set; }
            
        }
    }
    