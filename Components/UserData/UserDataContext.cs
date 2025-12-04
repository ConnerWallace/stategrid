using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Components.UserData;

public partial class UserDataContext : DbContext
{
    public UserDataContext()
    {
    }

    public UserDataContext(DbContextOptions<UserDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder.UseSqlite("Data Source=userData.db");

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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
