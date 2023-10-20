using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Enums
{
    public enum MethodList
    {
        None,

        [Description("method used for adding a account")]
        AccountAdd,
        [Description("method used for account deletion")]
        AccountDelete,
        [Description("method used to update the account")]
        AccountUpdate,
        [Description("method used for account listing")]
        AccountGetAll,
        [Description("method used for account get")]
        AccountGet,

        [Description("method used for adding a address")]
        AddressAdd,
        [Description("method used for address deletion")]
        AddressDelete,
        [Description("method used to update the address")]
        AddressUpdate,
        [Description("method used for address listing")]
        AddressGetAll,
        [Description("method used for address get")]
        AddressGet,

        [Description("method used for adding a brand")]
        BrandAdd,
        [Description("method used for brand deletion")]
        BrandDelete,
        [Description("method used to update the brand")]
        BrandUpdate,
        [Description("method used for brand listing")]
        BrandGetAll,
        [Description("method used for brand get")]
        BrandGet,

        [Description("method used for adding a carouselitem")]
        CarouselItemAdd,
        [Description("method used for carouselitem deletion")]
        CarouselItemDelete,
        [Description("method used to update the carouselitem")]
        CarouselItemUpdate,
        [Description("method used for carouselitem listing")]
        CarouselItemGetAll,
        [Description("method used for carouselitem get")]
        CarouselItemGet,

        [Description("method used for adding a category")]
        CategoryAdd,
        [Description("method used for category deletion")]
        CategoryDelete,
        [Description("method used to update the category")]
        CategoryUpdate,
        [Description("method used for category listing")]
        CategoryGetAll,
        [Description("method used for category get")]
        CategoryGet,

        [Description("method used for adding a chat")]
        ChatAdd,
        [Description("method used for chat deletion")]
        ChatDelete,
        [Description("method used to update the chat")]
        ChatUpdate,
        [Description("method used for chat listing")]
        ChatGetAll,
        [Description("method used for chat get")]
        ChatGet,

        [Description("method used for adding a comment")]
        CommentAdd,
        [Description("method used for comment deletion")]
        CommentDelete,
        [Description("method used to update the comment")]
        CommentUpdate,
        [Description("method used for comment listing")]
        CommentGetAll,
        [Description("method used for comment get")]
        CommentGet,

        [Description("method used for adding a country")]
        CountryAdd,
        [Description("method used for country deletion")]
        CountryDelete,
        [Description("method used to update the country")]
        CountryUpdate,
        [Description("method used for country listing")]
        CountryGetAll,
        [Description("method used for country get")]
        CountryGet,

        [Description("method used for adding a currency")]
        CurrencyAdd,
        [Description("method used for currency deletion")]
        CurrencyDelete,
        [Description("method used to update the currency")]
        CurrencyUpdate,
        [Description("method used for currency listing")]
        CurrencyGetAll,
        [Description("method used for currency get")]
        CurrencyGet,

        [Description("method used for adding a deliveryoption")]
        DeliveryOptionAdd,
        [Description("method used for deliveryoption deletion")]
        DeliveryOptionDelete,
        [Description("method used to update the deliveryoption")]
        DeliveryOptionUpdate,
        [Description("method used for deliveryoption listing")]
        DeliveryOptionGetAll,
        [Description("method used for deliveryoption get")]
        DeliveryOptionGet,

        [Description("method used for adding a gender")]
        GenderAdd,
        [Description("method used for gender deletion")]
        GenderDelete,
        [Description("method used to update the gender")]
        GenderUpdate,
        [Description("method used for gender listing")]
        GenderGetAll,
        [Description("method used for gender get")]
        GenderGet,

        [Description("method used for adding a identity")]
        IdentityAdd,
        [Description("method used for identity deletion")]
        IdentityDelete,
        [Description("method used to update the identity")]
        IdentityUpdate,
        [Description("method used for identity listing")]
        IdentityGetAll,
        [Description("method used for identity get")]
        IdentityGet,

        [Description("method used for adding a media")]
        MediaAdd,
        [Description("method used for media deletion")]
        MediaDelete,
        [Description("method used to update the media")]
        MediaUpdate,
        [Description("method used for media listing")]
        MediaGetAll,
        [Description("method used for media get")]
        MediaGet,

        [Description("method used for adding a message")]
        MessageAdd,
        [Description("method used for message deletion")]
        MessageDelete,
        [Description("method used to update the message")]
        MessageUpdate,
        [Description("method used for message listing")]
        MessageGetAll,
        [Description("method used for message get")]
        MessageGet,

        [Description("method used for adding a messagemedia")]
        MessageMediaAdd,
        [Description("method used for messagemedia deletion")]
        MessageMediaDelete,
        [Description("method used to update the messagemedia")]
        MessageMediaUpdate,
        [Description("method used for messagemedia listing")]
        MessageMediaGetAll,
        [Description("method used for messagemedia get")]
        MessageMediaGet,

        [Description("method used for adding a method")]
        MethodAdd,
        [Description("method used for method deletion")]
        MethodDelete,
        [Description("method used to update the method")]
        MethodUpdate,
        [Description("method used for method listing")]
        MethodGetAll,
        [Description("method used for method get")]
        MethodGet,

        [Description("method used for adding a notify")]
        NotifyAdd,
        [Description("method used for notify deletion")]
        NotifyDelete,
        [Description("method used to update the notify")]
        NotifyUpdate,
        [Description("method used for notify listing")]
        NotifyGetAll,
        [Description("method used for notify get")]
        NotifyGet,

        [Description("method used for adding a orderdetail")]
        OrderDetailAdd,
        [Description("method used for orderdetail deletion")]
        OrderDetailDelete,
        [Description("method used to update the orderdetail")]
        OrderDetailUpdate,
        [Description("method used for orderdetail listing")]
        OrderDetailGetAll,
        [Description("method used for orderdetail get")]
        OrderDetailGet,

        [Description("method used for adding a order")]
        OrderAdd,
        [Description("method used for order deletion")]
        OrderDelete,
        [Description("method used to update the order")]
        OrderUpdate,
        [Description("method used for order listing")]
        OrderGetAll,
        [Description("method used for order get")]
        OrderGet,

        [Description("method used for adding a productchat")]
        ProductChatAdd,
        [Description("method used for productchat deletion")]
        ProductChatDelete,
        [Description("method used to update the productchat")]
        ProductChatUpdate,
        [Description("method used for productchat listing")]
        ProductChatGetAll,
        [Description("method used for productchat get")]
        ProductChatGet,

        [Description("method used for adding a productcomment")]
        ProductCommentAdd,
        [Description("method used for productcomment deletion")]
        ProductCommentDelete,
        [Description("method used to update the productcomment")]
        ProductCommentUpdate,
        [Description("method used for productcomment listing")]
        ProductCommentGetAll,
        [Description("method used for productcomment get")]
        ProductCommentGet,

        [Description("method used for adding a product")]
        ProductAdd,
        [Description("method used for product deletion")]
        ProductDelete,
        [Description("method used to update the product")]
        ProductUpdate,
        [Description("method used for product listing")]
        ProductGetAll,
        [Description("method used for product get")]
        ProductGet,

        [Description("method used for adding a role")]
        RoleAdd,
        [Description("method used for role deletion")]
        RoleDelete,
        [Description("method used to update the role")]
        RoleUpdate,
        [Description("method used for role listing")]
        RoleGetAll,
        [Description("method used for role get")]
        RoleGet,

        [Description("method used for adding a rolemethod")]
        RoleMethodAdd,
        [Description("method used for rolemethod deletion")]
        RoleMethodDelete,
        [Description("method used to update the rolemethod")]
        RoleMethodUpdate,
        [Description("method used for rolemethod listing")]
        RoleMethodGetAll,
        [Description("method used for rolemethod get")]
        RoleMethodGet,

        [Description("method used for adding a roleuser")]
        RoleUserAdd,
        [Description("method used for roleuser deletion")]
        RoleUserDelete,
        [Description("method used to update the roleuser")]
        RoleUserUpdate,
        [Description("method used for roleuser listing")]
        RoleUserGetAll,
        [Description("method used for roleuser get")]
        RoleUserGet,

        [Description("method used for adding a session")]
        SessionAdd,
        [Description("method used for session deletion")]
        SessionDelete,
        [Description("method used to update the session")]
        SessionUpdate,
        [Description("method used for session listing")]
        SessionGetAll,
        [Description("method used for session get")]
        SessionGet,

        [Description("method used for adding a settings")]
        SettingsAdd,
        [Description("method used for settings deletion")]
        SettingsDelete,
        [Description("method used to update the settings")]
        SettingsUpdate,
        [Description("method used for settings listing")]
        SettingsGetAll,
        [Description("method used for settings get")]
        SettingsGet,

        [Description("method used for adding a status")]
        StatusAdd,
        [Description("method used for status deletion")]
        StatusDelete,
        [Description("method used to update the status")]
        StatusUpdate,
        [Description("method used for status listing")]
        StatusGetAll,
        [Description("method used for status get")]
        StatusGet,

        [Description("method used for adding a systemsettings")]
        SystemSettingsAdd,
        [Description("method used for systemsettings deletion")]
        SystemSettingsDelete,
        [Description("method used to update the systemsettings")]
        SystemSettingsUpdate,
        [Description("method used for systemsettings listing")]
        SystemSettingsGetAll,
        [Description("method used for systemsettings get")]
        SystemSettingsGet,

        [Description("method used for adding a useraddress")]
        UserAddressAdd,
        [Description("method used for useraddress deletion")]
        UserAddressDelete,
        [Description("method used to update the useraddress")]
        UserAddressUpdate,
        [Description("method used for useraddress listing")]
        UserAddressGetAll,
        [Description("method used for useraddress get")]
        UserAddressGet,

        [Description("method used for adding a usercart")]
        UserCartAdd,
        [Description("method used for usercart deletion")]
        UserCartDelete,
        [Description("method used to update the usercart")]
        UserCartUpdate,
        [Description("method used for usercart listing")]
        UserCartGetAll,
        [Description("method used for usercart get")]
        UserCartGet,

        [Description("method used for adding a userchat")]
        UserChatAdd,
        [Description("method used for userchat deletion")]
        UserChatDelete,
        [Description("method used to update the userchat")]
        UserChatUpdate,
        [Description("method used for userchat listing")]
        UserChatGetAll,
        [Description("method used for userchat get")]
        UserChatGet,

        [Description("method used for adding a userfavourite")]
        UserFavouriteAdd,
        [Description("method used for userfavourite deletion")]
        UserFavouriteDelete,
        [Description("method used to update the userfavourite")]
        UserFavouriteUpdate,
        [Description("method used for userfavourite listing")]
        UserFavouriteGetAll,
        [Description("method used for userfavourite get")]
        UserFavouriteGet,

        [Description("method used for adding a user")]
        UserAdd,
        [Description("method used for user deletion")]
        UserDelete,
        [Description("method used to update the user")]
        UserUpdate,
        [Description("method used for user listing")]
        UserGetAll,
        [Description("method used for user get")]
        UserGet,

        [Description("method used for adding a usersettings")]
        UserSettingsAdd,
        [Description("method used for usersettings deletion")]
        UserSettingsDelete,
        [Description("method used to update the usersettings")]
        UserSettingsUpdate,
        [Description("method used for usersettings listing")]
        UserSettingsGetAll,
        [Description("method used for usersettings get")]
        UserSettingsGet,

    }
}
