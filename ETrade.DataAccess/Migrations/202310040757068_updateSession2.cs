namespace ETrade.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSession2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Session", new[] { "identityId" });
            DropIndex("dbo.Session", new[] { "userId" });
            AddColumn("dbo.Session", "isActive", c => c.Boolean());
            AlterColumn("dbo.Session", "identityId", c => c.Long());
            AlterColumn("dbo.Session", "userId", c => c.Long());
            CreateIndex("dbo.Session", "identityId");
            CreateIndex("dbo.Session", "userId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Session", new[] { "userId" });
            DropIndex("dbo.Session", new[] { "identityId" });
            AlterColumn("dbo.Session", "userId", c => c.Long(nullable: false));
            AlterColumn("dbo.Session", "identityId", c => c.Long(nullable: false));
            DropColumn("dbo.Session", "isActive");
            CreateIndex("dbo.Session", "userId");
            CreateIndex("dbo.Session", "identityId");
        }
    }
}
