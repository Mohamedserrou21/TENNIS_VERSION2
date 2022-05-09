using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TENNIS_APP.Models
{
    [Table("Rencontre", Schema = "dbo")]
    public class Rencontre
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int? id { get; set; }
        [Required]
        [Column("Date_Tournoi")]
        public String date_tournoi { get; set; }
        [Required]
        [Column("SCORE")]
        public String score { get; set; }
        [Required]



        public int ID_Tournoi { get; set; }

        [ForeignKey("ID_Tournoi")]
        public Tournoi tournoi { get; set; }
        [Required]
        public int ID_Gagant { get; set; }

        [ForeignKey("ID_GAGNANT")]
        public Joueur gagnant { get; set; }
        [Required]
        public int ID_PERDANT { get; set; }

        [ForeignKey("ID_PERDANT")]
        public Joueur PERDANT { get; set; }

    }
}
