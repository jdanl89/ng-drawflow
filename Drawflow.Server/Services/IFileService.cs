namespace Drawflow.Server.Services;

public interface IFileService
{
    FileStream GetFile(string savedPath);
    Task<string> SaveFileAsync(string fileName, IFormFile formFile);
}
