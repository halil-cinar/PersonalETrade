using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Core.ExtensionMethods;
using ETrade.Core.Utils;
using ETrade.Dto.Dtos.Media;
using ETrade.Dto.Dtos.User;
using ETrade.Dto.Dtos.UserRole;
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
using System.Xml.XPath;

namespace ETrade.Business
{
    public class UserManager : ManagerBase<UserEntity>
    {
        private readonly MediaManager _mediaManager;
        private readonly UserRoleManager _userRoleManager;
        private readonly IdentityManager _identityManager;
        public UserManager(string userName, string ıpAddress, BaseEntityValidator<UserEntity> validator, IMapper mapper, IEntityDal<UserEntity> repository, MediaManager mediaManager, UserRoleManager userRoleManager, IdentityManager identityManager) : base(userName, ıpAddress, validator, mapper, repository)
        {
            _mediaManager = mediaManager;
            _userRoleManager = userRoleManager;
            _identityManager = identityManager;
        }


        public BusinessLayerResult<UserListDto> AddUser(UserDto userDto)
        {
            var response = new BusinessLayerResult<UserListDto>();
            using (var scope = new TransactionScope())
            {

                try
                {
                    //Add User
                    var entity = new UserEntity
                    {
                        BirthDate = userDto.BirthDate,
                        Email = userDto.Email,
                        Gender = userDto.Gender,
                        
                        Name = userDto.Name,
                        Surname = userDto.Surname,
                        Phone = userDto.Phone,
                        ProfilePhotoId = null,


                        CreateTime = DateTime.Now,
                        CreateUserName = UserName,
                        CreateIPAddress = IpAddress,
                        IsDeleted = false,
                        LastTransaction = "User has been added"
                    };
                    var validationResult = Validator.Validate(entity);

                    if (validationResult.IsValid)
                    {
                        Add(entity);
                        response.Result = mapper.Map<UserListDto>(entity);
                    }
                    if (validationResult.Errors.Count > 0)
                    {

                        foreach (var error in validationResult.Errors)
                        {
                            response.AddErrorMessages(ErrorMessageCode.UserAddUserValidationError, error.ErrorMessage);
                        }
                        scope.Dispose();
                        return response;

                    }

                    //Add Role
                    foreach (var roleId in userDto.RoleIds)
                    {
                        var userRole = new UserRoleDto
                        {
                            IsActive = true,
                            RoleId = roleId,
                            UserId = entity.ID,
                        };
                        var result = _userRoleManager.AddUserRole(userRole);
                        if (result.ErrorMessages.Count > 0)
                        {
                            foreach (var error in result.ErrorMessages)
                            {
                                response.AddErrorMessages(ErrorMessageCode.UserAddUserValidationError, error.Message);
                            }
                            scope.Dispose();
                            return response;
                        }

                    }

                    //Add Identity
                    if (userDto.Identity == null)
                    {
                        var password = ExtensionMethods.GenerateRandomPassword(6);
                        userDto.Identity = new Dto.Dtos.Identity.IdentityDto
                        {
                            isActive= true,
                            UserId= entity.ID,
                            UserName= entity.Name+"."+entity.Surname,
                            Password=password,
                            ConfirmPassword=password,
                        };
                    }
                    
                    var identityResult = _identityManager.AddIdentity(userDto.Identity.Password,userDto.Identity.UserName, entity.ID);
                    if (identityResult.ErrorMessages.Count > 0)
                    {
                        foreach (var error in identityResult.ErrorMessages)
                        {
                            response.AddErrorMessages(ErrorMessageCode.UserAddUserValidationError, error.Message);
                        }
                        scope.Dispose();
                        return response;
                    }

                    //Send EMail
                    var mailSender = new MailSender();
                    mailSender.SendEmail(entity.Email, "Hoş Geldiniz!!", "" +
                        $"Kullanıcı Adınız: {userDto.Identity.UserName} \n Şifre: {userDto.Identity.Password}");
                    scope.Complete();
                    return response;


                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.UserAddUserExceptionError, ex.Message);
                   
                }
            }
            return response;
        }

        public BusinessLayerResult<UserListDto> UpdateUser(UserDto userDto)
        {
            var response = new BusinessLayerResult<UserListDto>();

            try
            {
                var entity = GetById(userDto.Id);
                if (entity != null)
                {
                    entity.Surname = userDto.Surname;
                    entity.Phone = userDto.Phone;
                    entity.Email = userDto.Email;
                    entity.Name = userDto.Name;
                    entity.BirthDate = userDto.BirthDate;
                    entity.Gender = userDto.Gender;
                    entity.IsDeleted = false;

                    entity.IsDeleted = false;
                    entity.LastTransaction = "User Updated";


                    entity.UpdateIpAddress = IpAddress;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserName = UserName;
                }
                var validatorResult = UpdateValidator.Validate(entity);

                if (validatorResult.IsValid)
                {
                    Update(entity);
                    response.Result = mapper.Map<UserListDto>(entity);
                }
                if (validatorResult.Errors.Count > 0)
                {
                    foreach (var error in validatorResult.Errors)
                    {
                        response.AddErrorMessages(ErrorMessageCode.UserUpdateUserValidationError, error.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserUpdateUserExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserListDto> ChangeProfilePhoto(MediaDto mediaDto)
        {
            var response= new BusinessLayerResult<UserListDto>();
            using (var scope = new TransactionScope())
            {
                try
                {

                    var userEntity = GetById(mediaDto.EntityId);
                    if (userEntity != null)
                    {
                        //var mediaEntity=mapper.Map<MediaEntity>(mediaDto);
                        //mediaEntity.CreateIPAddress = IpAddress;
                        //mediaEntity.CreateTime=DateTime.Now;
                        //mediaEntity.CreateUserName= UserName;
                        //mediaEntity.IsDeleted = false;
                        var mediaResult = new BusinessLayerResult<MediaListDto>();
                        if (mediaDto.Id == null)
                        {
                            mediaResult = _mediaManager.AddMedia(mediaDto);
                        }
                        else
                        {
                            mediaResult = _mediaManager.UpdateMedia(mediaDto);
                        }

                        if (mediaResult.ErrorMessages.Count > 0)
                        {
                            scope.Dispose();
                            response.ErrorMessages.AddRange(mediaResult.ErrorMessages.ToList());
                        }
                        else
                        {
                            userEntity.ProfilePhotoId = mediaResult.Result.Id;
                            Update(userEntity);
                            response.Result = mapper.Map<UserListDto>(userEntity);
                            scope.Complete();
                            scope.Dispose();
                        }
                    }


                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.UserChangeProfilePhotoExceptionError, ex.Message);
                }
                return response;
            }
        }

       

        public BusinessLayerResult<UserListDto> DeleteUser(long userId)
        {
            var response = new BusinessLayerResult<UserListDto>();
            using(var scope = new TransactionScope())
            {
                try
                {
                    // delete user
                    var entity = GetById(userId);
                    entity.IsDeleted = true;
                    Update(entity);

                    // delete user roles
                    var userRoleResult=_userRoleManager.DeleteUserRoleByUserId(userId);    
                    if(userRoleResult.ErrorMessages.Count > 0)
                    {scope.Dispose();
                        response.ErrorMessages.AddRange(userRoleResult.ErrorMessages.ToList()) ;    
                        return response;
                        
                    }
                    response.Result=mapper.Map<UserListDto>(entity);

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    response.AddErrorMessages(ErrorMessageCode.UserDeleteUserExceptionError, ex.Message);
                }
            }
            
            return response;
        }

        public BusinessLayerResult<List<UserListDto>> Filter(UserFilter userFilter)
        {
            var response = new BusinessLayerResult<List<UserListDto>>();
            try
            {
                var query = "select * from User where isDeleted=0 and ";

                if (userFilter != null)
                {
                    if (userFilter.Gender != null)
                    {
                        query += $"gender= {userFilter.Gender} and ";
                    }
                    if (!string.IsNullOrEmpty(userFilter.Email))
                    {
                        query += $"email like '%{userFilter.Email}%' and ";
                    }
                    if (!string.IsNullOrEmpty(userFilter.Name))
                    {
                        query += $"name like '%{userFilter.Name}%' and ";
                    }
                    if (!string.IsNullOrEmpty(userFilter.Surname))
                    {
                        query += $"surname like '%{userFilter.Surname}%' and ";
                    }
                    if (!string.IsNullOrEmpty(userFilter.IdentityNumber))
                    {
                        query += $"identitynumber like '%{userFilter.IdentityNumber}%' and ";
                    }
                    if (!string.IsNullOrEmpty(userFilter.Phone))
                    {
                        query += $"phone like '%{userFilter.Phone}%' and ";
                    }
                    

                    if (userFilter.BirthDateFirst != null)
                    {
                        query += $"birthDate > '{userFilter.BirthDateFirst}' and ";
                    }
                    if (userFilter.BirthDateLast != null)
                    {
                        query += $"birthDate < '{userFilter.BirthDateLast}' and ";
                    }

                }
                if (query.EndsWith(" and "))
                {
                    query = query.Substring(0, query.Length - " and ".Length);
                }

                response.Result = GetAll(query).Select(x => mapper.Map<UserListDto>(x)).ToList();


            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserFilterUserExceptionError, ex.Message);
            }

            return response;
        }

        public BusinessLayerResult<UserLoadMoreDto> FilterUserList(BaseLoadMoreFilter<UserFilter> filter)
        {
            var response = new BusinessLayerResult<UserLoadMoreDto>();
            try
            {
                var result = new UserLoadMoreDto();
                List<UserListDto> contentList = new List<UserListDto>();
                if (filter.Filter == null)
                {
                    contentList = GetAll().Select(x => mapper.Map<UserListDto>(x)).ToList();


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
                    response.AddErrorMessages(ErrorMessageCode.UserFilterUserListError, "No more user");
                }
                else
                {
                    result.userListDtos = new List<UserListDto>();
                    for (int i = firstIndex; i < lastIndex; i++)
                    {
                        if (i > contentCount)
                        {
                            break;
                        }
                        result.userListDtos.Add(contentList[i]);
                    }

                    result.NextPage = (lastIndex < contentCount);

                    result.PreviousPage = (firstIndex != 0);
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserFilterUserListExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserListDto> GetUser(long id)
        {
            var response = new BusinessLayerResult<UserListDto>();
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    response.Result = mapper.Map<UserListDto>(entity);

                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.UserGetUserNotFoundExceptionError, "User was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserGetUserExceptionError, ex.Message);
            }
            return response;
        }

        public BusinessLayerResult<UserListDto> GetUserByUsername(string username)
        {
            var response = new BusinessLayerResult<UserListDto>();
            try
            {
                var entity = Get(x=>_identityManager.GetAll(y=>y.UserId==x.ID&&y.UserName==username).Count>0);
                if (entity != null)
                {
                    response.Result = mapper.Map<UserListDto>(entity);
                }
                else
                {
                    response.AddErrorMessages(ErrorMessageCode.UserGetUserNotFoundExceptionError, "User was not found.");
                }
            }
            catch (Exception ex)
            {
                response.AddErrorMessages(ErrorMessageCode.UserGetUserExceptionError, ex.Message);
            }
            return response;
        }


    }
}
