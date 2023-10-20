using ETrade.Dto.Dtos.SystemSettings;
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
    public interface ISystemSettingsService:IManager<SystemSettingsEntity>
    {
        public BusinessLayerResult<SystemSettingsListDto> AddSystemSettings(SystemSettingsDto systemsettingsDto);
        public BusinessLayerResult<SystemSettingsListDto> UpdateSystemSettings(SystemSettingsDto systemsettingsDto);
        public BusinessLayerResult<SystemSettingsListDto> DeleteSystemSettings(long systemsettingsId);
        public BusinessLayerResult<SystemSettingsListDto> GetSystemSettings(long id);

        public BusinessLayerResult<List<SystemSettingsListDto>> Filter(SystemSettingsFilter systemsettingsFilter);
        public BusinessLayerResult<SystemSettingsLoadMoreDto> FilterSystemSettingsList(BaseLoadMoreFilter<SystemSettingsFilter> filter);
    }
}

