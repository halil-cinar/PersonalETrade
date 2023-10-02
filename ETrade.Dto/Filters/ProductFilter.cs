
using ETrade.Entities.Concrete;
using ETrade.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
    {
        
        public class ProductFilter
        {
            
        
        [JsonProperty(PropertyName= "title")]
        public string? Title { get; set; }

        //[JsonProperty(PropertyName= "oldPrice")]
        //public Decimal? OldPrice { get; set; }

        [JsonProperty(PropertyName = "minPrice")]
        public Decimal? MinPrice { get; set; }

        [JsonProperty(PropertyName = "maxPrice")]
        public Decimal? MaxPrice { get; set; }


        [JsonProperty(PropertyName= "currencyId")]
        public long? CurrencyId { get; set; }

        [JsonProperty(PropertyName= "brandId")]
        public long[]? BrandIds { get; set; }

        [JsonProperty(PropertyName= "categoryId")]
        public long[]? CategoryIds { get; set; }

        [JsonProperty(PropertyName = "minRating")]
        public Double? MinRating { get; set; }

        [JsonProperty(PropertyName = "maxRating")]
        public Double? MaxRating { get; set; }



        [JsonProperty(PropertyName= "isSoldAbroad")]
        public bool? IsSoldAbroad { get; set; }

        [JsonProperty(PropertyName= "description")]
        public string? Description { get; set; }

        [JsonProperty(PropertyName= "statusType")]
        public ProductStatusType? StatusType { get; set; }

        [JsonProperty(PropertyName= "stockStatusType")]
        public ProductStockStatusType? StockStatusType { get; set; }



       



    
        }
    }
    