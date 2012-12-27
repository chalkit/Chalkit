using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using ChalkIt.Validation;

namespace ChalkIt.Models
{
    public class Course
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [Required]
        [Display(Name = "Course name")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Course description")]
        public string CourseDescription { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        [Required]
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}