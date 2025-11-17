using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class TransferReport
{
    public int PlayerId { get; set; }

    public int TeamId { get; set; }

    public long TransferValue { get; set; }

    public DateOnly TransferDate { get; set; }

    public int WeekSalary { get; set; }

    public bool Available { get; set; }

    public virtual PlayerProfile Player { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
