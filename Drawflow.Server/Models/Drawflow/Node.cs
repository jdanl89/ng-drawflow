namespace Drawflow.Server.Models.Drawflow;

using System.Text.Json.Serialization;

public class Node
{
    [JsonPropertyName("bodyHtml")]
    public string? BodyHtml { get; set; }

    [JsonPropertyName("data")]
    public Dictionary<string, object> Data { get; set; } = new(StringComparer.OrdinalIgnoreCase);

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("iconClass")]
    public string? IconClass { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("inputs")]
    public int Inputs { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("outputs")]
    public int Outputs { get; set; }

    public Module ToModule() => new()
    {
        ModuleId = this.Id,
        LongName = this.Name,
        IconClass = this.IconClass,
        ShortName = this.DisplayName,
        InputCount = this.Inputs,
        InputMap = this.Data,
        OutputCount = this.Outputs,
        OutputMap = new(StringComparer.OrdinalIgnoreCase),
        BodyHtml = this.BodyHtml,
    };
}