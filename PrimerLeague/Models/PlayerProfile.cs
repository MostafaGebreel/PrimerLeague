using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class PlayerProfile
{
    public int PlayerId { get; set; }

    public string PlayerName { get; set; } = null!;

    public DateOnly BirthDay { get; set; }

    public string? Position { get; set; }

    public int? Height { get; set; }

    public int? Weight { get; set; }

    public string? PreferredFoot { get; set; }

    public int MarketValue { get; set; }

    public int CountryId { get; set; }

    public int? TeamId { get; set; }

    public string? PlayerImage { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<PlayerReport> PlayerReports { get; set; } = new List<PlayerReport>();

    public virtual Team? Team { get; set; }

    public virtual ICollection<TransferReport> TransferReports { get; set; } = new List<TransferReport>();
}
