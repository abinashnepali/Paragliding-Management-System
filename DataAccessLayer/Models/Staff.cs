using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class Staff
    {
        public int StaffID { get; set; }

        [Required(ErrorMessage = "First Name Is Required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address Is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number Is Required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }
        public string Photo { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }

        [Required]
        public string Designation { get; set; }
    }
}
