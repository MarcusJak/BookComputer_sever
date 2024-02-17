using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication8.Model
{
    [Table("Kunder")]
    public partial class Kunder
    {
        public Kunder()
        {
            Hyrnings = new HashSet<Hyrning>();
        }

        [Key]
        [Column("Kund_ID")]
        public int KundId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Lösenord { get; set; }
        [Column("Företags_Namn")]
        [StringLength(50)]
        [Unicode(false)]
        public string? FöretagsNamn { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Adress { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Telefonnummer { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Epost { get; set; }

        [InverseProperty("Kund")]
        public virtual ICollection<Hyrning> Hyrnings { get; set; }
    }
}
