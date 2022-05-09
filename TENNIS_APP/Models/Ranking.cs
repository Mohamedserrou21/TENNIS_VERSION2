using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TENNIS_APP.Models
{
    [Table("RANKING", Schema = "dbo")]
    public class Ranking
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int? id { get; set; }
        [Required]
        [Column("SCORE")]
        public int score { get; set; }
        [Required]

        
        [Column("RANK")]
        public String Rank { get; set; }
        [Required]
        public int RANK_PLAYER { get; set; }

        [ForeignKey("ID_Player_RANK")]
        public Joueur Player_Rank { get; set; }

    }
}
