using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class Users
    {
        public int UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        public int RoleType { get; set; }
        public DateTime RegisteredDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
