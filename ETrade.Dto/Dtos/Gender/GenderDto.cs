﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.Gender
{
    public class GenderDto:BaseDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
