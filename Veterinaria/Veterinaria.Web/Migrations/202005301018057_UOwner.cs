namespace Veterinaria.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UOwner : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Owners", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Owners", "UserId");
            RenameColumn(table: "dbo.Owners", name: "ApplicationUser_Id", newName: "UserId");
            AlterColumn("dbo.Owners", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Owners", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Owners", new[] { "UserId" });
            AlterColumn("dbo.Owners", "UserId", c => c.String());
            RenameColumn(table: "dbo.Owners", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Owners", "UserId", c => c.String());
            CreateIndex("dbo.Owners", "ApplicationUser_Id");
        }
    }
}
