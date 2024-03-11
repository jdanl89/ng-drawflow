namespace Drawflow.Server.Data;

using Drawflow.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

#nullable disable

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("AppDbContext");
    }

    public override int SaveChanges()
    {
        this.PopulateAuditColumns();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        this.PopulateAuditColumns();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        this.PopulateAuditColumns();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        this.PopulateAuditColumns();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void PopulateAuditColumns()
    {
        foreach (EntityEntry<Auditable> _entry in this.ChangeTracker.Entries<Auditable>())
        {
            switch (_entry.State)
            {
                case EntityState.Added:
                    _entry.Entity.CreatedAt ??= "System";
                    _entry.Entity.CreatedBy ??= "System";
                    _entry.Entity.CreatedOn = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    _entry.Entity.LastModAt ??= "System";
                    _entry.Entity.LastModBy ??= "System";
                    _entry.Entity.LastModOn = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    _entry.State = EntityState.Modified;
                    _entry.Entity.DeletedAt ??= "System";
                    _entry.Entity.DeletedBy ??= "System";
                    _entry.Entity.DeletedOn = DateTime.UtcNow;
                    _entry.Entity.Status = EntityStatus.Deleted;
                    break;
            }
        }
    }

    public DbSet<Form> Forms { get; set; }
    public DbSet<FormTemplate> FormTemplates { get; set; }

    public void SeedData()
    {
        this.Database.EnsureCreated();

        if (!this.Forms.Any())
        {
            this.Forms.Add(new()
            {
                Name = "TestForm",
                Description = "This is only a test.",
                CreatedAt = "SeedData",
                CreatedBy = "SeedData",
                CreatedOn = DateTime.UtcNow,
                Status = EntityStatus.Active,
                FormTemplates = [
                    new()
                    {
                        Name = "HTML",
                        Description = "This is an HTML document.",
                        FileLocation = "Uploads\\Html.html",
                        CreatedAt = "SeedData",
                        CreatedBy = "SeedData",
                        CreatedOn = DateTime.UtcNow,
                        Status = EntityStatus.Active,
                    },
                    new()
                    {
                        Name = "Text",
                        Description = "This is a plain text document.",
                        FileLocation = "Uploads\\Text.txt",
                        CreatedAt = "SeedData",
                        CreatedBy = "SeedData",
                        CreatedOn = DateTime.UtcNow,
                        Status = EntityStatus.Active,
                    },
                    new()
                    {
                        Name = "PDF",
                        Description = "This is a PDF document.",
                        FileLocation = "Uploads\\PDF.pdf",
                        CreatedAt = "SeedData",
                        CreatedBy = "SeedData",
                        CreatedOn = DateTime.UtcNow,
                        Status = EntityStatus.Active,
                    },
                    new()
                    {
                        Name = "Word",
                        Description = "This is a Word document.",
                        FileLocation = "Uploads\\Word.docx",
                        CreatedAt = "SeedData",
                        CreatedBy = "SeedData",
                        CreatedOn = DateTime.UtcNow,
                        Status = EntityStatus.Active,
                    },
                ]
            });

            this.SaveChanges();
        }
    }
}
