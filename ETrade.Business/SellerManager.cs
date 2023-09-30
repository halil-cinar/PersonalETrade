using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.Seller;
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

namespace ETrade.Business
{
    public class SellerManager:ManagerBase<SellerEntity>
    {
        public SellerManager(string userName, string ıpAddress, BaseEntityValidator<SellerEntity> validator, IMapper mapper, IEntityDal<SellerEntity> repository) : base(userName, ıpAddress, validator, mapper, repository)
        {
        }

        public BusinessLayerResult<SellerListDto> AddSeller(SellerDto sellerDto)
        {
            var response = new BusinessLayerResult<SellerListDto>();
            try
            {
                var entity = new SellerEntity
                {
                    Description= sellerDto.Description,
                    Name= sellerDto.Name,
                    Rating= 5.0,
                    
                    UserId = sellerDto.UserId,
                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    CreateIPAddress = IpAddress,
                    IsDeleted = false,
                    LastTransaction = "Seller has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<SellerListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.SellerAddSellerValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SellerAddSellerExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SellerListDto> UpdateSeller(SellerDto sellerDto)
        {
            var response = new BusinessLayerResult<SellerListDto>();

            try
            {
                var entity = GetById(sellerDto.Id);
                if (entity != null)
                {
                    entity.Description= sellerDto.Description;
                    entity.Name= sellerDto.Name;
                    
                    entity.UserId = sellerDto.UserId;


                    entity.IsDeleted = false;
                    entity.LastTransaction = "Seller Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<SellerListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.SellerUpdateSellerValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SellerUpdateSellerExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SellerListDto> DeleteSeller(long sellerId)
        {
            var response = new BusinessLayerResult<SellerListDto>();
            try
            {
                var entity = GetById(sellerId);
                entity.IsDeleted = true;
                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SellerDeleteSellerExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<SellerListDto>> Filter(SellerFilter sellerFilter)
        {
            var response = new BusinessLayerResult<List<SellerListDto>>();
            try
            {
                var query = "select * from Seller where isDeleted=0 and ";

                if (sellerFilter != null)
                {
                    if (sellerFilter.UserId != null)
                    {
                        query += $"userId= {sellerFilter.UserId} and ";
                    }
                    if (!string.IsNullOrEmpty(sellerFilter.Text))
                    {
                        query += $"text like '%{sellerFilter.Text}%' and ";
                    }
                    if (!string.IsNullOrEmpty(sellerFilter.Title!))
                    {
                        query += $"title like '%{sellerFilter.Title}%' and ";
                    }
                    

                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<SellerListDto>(x)).ToList();

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SellerFilterSellerExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<SellerLoadMoreDto> FilterSellerList(BaseLoadMoreFilter<SellerFilter> filter)
        {
            var response = new BusinessLayerResult<SellerLoadMoreDto>();
            try
            {
                var result = new SellerLoadMoreDto();
                List<SellerListDto> contentList = new List<SellerListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<SellerListDto>(x)).ToList();


                }
                else
                {
                    var filterResult = Filter(filter.Filter);
                    if (filterResult.ErrorMessages.Count > 0)
                    {
                        response.ErrorMessages.AddRange(filterResult.ErrorMessages.ToList());
                    }
                    else
                    {
                        contentList = filterResult.Result;
                    }

                }

                var contentCount = contentList.Count;
                var firstIndex = filter.PageCount * contentCount;
                var lastIndex = firstIndex + contentCount;

                if (contentCount < firstIndex)
                {
                    response.AddErrorMessages(ErrorMessageCode.SellerFilterSellerListError, "No more seller");
                }
                else
                {
                    result.sellerListDtos = new List<SellerListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.sellerListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SellerFilterSellerListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<SellerListDto> GetSeller(long id)
        {
            var response = new BusinessLayerResult<SellerListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<SellerListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.SellerGetSellerNotFoundExceptionError, "Seller was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.SellerGetSellerExceptionError, ex.Message);
            }
            return response;
        }

    }
}
