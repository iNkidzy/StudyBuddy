using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    public enum UserType
    {
        User,
        Teacher,
        Admin
    }
    public class User
    {
        public long Id { get; set; }
        public List<Course> Courses { get; set; }
        public List<Topic> SavedTopics { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Password { get; set; }
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public string Email { get; set; }
    }
}
