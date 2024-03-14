namespace Drawflow.Server.Services;

using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Drawflow.Server.Data;
using Drawflow.Server.Data.Models;
using Drawflow.Server.Models;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class FormService(AppDbContext dbContext, IFileService fileService) : IFormService
{
    public async Task<Form> AddFormAsync(FormCreateModel model, [CallerMemberName] string createdAt = "AddFormAsync")
    {
        Form _form = Form.Create(model);
        EntityEntry<Form> _entry = dbContext.Forms.Add(_form);
        await dbContext.SaveChangesAsync();
        return _entry.Entity;
    }

    public async Task<Form> AddFormTemplateAsync(long formId, FormTemplateCreateModel model, [CallerMemberName] string createdAt = "AddFormTemplateAsync")
    {
        string _fileName = model.Name + Path.GetExtension(model.TemplateFile.FileName);
        string _fileLocation = await fileService.SaveFileAsync(_fileName, model.TemplateFile);
        FormTemplate _formTemplate = FormTemplate.Create(model, _fileLocation, formId);
        _formTemplate.CreatedAt = createdAt;

        dbContext.FormTemplates.Add(_formTemplate);

        await dbContext.SaveChangesAsync();

        Form _form = await dbContext.Forms.Include(f => f.FormTemplates).OrderBy(ft => ft.Id).FirstAsync(f => f.Id == formId);
        return _form;
    }

    public async Task DeleteFormAsync(long formId, [CallerMemberName] string deletedAt = "DeleteFormAsync")
    {
        Form _form = await dbContext.Forms.FirstOrDefaultAsync(f => f.Id == formId) ?? throw new ArgumentException("formId is invalid", nameof(formId));
        dbContext.Forms.Remove(_form);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteFormTemplateAsync(long formTemplateId, [CallerMemberName] string deletedAt = "DeleteFormTemplateAsync")
    {
        FormTemplate _formTemplate = await dbContext.FormTemplates.FirstOrDefaultAsync(f => f.Id == formTemplateId) ?? throw new ArgumentException("formTemplateId is invalid", nameof(formTemplateId));
        dbContext.FormTemplates.Remove(_formTemplate);
        await dbContext.SaveChangesAsync();
    }

    public Task<Form?> GetFormByIdAsync(long formId, CancellationToken token = default) => dbContext.Forms.Include(f => f.FormTemplates).OrderBy(ft => ft.Id).FirstOrDefaultAsync(f => f.Id == formId, token);

    public Task<List<Form>> GetFormsAsync(CancellationToken token = default) => dbContext.Forms.OrderBy(f => f.Id).ToListAsync(token);

    public Task<FormTemplate> GetFormTemplateByIdAsync(long formTemplateId, CancellationToken token = default) => dbContext.FormTemplates.FirstAsync(t => t.Id == formTemplateId, token);
    public async Task<(FileStream, string, string)> GetFormTemplateFileByFormTemplateIdAsync(long formTemplateId, CancellationToken token = default)
    {
        FormTemplate _formTemplate = await this.GetFormTemplateByIdAsync(formTemplateId, token);
        FileStream _fileStream = fileService.GetFile(_formTemplate.FileLocation);

        FileExtensionContentTypeProvider _provider = new();
        if (!_provider.TryGetContentType(_formTemplate.FileLocation, out string? _contentType))
        {
            _contentType = "application/octet-stream";
        }

        return (_fileStream, Path.GetFileName(_formTemplate.FileLocation), _contentType);
    }

    public async Task<(IEnumerable<string> _foundVariables, IEnumerable<FormTemplateVariable> _knownVariables)> FindFormTemplateVariablesAsync(long formTemplateId, CancellationToken token = default)
    {
        FormTemplate _formTemplate = await dbContext.FormTemplates
            .Include(ft => ft.Variables)
            .ThenInclude(ftv => ftv.Options)
            .Include(ft => ft.Variables)
            .ThenInclude(ftv => ftv.Validations)
            .SingleAsync(ft => ft.Id == formTemplateId, token);

        (FileStream _stream, string _, string _contentType) = await this.GetFormTemplateFileByFormTemplateIdAsync(formTemplateId, token);

        IEnumerable<string> _foundVariables = [];

        switch (_contentType)
        {
            case "text/html":
            case "text/plain":
                string _fileContent;
                using (StreamReader _sr = new(_stream))
                {
                    _fileContent = await _sr.ReadToEndAsync(token);
                }

                MatchCollection _matches = Regex.Matches(_fileContent, @"\{\{[a-zA-Z0-9_\-]+\}\}");
                _foundVariables = _matches.Select(m => m.Value.TrimStart('{').TrimEnd('}'));
                break;
            case "text/trf":
            case "text/richtext":
            case "application/rtf":
            case "application/msword":
            case "application/vnd.ms-word.document.macroEnabled.12":
            case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
            case "application/pdf":
            default:
                break;
        }

        return (_foundVariables, _formTemplate.Variables);
    }

    public async Task<Form> UpdateFormAsync(long formId, FormUpdateModel model, [CallerMemberName] string modifiedAt = "UpdateFormAsync")
    {
        Form _form = await dbContext.Forms.FirstOrDefaultAsync(f => f.Id == formId) ?? throw new ArgumentException("formId is invalid", nameof(formId));
        _form.Name = model.Name;
        _form.Description = model.Description;
        await dbContext.SaveChangesAsync();
        return _form;
    }

    public async Task<FormTemplate> UpdateFormTemplateAsync(long formTemplateId, FormTemplateUpdateModel model, [CallerMemberName] string modifiedAt = "UpdateFormTemplateAsync")
    {
        FormTemplate _template = await dbContext.FormTemplates.FirstAsync(t => t.Id == formTemplateId);
        _template.Name = model.Name;
        _template.Description = model.Description;
        await dbContext.SaveChangesAsync();
        return _template;
    }
}