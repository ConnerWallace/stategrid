using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1;

public partial class StateinfoContext : DbContext
{
    public StateinfoContext()
    {
    }

    public StateinfoContext(DbContextOptions<StateinfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=stateinfo.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.ToTable("answers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnswerSlot).HasColumnName("answerSlot");
            entity.Property(e => e.Game).HasColumnName("game");
            entity.Property(e => e.NumberOfGuesses).HasColumnName("numberOfGuesses");
            entity.Property(e => e.StateName).HasColumnName("stateName");

            entity.HasOne(d => d.GameNavigation).WithMany(p => p.Answers).HasForeignKey(d => d.Game);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories");

            entity.Property(e => e.Clause).HasColumnName("clause");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Modifier).HasColumnName("modifier");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.ToTable("games");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cat1).HasColumnName("cat1");
            entity.Property(e => e.Cat2).HasColumnName("cat2");
            entity.Property(e => e.Cat3).HasColumnName("cat3");
            entity.Property(e => e.Cat4).HasColumnName("cat4");
            entity.Property(e => e.Cat5).HasColumnName("cat5");
            entity.Property(e => e.Cat6).HasColumnName("cat6");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.ToTable("states");

            entity.Property(e => e.Abbreviation).HasColumnName("abbreviation");
            entity.Property(e => e.AbrahamLincoln).HasColumnName("abrahamLincoln");
            entity.Property(e => e.AppalachianMountains).HasColumnName("appalachianMountains");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.AverageTemp)
                .HasColumnType("NUMERIC")
                .HasColumnName("averageTemp");
            entity.Property(e => e.BigCity).HasColumnName("bigCity");
            entity.Property(e => e.BigCityPopulation).HasColumnName("bigCityPopulation");
            entity.Property(e => e.BorderStateNum).HasColumnName("borderStateNum");
            entity.Property(e => e.Capital).HasColumnName("capital");
            entity.Property(e => e.Capital2).HasColumnName("capital2");
            entity.Property(e => e.Capital3).HasColumnName("capital3");
            entity.Property(e => e.CapitalPopulation).HasColumnName("capitalPopulation");
            entity.Property(e => e.Cardinal).HasColumnName("cardinal");
            entity.Property(e => e.Confederate).HasColumnName("confederate");
            entity.Property(e => e.CongressDistrictNum).HasColumnName("congressDistrictNum");
            entity.Property(e => e.CountyNum).HasColumnName("countyNum");
            entity.Property(e => e.Deer).HasColumnName("deer");
            entity.Property(e => e.FlagAnimal).HasColumnName("flagAnimal");
            entity.Property(e => e.FlagBlack).HasColumnName("flagBlack");
            entity.Property(e => e.FlagBlue).HasColumnName("flagBlue");
            entity.Property(e => e.FlagBlueBg).HasColumnName("flagBlueBG");
            entity.Property(e => e.FlagBrown).HasColumnName("flagBrown");
            entity.Property(e => e.FlagCoatArms).HasColumnName("flagCoatArms");
            entity.Property(e => e.FlagColorNum).HasColumnName("flagColorNum");
            entity.Property(e => e.FlagEagle).HasColumnName("flagEagle");
            entity.Property(e => e.FlagGray).HasColumnName("flagGray");
            entity.Property(e => e.FlagGreen).HasColumnName("flagGreen");
            entity.Property(e => e.FlagHuman).HasColumnName("flagHuman");
            entity.Property(e => e.FlagOrange).HasColumnName("flagOrange");
            entity.Property(e => e.FlagPurple).HasColumnName("flagPurple");
            entity.Property(e => e.FlagRed).HasColumnName("flagRed");
            entity.Property(e => e.FlagStar).HasColumnName("flagStar");
            entity.Property(e => e.FlagText).HasColumnName("flagText");
            entity.Property(e => e.FlagTree).HasColumnName("flagTree");
            entity.Property(e => e.FlagWhite).HasColumnName("flagWhite");
            entity.Property(e => e.FlagYellow).HasColumnName("flagYellow");
            entity.Property(e => e.GdpPerCapita).HasColumnName("gdpPerCapita");
            entity.Property(e => e.GovernorParty).HasColumnName("governorParty");
            entity.Property(e => e.GreatLakes).HasColumnName("greatLakes");
            entity.Property(e => e.GulfOfMexico).HasColumnName("gulfOfMexico");
            entity.Property(e => e.InternationalBorder)
                .HasColumnType("INTEGER")
                .HasColumnName("internationalBorder");
            entity.Property(e => e.IvyLeague).HasColumnName("ivyLeague");
            entity.Property(e => e.LouisianaPurchase).HasColumnName("louisianaPurchase");
            entity.Property(e => e.MississippiRiver).HasColumnName("mississippiRiver");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NameEuropean).HasColumnName("nameEuropean");
            entity.Property(e => e.NameNative).HasColumnName("nameNative");
            entity.Property(e => e.NamePure).HasColumnName("namePure");
            entity.Property(e => e.NuclearPower).HasColumnName("nuclearPower");
            entity.Property(e => e.Olympics).HasColumnName("olympics");
            entity.Property(e => e.OriginalColony).HasColumnName("originalColony");
            entity.Property(e => e.Population).HasColumnName("population");
            entity.Property(e => e.PopulationDensity)
                .HasColumnType("NUMERIC")
                .HasColumnName("populationDensity");
            entity.Property(e => e.PresidentBirthplace).HasColumnName("presidentBirthplace");
            entity.Property(e => e.PresidentElectorNum).HasColumnName("presidentElectorNum");
            entity.Property(e => e.PresidentHomeState).HasColumnName("presidentHomeState");
            entity.Property(e => e.Region).HasColumnName("region");
            entity.Property(e => e.RockyMountains).HasColumnName("rockyMountains");
            entity.Property(e => e.SeaCoast).HasColumnName("seaCoast");
            entity.Property(e => e.Springfield).HasColumnName("springfield");
            entity.Property(e => e.StateLegislatorNum).HasColumnName("stateLegislatorNum");
            entity.Property(e => e.SuperBowlHost).HasColumnName("superBowlHost");
            entity.Property(e => e.SuperBowlPlay).HasColumnName("superBowlPlay");
            entity.Property(e => e.TallestBuildingHeight).HasColumnName("tallestBuildingHeight");
            entity.Property(e => e.TimezoneNum).HasColumnName("timezoneNum");
            entity.Property(e => e.UnionOrder).HasColumnName("unionOrder");
            entity.Property(e => e.UnionYear).HasColumnName("unionYear");
            entity.Property(e => e.WomanGovernor).HasColumnName("womanGovernor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
