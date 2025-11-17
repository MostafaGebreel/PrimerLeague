using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PrimerLeague.Models;

public partial class PremierLeagueContext : DbContext
{
    public PremierLeagueContext()
    {
    }

    public PremierLeagueContext(DbContextOptions<PremierLeagueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoachProfile> CoachProfile { get; set; }

    public virtual DbSet<Continents> Continents { get; set; }

    public virtual DbSet<Country> Country { get; set; }

    public virtual DbSet<MatchReport> MatchReport { get; set; }

    public virtual DbSet<PlayerProfile> PlayerProfile { get; set; }

    public virtual DbSet<PlayerReport> PlayerReport { get; set; }

    public virtual DbSet<Rank> Rank { get; set; }

    public virtual DbSet<Season> Season { get; set; }

    public virtual DbSet<Team> Team { get; set; }

    public virtual DbSet<TeamManagers> TeamManagers { get; set; }

    public virtual DbSet<TeamMarketValue> TeamMarketValue { get; set; }

    public virtual DbSet<TeamMatchReport> TeamMatchReport { get; set; }

    public virtual DbSet<TransferReport> TransferReport { get; set; }

    public virtual DbSet<VwTopTransfers> VwTopTransfers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=premier_league_analysis;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoachProfile>(entity =>
        {
            entity.HasKey(e => e.CoachId).HasName("PK_Coach2");

            entity.ToTable(tb => tb.HasTrigger("DeleteCoachProfile"));

            entity.Property(e => e.CoachId).ValueGeneratedNever();

            entity.HasOne(d => d.Country).WithMany(p => p.CoachProfile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COACH_COUNTRY");
        });

        modelBuilder.Entity<Continents>(entity =>
        {
            entity.HasKey(e => e.ContinentId).HasName("PK__Continen__7E522081D5561B32");

            entity.ToTable(tb => tb.HasTrigger("DeleteOrUpdateContinents"));
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__country__7E95F5EDD383FFDF");

            entity.ToTable(tb => tb.HasTrigger("DeleteOrUpdateCountry"));

            entity.HasOne(d => d.Continent).WithMany(p => p.Country).HasConstraintName("FK_Country_Continent");
        });

        modelBuilder.Entity<MatchReport>(entity =>
        {
            entity.Property(e => e.MatchId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PlayerProfile>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("DeleteProfile"));

            entity.HasOne(d => d.Country).WithMany(p => p.PlayerProfile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerProfile_Country");

            entity.HasOne(d => d.Team).WithMany(p => p.PlayerProfile).HasConstraintName("FK__PlayerPro__TeamI__65F62111");
        });

        modelBuilder.Entity<PlayerReport>(entity =>
        {
            entity.HasOne(d => d.Player).WithMany(p => p.PlayerReport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerReport_PlayerProfile");

            entity.HasOne(d => d.Season).WithMany(p => p.PlayerReport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerReport_Season");

            entity.HasOne(d => d.TeamNavigation).WithMany(p => p.PlayerReport).HasConstraintName("FK__PlayerRep__TeamI__66EA454A");
        });

        modelBuilder.Entity<Rank>(entity =>
        {
            entity.HasKey(e => new { e.TeamId, e.SeasonId }).HasName("PK_Pla");

            entity.ToTable(tb => tb.HasTrigger("DeleteOrUpdateRank"));

            entity.HasOne(d => d.Season).WithMany(p => p.Rank)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rank_Season");

            entity.HasOne(d => d.TeamNavigation).WithMany(p => p.Rank)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rank_Team");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.SeasonId).HasName("PK_Season1");

            entity.Property(e => e.SeasonId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK_Team1");

            entity.ToTable(tb => tb.HasTrigger("DeleteOrUpdateTeam"));

            entity.Property(e => e.TeamId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TeamManagers>(entity =>
        {
            entity.HasKey(e => new { e.CoachId, e.TeamId }).HasName("PK_Pl");

            entity.HasOne(d => d.Coach).WithMany(p => p.TeamManagers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COACHID");

            entity.HasOne(d => d.TeamNavigation).WithMany(p => p.TeamManagers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamManagers_Team");
        });

        modelBuilder.Entity<TeamMarketValue>(entity =>
        {
            entity.HasKey(e => new { e.TeamId, e.SeasonId }).HasName("PK_TEAM_Season_VALUE");

            entity.ToTable(tb => tb.HasTrigger("TeamDeleteOrUpdate"));

            entity.HasOne(d => d.Season).WithMany(p => p.TeamMarketValue)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Season_VALUE");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamMarketValue)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TEAM_VALUE");
        });

        modelBuilder.Entity<TeamMatchReport>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("TeamReport"));

            entity.HasOne(d => d.HomeTeam).WithMany(p => p.TeamMatchReport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamMatchReport_Team1");

            entity.HasOne(d => d.Match).WithMany(p => p.TeamMatchReport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamMatchReport_MatchReport");
        });

        modelBuilder.Entity<TransferReport>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.TeamId }).HasName("PK_PlayerRe");

            entity.ToTable(tb => tb.HasTrigger("DeleteOrUpdateTransfer"));

            entity.HasOne(d => d.Player).WithMany(p => p.TransferReport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferReport_PlayerProfile");

            entity.HasOne(d => d.Team).WithMany(p => p.TransferReport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferReport_Team");
        });

        modelBuilder.Entity<VwTopTransfers>(entity =>
        {
            entity.ToView("vw_TopTransfers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
