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

    public virtual DbSet<CoachProfile> CoachProfiles { get; set; }

    public virtual DbSet<Continent> Continents { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<MatchReport> MatchReports { get; set; }

    public virtual DbSet<PlayerProfile> PlayerProfiles { get; set; }

    public virtual DbSet<PlayerReport> PlayerReports { get; set; }

    public virtual DbSet<Rank> Ranks { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamManager> TeamManagers { get; set; }

    public virtual DbSet<TeamMarketValue> TeamMarketValues { get; set; }

    public virtual DbSet<TeamMatchReport> TeamMatchReports { get; set; }

    public virtual DbSet<TransferReport> TransferReports { get; set; }

    public virtual DbSet<VwTopTransfer> VwTopTransfers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=premier_league_analysis;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoachProfile>(entity =>
        {
            entity.HasKey(e => e.CoachId).HasName("PK_Coach2");

            entity.ToTable("CoachProfile", tb => tb.HasTrigger("DeleteCoachProfile"));

            entity.Property(e => e.CoachId)
                .ValueGeneratedNever()
                .HasColumnName("CoachID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.FullName).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.CoachProfiles)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COACH_COUNTRY");
        });

        modelBuilder.Entity<Continent>(entity =>
        {
            entity.HasKey(e => e.ContinentId).HasName("PK__Continen__7E522081D5561B32");

            entity.ToTable(tb => tb.HasTrigger("DeleteOrUpdateContinents"));

            entity.Property(e => e.ContinentId).HasColumnName("ContinentID");
            entity.Property(e => e.ContinentName).HasMaxLength(100);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__country__7E95F5EDD383FFDF");

            entity.ToTable("Country", tb => tb.HasTrigger("DeleteOrUpdateCountry"));

            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.ContinentId).HasColumnName("ContinentID");
            entity.Property(e => e.CountryName).HasMaxLength(100);

            entity.HasOne(d => d.Continent).WithMany(p => p.Countries)
                .HasForeignKey(d => d.ContinentId)
                .HasConstraintName("FK_Country_Continent");
        });

        modelBuilder.Entity<MatchReport>(entity =>
        {
            entity.HasKey(e => e.MatchId);

            entity.ToTable("MatchReport");

            entity.Property(e => e.MatchId)
                .ValueGeneratedNever()
                .HasColumnName("MatchID");
            entity.Property(e => e.Round).HasMaxLength(15);
            entity.Property(e => e.SeasonId).HasColumnName("SeasonID");
            entity.Property(e => e.TeamId1).HasColumnName("TeamID 1");
            entity.Property(e => e.TeamId2).HasColumnName("TeamID 2");
        });

        modelBuilder.Entity<PlayerProfile>(entity =>
        {
            entity.HasKey(e => e.PlayerId);

            entity.ToTable("PlayerProfile", tb => tb.HasTrigger("DeleteProfile"));

            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.PlayerName).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(10);
            entity.Property(e => e.PreferredFoot).HasMaxLength(10);
            entity.Property(e => e.TeamId).HasColumnName("TeamID");

            entity.HasOne(d => d.Country).WithMany(p => p.PlayerProfiles)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerProfile_Country");

            entity.HasOne(d => d.Team).WithMany(p => p.PlayerProfiles)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_TEAMID");
        });

        modelBuilder.Entity<PlayerReport>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.SeasonId });

            entity.ToTable("PlayerReport");

            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");
            entity.Property(e => e.SeasonId).HasColumnName("SeasonID");
            entity.Property(e => e.Gksaves).HasColumnName("GKSaves");
            entity.Property(e => e.PlayerName).HasMaxLength(50);
            entity.Property(e => e.Team).HasMaxLength(50);
            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.TotalPasses).HasColumnName("Total_Passes");
            entity.Property(e => e.Xg).HasColumnName("XG");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerReports)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerReport_PlayerProfile");

            entity.HasOne(d => d.Season).WithMany(p => p.PlayerReports)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerReport_Season");
        });

        modelBuilder.Entity<Rank>(entity =>
        {
            entity.HasKey(e => new { e.TeamId, e.SeasonId }).HasName("PK_Pla");

            entity.ToTable("Rank", tb => tb.HasTrigger("DeleteOrUpdateRank"));

            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.SeasonId).HasColumnName("SeasonID");
            entity.Property(e => e.Rank1).HasColumnName("Rank");
            entity.Property(e => e.Team).HasMaxLength(50);

            entity.HasOne(d => d.Season).WithMany(p => p.Ranks)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rank_Season");

            entity.HasOne(d => d.TeamNavigation).WithMany(p => p.Ranks)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rank_Team");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.SeasonId).HasName("PK_Season1");

            entity.ToTable("Season");

            entity.Property(e => e.SeasonId)
                .ValueGeneratedNever()
                .HasColumnName("SeasonID");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK_Team1");

            entity.ToTable("Team", tb => tb.HasTrigger("DeleteOrUpdateTeam"));

            entity.Property(e => e.TeamId)
                .ValueGeneratedNever()
                .HasColumnName("TeamID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Stadium).HasMaxLength(50);
            entity.Property(e => e.TeamName).HasMaxLength(50);
        });

        modelBuilder.Entity<TeamManager>(entity =>
        {
            entity.HasKey(e => new { e.Coachid, e.Teamid, e.Seasonid });

            entity.Property(e => e.Coachid).HasColumnName("coachid");
            entity.Property(e => e.Teamid).HasColumnName("teamid");
            entity.Property(e => e.Seasonid).HasColumnName("seasonid");
            entity.Property(e => e.Manager)
                .HasMaxLength(50)
                .HasColumnName("manager");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.Team)
                .HasMaxLength(50)
                .HasColumnName("team");

            entity.HasOne(d => d.Coach).WithMany(p => p.TeamManagers)
                .HasForeignKey(d => d.Coachid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COACHID");

            entity.HasOne(d => d.Season).WithMany(p => p.TeamManagers)
                .HasForeignKey(d => d.Seasonid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamManagers_Season");

            entity.HasOne(d => d.TeamNavigation).WithMany(p => p.TeamManagers)
                .HasForeignKey(d => d.Teamid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamManagers_Team");
        });

        modelBuilder.Entity<TeamMarketValue>(entity =>
        {
            entity.HasKey(e => new { e.TeamId, e.SeasonId }).HasName("PK_TEAM_Season_VALUE");

            entity.ToTable("TeamMarketValue", tb => tb.HasTrigger("TeamDeleteOrUpdate"));

            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

            entity.HasOne(d => d.Season).WithMany(p => p.TeamMarketValues)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Season_VALUE");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamMarketValues)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TEAM_VALUE");
        });

        modelBuilder.Entity<TeamMatchReport>(entity =>
        {
            entity.HasKey(e => new { e.MatchId, e.HomeTeamId });

            entity.ToTable("TeamMatchReport", tb => tb.HasTrigger("TeamReport"));

            entity.Property(e => e.MatchId).HasColumnName("MatchID");
            entity.Property(e => e.HomeTeamId).HasColumnName("HomeTeamID");
            entity.Property(e => e.OpponentTeamId).HasColumnName("OpponentTeamID");
            entity.Property(e => e.Result).HasMaxLength(5);
            entity.Property(e => e.YellowCard).HasColumnName("Yellow_card");

            entity.HasOne(d => d.HomeTeam).WithMany(p => p.TeamMatchReports)
                .HasForeignKey(d => d.HomeTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamMatchReport_Team1");

            entity.HasOne(d => d.Match).WithMany(p => p.TeamMatchReports)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamMatchReport_MatchReport");
        });

        modelBuilder.Entity<TransferReport>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.TeamId }).HasName("PK_PlayerRe");

            entity.ToTable("TransferReport", tb => tb.HasTrigger("DeleteOrUpdateTransfer"));

            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");
            entity.Property(e => e.TeamId).HasColumnName("TeamID");

            entity.HasOne(d => d.Player).WithMany(p => p.TransferReports)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferReport_PlayerProfile");

            entity.HasOne(d => d.Team).WithMany(p => p.TransferReports)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferReport_Team");
        });

        modelBuilder.Entity<VwTopTransfer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_TopTransfers");

            entity.Property(e => e.PlayerName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
