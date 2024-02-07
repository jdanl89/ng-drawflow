﻿namespace Drawflow.Server.Models;

using System.Text.Json.Serialization;

public class NodeElement
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("iconClass")]
    public string? IconClass { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("inputs")]
    public int Inputs { get; set; }

    [JsonPropertyName("outputs")]
    public int Outputs { get; set; }

    [JsonPropertyName("data")]
    public Dictionary<string, object> Data { get; set; } = new(StringComparer.OrdinalIgnoreCase);

    [JsonPropertyName("bodyHtml")]
    public string? BodyHtml { get; set; }

}
