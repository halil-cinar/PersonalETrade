
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.SellerComment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class SellerCommentLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="sellerCommentListDtos")]
        public List<SellerCommentListDto> SellerCommentListDtos { get; set; }
            
        }
    }
    