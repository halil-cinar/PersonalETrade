using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.Brand;
using ETrade.Dto.Errors;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using ETrade.Entities.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace ETrade.Business
{
    public class BrandManager : ManagerBase<BrandEntity>,IBrandService
    {
        private readonly IMediaService _mediaManager;
        public BrandManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
            _mediaManager = new MediaManager(userName, IpAddress);
        }
        public BusinessLayerResult<BrandListDto> AddBrand(BrandDto brandDto)
        {
            var response = new BusinessLayerResult<BrandListDto>();
            using (var scope = new TransactionScope())
            {
                try
                {

                    long? imageId = brandDto.ImageId;

                    if (imageId == null)
                    {
                        if (brandDto.ImageDto == null)
                        {
                            //imageId is nullable in brand entity
                            //scope.Dispose();
                            //response.AddErrorMessages(ErrorMessageCode.BrandAddBrandValidationError, "dto cannot be empty if id is null");
                            //return response;
                        }
                        else
                        {

                            var mediaResult = _mediaManager.AddMedia(brandDto.ImageDto);

                            if (mediaResult.ErrorMessages.Count > 0)
                            {
                                scope.Dispose();
                                response.ErrorMessages.AddRange(mediaResult.ErrorMessages);
                                return response;
                            }
                            imageId = mediaResult.Result.Id;
                        }
                    }


                    var entity = new BrandEntity
                    {
                        ImageId = imageId,
                        BrandName = brandDto.BrandName,
                        CreateIPAddress = IpAddress,
                        CreateTime = DateTime.Now,
                        CreateUserName = UserName,
                        isDeleted = false,
                        LastTransaction = "Brand has been added"
                    };
                    var validationResult = Validator.Validate(entity);

                    if (validationResult.IsValid)
                    {
                        
                        Add(entity);
                        response.Result = mapper.Map<BrandListDto>(entity);
                        scope.Complete();
                        scope.Dispose();

                    }
                    if (validationResult.Errors.Count > 0)
                    {
                        scope.Dispose();
                        foreach (var error in validationResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.BrandAddBrandValidationError, error.ErrorMessage);
                        }

                    }

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.BrandAddBrandExceptionError, ex.Message);
                }
            }
            return response;
        }

        public BusinessLayerResult<BrandListDto> UpdateBrand(BrandDto brandDto)
        {
            var response = new BusinessLayerResult<BrandListDto>();
            using (var scope = new TransactionScope())
            {


                try
                {


                    long? imageId = brandDto.ImageId;

                    if (imageId == null)
                    {
                        if (brandDto.ImageDto == null)
                        {
                            //imageId is nullable in brand entity
                            //scope.Dispose();
                            //response.AddErrorMessages(ErrorMessageCode.BrandAddBrandValidationError, "dto cannot be empty if id is null");
                            //return response;
                        }
                        else
                        {

                            var mediaResult = _mediaManager.AddMedia(brandDto.ImageDto);

                            if (mediaResult.ErrorMessages.Count > 0)
                            {
                                scope.Dispose();
                                response.ErrorMessages.AddRange(mediaResult.ErrorMessages);
                                return response;
                            }
                            imageId = mediaResult.Result.Id;
                        }
                    }



                    var entity = GetById(brandDto.Id);
                    if (entity != null)
                    {
                        entity.ImageId = brandDto.ImageId;
                        entity.BrandName = brandDto.BrandName;

                        entity.isDeleted = false;
                        entity.LastTransaction = "Brand Updated";
                        entity.UpdateIpAddress = IpAddress;
                        entity.UpdateTime = DateTime.Now;
                        entity.UpdateUserName = UserName;
                    }
                    var validatorResult = UpdateValidator.Validate(entity);

                    if (validatorResult.IsValid)
                    {
                        Update(entity);
                        response.Result = mapper.Map<BrandListDto>(entity);
                    }
                    if (validatorResult.Errors.Count > 0)
                    {
                        scope.Dispose();
                        foreach (var error in validatorResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.BrandUpdateBrandValidationError, error.ErrorMessage);

                        }
                    }
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.BrandUpdateBrandExceptionError, ex.Message);
                }
            }
            return response;
        }

        public BusinessLayerResult<BrandListDto> DeleteBrand(long brandId)
        {
            var response = new BusinessLayerResult<BrandListDto>();
            try
            {
                var entity = GetById(brandId);
                entity.isDeleted = true;
                Update(entity);
                response.Result = mapper.Map<BrandListDto>(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.BrandDeleteBrandExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<BrandListDto>> Filter(BrandFilter brandFilter)
        {
            var response = new BusinessLayerResult<List<BrandListDto>>();
            try
            {
                var query = "select * from Brand where isDeleted=0 and ";

                if (brandFilter != null)
                {
                    if (!string.IsNullOrEmpty(brandFilter.BrandName))
                    {
                        query += $"brandName like '%{brandFilter.BrandName}%' and ";
                    }

                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<BrandListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.BrandFilterBrandExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<BrandLoadMoreDto> FilterBrandList(BaseLoadMoreFilter<BrandFilter> filter)
        {
            var response = new BusinessLayerResult<BrandLoadMoreDto>();
            try
            {
                var result = new BrandLoadMoreDto();
                List<BrandListDto> contentList = new List<BrandListDto>();

                var filterResult = Filter(filter.Filter);
                if (filterResult.ErrorMessages.Count > 0)
                {
                    response.ErrorMessages.AddRange(filterResult.ErrorMessages.ToList());
                }
                else
                {
                    contentList = filterResult.Result;
                }



                var contentCount = contentList.Count;
                var firstIndex = filter.PageCount * filter.ContentCount;
                var lastIndex = firstIndex + filter.ContentCount;

                if (contentCount <= firstIndex)
                {
                    response.AddErrorMessages(ErrorMessageCode.BrandFilterBrandListError, "No more brand");
                }
                else
                {
                    result.BrandListDtos = new List<BrandListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i >= contentCount)
                        {
                            break;
                        }
                        result.BrandListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.BrandFilterBrandListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<BrandListDto> GetBrand(long brandId)
        {
            var response = new BusinessLayerResult<BrandListDto>();
            try
            {
                var entity = GetById(brandId);
                response.Result = mapper.Map<BrandListDto>(entity);
                // response.Result.Country = entity.Country;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.BrandDeleteBrandExceptionError, ex.Message);
            }
            return response;
        }

        


    }
}
