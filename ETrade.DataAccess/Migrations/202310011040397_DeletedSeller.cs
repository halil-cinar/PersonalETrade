namespace ETrade.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedSeller : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seller", "avatarImageId", "dbo.Media");
            DropForeignKey("dbo.Seller", "coverImageId", "dbo.Media");
            DropForeignKey("dbo.DeliveryOptionEntities", "sellerId", "dbo.Seller");
            DropForeignKey("dbo.Product", "seller", "dbo.Seller");
            DropForeignKey("dbo.SellerAddress", "addressId", "dbo.Address");
            DropForeignKey("dbo.SellerAddress", "sellerId", "dbo.Seller");
            DropForeignKey("dbo.Seller", "userId", "dbo.User");
            DropForeignKey("dbo.SellerComment", "commentId", "dbo.Comment");
            DropForeignKey("dbo.SellerComment", "SellerId", "dbo.Seller");
            DropIndex("dbo.Product", new[] { "seller" });
            DropIndex("dbo.DeliveryOptionEntities", new[] { "sellerId" });
            DropIndex("dbo.Seller", new[] { "userId" });
            DropIndex("dbo.Seller", new[] { "coverImageId" });
            DropIndex("dbo.Seller", new[] { "avatarImageId" });
            DropIndex("dbo.SellerAddress", new[] { "sellerId" });
            DropIndex("dbo.SellerAddress", new[] { "addressId" });
            DropIndex("dbo.SellerComment", new[] { "SellerId" });
            DropIndex("dbo.SellerComment", new[] { "commentId" });
            RenameColumn(table: "dbo.Product", name: "statusId", newName: "StatusEntity_ID");
            RenameIndex(table: "dbo.Product", name: "IX_statusId", newName: "IX_StatusEntity_ID");
            AddColumn("dbo.Product", "userId", c => c.Long(nullable: false));
            AddColumn("dbo.Product", "statusType", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "stockStatusType", c => c.Int(nullable: false));
            AlterColumn("dbo.Identity", "userId", c => c.Long(nullable: false));
            CreateIndex("dbo.Product", "userId");
            CreateIndex("dbo.Identity", "userId");
            AddForeignKey("dbo.Product", "userId", "dbo.User", "ID");
            AddForeignKey("dbo.Identity", "userId", "dbo.User", "ID");
            DropColumn("dbo.Product", "seller");
            DropColumn("dbo.DeliveryOptionEntities", "sellerId");
            DropTable("dbo.Seller");
            DropTable("dbo.SellerAddress");
            DropTable("dbo.SellerComment");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.DeliveryOptionEntities", "sellerId", c => c.Long());
            AddColumn("dbo.Product", "seller", c => c.Long(nullable: false));
            DropForeignKey("dbo.Identity", "userId", "dbo.User");
            DropForeignKey("dbo.Product", "userId", "dbo.User");
            DropIndex("dbo.Identity", new[] { "userId" });
            DropIndex("dbo.Product", new[] { "userId" });
            AlterColumn("dbo.Identity", "userId", c => c.String());
            DropColumn("dbo.Product", "stockStatusType");
            DropColumn("dbo.Product", "statusType");
            DropColumn("dbo.Product", "userId");
            RenameIndex(table: "dbo.Product", name: "IX_StatusEntity_ID", newName: "IX_statusId");
            RenameColumn(table: "dbo.Product", name: "StatusEntity_ID", newName: "statusId");
            CreateIndex("dbo.SellerComment", "commentId");
            CreateIndex("dbo.SellerComment", "SellerId");
            CreateIndex("dbo.SellerAddress", "addressId");
            CreateIndex("dbo.SellerAddress", "sellerId");
            CreateIndex("dbo.Seller", "avatarImageId");
            CreateIndex("dbo.Seller", "coverImageId");
            CreateIndex("dbo.Seller", "userId");
            CreateIndex("dbo.DeliveryOptionEntities", "sellerId");
            CreateIndex("dbo.Product", "seller");
            AddForeignKey("dbo.SellerComment", "SellerId", "dbo.Seller", "ID");
            AddForeignKey("dbo.SellerComment", "commentId", "dbo.Comment", "ID");
            AddForeignKey("dbo.Seller", "userId", "dbo.User", "ID");
            AddForeignKey("dbo.SellerAddress", "sellerId", "dbo.Seller", "ID");
            AddForeignKey("dbo.SellerAddress", "addressId", "dbo.Address", "ID");
            AddForeignKey("dbo.Product", "seller", "dbo.Seller", "ID");
            AddForeignKey("dbo.DeliveryOptionEntities", "sellerId", "dbo.Seller", "ID");
            AddForeignKey("dbo.Seller", "coverImageId", "dbo.Media", "ID");
            AddForeignKey("dbo.Seller", "avatarImageId", "dbo.Media", "ID");
        }
    }
}
