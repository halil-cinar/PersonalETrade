
using ETrade.Entities.Concrete;
using ETrade.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. Product
    {
        
        public class ProductDto:BaseDto
        {
            
        
        [JsonProperty(PropertyName= "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName= "oldPrice")]
        public Decimal? OldPrice { get; set; }

        [JsonProperty(PropertyName= "price")]
        public Decimal Price { get; set; }

        [JsonProperty(PropertyName= "currencyId")]
        public long CurrencyId { get; set; }

        [JsonProperty(PropertyName= "brandId")]
        public long? BrandId { get; set; }

        [JsonProperty(PropertyName= "categoryId")]
        public long CategoryId { get; set; }

        [JsonProperty(PropertyName= "userId")]
        public long UserId { get; set; }

        [JsonProperty(PropertyName= "rating")]
        public Double Rating { get; set; }

        [JsonProperty(PropertyName= "isSoldAbroad")]
        public bool IsSoldAbroad { get; set; }

        [JsonProperty(PropertyName= "description")]
        public string? Description { get; set; }

        [JsonProperty(PropertyName= "statusType")]
        public ProductStatusType StatusType { get; set; }

        [JsonProperty(PropertyName= "stockStatusType")]
        public ProductStockStatusType StockStatusType { get; set; }



        


    
        }
    }
    