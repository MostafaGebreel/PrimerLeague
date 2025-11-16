using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

public partial class Team
{
    [Key]
    [Column("TeamID")]
    public int TeamId { get; set; }

    [StringLength(50)]
    public string TeamName { get; set; } = null!;

    [StringLength(50)]
    public string Stadium { get; set; } = null!;

    [StringLength(50)]
    public string City { get; set; } = null!;

    [InverseProperty("Team")]
    public virtual ICollection<PlayerProfile> PlayerProfile { get; set; } = new List<PlayerProfile>();

    [InverseProperty("TeamNavigation")]
    public virtual ICollection<PlayerReport> PlayerReport { get; set; } = new List<PlayerReport>();

    [InverseProperty("TeamNavigation")]
    public virtual ICollection<Rank> Rank { get; set; } = new List<Rank>();

    [InverseProperty("TeamNavigation")]
    public virtual ICollection<TeamManagers> TeamManagers { get; set; } = new List<TeamManagers>();

    [InverseProperty("Team")]
    public virtual ICollection<TeamMarketValue> TeamMarketValue { get; set; } = new List<TeamMarketValue>();

    [InverseProperty("HomeTeam")]
    public virtual ICollection<TeamMatchReport> TeamMatchReport { get; set; } = new List<TeamMatchReport>();

    [InverseProperty("Team")]
    public virtual ICollection<TransferReport> TransferReport { get; set; } = new List<TransferReport>();
}
