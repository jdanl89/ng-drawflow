namespace Drawflow.Server.Services;

public class FileService : IFileService
{
    public async Task<string> SaveFileAsync(IFormFile formFile)
    {
        string _filePath = Path.GetTempFileName();
        await using FileStream _stream = File.Create(_filePath);
        await formFile.CopyToAsync(_stream);
        return _filePath;
    }
}
