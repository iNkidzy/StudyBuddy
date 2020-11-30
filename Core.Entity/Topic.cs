using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

namespace Core.Entity
{
    public class Topic
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MainBody { get; set; }
        public List<Comment> Comment { get; set; }
        public Course Course { get; set; }
    }
}
