using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class TeamMarketValue
{
    public int TeamId { get; set; }

    public int SeasonId { get; set; }

    public int MarketValue { get; set; }

    public virtual Season Season { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
