using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

public partial class MatchReport
{
    [Key]
    [Column("MatchID")]
    public int MatchId { get; set; }

    public DateOnly MatchDate { get; set; }

    public TimeOnly MatchTime { get; set; }

    [StringLength(15)]
    public string Round { get; set; } = null!;

    [Column("TeamID 1")]
    public int? TeamId1 { get; set; }

    [Column("TeamID 2")]
    public int? TeamId2 { get; set; }

    [InverseProperty("Match")]
    public virtual ICollection<TeamMatchReport> TeamMatchReport { get; set; } = new List<TeamMatchReport>();
}
