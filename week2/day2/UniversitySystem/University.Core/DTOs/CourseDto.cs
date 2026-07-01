using System;
using System.Collections.Generic;
using System.Text;

namespace University.Core.DTOs
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public int Weight { get; set; }
    }
}
