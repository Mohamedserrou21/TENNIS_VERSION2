using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TENNIS_APP.Models
{
    public class Event
    {
        [Key]
        [Column("EventID")]
        public int EventID { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("Subject")]
        public string Subject { get; set; }
        [Required]
        [MaxLength(10000)]
        [Column("Description")]
        public string Description{ get; set; }
        [Required]
       
        [Column("Start")]
        public DateTime Start{ get; set; }
        [Required]
       
        [Column("End")]
        public DateTime End { get; set; }

        [Required]
        [MaxLength(1000)]
        [Column("ThemeColor")]
        public string ThemeColor{ get; set; }


        [Required]
        
        [Column("IsFullDay")]
        public Boolean IsFullDay { get; set; }

    }
}
