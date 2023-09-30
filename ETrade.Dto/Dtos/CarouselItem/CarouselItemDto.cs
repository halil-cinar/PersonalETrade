
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. CarouselItem
    {
        
        public class CarouselItemDto:BaseDto
        {
            
        [JsonProperty(PropertyName= "backgroudImageId")]
        public long BackgroudImageId { get; set; }

        [JsonProperty(PropertyName= "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName= "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName= "subtitle")]
        public string Subtitle { get; set; }

   





    
        }
    }
    