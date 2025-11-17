using System;
using System.Collections.Generic;

namespace PrimerLeague.Models;

public partial class VwTopTransfer
{
    public string PlayerName { get; set; } = null!;

    public long TransferValue { get; set; }

    public DateOnly TransferDate { get; set; }
}
