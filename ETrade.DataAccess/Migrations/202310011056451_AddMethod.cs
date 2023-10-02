namespace ETrade.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMethod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleMethod",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        roleId = c.Long(nullable: false),
                        methodId = c.Long(nullable: false),
                        expiryDate = c.DateTime(),
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
                .ForeignKey("dbo.Method", t => t.methodId)
                .ForeignKey("dbo.Role", t => t.roleId)
                .Index(t => t.roleId)
                .Index(t => t.methodId);
            
            CreateTable(
                "dbo.Method",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        key = c.Int(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleMethod", "roleId", "dbo.Role");
            DropForeignKey("dbo.RoleMethod", "methodId", "dbo.Method");
            DropIndex("dbo.RoleMethod", new[] { "methodId" });
            DropIndex("dbo.RoleMethod", new[] { "roleId" });
            DropTable("dbo.Method");
            DropTable("dbo.RoleMethod");
        }
    }
}
