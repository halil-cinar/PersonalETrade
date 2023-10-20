using ETrade.Dto.Dtos.UserSettings;
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
    public interface IUserSettingsService:IManager<UserSettingsEntity>
    {
        public BusinessLayerResult<UserSettingsListDto> AddUserSettings(UserSettingsDto usersettingsDto);
        public BusinessLayerResult<UserSettingsListDto> UpdateUserSettings(UserSettingsDto usersettingsDto);
        public BusinessLayerResult<UserSettingsListDto> DeleteUserSettings(long usersettingsId);
        public BusinessLayerResult<UserSettingsListDto> GetUserSettings(long id);

        public BusinessLayerResult<List<UserSettingsListDto>> Filter(UserSettingsFilter usersettingsFilter);
        public BusinessLayerResult<UserSettingsLoadMoreDto> FilterUserSettingsList(BaseLoadMoreFilter<UserSettingsFilter> filter);
    }
}

