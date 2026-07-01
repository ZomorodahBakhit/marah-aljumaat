using System;
using System.Collections.Generic;
using System.Text;

namespace University.Core.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Phone { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string Role { get; set; }
    }
}
