namespace ChalkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesToAuthorStudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        Author_UserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Authors", t => t.Author_UserName)
                .Index(t => t.Author_UserName);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Courses", new[] { "Author_UserName" });
            DropForeignKey("dbo.Courses", "Author_UserName", "dbo.Authors");
            DropTable("dbo.Courses");
        }
    }
}
