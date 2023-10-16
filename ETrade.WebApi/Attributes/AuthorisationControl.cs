using ETrade.Business.Abstract;
using ETrade.Entities.Enums;

namespace ETrade.WebApi.Attributes
{
    public  class AuthorisationControl
    {
        public static bool? AuthorisationControll(MethodList methodType,IAccountService accountService,string token)
        {
          var session=  accountService.GetActiveSessionByToken(token);
            if(session == null || session.Result==null || session.ErrorMessages.Count>0)
            {
                return false;
            }
            //var roleMethods = accountService.GetUserRoleMethods(session.Result.UserId);

            return null;

        }
    }
}
