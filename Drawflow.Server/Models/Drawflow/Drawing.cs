namespace Drawflow.Server.Models.Drawflow;

using System.Text.Json.Serialization;

public class Drawing
{
    [JsonPropertyName("drawflow")]
    public DrawflowSection Drawflow { get; set; } = new();

    public WorkflowVersion ToWorkflowVersion(int workflowId)
    {
        // TODO: if workflow version didn't change, then don't create a new one.
        // TODO: name, description, and formTemplateId should come from a form.
        WorkflowVersion _workflowVersion = new()
        {
            WorkflowId = workflowId,
            WorkflowSteps = this.Drawflow.Home.Data.Select(x => x.Value.ToWorkflowStep(long.Parse(x.Key))).ToList()
        };

        return _workflowVersion;
    }

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

                public WorkflowStep ToWorkflowStep(long moduleId)
                {
                    WorkflowStep _workflowStep = new()
                    {
                        WorkflowStepId = this.Data.TryGetValue("WorkflowStepId", out object? _workflowStepId) ? _workflowStepId as long? ?? 0 : 0,
                    };

                    // TODO: if workflow step didn't change, then don't create a new version.
                    _workflowStep.WorkflowStepVersions = new List<WorkflowStepVersion>()
                    {
                        new()
                        {
                            Name = this.Name,
                            Description = this.Data.TryGetValue("Description", out object? _description) ? _description.ToString() : string.Empty,
                            InputMap = this.Data,
                            ModuleId = moduleId,
                            WorkflowStepId = _workflowStep.WorkflowStepId,
                            NextStepId = 0, // TODO: find a way to get from Outputs
                            PreviousStepId = 0, // TODO: find a way to get from Inputs
                            DrawflowNodePosX = this.PosX,
                            DrawflowNodePosY = this.PosY,
                        }
                    };

                    return _workflowStep;
                }

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