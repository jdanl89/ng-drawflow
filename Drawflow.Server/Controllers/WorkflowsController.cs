namespace Drawflow.Server.Controllers;

using Drawflow.Server.Models;
using Drawflow.Server.Models.Drawflow;
using Drawflow.Server.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WorkflowsController(IWorkflowService workflowService) : ControllerBase
{
    [HttpPost]
    [Route("/api/workflows/{workflowId}/version")]
    public WorkflowVersion CreateWorkflowVersion(int workflowId, Drawing drawing)
    {
        return workflowService.CreateWorkflowVersionFromDrawing(workflowId, drawing);
    }

    [HttpGet]
    [Route("/api/workflows/versions/{workflowVersionId}/drawing")]
    public Drawing GetDrawing(long workflowVersionId)
    {
        return workflowService.GetWorkflowVersionDrawing(workflowVersionId);
    }
}