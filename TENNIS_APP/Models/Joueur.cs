using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TENNIS_APP.Models
{
    public class Joueur
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
        [Column("PRENOM")]
        public string prenom { get; set; }
        [Required]

        [Column("AGE")]
        public int Age { get; set; }

        [MaxLength(50)]
        [Column("NATIONALITE")]
        public string Nationalite { get; set; }

      
        
    }
}
