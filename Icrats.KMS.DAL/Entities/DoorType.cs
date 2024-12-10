using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Icrats.KMS.DAL.Entities
{
    public class DoorType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoorTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string? DoorTypeName { get; set; } 

        [StringLength(500)]
        public string? DoorTypeDescription { get; set; }

        // Navigation Property for Doors
        public ICollection<Door> Doors { get; set; } = new List<Door>();
    }
}
