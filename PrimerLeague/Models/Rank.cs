using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

[PrimaryKey("TeamId", "SeasonId")]
public partial class Rank
{
    [StringLength(50)]
    public string Team { get; set; } = null!;

    [Column("Rank")]
    public int Rank1 { get; set; }

    [Key]
    [Column("SeasonID")]
    public int SeasonId { get; set; }

    [Key]
    [Column("TeamID")]
    public int TeamId { get; set; }

    [ForeignKey("SeasonId")]
    [InverseProperty("Rank")]
    public virtual Season Season { get; set; } = null!;

    [ForeignKey("TeamId")]
    [InverseProperty("Rank")]
    public virtual Team TeamNavigation { get; set; } = null!;
}
