﻿using System;
using System.Collections.Generic;

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
        public string Name { get; set; }
        public UserType UserType { get; set;}
        public string Email { get; set; }
        public List<Course> Courses { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
