using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Errors
{
    public class ErrorMessageObj
    {
        public ErrorMessageCode ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
