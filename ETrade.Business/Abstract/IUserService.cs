using ETrade.Dto.Dtos.User;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Dto.Dtos.Media;

namespace ETrade.Business.Abstract
{
    public interface IUserService : IManager<UserEntity>
    {
        public BusinessLayerResult<UserListDto> AddUser(UserDto userDto);
        public BusinessLayerResult<UserListDto> UpdateUser(UserDto userDto);
        public BusinessLayerResult<UserListDto> DeleteUser(long userId);
        public BusinessLayerResult<UserListDto> GetUser(long id);

        public BusinessLayerResult<List<UserListDto>> Filter(UserFilter userFilter);
        public BusinessLayerResult<UserLoadMoreDto> FilterUserList(BaseLoadMoreFilter<UserFilter> filter);
        //public BusinessLayerResult<UserListDto> ChangeProfilePhoto(long userId, MediaDto mediaDto);
        public BusinessLayerResult<UserListDto> GetUserByUsername(string username);
    }
}
