using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icrats.KMS.DAL.Entities
{
    public class Custodian
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustodianId { get; set; } // Unique identifier for the custodian entry

        public int UserId { get; set; }  // Foreign Key for User (mapping users to custodian)
        public User? User { get; set; }   // Navigation property to User entity

        public int CustodianTypeId { get; set; }  // Foreign Key for CustodianType
        public CustodianType? CustodianType { get; set; }  // Navigation property to CustodianType entity

        // Optional: Additional fields, such as the date the custodian was assigned
        public DateTime AssignedOn { get; set; }

        public string? Status { get; set; } // Optional: You can track the status of the assignment (e.g., Active, Inactive)
    }

}
