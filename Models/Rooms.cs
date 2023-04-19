using System.ComponentModel.DataAnnotations;

namespace PGManagement.Models
{
    public class Rooms
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomNumber { get; set;}

    }
}
