using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication8.Model
{
    public partial class Person
    {
        public Person()
        {
            Tests = new HashSet<Test>();
        }

        [Key]
        [Column("PersonID")]
        public int PersonId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Name { get; set; }

        [InverseProperty("Person")]
        public virtual ICollection<Test> Tests { get; set; }
    }
}
