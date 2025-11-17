using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class Continent
{
    public int ContinentId { get; set; }

    public string ContinentName { get; set; } = null!;

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
}
