using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Icrats.KMS.DAL.Entities
{
    public class CustodianType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustodianTypeId { get; set; }
        [Required]
        [StringLength(100)]
        public string? CustodianTypeName { get; set; }
        [StringLength(500)]
        public string? CustodianTypeDescription { get; set; }
    }
}
