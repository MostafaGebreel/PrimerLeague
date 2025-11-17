using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class MatchReport
{
    public int MatchId { get; set; }

    public DateOnly MatchDate { get; set; }

    public TimeOnly MatchTime { get; set; }

    public string Round { get; set; } = null!;

    public int? TeamId1 { get; set; }

    public int? TeamId2 { get; set; }

    public int? SeasonId { get; set; }

    public virtual ICollection<TeamMatchReport> TeamMatchReports { get; set; } = new List<TeamMatchReport>();
}
