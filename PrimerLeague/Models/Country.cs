using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public int? FifaRank { get; set; }

    public int? ContinentId { get; set; }

    public virtual ICollection<CoachProfile> CoachProfiles { get; set; } = new List<CoachProfile>();

    public virtual Continent? Continent { get; set; }

    public virtual ICollection<PlayerProfile> PlayerProfiles { get; set; } = new List<PlayerProfile>();
}
