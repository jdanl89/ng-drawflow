namespace Drawflow.Server.Models;

#nullable disable

public class WorkflowVersion
{
    #region PrimaryKey

    public long WorkflowVersionId { get; set; }

    #endregion PrimaryKey

    public string Description { get; set; }

    public long FormTemplateId { get; set; }

    public string Name { get; set; }

    #region ForeignKeys

    public Workflow Workflow { get; set; }
    public int WorkflowId { get; set; }

    public virtual IEnumerable<WorkflowStep> WorkflowSteps { get; set; } = Enumerable.Empty<WorkflowStep>();

    #endregion ForeignKeys
}