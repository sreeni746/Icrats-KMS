using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Icrats.KMS.DAL.Entities
{
    public class Door
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoorId { get; set; }

        [Required]
        [StringLength(100)]
        public string? DoorCode { get; set; }

        [StringLength(500)]
        public string? DoorDescription { get; set; } 

        // Foreign Key to Facility
        [Required]
        public int FacilityId { get; set; }

        // Navigation Property for Facility
        public Facility? Facility { get; set; }

        // Foreign Key to DoorType
        [Required]
        public int DoorTypeId { get; set; }

        // Navigation Property for DoorType
        public DoorType? DoorType { get; set; }

        // Collection of locks associated with the door
        public ICollection<Lock> Locks { get; set; } = new List<Lock>();
    }
}
