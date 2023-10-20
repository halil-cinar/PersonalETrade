namespace ETrade.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMediaMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Media", "contentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Media", "contentType");
        }
    }
}
