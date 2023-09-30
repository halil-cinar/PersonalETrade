
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. Seller
    {
        
        public class SellerListDto:BaseListDto
        {
            
        [JsonProperty(PropertyName= "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName= "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName= "userId")]
        public long UserId { get; set; }

        [JsonProperty(PropertyName= "coverImageId")]
        public long? CoverImageId { get; set; }

        [JsonProperty(PropertyName= "avatarImageId")]
        public long? AvatarImageId { get; set;}

        [JsonProperty(PropertyName= "rating")]
        public Double  Rating { get; set; }

        

        









    
        }
    }
    