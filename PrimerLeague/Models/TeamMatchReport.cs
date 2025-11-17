using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class TeamMatchReport
{
    public int MatchId { get; set; }

    public int HomeTeamId { get; set; }

    public int OpponentTeamId { get; set; }

    public bool IsHome { get; set; }

    public string Result { get; set; } = null!;

    public short GoalsScored { get; set; }

    public short GoalsRecived { get; set; }

    public int Possession { get; set; }

    public short RedCard { get; set; }

    public short YellowCard { get; set; }

    public short Offside { get; set; }

    public virtual Team HomeTeam { get; set; } = null!;

    public virtual MatchReport Match { get; set; } = null!;
}
