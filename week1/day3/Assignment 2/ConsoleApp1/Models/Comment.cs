using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDB2.Models
{
    internal class Comment
    {
        public int CommentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CommentContent { get; set; }
        // relationships (1:M user, M:1 assignment )
        public int UserId { get; set; } // FK we put the FK here BC comment is the dependent entity
        public User User { get; set; }
        public int AssignmentId { get; set; } // FK we put the FK here BC comment is the dependent entity
        public Assignment Assignment { get; set; }
    }
}
