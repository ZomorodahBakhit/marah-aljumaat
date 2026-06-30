using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University.Core.Forms
{
    public class CreateCourseFrom
    {
        public string CourseName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Range(0,100)]
        int Weight { get; set; }
    }
}
