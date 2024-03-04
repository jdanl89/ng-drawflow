namespace Drawflow.Server.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Drawflow.Server.Models;

#nullable disable

public class Form : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public virtual ICollection<FormTemplate> FormTemplates { get; set; } = [];

    public static Form Create(FormCreateModel model, [CallerMemberName] string createdAt = "") => new()
    {
        Name = model.Name,
        Description = model.Description,
        CreatedAt = createdAt,
        CreatedOn = DateTime.UtcNow,
        Status = EntityStatus.Active,
    };
}
