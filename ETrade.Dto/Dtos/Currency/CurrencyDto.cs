using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.Currency
{
    public class CurrencyDto:BaseDto
    {
        [JsonProperty(PropertyName="title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName="currencyCode")]
        public string Code { get; set; }

        [JsonProperty(PropertyName="symbol")]
        public string Symbol { get; set; }
    }
}
