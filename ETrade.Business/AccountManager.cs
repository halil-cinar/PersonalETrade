using ETrade.Business.Abstract;
using ETrade.Dto.Dtos.Account;
using ETrade.Dto.Dtos.Session;
using ETrade.Dto.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ETrade.Business
{
    public class AccountManager
    {

        public BusinessLayerResult<SessionListDto> LogIn(LogInDto logInDto)
        {
            var response=new BusinessLayerResult<SessionDto>();
            using(var scope=new TransactionScope())
            {
                try
                {
                    var sessionDto
                }
            }
        }
    }
}
