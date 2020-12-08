using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class StudyBuddyContext : DbContext
    {
        public StudyBuddyContext(DbContextOptions<StudyBuddyContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.UserType)
                .HasConversion<string>();
            //modelBuilder.Entity<User>().Property(u => u.Name)
            //    .HasMaxLength(40);
            //modelBuilder.Entity<Course>().Property(c => c.Name)
            //    .HasMaxLength(15);
            //modelBuilder.Entity<Topic>().Property(t => t.Name)
            //    .HasMaxLength(30);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
