using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Core.Entity
{
    public class Course
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
