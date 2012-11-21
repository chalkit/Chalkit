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
    public class ChalkitDbContext : DbContext
    {
        public ChalkitDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Student> Students { get; set; }
    }

}