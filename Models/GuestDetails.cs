using System.ComponentModel.DataAnnotations;

namespace PGManagement.Models
{
    public class GuestDetails
    {
        [Key]
        public int GuestId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string contact { get; set; }
        public string AadharNumber { get; set; }
        public DateTime JoiningDate { get; set; }
        public bool IsActive { get; set; }

    }
}
