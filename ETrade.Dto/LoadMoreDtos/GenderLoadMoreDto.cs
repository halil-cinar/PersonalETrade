using ETrade.Dto.Dtos.Gender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
{
    public class GenderLoadMoreDto:BaseLoadMoreDto
    {
        public List<GenderListDto> genderListDtos { get; set; }
    }
}
