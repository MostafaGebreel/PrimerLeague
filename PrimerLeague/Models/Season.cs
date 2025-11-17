using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class Season
{
    public int SeasonId { get; set; }

    public int NumberOfMatchPlayed { get; set; }

    public virtual ICollection<PlayerReport> PlayerReports { get; set; } = new List<PlayerReport>();

    public virtual ICollection<Rank> Ranks { get; set; } = new List<Rank>();

    public virtual ICollection<TeamManager> TeamManagers { get; set; } = new List<TeamManager>();

    public virtual ICollection<TeamMarketValue> TeamMarketValues { get; set; } = new List<TeamMarketValue>();
}
