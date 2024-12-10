using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icrats.KMS.DAL.Entities
{
    public class KeySpareKeyMap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KeySpareKeyMapId { get; set; } // Unique identifier for the mapping

        // Foreign Key for the original Key
        public int KeyId { get; set; }
        public Key? Key { get; set; }

        // Foreign Key for the spare Key
        public int SpareKeyId { get; set; }
        public Key? SpareKey { get; set; }

        // Optional: Date or other metadata
        public DateTime AssignedOn { get; set; }
    }

}
