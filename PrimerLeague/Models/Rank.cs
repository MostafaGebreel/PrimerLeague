using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class Rank
{
    public string Team { get; set; } = null!;

    public int Rank1 { get; set; }

    public int SeasonId { get; set; }

    public int TeamId { get; set; }

    public virtual Season Season { get; set; } = null!;

    public virtual Team TeamNavigation { get; set; } = null!;
}
