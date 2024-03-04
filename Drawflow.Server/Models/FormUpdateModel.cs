namespace Drawflow.Server.Models;

using System.ComponentModel.DataAnnotations;

public class FormUpdateModel
{
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }
}
