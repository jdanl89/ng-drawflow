namespace Drawflow.Server.Controllers;

using Drawflow.Server.Models.Drawflow;
using Drawflow.Server.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ModulesController(IModuleService moduleService) : ControllerBase
{
    [HttpGet]
    [Route("/api/modules/nodes")]
    public IEnumerable<Node> GetNodes()
    {
        return moduleService.GetModuleNodes();
    }
}