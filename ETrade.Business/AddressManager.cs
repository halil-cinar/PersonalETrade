using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.Address;
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

namespace ETrade.Business
{
    public class AddressManager : ManagerBase<AddressEntity>,IAddressService
    {
        public AddressManager(string userName, string ıpAddress) : base(userName, ıpAddress)
        {
        }

        public BusinessLayerResult<AddressListDto> AddAddress(AddressDto addressDto)
        {
            var response=new BusinessLayerResult<AddressListDto>();
            try
            {
                var entity = new AddressEntity
                {
                    Address = addressDto.Address,
                    City = addressDto.City,
                    CountryId = addressDto.CountryId,
                    PhoneNumber = addressDto.PhoneNumber,
                    PostalCode = addressDto.PostalCode,

                    CreateIPAddress = IpAddress,
                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    isDeleted = false,
                    LastTransaction = "Address has been added"
                };
                var validationResult=Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result=mapper.Map<AddressListDto>(entity);

                }
                if(validationResult.Errors.Count > 0)
                {
                    foreach(var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.AddressAddAddressValidationError, error.ErrorMessage);
                    }
                   
                }

            }catch(Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AddressAddAddressExceptionError,ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<AddressListDto> UpdateAddress(AddressDto addressDto)
        {
            var response= new BusinessLayerResult<AddressListDto>();

            try
            {
                var entity = GetById(addressDto.Id);
                if (entity != null)
                {
                    entity.City = addressDto.City;
                    entity.Address = addressDto.Address;
                    entity.PhoneNumber = addressDto.PhoneNumber;
                    entity.PostalCode = addressDto.PostalCode;
                    entity.CountryId = addressDto.CountryId;
                    
                    entity.isDeleted = false;
                    entity.LastTransaction = "Address Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime=DateTime.Now;
                    entity.UpdateUserName= UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if(validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result=mapper.Map<AddressListDto>(entity);
                }
                if(validatorResult.Errors.Count > 0)
                {
                    foreach(var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.AddressUpdateAddressValidationError, error.ErrorMessage);

                    }
                }
            }catch(Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AddressUpdateAddressExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<AddressListDto> DeleteAddress(long addressId)
        {
            var response=new BusinessLayerResult<AddressListDto>(); 
            try
            {
                var entity = GetById(addressId);
                entity.isDeleted = true;
                Update(entity);
                response.Result= mapper.Map<AddressListDto>(entity);
            }catch(Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AddressDeleteAddressExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<AddressListDto>> Filter(AddressFilter addressFilter)
        {
            var response = new BusinessLayerResult<List<AddressListDto>>();
            try
            {
                var query = "select * from Address where isDeleted = 0 and ";

                if (addressFilter != null)
                {
                    if (addressFilter.CountryId != null)
                    {
                        query += $"countryId= {addressFilter.CountryId} and ";
                    }
                    if (!string.IsNullOrEmpty(addressFilter.Address))
                    {
                        query += $"address like '%{addressFilter.Address}%' and ";
                    }
                    if (!string.IsNullOrEmpty(addressFilter.PhoneNumber !))
                    {
                        query += $"countryId like '%{addressFilter.PhoneNumber}%' and ";
                    }
                    if (!string.IsNullOrEmpty(addressFilter.PostalCode ))
                    {
                        query += $"countryId like '%{addressFilter.PostalCode}%' and ";
                    }
                    if (!string.IsNullOrEmpty(addressFilter.City ))
                    {
                        query += $"countryId like '%{addressFilter.City}%' and ";
                    }

                }
                if(query.EndsWith(" and "))
                {
                    query=query.Substring(0,query.Length - " and ".Length);
                }

                response.Result=GetAll(query).Select(x=>mapper.Map<AddressListDto>(x)).ToList();

                
            }catch(Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AddressFilterAddressExceptionError, ex.Message);
            }

            return response;
        }

       
        public BusinessLayerResult<AddressLoadMoreDto> FilterAddressList(BaseLoadMoreFilter<AddressFilter> filter)
        {
            var response=new BusinessLayerResult<AddressLoadMoreDto>();
            try
            {
                var result=new AddressLoadMoreDto();
                List<AddressListDto> contentList=new List<AddressListDto>();
               
                   var filterResult=Filter(filter.Filter);
                    if (filterResult.ErrorMessages.Count>0)
                    {
                        response.ErrorMessages.AddRange(filterResult.ErrorMessages.ToList());
                    }
                    else
                    {
                        contentList=filterResult.Result;
                    }

                

                var contentCount=contentList.Count;
                var firstIndex = filter.PageCount * filter.ContentCount;
                var lastIndex = firstIndex + filter.ContentCount;

                if (contentCount <= firstIndex )
                {
                    response.AddErrorMessages(ErrorMessageCode.AddressFilterAddressListError, "No more address");
                }
                else
                {
                    result.addressListDtos = new List<AddressListDto>();
                    for(int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i >= contentCount)
                        {
                            break;
                        }
                        result.addressListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);
                    
                    result.PreviousPage= (firstIndex!=0);
                }
                response.Result=result;
            }catch(Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AddressFilterAddressListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<AddressListDto> GetAddress(long addressId)
        {
            var response = new BusinessLayerResult<AddressListDto>();
            try
            {
                var entity = GetById(addressId);
                response.Result=mapper.Map<AddressListDto>(entity);
               // response.Result.Country = entity.Country;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.AddressDeleteAddressExceptionError, ex.Message);
            }
            return response;
        }

    }
}
