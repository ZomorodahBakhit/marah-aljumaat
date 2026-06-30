using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace University.Core.Forms
{
    public class CreateStudentForm
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
