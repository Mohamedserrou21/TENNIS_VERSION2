using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TENNIS_APP.Models
{
    [Table("Sponsor", Schema = "dbo")]
    public class Sponsor
    {
        [Key]
        [Column("ID")]
        public int? id { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("NOM")]
        public string nom { get; set; }
        [Required]
        [MaxLength(10)]
        [Column("ADRESS")]
        public string adress { get; set; }
        [Required]
        
        [Column("CHIFFRE")]
        public int chiffre_daffaire { get; set; }
    }
}
