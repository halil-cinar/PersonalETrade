namespace ETrade.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMessageMedia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageMedia",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        messageId = c.Long(nullable: false),
                        mediaId = c.Long(nullable: false),
                        description = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        isDeletable = c.Boolean(),
                        createUserName = c.String(),
                        createIpAddress = c.String(),
                        createTime = c.DateTime(nullable: false),
                        updateUserName = c.String(),
                        updateIpAddress = c.String(),
                        updateTime = c.DateTime(),
                        lastTransaction = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Media", t => t.mediaId)
                .ForeignKey("dbo.Message", t => t.messageId)
                .Index(t => t.messageId)
                .Index(t => t.mediaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageMedia", "messageId", "dbo.Message");
            DropForeignKey("dbo.MessageMedia", "mediaId", "dbo.Media");
            DropIndex("dbo.MessageMedia", new[] { "mediaId" });
            DropIndex("dbo.MessageMedia", new[] { "messageId" });
            DropTable("dbo.MessageMedia");
        }
    }
}
