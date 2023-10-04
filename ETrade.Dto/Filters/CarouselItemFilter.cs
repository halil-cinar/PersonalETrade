
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
    {
        
        public class CarouselItemFilter
        {
            
       

        [JsonProperty(PropertyName= "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName= "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName= "subtitle")]
        public string Subtitle { get; set; }

       




    
        }
    }
    