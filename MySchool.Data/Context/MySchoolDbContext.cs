using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySchool.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Data.Context
{
    public class MySchoolDbContext : IdentityDbContext<User>
    {
        public MySchoolDbContext(DbContextOptions<MySchoolDbContext> options) : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAssignment> TeacherAssignments { get; set; }
        public DbSet<Topic> Topics { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints here using the modelBuilder object
            // For example:
            // modelBuilder.Entity<Teacher>()
            //     .HasMany(t => t.Classes)
            //     .WithOne(c => c.Teacher)
            //     .HasForeignKey(c => c.TeacherId);
        }
    }
}
