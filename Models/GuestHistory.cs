using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PGManagement.Models
{
    public class GuestHistory
    {
        [Key]
        public int Id { get; set; }        
        public DateTime PaidOn { get; set; }
        public string? Description { get; set; }

        public int GuestId { get; set; }

        [ForeignKey("GuestId")]
        public GuestDetails GuestDetails { get; set; }
    }
}
