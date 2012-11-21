namespace ChalkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.RegisterModels",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        PersonalEmail = c.String(nullable: false),
                        TermsAndConditions = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegisterModels");
            DropTable("dbo.UserProfile");
        }
    }
}
