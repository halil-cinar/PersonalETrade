using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Core.Utils;
using ETrade.Dto.Dtos.Identity;
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
    public class IdentityManager : ManagerBase<IdentityEntity>
    {
       
        public IdentityManager(string userName, string ıpAddress, BaseEntityValidator<IdentityEntity> validator, IMapper mapper, IEntityDal<IdentityEntity> repository) : base(userName, ıpAddress, validator, mapper, repository)
        {
        }

        public BusinessLayerResult<IdentityListDto> AddIdentity(string password,string userName,long userId)
        {
            var response = new BusinessLayerResult<IdentityListDto>();
            using (var scope = new TransactionScope())
            {
                try
                {
                    var oldIdentities=GetAll(x=> x.UserId == userId&&x.isActive==true);
                    foreach(var oldIdentity in oldIdentities)
                    {
                        oldIdentity.isActive= false;
                        oldIdentity.UpdateIpAddress = IpAddress;
                        oldIdentity.UpdateTime = DateTime.Now;  
                        oldIdentity.UpdateUserName= userName;
                        Update(oldIdentity);
                    }
                    var entity = new IdentityEntity
                    {
                        PasswordSalt = ExtensionMethods.GenerateRandomString(13),
                        PasswordHash = "",
                        UserName = userName,
                        UserId = userId,
                        CreateTime = DateTime.Now,
                        CreateUserName = UserName,
                        CreateIPAddress = IpAddress,
                        IsDeleted = false,
                        LastTransaction = "Identity has been added"
                    };
                    entity.PasswordHash = ExtensionMethods.CalculateMD5Hash(password + entity.PasswordSalt);
                    var validationResult = Validator.Validate(entity);

                    if (validationResult.IsValid)
                    {
                        Add(entity);
                        response.Result = mapper.Map<IdentityListDto>(entity);
                    }
                    if (validationResult.Errors.Count > 0)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.IdentityAddIdentityValidationError, error.ErrorMessage);
                        }

                    }

                }
                catch (Exception ex)
                {
                    response.AddErrorMessages(ErrorMessageCode.IdentityAddIdentityExceptionError, ex.Message);
                }
            }
            return response;
        }

        public BusinessLayerResult<IdentityListDto> ChangePassword(IdentityDto identityDto)
        {
            var response = new BusinessLayerResult<IdentityListDto>();

            using (var scope = new TransactionScope())
            {
                try
                {

                    var entity = GetById(identityDto.Id);

                    if (entity != null)
                    {
                       var validationResult= Validator.Validate(entity);
                        if (validationResult.IsValid)
                        {
                            entity.IsDeleted = true;
                            Update(entity);
                        }
                        else
                        {
                            foreach(var error in validationResult.Errors)
                            {
                                response.AddErrorMessages(ErrorMessageCode.IdentityChangePasswordValidationError, error.ErrorMessage);

                            }
                        }
                        
                    }

                    var result = AddIdentity(identityDto.Password,identityDto.UserName,identityDto.UserId);




                    if (result.ErrorMessages.Count > 0)
                    {
                        scope.Dispose();
                        foreach (var error in result.ErrorMessages)
                        {
                            
                            response.AddErrorMessages(ErrorMessageCode.IdentityUpdateIdentityValidationError, error.Message);
                            
                        }
                        return response;
                    }

                    //Todo: sesion identity id guncellenecek?


                    scope.Complete();
                    scope.Dispose();    
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.IdentityUpdateIdentityExceptionError, ex.Message);
                }

            }
            return response;
        }

        //public BusinessLayerResult<IdentityListDto> DeleteIdentity(long identityId)
        //{
        //    var response = new BusinessLayerResult<IdentityListDto>();
        //    try
        //    {
        //        var entity = GetById(identityId);
        //        entity.IsDeleted = true;

        //        Update(entity);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.AddErrorMessages(ErrorMessageCode.IdentityDeleteIdentityExceptionError, ex.Message);
        //    }
        //    return response;
        //}

        //public BusinessLayerResult<List<IdentityListDto>> Filter(IdentityFilter identityFilter)
        //{
        //    var response = new BusinessLayerResult<List<IdentityListDto>>();
        //    try
        //    {
        //        var query = "select * from Identity where isDeleted=0 and ";

        //        if (identityFilter != null)
        //        {
        //            if (identityFilter.UserId != null)
        //            {
        //                query += $"userId= {identityFilter.UserId} and ";
        //            }
        //            if (!string.IsNullOrEmpty(identityFilter.Text))
        //            {
        //                query += $"text like '%{identityFilter.Text}%' and ";
        //            }
        //            if (!string.IsNullOrEmpty(identityFilter.Title!))
        //            {
        //                query += $"title like '%{identityFilter.Title}%' and ";
        //            }
        //            if (identityFilter.FirstDate != null)
        //            {
        //                query += $"identityDate > '{identityFilter.FirstDate}' and ";
        //            }
        //            if (identityFilter.LastDate != null)
        //            {
        //                query += $"identityDate < '{identityFilter.LastDate}' and ";
        //            }

        //        }
        //        if (query.EndsWith(" and "))
        //        {
        //            query = query.Substring(0, query.Length - " and ".Length);
        //        }

        //        response.Result = GetAll(query).Select(x => mapper.Map<IdentityListDto>(x)).ToList();


        //    }
        //    catch (Exception ex)
        //    {
        //        response.AddErrorMessages(ErrorMessageCode.IdentityFilterIdentityExceptionError, ex.Message);
        //    }

        //    return response;
        //}

        //public BusinessLayerResult<IdentityLoadMoreDto> FilterIdentityList(BaseLoadMoreFilter<IdentityFilter> filter)
        //{
        //    var response = new BusinessLayerResult<IdentityLoadMoreDto>();
        //    try
        //    {
        //        var result = new IdentityLoadMoreDto();
        //        List<IdentityListDto> contentList = new List<IdentityListDto>();
        //        if (filter.Filter == null)
        //        {
        //            contentList = GetAll().Select(x => mapper.Map<IdentityListDto>(x)).ToList();


        //        }
        //        else
        //        {
        //            var filterResult = Filter(filter.Filter);
        //            if (filterResult.ErrorMessages.Count > 0)
        //            {
        //                response.ErrorMessages.AddRange(filterResult.ErrorMessages.ToList());
        //            }
        //            else
        //            {
        //                contentList = filterResult.Result;
        //            }

        //        }

        //        var contentCount = contentList.Count;
        //        var firstIndex = filter.PageCount * contentCount;
        //        var lastIndex = firstIndex + contentCount;

        //        if (contentCount < firstIndex)
        //        {
        //            response.AddErrorMessages(ErrorMessageCode.IdentityFilterIdentityListError, "No more identity");
        //        }
        //        else
        //        {
        //            result.identityListDtos = new List<IdentityListDto>();
        //            for (int i = firstIndex; i < lastIndex; i++)
        //            {
        //                if (i > contentCount)
        //                {
        //                    break;
        //                }
        //                result.identityListDtos.Add(contentList[i]);
        //            }

        //            result.NextPage = (lastIndex < contentCount);

        //            result.PreviousPage = (firstIndex != 0);
        //        }
        //        response.Result = result;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.AddErrorMessages(ErrorMessageCode.IdentityFilterIdentityListExceptionError, ex.Message);
        //    }
        //    return response;
        //}

        private IdentityEntity GetIdentity(string username)
        {
            try
            {
                var entity = Get(x=>x.UserName.Equals(username));
                if (entity != null)
                {
                   return entity;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }

        public BusinessLayerResult<bool> CheckPassword(IdentityDto identityDto)
        {
            var response = new BusinessLayerResult<bool>();

            try
            {
                var identity = GetIdentity(identityDto.UserName);
                if (identity != null)
                {
                    var passwordHash=ExtensionMethods.CalculateMD5Hash(identityDto.Password+identity.PasswordSalt);
                    if(passwordHash.Equals(identity.PasswordHash))
                    {
                        response.Result = true;
                    }
                    else
                    {
                        response.Result = false;
                    }
                }
                else
                {
                    response.Result = false;
                }
            }catch(Exception ex)
            {
                response.Result = false;
                response.AddErrorMessages(ErrorMessageCode.IdentityCheckPasswordExceptionError,ex.Message);
            }
            return response;

        }
    }
}
