using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Icrats.KMS.DAL.Entities
{
    public class Lock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LockId { get; set; }

        [Required]
        [StringLength(100)]
        public string? LockCode { get; set; } 

        // Collection of keys for this lock
        public ICollection<Key> Keys { get; set; } = new List<Key>();

        // Foreign Key to Door
        [Required]
        public int DoorId { get; set; }

        // Navigation Property for Door
        public Door? Door { get; set; }
    }
}
