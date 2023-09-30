
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. Category
    {
        
        public class CategoryListDto:BaseListDto
        {
            
        [JsonProperty(PropertyName= "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName= "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName= "topCategoryId")]
        public long? TopCategoryId { get; set; }

        [JsonProperty(PropertyName= "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName= "imageId")]
        public long ImageId { get; set; }

        [ForeignKey("ImageId")]
        public virtual MediaEntity Image { get; set;}

        




    
        }
    }
    