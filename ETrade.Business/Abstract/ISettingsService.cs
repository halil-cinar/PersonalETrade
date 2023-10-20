using ETrade.Dto.Dtos.Settings;
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
    public interface ISettingsService:IManager<SettingsEntity>
    {
        public BusinessLayerResult<SettingsListDto> AddSettings(SettingsDto settingsDto);
        public BusinessLayerResult<SettingsListDto> UpdateSettings(SettingsDto settingsDto);
        public BusinessLayerResult<SettingsListDto> DeleteSettings(long settingsId);
        public BusinessLayerResult<SettingsListDto> GetSettings(long id);

        public BusinessLayerResult<List<SettingsListDto>> Filter(SettingsFilter settingsFilter);
        public BusinessLayerResult<SettingsLoadMoreDto> FilterSettingsList(BaseLoadMoreFilter<SettingsFilter> filter);
    }
}

