using System.ComponentModel.DataAnnotations.Schema;

namespace PGManagement.Models
{
    public class Guests
    {
        public int Id { get; set; }
        
        public int GuestId { get; set; }
        [ForeignKey("GuestId")]
        public GuestDetails GuestDetails { get; set; }
        public int FloorId { get; set; }
        [ForeignKey("FloorId")]
        public Floors Floors { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Rooms Rooms { get; set; }
        public int BedId { get; set; }
        [ForeignKey("BedId")]
        public Beds Beds { get; set; }

    }
}
