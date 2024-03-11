namespace Drawflow.Server.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class FormTemplateUpdateModel
{
    [MaxLength(500)]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [Required]
    [MaxLength(100)]
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}