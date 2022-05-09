using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TENNIS_APP.Models
{
    [Table("Subvention", Schema = "dbo")]
    public class Subvention
    {

        [Key]
        
        [Column("ID")]
        public int? id { get; set; }
        [Required]
        [Column("MONTANT")]
        public int Montant { get; set; }
        [Required]
        public int NOM_TR { get; set; }

        [ForeignKey("NOM_TR")]
        public Tournoi Nom_tr { get; set; }
        [Required]
        public String NAME_SPR { get; set; }

        [ForeignKey("NOM_SPTR")]
        public Sponsor NAME_SP { get; set; }
    }
}
