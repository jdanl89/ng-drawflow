namespace Drawflow.Server.Models;

using System.Text.Json.Serialization;

public class Drawing
{
    [JsonPropertyName("drawflow")]
    public DrawflowSection Drawflow { get; set; } = new();

    public class DrawflowSection
    {
        [JsonPropertyName("Home")]
        public DrawflowDataSection Home { get; set; } = new();

        [JsonPropertyName("Other")]
        public DrawflowDataSection Other { get; set; } = new();

        public class DrawflowDataSection
        {
            [JsonPropertyName("data")]
            public Dictionary<string, DrawflowDataElement> Data { get; set; } = new(StringComparer.OrdinalIgnoreCase);

            public class DrawflowDataElement
            {
                [JsonPropertyName("class")]
                public string? Class { get; set; }

                [JsonPropertyName("data")]
                public Dictionary<string, object> Data { get; set; } = new(StringComparer.OrdinalIgnoreCase);

                [JsonPropertyName("html")]
                public string? Html { get; set; }

                [JsonPropertyName("id")]
                public long Id { get; set; }

                [JsonPropertyName("inputs")]
                public Dictionary<string, DrawflowConnectionsElement> Inputs { get; set; } = new(StringComparer.OrdinalIgnoreCase);

                [JsonPropertyName("name")]
                public string? Name { get; set; }

                [JsonPropertyName("outputs")]
                public Dictionary<string, DrawflowConnectionsElement> Outputs { get; set; } = new(StringComparer.OrdinalIgnoreCase);

                [JsonPropertyName("pos_x")]
                public double PosX { get; set; }

                [JsonPropertyName("pos_y")]
                public double PosY { get; set; }

                [JsonPropertyName("typenode")]
                public bool TypeNode { get; set; }

                public class DrawflowConnectionsElement
                {
                    [JsonPropertyName("connections")]
                    public List<DrawflowConnectionElement> Connections { get; set; } = [];

                    public class DrawflowConnectionElement
                    {
                        [JsonPropertyName("input")]
                        public string? Input { get; set; }

                        [JsonPropertyName("node")]
                        public string? Node { get; set; }

                        [JsonPropertyName("output")]
                        public string? Output { get; set; }
                    }
                }
            }
        }
    }
}