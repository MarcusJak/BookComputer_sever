using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication8.Model
{
    [Table("Datorer")]
    public partial class Datorer
    {
        public Datorer()
        {
            DatorHyrnings = new HashSet<DatorHyrning>();
        }

        [Key]
        [Column("Dator_ID")]
        public int DatorId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Typ { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Märke { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Modell { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Serienummer { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? PrisPerDag { get; set; }

        [InverseProperty("Dator")]
        public virtual ICollection<DatorHyrning> DatorHyrnings { get; set; }
    }
}
