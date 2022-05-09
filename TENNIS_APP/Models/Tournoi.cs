using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TENNIS_APP.Models
{
    [Table("Tournoi", Schema = "dbo")]
    public class Tournoi
    {
        [Key]
        [Column("ID")]
        public int? id { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("NOM")]
        public string nom { get; set; }
        [Required]

        [Column("PRIX")]
        public int prix { get; set; }
        [Required]

        [Column("DATE")]
        public int date { get; set; }


        [Column("CAPACITE")]
        public int capacite { get; set; }

    }
}
