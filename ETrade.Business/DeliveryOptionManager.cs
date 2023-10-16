using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.DeliveryOption;
using ETrade.Dto.Errors;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using ETrade.Entities.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ETrade.Business
{
    public class DeliveryOptionManager : ManagerBase<DeliveryOptionEntity>,IDeliveryOptionService
    {
        private readonly IMediaService _mediaManager;
        public DeliveryOptionManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
            _mediaManager = new MediaManager(userName,ıpAddress);
        }
        public BusinessLayerResult<DeliveryOptionListDto> AddDeliveryOption(DeliveryOptionDto deliveryOptionDto)
        {
            var response = new BusinessLayerResult<DeliveryOptionListDto>();
            using (var scope = new TransactionScope())
            {
                try
                {

                    long? imageId = deliveryOptionDto.LogoId;

                    if (imageId == null)
                    {
                        if (deliveryOptionDto.Logo == null)
                        {
                            //imageId is nullable in deliveryOption entity
                            //scope.Dispose();
                            //response.AddErrorMessages(ErrorMessageCode.DeliveryOptionAddDeliveryOptionValidationError, "dto cannot be empty if id is null");
                            //return response;
                        }
                        else
                        {

                            var mediaResult = _mediaManager.AddMedia(deliveryOptionDto.Logo);

                            if (mediaResult.ErrorMessages.Count > 0)
                            {
                                scope.Dispose();
                                response.ErrorMessages.AddRange(mediaResult.ErrorMessages);
                                return response;
                            }
                            imageId = mediaResult.Result.Id;
                        }
                    }


                    var entity = new DeliveryOptionEntity
                    {

                        LogoId = imageId,
                        BrandName = deliveryOptionDto.BrandName,
                        IsFree = deliveryOptionDto.IsFree,
                        IsSentAbroad = deliveryOptionDto.IsSentAbroad,


                        CreateIPAddress = IpAddress,
                        CreateTime = DateTime.Now,
                        CreateUserName = UserName,
                        isDeleted = false,
                        LastTransaction = "DeliveryOption has been added"
                    };
                    var validationResult = Validator.Validate(entity);

                    if (validationResult.IsValid)
                    {

                        Add(entity);
                        response.Result = mapper.Map<DeliveryOptionListDto>(entity);
                        scope.Complete();
                        scope.Dispose();

                    }
                    if (validationResult.Errors.Count > 0)
                    {
                        scope.Dispose();
                        foreach (var error in validationResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.DeliveryOptionAddDeliveryOptionValidationError, error.ErrorMessage);
                        }

                    }

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.DeliveryOptionAddDeliveryOptionExceptionError, ex.Message);
                }
            }
            return response;
        }

        public BusinessLayerResult<DeliveryOptionListDto> UpdateDeliveryOption(DeliveryOptionDto deliveryOptionDto)
        {
            var response = new BusinessLayerResult<DeliveryOptionListDto>();
            using (var scope = new TransactionScope())
            {


                try
                {


                    long? imageId = deliveryOptionDto.LogoId;

                    if (imageId == null)
                    {
                        if (deliveryOptionDto.Logo == null)
                        {
                            //imageId is nullable in deliveryOption entity
                            //scope.Dispose();
                            //response.AddErrorMessages(ErrorMessageCode.DeliveryOptionAddDeliveryOptionValidationError, "dto cannot be empty if id is null");
                            //return response;
                        }
                        else
                        {

                            var mediaResult = _mediaManager.AddMedia(deliveryOptionDto.Logo);

                            if (mediaResult.ErrorMessages.Count > 0)
                            {
                                scope.Dispose();
                                response.ErrorMessages.AddRange(mediaResult.ErrorMessages);
                                return response;
                            }
                            imageId = mediaResult.Result.Id;
                        }
                    }



                    var entity = GetById(deliveryOptionDto.Id);
                    if (entity != null)
                    {
                        entity.LogoId = imageId;
                        entity.BrandName = deliveryOptionDto.BrandName;
                        entity.IsFree = deliveryOptionDto.IsFree;
                        entity.IsSentAbroad = deliveryOptionDto.IsSentAbroad;

                        entity.isDeleted = false;
                        entity.LastTransaction = "DeliveryOption Updated";
                        entity.UpdateIpAddress = IpAddress;
                        entity.UpdateTime = DateTime.Now;
                        entity.UpdateUserName = UserName;
                    }
                    var validatorResult = UpdateValidator.Validate(entity);

                    if (validatorResult.IsValid)
                    {
                        Update(entity);
                        response.Result = mapper.Map<DeliveryOptionListDto>(entity);
                    }
                    if (validatorResult.Errors.Count > 0)
                    {
                        scope.Dispose();
                        foreach (var error in validatorResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.DeliveryOptionUpdateDeliveryOptionValidationError, error.ErrorMessage);

                        }
                    }
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.DeliveryOptionUpdateDeliveryOptionExceptionError, ex.Message);
                }
            }
            return response;
        }

        public BusinessLayerResult<DeliveryOptionListDto> DeleteDeliveryOption(long deliveryOptionId)
        {
            var response = new BusinessLayerResult<DeliveryOptionListDto>();
            try
            {
                var entity = GetById(deliveryOptionId);
                entity.isDeleted = true;
                Update(entity);
                response.Result = mapper.Map<DeliveryOptionListDto>(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.DeliveryOptionDeleteDeliveryOptionExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<DeliveryOptionListDto>> Filter(DeliveryOptionFilter deliveryOptionFilter)
        {
            var response = new BusinessLayerResult<List<DeliveryOptionListDto>>();
            try
            {
                var query = "select * from DeliveryOption where isDeleted=0 and ";

                if (deliveryOptionFilter != null)
                {
                    if (!string.IsNullOrEmpty(deliveryOptionFilter.BrandName))
                    {
                        query += $"brandName like '%{deliveryOptionFilter.BrandName}%' and ";
                    }
                    if (deliveryOptionFilter.IsFree != null)
                    {
                        query += $"isFree ={deliveryOptionFilter.IsFree} and ";
                    }
                    if (deliveryOptionFilter.IsSentAbroad != null)
                    {
                        query += $"isFree ={deliveryOptionFilter.IsSentAbroad} and ";
                    }
                    if (deliveryOptionFilter.SellerId != null)
                    {
                        query += $"sellerId ={deliveryOptionFilter.SellerId} and ";
                    }
                    if (deliveryOptionFilter.MinPrice != null)
                    {
                        query += $"price >={deliveryOptionFilter.MinPrice} and ";
                    }
                    if (deliveryOptionFilter.MaxPrice != null)
                    {
                        query += $"price <={deliveryOptionFilter.MaxPrice} and ";
                    }




                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<DeliveryOptionListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.DeliveryOptionFilterDeliveryOptionExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<DeliveryOptionLoadMoreDto> FilterDeliveryOptionList(BaseLoadMoreFilter<DeliveryOptionFilter> filter)
        {
            var response = new BusinessLayerResult<DeliveryOptionLoadMoreDto>();
            try
            {
                var result = new DeliveryOptionLoadMoreDto();
                List<DeliveryOptionListDto> contentList = new List<DeliveryOptionListDto>();

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
                    response.AddErrorMessages(ErrorMessageCode.DeliveryOptionFilterDeliveryOptionListError, "No more deliveryOption");
                }
                else
                {
                    result.DeliveryOptionListDtos = new List<DeliveryOptionListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i >= contentCount)
                        {
                            break;
                        }
                        result.DeliveryOptionListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.DeliveryOptionFilterDeliveryOptionListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<DeliveryOptionListDto> GetDeliveryOption(long deliveryOptionId)
        {
            var response = new BusinessLayerResult<DeliveryOptionListDto>();
            try
            {
                var entity = GetById(deliveryOptionId);
                response.Result = mapper.Map<DeliveryOptionListDto>(entity);
                // response.Result.Country = entity.Country;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.DeliveryOptionDeleteDeliveryOptionExceptionError, ex.Message);
            }
            return response;
        }




    }
}

