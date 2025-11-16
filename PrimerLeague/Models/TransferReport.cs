using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

[PrimaryKey("PlayerId", "TeamId")]
public partial class TransferReport
{
    [Key]
    [Column("PlayerID")]
    public int PlayerId { get; set; }

    [Key]
    [Column("TeamID")]
    public int TeamId { get; set; }

    public long TransferValue { get; set; }

    public DateOnly TransferDate { get; set; }

    public int WeekSalary { get; set; }

    public bool Available { get; set; }

    [ForeignKey("PlayerId")]
    [InverseProperty("TransferReport")]
    public virtual PlayerProfile Player { get; set; } = null!;

    [ForeignKey("TeamId")]
    [InverseProperty("TransferReport")]
    public virtual Team Team { get; set; } = null!;
}
