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
    public class Exercise
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Exercise ID")]
        public int ExerciseID { get; set; }

        [Required]
        [Display(Name = "Exercise name")]
        public string ExerciseName { get; set; }

        [Required]
        [Display(Name = "Exercise description")]
        public string ExerciseDescription { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}