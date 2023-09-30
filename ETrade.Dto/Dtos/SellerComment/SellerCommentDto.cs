
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. SellerComment
    {
        
        public class SellerCommentDto:BaseDto
        {
            
        [JsonProperty(PropertyName= "SellerId")]
        public long SellerId { get; set; }

        [JsonProperty(PropertyName= "commentId")]
        public long CommentId { get; set; }

        [JsonProperty(PropertyName= "isActive")]
        public bool IsActive { get; set; }

        
        }
    }
    