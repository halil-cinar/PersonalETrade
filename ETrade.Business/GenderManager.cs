using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Dto.Dtos.Gender;
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
    public class GenderManager : ManagerBase<GenderEntity>
    {
        public GenderManager(string userName, string ıpAddress, BaseEntityValidator<GenderEntity> validator, IMapper mapper, IEntityDal<GenderEntity> repository) : base(userName, ıpAddress, validator, mapper, repository)
        {
        }
        public BusinessLayerResult<GenderListDto> AddGender(GenderDto genderDto)
        {
            var response = new BusinessLayerResult<GenderListDto>();
            try
            {
                var entity = new GenderEntity
                {
                    Name= genderDto.Name,
                    CreateTime = DateTime.Now,
                    CreateUserName = UserName,
                    IsDeleted = false,
                    LastTransaction = "Gender has been added"
                };
                var validationResult = Validator.Validate(entity);

                if (validationResult.IsValid)
                {
                    Add(entity);
                    response.Result = mapper.Map<GenderListDto>(entity);
                }
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.GenderAddGenderValidationError, error.ErrorMessage);
                    }

                }

            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.GenderAddGenderExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<GenderListDto> UpdateGender(GenderDto genderDto)
        {
            var response = new BusinessLayerResult<GenderListDto>();

            try
            {
                var entity = GetById(genderDto.Id);
                if (entity != null)
                {
                    entity.Name= genderDto.Name;

                    entity.IsDeleted = false;
                    entity.LastTransaction = "Gender Updated";
                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<GenderListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.GenderUpdateGenderValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.GenderUpdateGenderExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<GenderListDto> DeleteGender(long genderId)
        {
            var response = new BusinessLayerResult<GenderListDto>();
            try
            {
                var entity = GetById(genderId);
                entity.IsDeleted = true;
                Update(entity);
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.GenderDeleteGenderExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<List<GenderListDto>> Filter(GenderFilter genderFilter)
        {
            var response = new BusinessLayerResult<List<GenderListDto>>();
            try
            {
                var query = "select * from Gender where isDeleted=0 and ";

                if (genderFilter != null)
                {
                    
                    if (!string.IsNullOrEmpty(genderFilter.Name))
                    {
                        query += $"name like '%{genderFilter.Name}%' and ";
                    }
                   

                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<GenderListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.GenderFilterGenderExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<GenderLoadMoreDto> FilterGenderList(BaseLoadMoreFilter<GenderFilter> filter)
        {
            var response = new BusinessLayerResult<GenderLoadMoreDto>();
            try
            {
                var result = new GenderLoadMoreDto();
                List<GenderListDto> contentList = new List<GenderListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<GenderListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.GenderFilterGenderListError, "No more gender");
                }
                else
                {
                    result.genderListDtos = new List<GenderListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.genderListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.GenderFilterGenderListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<GenderListDto> GetGender(long id)
        {
            var response = new BusinessLayerResult<GenderListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<GenderListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.GenderGetGenderNotFoundExceptionError, "Gender was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.GenderGetGenderExceptionError, ex.Message);
            }
            return response;
        }

    }
}
