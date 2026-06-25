using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDB2.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int GradeNumber { get; set; }
        // relationships (M:1 user, 1:M assignment)
        public int StudentId { get; set; } // FK we put the FK here BC grade is the dependent entity
        public User Student { get; set; }
        public int AssignmentId { get; set; } // FK we put the FK here BC grade is the dependent entity
        public Assignment Assignment { get; set; }
    }
}
