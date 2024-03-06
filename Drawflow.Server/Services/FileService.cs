namespace Drawflow.Server.Services;

public class FileService : IFileService
{
    public async Task<string> SaveFileAsync(string fileName, IFormFile formFile)
    {
        string _folderName = Path.Combine("Uploads");
        string _pathToSave = Path.Combine(Directory.GetCurrentDirectory(), _folderName);
        string _fullPath = Path.Combine(_pathToSave, fileName);
        string _dbPath = Path.Combine(_folderName, fileName);
        await using FileStream _stream = new(_fullPath, FileMode.Create);
        await formFile.CopyToAsync(_stream);

        return _dbPath;
    }
}
