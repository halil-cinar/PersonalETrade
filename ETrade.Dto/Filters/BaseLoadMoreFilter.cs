﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
{
    public class BaseLoadMoreFilter<T>
    {
        public T? Filter { get; set; }

        public int PageCount { get; set; }
        public int ContentCount { get; set; }

    }
}
