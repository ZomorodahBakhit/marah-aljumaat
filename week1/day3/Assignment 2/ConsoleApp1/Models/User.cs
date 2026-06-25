using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDB2.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; } //email address should be unique 
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        // relationships (M:N courses, 1:M comments, 1:M Grades) 
        public ICollection<Course> Courses { get; set; } // one-to-many relationship with Course
        public ICollection<Comment> Comments { get; set; } // one-to-many relationship with Comment
        public ICollection<Grade> Grades { get; set; } // one-to-many relationship with Grade
    }
}
