namespace ChalkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterModels", "AccountType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisterModels", "AccountType");
        }
    }
}
