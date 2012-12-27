namespace ChalkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exercise_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ExerciseID = c.Int(nullable: false, identity: true),
                        ExerciseName = c.String(nullable: false),
                        ExerciseDescription = c.String(nullable: false),
                        Course_CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.ExerciseID)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID)
                .Index(t => t.Course_CourseID);
            
            AddColumn("dbo.Authors", "Exercise_ExerciseID", c => c.Int());
            AddForeignKey("dbo.Authors", "Exercise_ExerciseID", "dbo.Exercises", "ExerciseID");
            CreateIndex("dbo.Authors", "Exercise_ExerciseID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Exercises", new[] { "Course_CourseID" });
            DropIndex("dbo.Authors", new[] { "Exercise_ExerciseID" });
            DropForeignKey("dbo.Exercises", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Authors", "Exercise_ExerciseID", "dbo.Exercises");
            DropColumn("dbo.Authors", "Exercise_ExerciseID");
            DropTable("dbo.Exercises");
        }
    }
}
