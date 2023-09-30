namespace ETrade.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_session : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        identityId = c.Long(nullable: false),
                        userId = c.Long(nullable: false),
                        expiryDate = c.DateTime(nullable: false),
                        ipAddress = c.String(),
                        deviceType = c.Int(nullable: false),
                        notifyToken = c.String(),
                        token = c.Guid(nullable: false),
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
                .ForeignKey("dbo.Identity", t => t.identityId)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.identityId)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Session", "userId", "dbo.User");
            DropForeignKey("dbo.Session", "identityId", "dbo.Identity");
            DropIndex("dbo.Session", new[] { "userId" });
            DropIndex("dbo.Session", new[] { "identityId" });
            DropTable("dbo.Session");
        }
    }
}
