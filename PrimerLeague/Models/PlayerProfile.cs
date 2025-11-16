using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

public partial class PlayerProfile
{
    [Key]
    [Column("PlayerID")]
    public int PlayerId { get; set; }

    [StringLength(50)]
    public string PlayerName { get; set; } = null!;

    public DateOnly BirthDay { get; set; }

    [StringLength(10)]
    public string? Position { get; set; }

    public int? Height { get; set; }

    public int? Weight { get; set; }

    [StringLength(10)]
    public string? PreferredFoot { get; set; }

    public int MarketValue { get; set; }

    [Column("CountryID")]
    public int CountryId { get; set; }

    [Column("TeamID")]
    public int? TeamId { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("PlayerProfile")]
    public virtual Country Country { get; set; } = null!;

    [InverseProperty("Player")]
    public virtual ICollection<PlayerReport> PlayerReport { get; set; } = new List<PlayerReport>();

    [ForeignKey("TeamId")]
    [InverseProperty("PlayerProfile")]
    public virtual Team? Team { get; set; }

    [InverseProperty("Player")]
    public virtual ICollection<TransferReport> TransferReport { get; set; } = new List<TransferReport>();
}
