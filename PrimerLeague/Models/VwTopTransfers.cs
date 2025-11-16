using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

[Keyless]
public partial class VwTopTransfers
{
    [StringLength(50)]
    public string PlayerName { get; set; } = null!;

    public long TransferValue { get; set; }

    public DateOnly TransferDate { get; set; }
}
