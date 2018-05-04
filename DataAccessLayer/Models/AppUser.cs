using Microsoft.AspNetCore.Identity;
using System;

namespace DataAccessLayer.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }

    }
}
