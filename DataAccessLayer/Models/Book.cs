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
        public DateTime BookedFors { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime CanceledOn { get; set; }
        public string BookedBy { get; set; }
        public int BookPilotMappingID { get; set; }
        public string StaffIDs { get; set; }
        public Users Users { get; set; }
    }
}
