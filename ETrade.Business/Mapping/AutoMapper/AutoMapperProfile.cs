using AutoMapper;
using ETrade.Dto.Dtos.Address;
using ETrade.Dto.Dtos.Comment;
using ETrade.Dto.Dtos.Gender;
using ETrade.Dto.Dtos.Media;
using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business.Mapping.AutoMapper
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


        }
    }
}
