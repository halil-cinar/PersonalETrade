using ETrade.Dto.Dtos.Account;
using ETrade.Dto.Dtos.Identity;
using ETrade.Dto.Dtos.Notify;
using ETrade.Dto.Dtos.Role;
using ETrade.Dto.Dtos.RoleMethod;
using ETrade.Dto.Dtos.Session;
using ETrade.Dto.Dtos.User;
using ETrade.Dto.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business.Abstract
{
    public interface IAccountService
    {

        public BusinessLayerResult<SessionListDto> Login(LogInDto loginDto);

        public BusinessLayerResult<NotifyListDto> ForgattenPasswordAnonymous(string email);

        public BusinessLayerResult<SessionListDto> ForgattenPassword(IdentityDto identity,string notifyToken);

        public BusinessLayerResult<SessionListDto> GetActiveSessionByIp(string ip);
        public BusinessLayerResult<SessionListDto> GetSessionFromIp();



        public BusinessLayerResult<SessionListDto> GetActiveSessionByToken(string token);

        public BusinessLayerResult<UserListDto> SignUp(UserDto userDto);
        public BusinessLayerResult<List<RoleMethodListDto>> GetUserRoleMethods(long userId);

        public BusinessLayerResult<List<RoleListDto>> GetUserRoles(long userId);


        public BusinessLayerResult<List<RoleMethodListDto>> GetGuestRoleMethods();


    }
}
