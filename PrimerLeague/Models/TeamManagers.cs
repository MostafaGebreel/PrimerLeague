using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

[PrimaryKey("CoachId", "TeamId")]
public partial class TeamManagers
{
    [StringLength(50)]
    public string Manager { get; set; } = null!;

    [StringLength(50)]
    public string Team { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [Key]
    [Column("CoachID")]
    public int CoachId { get; set; }

    [Key]
    [Column("TeamID")]
    public int TeamId { get; set; }

    [ForeignKey("CoachId")]
    [InverseProperty("TeamManagers")]
    public virtual CoachProfile Coach { get; set; } = null!;

    [ForeignKey("TeamId")]
    [InverseProperty("TeamManagers")]
    public virtual Team TeamNavigation { get; set; } = null!;
}
