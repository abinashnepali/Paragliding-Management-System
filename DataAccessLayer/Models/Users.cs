using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class Users
    {               
        public string Id { get; set; }  
        
        [Required(ErrorMessage = "First Name Is Required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }  
        
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage ="Not A Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Username Is Required")]       
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Phone Number Is Required")]
        public string Phone { get; set; }          
        public int RoleType { get; set; }           
        public DateTime RegisteredDate { get; set; }        
        public bool IsDeleted { get; set; }        
        public DateTime DeletedOn { get; set; }
    }
}
