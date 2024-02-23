namespace Drawflow.Server.Models;

#nullable disable

public class WorkflowStepVersion
{
    #region PrimaryKey

    public long WorkflowStepVersionId { get; set; }

    #endregion PrimaryKey

    public string Description { get; set; }

    public double DrawflowNodePosX { get; set; }

    public double DrawflowNodePosY { get; set; }

    public Dictionary<string, object> InputMap { get; set; }

    public string Name { get; set; }

    #region ForeignKeys

    public Module Module { get; set; }
    public long ModuleId { get; set; }

    public WorkflowStep NextStep { get; set; }
    public long NextStepId { get; set; }

    public WorkflowStep PreviousStep { get; set; }
    public long PreviousStepId { get; set; }

    public WorkflowStep WorkflowStep { get; set; }
    public long WorkflowStepId { get; set; }

    #endregion ForeignKeys
}