using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TENNIS_APP.Models
{

    [Table("Gain", Schema = "dbo")]
    public class Gain
    {
        [Key]
        [Column("ID")]
        public int? id { get; set; }

        [Required]
        public int ID_JOUEUR { get; set; }

        [ForeignKey("ID_JOUEUR")]
        public Joueur joueur { get; set; }
        [Required]
        public int Nom_SPONSOR { get; set; }

        [ForeignKey("Nom_SPONSOR")]
        public Sponsor Nom_sponsor { get; set; }
        [Required]


        [Column("PRIME")]
        public int prime { get; set; }
        [Required]
        public int ANNEE { get; set; }

        [ForeignKey("ANNEE_TOURNOI")]
        public Tournoi annee_tournoi { get; set; }


    }
}
