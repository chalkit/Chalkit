namespace ChalkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorUserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PersonalEmail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorUserName);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        CourseDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
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
            
            CreateTable(
                "dbo.AuthorCourses",
                c => new
                    {
                        Author_AuthorUserName = c.String(nullable: false, maxLength: 128),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Author_AuthorUserName, t.Course_CourseID })
                .ForeignKey("dbo.Authors", t => t.Author_AuthorUserName, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Author_AuthorUserName)
                .Index(t => t.Course_CourseID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AuthorCourses", new[] { "Course_CourseID" });
            DropIndex("dbo.AuthorCourses", new[] { "Author_AuthorUserName" });
            DropForeignKey("dbo.AuthorCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.AuthorCourses", "Author_AuthorUserName", "dbo.Authors");
            DropTable("dbo.AuthorCourses");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
            DropTable("dbo.Authors");
        }
    }
}
