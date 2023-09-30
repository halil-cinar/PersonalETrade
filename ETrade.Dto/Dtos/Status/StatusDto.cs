
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. Status
    {
        
        public class StatusDto:BaseDto
        {
            

        [JsonProperty(PropertyName= "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName= "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName= "color")]
        public string Color { get; set; }


    
        }
    }
    