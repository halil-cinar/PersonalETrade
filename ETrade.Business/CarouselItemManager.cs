using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.CarouselItem;
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

namespace ETrade.Business
{
    public class CarouselItemManager:ManagerBase<CarouselItemEntity>,ICarouselItemService
    {
        private readonly IMediaService _mediaManager;
        public CarouselItemManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
            _mediaManager = new MediaManager(userName,IpAddress);
        }
        public BusinessLayerResult<CarouselItemListDto> AddCarouselItem(CarouselItemDto carouselItemDto)
        {
            var response = new BusinessLayerResult<CarouselItemListDto>();
            using (var scope = new TransactionScope())
            {
                try
                {

                    long? imageId = carouselItemDto.BackgroudImageId;

                    if (imageId == null)
                    {
                        if (carouselItemDto.BackgroudImage == null)
                        {
                           
                            scope.Dispose();
                            response.AddErrorMessages(ErrorMessageCode.CarouselItemAddCarouselItemValidationError, "dto cannot be empty if id is null");
                            return response;
                        }
                        else
                        {

                            var mediaResult = _mediaManager.AddMedia(carouselItemDto.BackgroudImage);

                            if (mediaResult.ErrorMessages.Count > 0)
                            {
                                scope.Dispose();
                                response.ErrorMessages.AddRange(mediaResult.ErrorMessages);
                                return response;
                            }
                            imageId = mediaResult.Result.Id;
                        }
                    }


                    var entity = new CarouselItemEntity
                    {
                        BackgroudImageId = (long)imageId,
                        Link= carouselItemDto.Link,
                        Subtitle= carouselItemDto.Subtitle,
                        Title= carouselItemDto.Title,
                        

                        CreateIPAddress = IpAddress,
                        CreateTime = DateTime.Now,
                        CreateUserName = UserName,
                        isDeleted = false,
                        LastTransaction = "CarouselItem has been added"
                    };
                    var validationResult = Validator.Validate(entity);

                    if (validationResult.IsValid)
                    {

                        Add(entity);
                        response.Result = mapper.Map<CarouselItemListDto>(entity);
                        scope.Complete();
                        scope.Dispose();

                    }
                    if (validationResult.Errors.Count > 0)
                    {
                        scope.Dispose();
                        foreach (var error in validationResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.CarouselItemAddCarouselItemValidationError, error.ErrorMessage);
                        }

                    }

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.CarouselItemAddCarouselItemExceptionError, ex.Message);
                }
            }
            return response;
        }

        public BusinessLayerResult<CarouselItemListDto> UpdateCarouselItem(CarouselItemDto carouselItemDto)
        {
            var response = new BusinessLayerResult<CarouselItemListDto>();
            using (var scope = new TransactionScope())
            {


                try
                {


                    long? imageId = carouselItemDto.BackgroudImageId;

                    if (imageId == null)
                    {
                        if (carouselItemDto.BackgroudImage == null)
                        {
                            //imageId is nullable in carouselItem entity
                            //scope.Dispose();
                            //response.AddErrorMessages(ErrorMessageCode.CarouselItemAddCarouselItemValidationError, "dto cannot be empty if id is null");
                            //return response;
                        }
                        else
                        {

                            var mediaResult = _mediaManager.AddMedia(carouselItemDto.BackgroudImage);

                            if (mediaResult.ErrorMessages.Count > 0)
                            {
                                scope.Dispose();
                                response.ErrorMessages.AddRange(mediaResult.ErrorMessages);
                                return response;
                            }
                            imageId = mediaResult.Result.Id;
                        }
                    }



                    var entity = GetById(carouselItemDto.Id);
                    if (entity != null)
                    {
                        entity.BackgroudImageId = (long)imageId;
                        entity.Link = carouselItemDto.Link;
                        entity.Subtitle = carouselItemDto.Subtitle;
                        entity.Title = carouselItemDto.Title;

                        entity.isDeleted = false;
                        entity.LastTransaction = "CarouselItem Updated";
                        entity.UpdateIpAddress = IpAddress;
                        entity.UpdateTime = DateTime.Now;
                        entity.UpdateUserName = UserName;
                    }
                    var validatorResult = UpdateValidator.Validate(entity);

                    if (validatorResult.IsValid)
                    {
                        Update(entity);
                        response.Result = mapper.Map<CarouselItemListDto>(entity);
                    }
                    if (validatorResult.Errors.Count > 0)
                    {
                        scope.Dispose();
                        foreach (var error in validatorResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.CarouselItemUpdateCarouselItemValidationError, error.ErrorMessage);

                        }
                    }
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.CarouselItemUpdateCarouselItemExceptionError, ex.Message);
                }
            }
            return response;
        }

        public BusinessLayerResult<CarouselItemListDto> DeleteCarouselItem(long carouselItemId)
        {
            var response = new BusinessLayerResult<CarouselItemListDto>();
            try
            {
                var entity = GetById(carouselItemId);
                entity.isDeleted = true;
                Update(entity);
                response.Result = mapper.Map<CarouselItemListDto>(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CarouselItemDeleteCarouselItemExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<CarouselItemListDto>> Filter(CarouselItemFilter carouselItemFilter)
        {
            var response = new BusinessLayerResult<List<CarouselItemListDto>>();
            try
            {
                var query = "select * from CarouselItem where isDeleted=0 and ";

                if (carouselItemFilter != null)
                {
                    if (!string.IsNullOrEmpty(carouselItemFilter.Title))
                    {
                        query += $"title like '%{carouselItemFilter.Title}%' and ";
                    }
                    if (!string.IsNullOrEmpty(carouselItemFilter.Link))
                    {
                        query += $"link like '%{carouselItemFilter.Link}%' and ";
                    }
                    if (!string.IsNullOrEmpty(carouselItemFilter.Subtitle))
                    {
                        query += $"subtitle like '%{carouselItemFilter.Subtitle}%' and ";
                    }


                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<CarouselItemListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CarouselItemFilterCarouselItemExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<CarouselItemLoadMoreDto> FilterCarouselItemList(BaseLoadMoreFilter<CarouselItemFilter> filter)
        {
            var response = new BusinessLayerResult<CarouselItemLoadMoreDto>();
            try
            {
                var result = new CarouselItemLoadMoreDto();
                List<CarouselItemListDto> contentList = new List<CarouselItemListDto>();

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
                    response.AddErrorMessages(ErrorMessageCode.CarouselItemFilterCarouselItemListError, "No more carouselItem");
                }
                else
                {
                    result.CarouselItemListDtos = new List<CarouselItemListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i >= contentCount)
                        {
                            break;
                        }
                        result.CarouselItemListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CarouselItemFilterCarouselItemListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<CarouselItemListDto> GetCarouselItem(long carouselItemId)
        {
            var response = new BusinessLayerResult<CarouselItemListDto>();
            try
            {
                var entity = GetById(carouselItemId);
                response.Result = mapper.Map<CarouselItemListDto>(entity);
                // response.Result.Country = entity.Country;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.CarouselItemDeleteCarouselItemExceptionError, ex.Message);
            }
            return response;
        }




    }
}

