namespace Drawflow.Server.Models;

using System.ComponentModel.DataAnnotations;

public class FormTemplateCreateModel
{
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    public IFormFile TemplateFile { get; set; }

    [Required]
    public long FormId { get; set; }
}
