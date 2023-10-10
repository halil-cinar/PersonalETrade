using ETrade.Dto.Dtos.UserRole;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business.Abstract
{
    public interface IUserRoleService:IManager<UserRoleEntity>
    {
        public BusinessLayerResult<UserRoleListDto> AddUserRole(UserRoleDto userRoleDto);
        public BusinessLayerResult<UserRoleListDto> UpdateUserRole(UserRoleDto userRoleDto);
        public BusinessLayerResult<UserRoleListDto> DeleteUserRole(long userRoleId);
        public BusinessLayerResult<UserRoleListDto> GetUserRole(long id);

        public BusinessLayerResult<List<UserRoleListDto>> Filter(UserRoleFilter userRoleFilter);
        public BusinessLayerResult<UserRoleLoadMoreDto> FilterUserRoleList(BaseLoadMoreFilter<UserRoleFilter> filter);

        public BusinessLayerResult<UserRoleListDto> DeleteUserRoleByUserId(long userId);

    }
}
