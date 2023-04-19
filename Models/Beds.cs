using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PGManagement.Models
{
    public class Beds
    {
        [Key]
        public int BedId { get; set; }
        public string BedNumber { get; set;}

    }
}
