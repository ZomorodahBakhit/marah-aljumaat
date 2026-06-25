using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDB2.Models
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        // relationships (1:1 syllabus, M:1 users, 1:M Assignments )
        public Syllabus Syllabus { get; set; }
        public int TeacherId { get; set; }// FK we put the FK here BC course is the dependent entity
        public User Teacher { get; set; } 
        public ICollection<Assignment> Assignments { get; set; }
    }
}
