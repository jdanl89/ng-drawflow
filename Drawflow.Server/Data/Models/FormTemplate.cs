namespace Drawflow.Server.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Drawflow.Server.Models;

#nullable disable

public class FormTemplate : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    [Required]
    [MaxLength(500)]
    public string FileLocation { get; set; }

    [Required]
    [ForeignKey("Form")]
    public long FormId { get; set; }
    public virtual Form Form { get; set; }

    public static FormTemplate Create(FormTemplateCreateModel model, string fileLocation, long formId, [CallerMemberName] string createdAt = "") => new()
    {
        Name = model.Name,
        Description = model.Description,
        FileLocation = fileLocation,
        FormId = formId,
        CreatedAt = createdAt,
        CreatedOn = DateTime.UtcNow,
        Status = EntityStatus.Active,
    };
}
