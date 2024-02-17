using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication8.Model
{
    [Table("Hyrning")]
    public partial class Hyrning
    {
        public Hyrning()
        {
            DatorHyrnings = new HashSet<DatorHyrning>();
        }

        [Key]
        [Column("Hyrnings_ID")]
        public int HyrningsId { get; set; }
        [Column("Kund_ID")]
        public int? KundId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Startdatum { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Slutdatum { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Pris { get; set; }
        public bool? Paminelse { get; set; }

        [ForeignKey("KundId")]
        [InverseProperty("Hyrnings")]
        public virtual Kunder? Kund { get; set; }
        [InverseProperty("Hyrnings")]
        public virtual ICollection<DatorHyrning> DatorHyrnings { get; set; }
    }
}
