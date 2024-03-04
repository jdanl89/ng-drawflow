namespace Drawflow.Server.Models;

using System.ComponentModel.DataAnnotations;

public class FormCreateModel
{
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }
}
