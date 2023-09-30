namespace ETrade.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        countryId = c.Long(nullable: false),
                        phoneNumber = c.String(),
                        city = c.String(),
                        address = c.String(),
                        postalCode = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Country", t => t.countryId)
                .Index(t => t.countryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        title = c.String(),
                        code = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        brandName = c.String(),
                        imageId = c.Long(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Media", t => t.imageId)
                .Index(t => t.imageId);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        entityType = c.Int(),
                        entityId = c.Long(),
                        fileType = c.Int(nullable: false),
                        fileName = c.String(),
                        content = c.Binary(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        title = c.String(),
                        oldPrice = c.Decimal(precision: 18, scale: 2),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        currencyId = c.Long(nullable: false),
                        brandId = c.Long(),
                        categoryId = c.Long(nullable: false),
                        seller = c.Long(nullable: false),
                        rating = c.Double(nullable: false),
                        isSoldAbroad = c.Boolean(nullable: false),
                        description = c.String(),
                        statusId = c.Long(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brand", t => t.brandId)
                .ForeignKey("dbo.Category", t => t.categoryId)
                .ForeignKey("dbo.Currency", t => t.currencyId)
                .ForeignKey("dbo.Seller", t => t.seller)
                .ForeignKey("dbo.Status", t => t.statusId)
                .Index(t => t.currencyId)
                .Index(t => t.brandId)
                .Index(t => t.categoryId)
                .Index(t => t.seller)
                .Index(t => t.statusId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        topCategoryId = c.Long(),
                        link = c.String(),
                        imageId = c.Long(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Media", t => t.imageId)
                .Index(t => t.imageId);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        title = c.String(),
                        currencyCode = c.String(),
                        symbol = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        orderId = c.Long(nullable: false),
                        productId = c.Long(nullable: false),
                        unitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                        discountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TrackingNumber = c.String(),
                        deliveryOptionId = c.Long(nullable: false),
                        shippedDate = c.DateTime(),
                        currencyId = c.Long(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Currency", t => t.currencyId)
                .ForeignKey("dbo.DeliveryOptionEntities", t => t.deliveryOptionId)
                .ForeignKey("dbo.Order", t => t.orderId)
                .ForeignKey("dbo.Product", t => t.productId)
                .Index(t => t.orderId)
                .Index(t => t.productId)
                .Index(t => t.deliveryOptionId)
                .Index(t => t.currencyId);
            
            CreateTable(
                "dbo.DeliveryOptionEntities",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        brandName = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isFree = c.Boolean(nullable: false),
                        isSentAbroad = c.Boolean(nullable: false),
                        sellerId = c.Long(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Seller", t => t.sellerId)
                .Index(t => t.sellerId);
            
            CreateTable(
                "dbo.Seller",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        userId = c.Long(nullable: false),
                        coverImageId = c.Long(),
                        avatarImageId = c.Long(),
                        rating = c.Double(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Media", t => t.avatarImageId)
                .ForeignKey("dbo.Media", t => t.coverImageId)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.coverImageId)
                .Index(t => t.avatarImageId);
            
            CreateTable(
                "dbo.SellerAddress",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        sellerId = c.Long(nullable: false),
                        addressId = c.Long(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.addressId)
                .ForeignKey("dbo.Seller", t => t.sellerId)
                .Index(t => t.sellerId)
                .Index(t => t.addressId);
            
            CreateTable(
                "dbo.SellerComment",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        SellerId = c.Long(nullable: false),
                        commentId = c.Long(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comment", t => t.commentId)
                .ForeignKey("dbo.Seller", t => t.SellerId)
                .Index(t => t.SellerId)
                .Index(t => t.commentId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        title = c.String(),
                        text = c.String(),
                        commentDate = c.DateTime(nullable: false),
                        userId = c.Long(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        surname = c.String(),
                        email = c.String(),
                        phoneNumber = c.String(),
                        identityNumber = c.String(),
                        profilePhotoId = c.Long(),
                        genderId = c.Long(nullable: false),
                        birthDate = c.DateTime(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gender", t => t.genderId)
                .ForeignKey("dbo.Media", t => t.profilePhotoId)
                .Index(t => t.profilePhotoId)
                .Index(t => t.genderId);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        chatId = c.Long(nullable: false),
                        sentUserId = c.Long(nullable: false),
                        answeredMessageId = c.Long(),
                        message = c.String(),
                        sendingTime = c.DateTime(nullable: false),
                        isContainsImages = c.Boolean(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chat", t => t.chatId)
                .ForeignKey("dbo.User", t => t.sentUserId)
                .Index(t => t.chatId)
                .Index(t => t.sentUserId);
            
            CreateTable(
                "dbo.Chat",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        iconImageId = c.Long(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Media", t => t.iconImageId)
                .Index(t => t.iconImageId);
            
            CreateTable(
                "dbo.ProductChatEntities",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        chatId = c.Long(nullable: false),
                        productId = c.Long(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chat", t => t.chatId)
                .ForeignKey("dbo.Product", t => t.productId)
                .Index(t => t.chatId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.UserChat",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        userId = c.Long(nullable: false),
                        chatId = c.Long(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        joinDate = c.DateTime(nullable: false),
                        DepartureDate = c.DateTime(),
                        isSeller = c.Boolean(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chat", t => t.chatId)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.chatId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        userId = c.Long(nullable: false),
                        orderNo = c.Long(nullable: false),
                        orderDate = c.DateTime(nullable: false),
                        billingAddressId = c.Long(nullable: false),
                        deliveryAddressId = c.Long(nullable: false),
                        discountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.UserAddress",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        userId = c.Long(nullable: false),
                        addressId = c.Long(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.addressId)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.addressId);
            
            CreateTable(
                "dbo.UserCart",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        userId = c.Long(nullable: false),
                        productId = c.Long(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        count = c.Int(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.productId)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.UserFavourite",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        userId = c.Long(nullable: false),
                        productId = c.Long(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.productId)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        userId = c.Long(nullable: false),
                        roleId = c.Long(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.roleId)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.roleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductComment",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        productId = c.Long(nullable: false),
                        commentId = c.Long(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comment", t => t.commentId)
                .ForeignKey("dbo.Product", t => t.productId)
                .Index(t => t.productId)
                .Index(t => t.commentId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        color = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CarouselItem",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        backgroudImageId = c.Long(nullable: false),
                        link = c.String(),
                        title = c.String(),
                        subtitle = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Media", t => t.backgroudImageId)
                .Index(t => t.backgroudImageId);
            
            CreateTable(
                "dbo.Identity",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        userId = c.String(),
                        isActive = c.Boolean(nullable: false),
                        userName = c.String(),
                        passwordHash = c.String(),
                        passwordSalt = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarouselItem", "backgroudImageId", "dbo.Media");
            DropForeignKey("dbo.Product", "statusId", "dbo.Status");
            DropForeignKey("dbo.ProductComment", "productId", "dbo.Product");
            DropForeignKey("dbo.ProductComment", "commentId", "dbo.Comment");
            DropForeignKey("dbo.OrderDetail", "productId", "dbo.Product");
            DropForeignKey("dbo.SellerComment", "SellerId", "dbo.Seller");
            DropForeignKey("dbo.SellerComment", "commentId", "dbo.Comment");
            DropForeignKey("dbo.UserRole", "userId", "dbo.User");
            DropForeignKey("dbo.UserRole", "roleId", "dbo.Role");
            DropForeignKey("dbo.UserFavourite", "userId", "dbo.User");
            DropForeignKey("dbo.UserFavourite", "productId", "dbo.Product");
            DropForeignKey("dbo.UserCart", "userId", "dbo.User");
            DropForeignKey("dbo.UserCart", "productId", "dbo.Product");
            DropForeignKey("dbo.UserAddress", "userId", "dbo.User");
            DropForeignKey("dbo.UserAddress", "addressId", "dbo.Address");
            DropForeignKey("dbo.Seller", "userId", "dbo.User");
            DropForeignKey("dbo.Order", "userId", "dbo.User");
            DropForeignKey("dbo.OrderDetail", "orderId", "dbo.Order");
            DropForeignKey("dbo.Message", "sentUserId", "dbo.User");
            DropForeignKey("dbo.UserChat", "userId", "dbo.User");
            DropForeignKey("dbo.UserChat", "chatId", "dbo.Chat");
            DropForeignKey("dbo.ProductChatEntities", "productId", "dbo.Product");
            DropForeignKey("dbo.ProductChatEntities", "chatId", "dbo.Chat");
            DropForeignKey("dbo.Message", "chatId", "dbo.Chat");
            DropForeignKey("dbo.Chat", "iconImageId", "dbo.Media");
            DropForeignKey("dbo.User", "profilePhotoId", "dbo.Media");
            DropForeignKey("dbo.User", "genderId", "dbo.Gender");
            DropForeignKey("dbo.Comment", "userId", "dbo.User");
            DropForeignKey("dbo.SellerAddress", "sellerId", "dbo.Seller");
            DropForeignKey("dbo.SellerAddress", "addressId", "dbo.Address");
            DropForeignKey("dbo.Product", "seller", "dbo.Seller");
            DropForeignKey("dbo.DeliveryOptionEntities", "sellerId", "dbo.Seller");
            DropForeignKey("dbo.Seller", "coverImageId", "dbo.Media");
            DropForeignKey("dbo.Seller", "avatarImageId", "dbo.Media");
            DropForeignKey("dbo.OrderDetail", "deliveryOptionId", "dbo.DeliveryOptionEntities");
            DropForeignKey("dbo.OrderDetail", "currencyId", "dbo.Currency");
            DropForeignKey("dbo.Product", "currencyId", "dbo.Currency");
            DropForeignKey("dbo.Product", "categoryId", "dbo.Category");
            DropForeignKey("dbo.Category", "imageId", "dbo.Media");
            DropForeignKey("dbo.Product", "brandId", "dbo.Brand");
            DropForeignKey("dbo.Brand", "imageId", "dbo.Media");
            DropForeignKey("dbo.Address", "countryId", "dbo.Country");
            DropIndex("dbo.CarouselItem", new[] { "backgroudImageId" });
            DropIndex("dbo.ProductComment", new[] { "commentId" });
            DropIndex("dbo.ProductComment", new[] { "productId" });
            DropIndex("dbo.UserRole", new[] { "roleId" });
            DropIndex("dbo.UserRole", new[] { "userId" });
            DropIndex("dbo.UserFavourite", new[] { "productId" });
            DropIndex("dbo.UserFavourite", new[] { "userId" });
            DropIndex("dbo.UserCart", new[] { "productId" });
            DropIndex("dbo.UserCart", new[] { "userId" });
            DropIndex("dbo.UserAddress", new[] { "addressId" });
            DropIndex("dbo.UserAddress", new[] { "userId" });
            DropIndex("dbo.Order", new[] { "userId" });
            DropIndex("dbo.UserChat", new[] { "chatId" });
            DropIndex("dbo.UserChat", new[] { "userId" });
            DropIndex("dbo.ProductChatEntities", new[] { "productId" });
            DropIndex("dbo.ProductChatEntities", new[] { "chatId" });
            DropIndex("dbo.Chat", new[] { "iconImageId" });
            DropIndex("dbo.Message", new[] { "sentUserId" });
            DropIndex("dbo.Message", new[] { "chatId" });
            DropIndex("dbo.User", new[] { "genderId" });
            DropIndex("dbo.User", new[] { "profilePhotoId" });
            DropIndex("dbo.Comment", new[] { "userId" });
            DropIndex("dbo.SellerComment", new[] { "commentId" });
            DropIndex("dbo.SellerComment", new[] { "SellerId" });
            DropIndex("dbo.SellerAddress", new[] { "addressId" });
            DropIndex("dbo.SellerAddress", new[] { "sellerId" });
            DropIndex("dbo.Seller", new[] { "avatarImageId" });
            DropIndex("dbo.Seller", new[] { "coverImageId" });
            DropIndex("dbo.Seller", new[] { "userId" });
            DropIndex("dbo.DeliveryOptionEntities", new[] { "sellerId" });
            DropIndex("dbo.OrderDetail", new[] { "currencyId" });
            DropIndex("dbo.OrderDetail", new[] { "deliveryOptionId" });
            DropIndex("dbo.OrderDetail", new[] { "productId" });
            DropIndex("dbo.OrderDetail", new[] { "orderId" });
            DropIndex("dbo.Category", new[] { "imageId" });
            DropIndex("dbo.Product", new[] { "statusId" });
            DropIndex("dbo.Product", new[] { "seller" });
            DropIndex("dbo.Product", new[] { "categoryId" });
            DropIndex("dbo.Product", new[] { "brandId" });
            DropIndex("dbo.Product", new[] { "currencyId" });
            DropIndex("dbo.Brand", new[] { "imageId" });
            DropIndex("dbo.Address", new[] { "countryId" });
            DropTable("dbo.Identity");
            DropTable("dbo.CarouselItem");
            DropTable("dbo.Status");
            DropTable("dbo.ProductComment");
            DropTable("dbo.Role");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserFavourite");
            DropTable("dbo.UserCart");
            DropTable("dbo.UserAddress");
            DropTable("dbo.Order");
            DropTable("dbo.UserChat");
            DropTable("dbo.ProductChatEntities");
            DropTable("dbo.Chat");
            DropTable("dbo.Message");
            DropTable("dbo.Gender");
            DropTable("dbo.User");
            DropTable("dbo.Comment");
            DropTable("dbo.SellerComment");
            DropTable("dbo.SellerAddress");
            DropTable("dbo.Seller");
            DropTable("dbo.DeliveryOptionEntities");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Currency");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.Media");
            DropTable("dbo.Brand");
            DropTable("dbo.Country");
            DropTable("dbo.Address");
        }
    }
}
