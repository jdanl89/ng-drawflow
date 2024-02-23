namespace Drawflow.Server.Services;

using Drawflow.Server.Models.Drawflow;

public interface IModuleService
{
    IEnumerable<Node> GetModuleNodes();
}