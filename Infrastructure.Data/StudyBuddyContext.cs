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
            modelBuilder.Entity<User>().HasMany(c => c.Courses);
            modelBuilder.Entity<User>().HasMany(c => c.SavedTopics);
            modelBuilder.Entity<Course>().HasMany(t => t.Topics);
            modelBuilder.Entity<Topic>().HasMany(c => c.Comments);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
