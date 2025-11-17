using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public string Stadium { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? TeamPlayersImage { get; set; }

    public virtual ICollection<PlayerProfile> PlayerProfiles { get; set; } = new List<PlayerProfile>();

    public virtual ICollection<Rank> Ranks { get; set; } = new List<Rank>();

    public virtual ICollection<TeamManager> TeamManagers { get; set; } = new List<TeamManager>();

    public virtual ICollection<TeamMarketValue> TeamMarketValues { get; set; } = new List<TeamMarketValue>();

    public virtual ICollection<TeamMatchReport> TeamMatchReports { get; set; } = new List<TeamMatchReport>();

    public virtual ICollection<TransferReport> TransferReports { get; set; } = new List<TransferReport>();
}
