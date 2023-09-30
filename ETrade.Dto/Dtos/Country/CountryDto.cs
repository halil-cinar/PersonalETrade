
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. Country
    {
        
        public class CountryDto:BaseDto
        {
            
        [JsonProperty(PropertyName= "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName= "code")]
        public string Code { get; set; }


    
        }
    }
    