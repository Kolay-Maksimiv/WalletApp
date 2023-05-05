using Microsoft.EntityFrameworkCore;
using WalletApp.Core.Entities;

namespace WalletApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    //public DbSet<Icon> Icons { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(
            entity =>
            {
                entity.ToTable("users");

                entity.HasKey(k => k.Id);

                entity.Property(p => p.Id)
                      .HasColumnName("id");

                entity.Property(p => p.FirstName)
                      .HasColumnName("first_name");

                entity.Property(p => p.LastName)
                      .HasColumnName("last_name");
            });


        modelBuilder.Entity<Transaction>(
            entity =>
            {
                entity.ToTable("transaction");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .HasColumnName("id");

                entity.Property(p => p.Name)
                    .HasColumnName("name");

                entity.Property(p => p.Description)
                    .HasColumnName("description");

                entity.Property(p => p.OwnerId)
                    .HasColumnName("owner_id");

                entity.Property(p => p.TypeTransaction)
                    .HasColumnName("type_transaction");

                entity.Property(p => p.DateTransaction)
                    .HasColumnName("date_transaction");

                entity.Property(p => p.IsPending)
                    .HasColumnName("is_pending");

                entity.Property(p => p.SenderName)
                    .HasColumnName("sender_name");

                entity.Property(p => p.IconId)
                    .HasColumnName("icon_id");
            });

        modelBuilder.Entity<Icon>(
            entity =>
            {
                entity.ToTable("icons");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                      .HasColumnName("id");

                entity.Property(p => p.IconUrl)
                    .HasColumnName("icon_url");
            });
    }
}
