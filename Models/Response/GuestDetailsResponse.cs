namespace PGManagement.Models.Response
{
    public class GuestDetailsResponse
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public string Name { get; set; }

        public string FloorNumber { get; set; }
        public string RoomNumber { get; set; }
        public string BedNumber { get; set; }
        public string JoiningDate { get; set; }
        public bool IsActive { get; set; }
    }
}
