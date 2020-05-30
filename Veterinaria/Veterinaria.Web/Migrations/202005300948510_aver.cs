namespace Veterinaria.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Owners", "UserId");
        }
    }
}
