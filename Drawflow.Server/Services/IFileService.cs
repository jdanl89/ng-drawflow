namespace Drawflow.Server.Services;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile formFile);
}
