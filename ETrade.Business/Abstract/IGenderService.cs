using ETrade.Dto.Dtos.Gender;
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
    public interface IGenderService:IManager<GenderEntity>
    {
        public BusinessLayerResult<GenderListDto> AddGender(GenderDto genderDto);
        public BusinessLayerResult<GenderListDto> UpdateGender(GenderDto genderDto);
        public BusinessLayerResult<GenderListDto> DeleteGender(long genderId);
        public BusinessLayerResult<GenderListDto> GetGender(long id);

        public BusinessLayerResult<List<GenderListDto>> Filter(GenderFilter genderFilter);
        public BusinessLayerResult<GenderLoadMoreDto> FilterGenderList(BaseLoadMoreFilter<GenderFilter> filter);
    }
}
