using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

public partial class CoachProfile
{
    [Key]
    [Column("CoachID")]
    public int CoachId { get; set; }

    [StringLength(50)]
    public string FullName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    [Column("CountryID")]
    public int CountryId { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("CoachProfile")]
    public virtual Country Country { get; set; } = null!;

    [InverseProperty("Coach")]
    public virtual ICollection<TeamManagers> TeamManagers { get; set; } = new List<TeamManagers>();
}
