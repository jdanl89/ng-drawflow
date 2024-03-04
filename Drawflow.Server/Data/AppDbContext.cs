namespace Drawflow.Server.Data;

using Drawflow.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("AppDbContext");
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
                        Name = "TestForm",
                        Description = "This is only a test.",
                        FileLocation = "",
                        CreatedAt = "SeedData",
                        CreatedBy = "SeedData",
                        CreatedOn = DateTime.UtcNow,
                        Status = EntityStatus.Active,
                    }
                ]
            });

            this.SaveChanges();
        }
    }
}
