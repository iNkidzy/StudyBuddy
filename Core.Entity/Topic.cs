using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

namespace Core.Entity
{
    public class Topic
    {
        public long Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        public string MainBody { get; set; }
        public List<Comment> Comments { get; set; }
        public Course Course { get; set; }
    }
}
