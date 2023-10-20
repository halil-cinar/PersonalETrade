using ETrade.Dto.Dtos.UserFavourite;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business.Abstract
{
    public interface IUserFavouriteService:IManager<UserFavouriteEntity>
    {
        public BusinessLayerResult<UserFavouriteListDto> AddUserFavourite(UserFavouriteDto userfavouriteDto);
        public BusinessLayerResult<UserFavouriteListDto> UpdateUserFavourite(UserFavouriteDto userfavouriteDto);
        public BusinessLayerResult<UserFavouriteListDto> DeleteUserFavourite(long userfavouriteId);
        public BusinessLayerResult<UserFavouriteListDto> GetUserFavourite(long id);

        public BusinessLayerResult<List<UserFavouriteListDto>> Filter(UserFavouriteFilter userfavouriteFilter);
        public BusinessLayerResult<UserFavouriteLoadMoreDto> FilterUserFavouriteList(BaseLoadMoreFilter<UserFavouriteFilter> filter);
    }
}

