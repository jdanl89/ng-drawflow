namespace Drawflow.Server.Models;

#nullable disable

public class Workflow
{
    #region PrimaryKey

    public int WorkflowId { get; set; }

    #endregion PrimaryKey

    public string CodeName { get; set; }

    public string Description { get; set; }

    #region ForeignKeys

    public long FormId { get; set; }

    public virtual IEnumerable<WorkflowVersion> WorkflowVersions { get; set; } = Enumerable.Empty<WorkflowVersion>();

    #endregion ForeignKeys
}