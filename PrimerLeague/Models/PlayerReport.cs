using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

[PrimaryKey("PlayerId", "SeasonId")]
public partial class PlayerReport
{
    [StringLength(50)]
    public string PlayerName { get; set; } = null!;

    [StringLength(50)]
    public string Team { get; set; } = null!;

    public int? MatchPlayed { get; set; }

    public int? Start { get; set; }

    public int? Minutes { get; set; }

    [Column("XG")]
    public double? Xg { get; set; }

    public int? Goals { get; set; }

    public int? Assists { get; set; }

    public int? TotalShots { get; set; }

    public int? ShotsOnTarget { get; set; }

    [Column("Total_Passes")]
    public int? TotalPasses { get; set; }

    public double? SuccessfulPasses { get; set; }

    public int? Blocks { get; set; }

    public int? YellowCards { get; set; }

    public int? RedCards { get; set; }

    [Column("GKSaves")]
    public int? Gksaves { get; set; }

    [Key]
    [Column("SeasonID")]
    public int SeasonId { get; set; }

    [Key]
    [Column("PlayerID")]
    public int PlayerId { get; set; }

    [Column("TeamID")]
    public int? TeamId { get; set; }

    [ForeignKey("PlayerId")]
    [InverseProperty("PlayerReport")]
    public virtual PlayerProfile Player { get; set; } = null!;

    [ForeignKey("SeasonId")]
    [InverseProperty("PlayerReport")]
    public virtual Season Season { get; set; } = null!;

    [ForeignKey("TeamId")]
    [InverseProperty("PlayerReport")]
    public virtual Team? TeamNavigation { get; set; }
}
