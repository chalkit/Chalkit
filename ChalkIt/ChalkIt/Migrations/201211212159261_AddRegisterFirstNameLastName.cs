namespace ChalkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegisterFirstNameLastName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterModels", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.RegisterModels", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisterModels", "LastName");
            DropColumn("dbo.RegisterModels", "FirstName");
        }
    }
}
