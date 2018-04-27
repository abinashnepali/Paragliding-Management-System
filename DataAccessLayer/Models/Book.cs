using System;

namespace DataAccessLayer
{
    public class Book
    {
        public int BookID { get; set; }
        public DateTime BookedOn { get; set; }
        public DateTime BookedFor { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime CanceledOn { get; set; }
        public int BookedBy { get; set; }
        public int BookPilotMappingID { get; set; }
        public int StaffID { get; set; }
    }
}
