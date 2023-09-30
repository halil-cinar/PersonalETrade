using ETrade.Dto.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Result
{
    public class BusinessLayerResult<T> 
    {
        public List<ErrorMessageObj> ErrorMessages { get; set; }

        public T Result { get; set; }

        public BusinessLayerResult() { 
            ErrorMessages= new List<ErrorMessageObj>();
        }

        public void AddErrorMessages(ErrorMessageCode errorCode,string message)
        {
            ErrorMessages.Add(new ErrorMessageObj {ErrorCode=errorCode,Message=message });
        }
    }
}
