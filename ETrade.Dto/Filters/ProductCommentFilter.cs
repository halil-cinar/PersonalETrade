
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
    {
        
        public class ProductCommentFilter
        {
            
        [JsonProperty(PropertyName= "productId")]
        public long ProductId { get; set; }

        [JsonProperty(PropertyName= "commentId")]
        public long CommentId { get; set; }

        [JsonProperty(PropertyName= "isActive")]
        public bool IsActive { get; set; }

       
    
        }
    }
    