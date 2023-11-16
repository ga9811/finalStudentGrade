using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewStudent.Models;

namespace NewStudent.Data
{
    public class NewStudentContext : IdentityDbContext
    {
        public NewStudentContext (DbContextOptions<NewStudentContext> options)
            : base(options)
        {
        }

        public DbSet<NewStudent.Models.User> User { get; set; } = default!;

        public DbSet<NewStudent.Models.Course> Course { get; set; } = default!;

        public DbSet<NewStudent.Models.CourseGrade> CourseGrade { get; set; } = default!;
    }
}
