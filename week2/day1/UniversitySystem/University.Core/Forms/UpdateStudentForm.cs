using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University.Core.Forms
{
    public class UpdateStudentForm
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
