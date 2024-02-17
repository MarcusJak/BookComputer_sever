using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication8.Model
{
    public partial class Test
    {
        [Key]
        [Column("TestID")]
        public int TestId { get; set; }
        [Column("PersonID")]
        public int? PersonId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? TestName { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? TestResult { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("Tests")]
        public virtual Person? Person { get; set; }
    }
}
