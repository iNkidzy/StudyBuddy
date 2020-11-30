using System;
using System.Collections.Generic;

namespace Core.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsTeacher { get; set; }
        public string Email { get; set; }
        public List<Course> Courses { get; set; }
    }
}
