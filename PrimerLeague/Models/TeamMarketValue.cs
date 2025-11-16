using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

[PrimaryKey("TeamId", "SeasonId")]
public partial class TeamMarketValue
{
    [Key]
    [Column("TeamID")]
    public int TeamId { get; set; }

    [Key]
    [Column("SeasonID")]
    public int SeasonId { get; set; }

    public int MarketValue { get; set; }

    [ForeignKey("SeasonId")]
    [InverseProperty("TeamMarketValue")]
    public virtual Season Season { get; set; } = null!;

    [ForeignKey("TeamId")]
    [InverseProperty("TeamMarketValue")]
    public virtual Team Team { get; set; } = null!;
}
