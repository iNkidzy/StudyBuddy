using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text;

namespace Core.Entity
{
    public class Comment
    {
        public long Id { get; set; }
        [Required]
        public User User { get; set; }
        public Topic Topic { get; set; }
        public DateTime DatePosted { get; set; }
        public string MainBody { get; set; }
    }
}
