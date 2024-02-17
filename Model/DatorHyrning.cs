using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication8.Model
{
    [Table("Dator_Hyrning")]
    public partial class DatorHyrning
    {
        public DatorHyrning()
        {
        }
        [Column("Dator_ID")]
        public int DatorId { get; set; }
        [Column("Hyrnings_ID")]
        public int HyrningsId { get; set; }
        [Key]
        [Column("Dator_Hyrning_id")]
        public int DatorHyrningId { get; set; }

        [ForeignKey("DatorId")]
        [InverseProperty("DatorHyrnings")]
        public virtual Datorer? Dator { get; set; } = null;
        [ForeignKey("HyrningsId")]
        [InverseProperty("DatorHyrnings")]
        public virtual Hyrning? Hyrnings { get; set; } = null;
    }
}
