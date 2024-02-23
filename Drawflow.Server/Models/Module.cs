namespace Drawflow.Server.Models;

#nullable disable

using global::Drawflow.Server.Models.Drawflow;

public class Module
{
    #region PrimaryKey

    public long ModuleId { get; set; }

    #endregion PrimaryKey

    public string BodyHtml { get; set; }

    public string Description { get; set; }

    public string IconClass { get; set; }

    public int InputCount { get; set; }

    public Dictionary<string, object> InputMap { get; set; } = new(StringComparer.OrdinalIgnoreCase);

    public string LongName { get; set; }

    public int OutputCount { get; set; }

    public Dictionary<string, object> OutputMap { get; set; } = new(StringComparer.OrdinalIgnoreCase);

    public string ShortName { get; set; }

    #region ForeignKeys

    public virtual IEnumerable<WorkflowStepVersion> WorkflowStepVersions { get; set; } = Enumerable.Empty<WorkflowStepVersion>();

    #endregion ForeignKeys

    public Node ToNode() => new()
    {
        Id = this.ModuleId,
        Name = this.LongName,
        IconClass = this.IconClass,
        DisplayName = this.ShortName,
        Inputs = this.InputCount,
        Outputs = this.OutputCount,
        Data = this.InputMap,
        BodyHtml = this.BodyHtml,
    };
}