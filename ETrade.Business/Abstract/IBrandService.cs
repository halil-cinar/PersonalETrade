using ETrade.Dto.Dtos.Brand;
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
    public interface IBrandService:IManager<BrandEntity>
    {
        public BusinessLayerResult<BrandListDto> AddBrand(BrandDto brandDto);
        public BusinessLayerResult<BrandListDto> UpdateBrand(BrandDto brandDto);
        public BusinessLayerResult<BrandListDto> DeleteBrand(long brandId);
        public BusinessLayerResult<BrandListDto> GetBrand(long id);

        public BusinessLayerResult<List<BrandListDto>> Filter(BrandFilter brandFilter);
        public BusinessLayerResult<BrandLoadMoreDto> FilterBrandList(BaseLoadMoreFilter<BrandFilter> filter);
    }
}
