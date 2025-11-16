using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

public partial class Season
{
    [Key]
    [Column("SeasonID")]
    public int SeasonId { get; set; }

    public int NumberOfMatchPlayed { get; set; }

    [InverseProperty("Season")]
    public virtual ICollection<PlayerReport> PlayerReport { get; set; } = new List<PlayerReport>();

    [InverseProperty("Season")]
    public virtual ICollection<Rank> Rank { get; set; } = new List<Rank>();

    [InverseProperty("Season")]
    public virtual ICollection<TeamMarketValue> TeamMarketValue { get; set; } = new List<TeamMarketValue>();
}
