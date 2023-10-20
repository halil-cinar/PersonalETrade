using AutoMapper;
using ETrade.Dto.Dtos.Address;
using ETrade.Dto.Dtos.Brand;
using ETrade.Dto.Dtos.CarouselItem;
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.Chat;
using ETrade.Dto.Dtos.Comment;
using ETrade.Dto.Dtos.Country;
using ETrade.Dto.Dtos.Currency;
using ETrade.Dto.Dtos.DeliveryOption;
using ETrade.Dto.Dtos.Gender;
using ETrade.Dto.Dtos.Identity;
using ETrade.Dto.Dtos.Media;
using ETrade.Dto.Dtos.Message;
using ETrade.Dto.Dtos.MessageMedia;
using ETrade.Dto.Dtos.Method;
using ETrade.Dto.Dtos.Notify;
using ETrade.Dto.Dtos.Order;
using ETrade.Dto.Dtos.OrderDetail;
using ETrade.Dto.Dtos.Product;
using ETrade.Dto.Dtos.ProductChat;
using ETrade.Dto.Dtos.ProductComment;
using ETrade.Dto.Dtos.Role;
using ETrade.Dto.Dtos.RoleMethod;
using ETrade.Dto.Dtos.Session;
using ETrade.Dto.Dtos.Settings;
using ETrade.Dto.Dtos.Status;
using ETrade.Dto.Dtos.SystemSettings;
using ETrade.Dto.Dtos.User;
using ETrade.Dto.Dtos.UserAddress;
using ETrade.Dto.Dtos.UserCart;
using ETrade.Dto.Dtos.UserChat;
using ETrade.Dto.Dtos.UserFavourite;
using ETrade.Dto.Dtos.UserRole;
using ETrade.Dto.Dtos.UserSettings;
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

            CreateMap<AddressListDto, AddressEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<AddressDto, AddressEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region BrandMapping

            CreateMap<BrandListDto, BrandEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<BrandDto, BrandEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region CarouselItemMapping

            CreateMap<CarouselItemListDto, CarouselItemEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<CarouselItemDto, CarouselItemEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region CategoryMapping

            CreateMap<CategoryListDto, CategoryEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<CategoryDto, CategoryEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region ChatMapping

            CreateMap<ChatListDto, ChatEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<ChatDto, ChatEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region CommentMapping

            CreateMap<CommentListDto, CommentEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<CommentDto, CommentEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region CountryMapping

            CreateMap<CountryListDto, CountryEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<CountryDto, CountryEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region CurrencyMapping

            CreateMap<CurrencyListDto, CurrencyEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<CurrencyDto, CurrencyEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region DeliveryOptionMapping

            CreateMap<DeliveryOptionListDto, DeliveryOptionEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<DeliveryOptionDto, DeliveryOptionEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region GenderMapping

            CreateMap<GenderListDto, GenderEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<GenderDto, GenderEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region IdentityMapping

            CreateMap<IdentityListDto, IdentityEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<IdentityDto, IdentityEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region MediaMapping

            CreateMap<MediaListDto, MediaEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<MediaDto, MediaEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region MessageMapping

            CreateMap<MessageListDto, MessageEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<MessageDto, MessageEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region MessageMediaMapping

            CreateMap<MessageMediaListDto, MessageMediaEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<MessageMediaDto, MessageMediaEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region MethodMapping

            CreateMap<MethodListDto, MethodEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<MethodDto, MethodEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region NotifyMapping

            CreateMap<NotifyListDto, NotifyEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<NotifyDto, NotifyEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region OrderDetailMapping

            CreateMap<OrderDetailListDto, OrderDetailEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<OrderDetailDto, OrderDetailEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region OrderMapping

            CreateMap<OrderListDto, OrderEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<OrderDto, OrderEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region ProductChatMapping

            CreateMap<ProductChatListDto, ProductChatEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<ProductChatDto, ProductChatEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region ProductCommentMapping

            CreateMap<ProductCommentListDto, ProductCommentEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<ProductCommentDto, ProductCommentEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region ProductMapping

            CreateMap<ProductListDto, ProductEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<ProductDto, ProductEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region RoleMapping

            CreateMap<RoleListDto, RoleEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<RoleDto, RoleEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region RoleMethodMapping

            CreateMap<RoleMethodListDto, RoleMethodEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<RoleMethodDto, RoleMethodEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region RoleMethodListMapping

            CreateMap<RoleMethodListDto, RoleMethodListEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<RoleMethodListDto, RoleMethodListEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region SessionMapping

            CreateMap<SessionListDto, SessionEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<SessionDto, SessionEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region SessionListMapping

            CreateMap<SessionListDto, SessionListEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<SessionListDto, SessionListEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region SettingsMapping

            CreateMap<SettingsListDto, SettingsEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<SettingsDto, SettingsEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region StatusMapping

            CreateMap<StatusListDto, StatusEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<StatusDto, StatusEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region SystemSettingsMapping

            CreateMap<SystemSettingsListDto, SystemSettingsEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<SystemSettingsDto, SystemSettingsEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region UserAddressMapping

            CreateMap<UserAddressListDto, UserAddressEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<UserAddressDto, UserAddressEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region UserCartMapping

            CreateMap<UserCartListDto, UserCartEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<UserCartDto, UserCartEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region UserChatMapping

            CreateMap<UserChatListDto, UserChatEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<UserChatDto, UserChatEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region UserMapping

            CreateMap<UserListDto, UserEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<UserDto, UserEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region UserFavouriteMapping

            CreateMap<UserFavouriteListDto, UserFavouriteEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<UserFavouriteDto, UserFavouriteEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region UserRoleMapping

            CreateMap<UserRoleListDto, UserRoleEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<UserRoleDto, UserRoleEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion


            #region UserSettingsMapping

            CreateMap<UserSettingsListDto, UserSettingsEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();

            CreateMap<UserSettingsDto, UserSettingsEntity>()
                    .ForMember(x => x.CreateTime, opt => opt.Ignore())
                    .ForMember(x => x.CreateUserName, opt => opt.Ignore())
                    .ForMember(x => x.CreateIPAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateTime, opt => opt.Ignore())
                    .ForMember(x => x.UpdateIpAddress, opt => opt.Ignore())
                    .ForMember(x => x.UpdateUserName, opt => opt.Ignore())
                    .ReverseMap();
            #endregion



        }
    }
}
