using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text;

namespace Core.Entity
{
    public class Course
    {
        public long Id { get; set; }
        [Required]
        [MinLength(1)]  
        public string Name { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
