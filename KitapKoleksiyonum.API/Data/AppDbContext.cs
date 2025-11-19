using KitapKoleksiyonum.API.Models;
using Microsoft.EntityFrameworkCore;

namespace KitapKoleksiyonum.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=KitapKoleksiyonumDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
        });
        
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Author).IsRequired().HasMaxLength(150);
            entity.Property(e => e.ISBN).HasMaxLength(20);
            entity.Property(e => e.Notes).HasMaxLength(1000);
            
            entity.HasOne(e => e.Category)
                  .WithMany(c => c.Books)
                  .HasForeignKey(e => e.CategoryId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
        
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Roman", Description = "Roman kitapları" },
            new Category { Id = 2, Name = "Bilim Kurgu", Description = "Bilim kurgu kitapları" },
            new Category { Id = 3, Name = "Teknik", Description = "Teknik ve programlama kitapları" }
        );
    }
}