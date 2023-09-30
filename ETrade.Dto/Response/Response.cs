using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Response
{
    public class Response<T>
    {
        public ResponseStatusCode StatusCode { get; set; }

        public List<string> Message { get; set; }

        public T Data { get; set; }

        public Response() { 
        Message= new List<string>();
        }


    }
}
