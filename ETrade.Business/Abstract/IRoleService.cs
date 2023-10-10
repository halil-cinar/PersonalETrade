using ETrade.Dto.Dtos.Role;
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
    public interface IRoleService:IManager<RoleEntity>
    {
        public BusinessLayerResult<RoleListDto> AddRole(RoleDto roleDto);
        public BusinessLayerResult<RoleListDto> UpdateRole(RoleDto roleDto);
        public BusinessLayerResult<RoleListDto> DeleteRole(long roleId);
        public BusinessLayerResult<RoleListDto> GetRole(long id);

        public BusinessLayerResult<List<RoleListDto>> Filter(RoleFilter roleFilter);
        public BusinessLayerResult<RoleLoadMoreDto> FilterRoleList(BaseLoadMoreFilter<RoleFilter> filter);
    }
}
