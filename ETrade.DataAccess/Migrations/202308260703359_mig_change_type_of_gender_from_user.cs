namespace ETrade.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_change_type_of_gender_from_user : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.User", new[] { "genderId" });
            RenameColumn(table: "dbo.User", name: "genderId", newName: "GenderEntity_ID");
            AddColumn("dbo.User", "gender", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "GenderEntity_ID", c => c.Long());
            CreateIndex("dbo.User", "GenderEntity_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "GenderEntity_ID" });
            AlterColumn("dbo.User", "GenderEntity_ID", c => c.Long(nullable: false));
            DropColumn("dbo.User", "gender");
            RenameColumn(table: "dbo.User", name: "GenderEntity_ID", newName: "genderId");
            CreateIndex("dbo.User", "genderId");
        }
    }
}
