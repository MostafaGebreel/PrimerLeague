using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

public partial class Continents
{
    [Key]
    [Column("ContinentID")]
    public int ContinentId { get; set; }

    [StringLength(100)]
    public string ContinentName { get; set; } = null!;

    [InverseProperty("Continent")]
    public virtual ICollection<Country> Country { get; set; } = new List<Country>();
}
