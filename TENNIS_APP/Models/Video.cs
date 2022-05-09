using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TENNIS_APP.Models
{
    [Table("Video", Schema = "dbo")]
    public class Video
    {
        [Key]
        [Column("ID")]
        public int? id { get; set; }
        [Required]
        [MaxLength(1000000)]
        public string Joueur_video { get; set; }

        [ForeignKey("Video_Joueur")]
        public Joueur Video_JO { get; set; }
        [Required]
        [MaxLength(1000000)]
        [Column("Video_Player")]
        public string Source { get; set; }
    }
}
