using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Icrats.KMS.DAL.Entities
{
    public class Key
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KeyId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Stampings { get; set; }

        [Required]
        [StringLength(50)]
        public string? KeyCode { get; set; }

        [StringLength(100)]
        public string? Brand { get; set; } 

        // Foreign Key to Lock
        [Required]
        public int LockId { get; set; }

        // Navigation Property for Lock
        public Lock? Lock { get; set; }

    }
}
