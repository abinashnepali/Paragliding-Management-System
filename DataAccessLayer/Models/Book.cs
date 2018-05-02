using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class Book
    {
        [HiddenInput]
        public int BookID { get; set; }
        [Required]
        public DateTime BookedOn { get; set; }
        public DateTime BookedFor { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime CanceledOn { get; set; }
        public int BookedBy { get; set; }
        public int BookPilotMappingID { get; set; }
        public int StaffID { get; set; }
        public Users Users { get; set; }
    }
}
