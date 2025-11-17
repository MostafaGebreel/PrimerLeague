using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class PlayerReport
{
    public string PlayerName { get; set; } = null!;

    public string Team { get; set; } = null!;

    public int? MatchPlayed { get; set; }

    public int? Start { get; set; }

    public int? Minutes { get; set; }

    public double? Xg { get; set; }

    public int? Goals { get; set; }

    public int? Assists { get; set; }

    public int? TotalShots { get; set; }

    public int? ShotsOnTarget { get; set; }

    public int? TotalPasses { get; set; }

    public double? SuccessfulPasses { get; set; }

    public int? Blocks { get; set; }

    public int? YellowCards { get; set; }

    public int? RedCards { get; set; }

    public int? Gksaves { get; set; }

    public int SeasonId { get; set; }

    public int PlayerId { get; set; }

    public int? TeamId { get; set; }

    public virtual PlayerProfile Player { get; set; } = null!;

    public virtual Season Season { get; set; } = null!;
}
