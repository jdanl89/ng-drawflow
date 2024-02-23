namespace Drawflow.Server.Services;

using Drawflow.Server.Models;
using Drawflow.Server.Models.Drawflow;

public interface IWorkflowService
{
    WorkflowVersion CreateWorkflowVersionFromDrawing(int workflowId, Drawing drawing);

    Drawing GetWorkflowVersionDrawing(long workflowVersionId);
}