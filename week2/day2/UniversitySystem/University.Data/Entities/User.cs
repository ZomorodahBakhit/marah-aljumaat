using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace University.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Role : IdentityRole<int>
    {
    }
    public class RoleClaim : IdentityRoleClaim<int>
    {
    }
    public class UserClaim : IdentityUserClaim<int>
    {
    }
    public class UserLogin : IdentityUserLogin<int>
    {
    }
    public class UserRole : IdentityUserRole<int>
    {
    }
    public class UserToken : IdentityUserToken<int>
    {
    }
}

