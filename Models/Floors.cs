using System.ComponentModel.DataAnnotations;

namespace PGManagement.Models
{
    public class Floors
    {
        [Key]
        public int FloorId { get; set; }
        public string FloorNumber { get; set;}
    }
}
