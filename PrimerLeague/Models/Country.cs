using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

public partial class Country
{
    [Key]
    [Column("CountryID")]
    public int CountryId { get; set; }

    [StringLength(100)]
    public string CountryName { get; set; } = null!;

    public int? FifaRank { get; set; }

    [Column("ContinentID")]
    public int? ContinentId { get; set; }

    [InverseProperty("Country")]
    public virtual ICollection<CoachProfile> CoachProfile { get; set; } = new List<CoachProfile>();

    [ForeignKey("ContinentId")]
    [InverseProperty("Country")]
    public virtual Continents? Continent { get; set; }

    [InverseProperty("Country")]
    public virtual ICollection<PlayerProfile> PlayerProfile { get; set; } = new List<PlayerProfile>();
}
