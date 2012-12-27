namespace ChalkIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exercise_Migration_changeFromAuthorToCoursesCollection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authors", "Exercise_ExerciseID", "dbo.Exercises");
            DropForeignKey("dbo.Exercises", "Course_CourseID", "dbo.Courses");
            DropIndex("dbo.Authors", new[] { "Exercise_ExerciseID" });
            DropIndex("dbo.Exercises", new[] { "Course_CourseID" });
            CreateTable(
                "dbo.CourseExercises",
                c => new
                    {
                        Course_CourseID = c.Int(nullable: false),
                        Exercise_ExerciseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_CourseID, t.Exercise_ExerciseID })
                .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Exercises", t => t.Exercise_ExerciseID, cascadeDelete: true)
                .Index(t => t.Course_CourseID)
                .Index(t => t.Exercise_ExerciseID);
            
            DropColumn("dbo.Authors", "Exercise_ExerciseID");
            DropColumn("dbo.Exercises", "Course_CourseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exercises", "Course_CourseID", c => c.Int());
            AddColumn("dbo.Authors", "Exercise_ExerciseID", c => c.Int());
            DropIndex("dbo.CourseExercises", new[] { "Exercise_ExerciseID" });
            DropIndex("dbo.CourseExercises", new[] { "Course_CourseID" });
            DropForeignKey("dbo.CourseExercises", "Exercise_ExerciseID", "dbo.Exercises");
            DropForeignKey("dbo.CourseExercises", "Course_CourseID", "dbo.Courses");
            DropTable("dbo.CourseExercises");
            CreateIndex("dbo.Exercises", "Course_CourseID");
            CreateIndex("dbo.Authors", "Exercise_ExerciseID");
            AddForeignKey("dbo.Exercises", "Course_CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.Authors", "Exercise_ExerciseID", "dbo.Exercises", "ExerciseID");
        }
    }
}
