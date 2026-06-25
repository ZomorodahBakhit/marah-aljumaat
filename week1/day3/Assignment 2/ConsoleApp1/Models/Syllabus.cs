using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDB2.Models
{
    internal class Syllabus
    {
        public int SyllabusId { get; set; }
        public string SyllabusDescription { get; set; }
        // relationships (1:1 course)   
        public int CourseId { get; set; } // FK we put the FK here BC syllabus is the dependent entity 
        public Course Course { get; set; }
    }
}
