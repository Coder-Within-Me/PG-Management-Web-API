using System.ComponentModel.DataAnnotations;

namespace PGManagement.Models.DTO
{
    public class CreateNewGuestDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Aadhar { get; set; }
        public string JoiningDate { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public string Bed { get; set; }
        
    }
}
