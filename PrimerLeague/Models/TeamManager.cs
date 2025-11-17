using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class TeamManager
{
    public string Manager { get; set; } = null!;

    public string Team { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int Coachid { get; set; }

    public int Teamid { get; set; }

    public int Seasonid { get; set; }

    public virtual CoachProfile Coach { get; set; } = null!;

    public virtual Season Season { get; set; } = null!;

    public virtual Team TeamNavigation { get; set; } = null!;
}
