using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

[PrimaryKey("MatchId", "HomeTeamId")]
public partial class TeamMatchReport
{
    [Key]
    [Column("MatchID")]
    public int MatchId { get; set; }

    [Key]
    [Column("HomeTeamID")]
    public int HomeTeamId { get; set; }

    [Column("OpponentTeamID")]
    public int OpponentTeamId { get; set; }

    public bool IsHome { get; set; }

    [StringLength(5)]
    public string Result { get; set; } = null!;

    public short GoalsScored { get; set; }

    public short GoalsRecived { get; set; }

    public int Possession { get; set; }

    public short RedCard { get; set; }

    [Column("Yellow_card")]
    public short YellowCard { get; set; }

    public short Offside { get; set; }

    [ForeignKey("HomeTeamId")]
    [InverseProperty("TeamMatchReport")]
    public virtual Team HomeTeam { get; set; } = null!;

    [ForeignKey("MatchId")]
    [InverseProperty("TeamMatchReport")]
    public virtual MatchReport Match { get; set; } = null!;
}
