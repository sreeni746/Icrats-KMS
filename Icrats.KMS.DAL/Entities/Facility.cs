using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Icrats.KMS.DAL.Entities
{
    public class Facility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacilityId { get; set; }

        [Required]
        [StringLength(100)]
        public string? FacilityName { get; set; } 

        [Required]
        [StringLength(250)]
        public string? FacilityAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string? FacilityLocation { get; set; }

        // Navigation Property for Doors
        public ICollection<Door> Doors { get; set; } = new List<Door>();
    }

}
