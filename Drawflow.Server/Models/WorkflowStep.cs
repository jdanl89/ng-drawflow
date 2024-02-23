namespace Drawflow.Server.Models;

#nullable disable

public class WorkflowStep
{
    #region PrimaryKey

    public long WorkflowStepId { get; set; }

    #endregion PrimaryKey

    public string CodeName { get; set; }

    #region ForeignKeys

    public WorkflowVersion WorkflowVersion { get; set; }
    public long WorkflowVersionId { get; set; }

    public virtual IEnumerable<WorkflowStepVersion> WorkflowStepVersions { get; set; } = Enumerable.Empty<WorkflowStepVersion>();

    #endregion PrimaryKey
}
