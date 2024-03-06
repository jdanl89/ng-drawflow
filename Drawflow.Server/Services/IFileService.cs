namespace Drawflow.Server.Services;

public interface IFileService
{
    Task<string> SaveFileAsync(string fileName, IFormFile formFile);
}
