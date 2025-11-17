using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class CoachProfile
{
    public int CoachId { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<TeamManager> TeamManagers { get; set; } = new List<TeamManager>();
}
