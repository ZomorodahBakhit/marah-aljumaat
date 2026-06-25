using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDB2.Models
{
    internal class Assignment
    {
        public int AssignmentId { get; set; }
        public string AssignmentTitle { get; set; }
        public string AssignmentDescription { get; set; }
        public Decimal Weight { get; set; }
        public int MaxGrade { get; set; }
        public DateOnly DueDate { get; set; }

        // relationships (M:1 course, 1:M comments, 1:M grade)
        public int CourseId { get; set; } // FK we put the FK here BC assignment is the dependent entity
        public Course Course { get; set; }
        public ICollection<Comment> Comments { get; set; } // one-to-many relationship with Comment
        public ICollection<Grade> Grades { get; set; } // one-to-many relationship with Grade
    }
}
