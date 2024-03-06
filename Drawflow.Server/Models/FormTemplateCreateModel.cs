namespace Drawflow.Server.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class FormTemplateCreateModel
{
    [MaxLength(500)]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [Required]
    [MaxLength(100)]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Required]
    [JsonPropertyName("templateFile")]
    public IFormFile TemplateFile { get; set; }
}