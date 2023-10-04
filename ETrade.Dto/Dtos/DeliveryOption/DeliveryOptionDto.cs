
using ETrade.Dto.Dtos.Media;
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. DeliveryOption
    {
        
        public class DeliveryOptionDto:BaseDto
        {
            
        [JsonProperty(PropertyName= "brandName")]
        public string BrandName { get; set; }

        [JsonProperty(PropertyName= "price")]
        public Decimal Price { get; set; }

        [JsonProperty(PropertyName= "isFree")]
        public bool IsFree { get; set;}

        [JsonProperty(PropertyName= "isSentAbroad")]
        public bool IsSentAbroad { get; set; }

        [JsonProperty(PropertyName = "logoId")]
        public long? LogoId { get; set; }

        [JsonProperty(PropertyName = "logo")]
        public MediaDto Logo { get; set; }









    }
}
    