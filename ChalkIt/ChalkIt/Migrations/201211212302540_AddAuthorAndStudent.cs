namespace ChalkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorAndStudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PersonalEmail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PersonalEmail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            DropTable("dbo.UserProfile");
            DropTable("dbo.RegisterModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegisterModels",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PersonalEmail = c.String(nullable: false),
                        AccountType = c.Int(nullable: false),
                        TermsAndConditions = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropTable("dbo.Students");
            DropTable("dbo.Authors");
        }
    }
}
