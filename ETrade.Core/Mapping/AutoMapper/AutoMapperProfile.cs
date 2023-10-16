using AutoMapper;
using ETrade.Dto.Dtos.Address;
using ETrade.Dto.Dtos.Comment;
using ETrade.Dto.Dtos.Country;
using ETrade.Dto.Dtos.Gender;
using ETrade.Dto.Dtos.Identity;
using ETrade.Dto.Dtos.Media;
using ETrade.Dto.Dtos.Role;
using ETrade.Dto.Dtos.RoleMethod;
using ETrade.Dto.Dtos.Session;
using ETrade.Dto.Dtos.User;
using ETrade.Dto.Dtos.UserRole;
using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core.Mapping.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            #region AddressMapping
            CreateMap<AddressEntity, AddressDto>()
                .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            CreateMap<AddressEntity, AddressListDto>()
                            .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();
            CreateMap<AddressEntity, AddressDetailListDto>()
                                        .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                                        .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                                        .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                                        .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate())
                                        .ForSourceMember(x => x.Country, opt => opt.DoNotValidate())

                                        .ReverseMap();

            #endregion

            #region CommentMapping
            CreateMap<CommentEntity, CommentDto>()
                .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            CreateMap<CommentEntity, CommentListDto>()
                            .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();
            #endregion

            #region GenderMapping
            CreateMap<GenderEntity, GenderDto>()
                .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            CreateMap<GenderEntity, GenderListDto>()
                            .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            #endregion

            #region MediaMapping

            CreateMap<MediaEntity, MediaDto>()
                .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            CreateMap<MediaEntity, MediaListDto>()
                            .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();
            #endregion

            #region RoleMapping
            CreateMap<RoleEntity, RoleDto>()
            .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
            .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
            .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
            .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            CreateMap<RoleEntity, RoleListDto>()
                            .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            #endregion

            #region UseMapping

            CreateMap<UserEntity, UserDto>()
                .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            CreateMap<UserEntity, UserListDto>()
                            .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();
            #endregion

            #region UserRoleMapping
            CreateMap<UserRoleEntity, UserRoleDto>()
                .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            CreateMap<UserRoleEntity, UserRoleListDto>()
                            .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();
            #endregion

            #region IdentityMapping

            CreateMap<IdentityEntity, IdentityDto>()
                .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            CreateMap<IdentityEntity, IdentityListDto>()
                            .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();
            #endregion

            #region SessionMapping

            CreateMap<SessionEntity, SessionDto>()
                .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            CreateMap<SessionEntity, SessionListDto>()
                            .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            CreateMap<SessionListEntity, SessionListDto>()
                                        .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                                        .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                                        .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                                        .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();


            #endregion

            #region RoleMethodMapping

            CreateMap<RoleMethodEntity, RoleMethodDto>()
                .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            CreateMap<RoleMethodEntity, RoleMethodListDto>()
                            .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();
            CreateMap<RoleMethodListEntity, RoleMethodListDto>()
                                        .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                                        .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                                        .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                                        .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            #endregion

            #region CountryMapping

            CreateMap<CountryEntity, CountryDto>()
                .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            CreateMap<CountryEntity, CountryListDto>()
                            .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
                            .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();
            //CreateMap<CountryListEntity, CountryListDto>()
            //                            .ForSourceMember(x => x.CreateIPAddress, opt => opt.DoNotValidate())
            //                            .ForSourceMember(x => x.CreateUserName, opt => opt.DoNotValidate())
            //                            .ForSourceMember(x => x.UpdateIpAddress, opt => opt.DoNotValidate())
            //                            .ForSourceMember(x => x.UpdateUserName, opt => opt.DoNotValidate()).ReverseMap();

            #endregion




        }
    }
}
