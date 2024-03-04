namespace Drawflow.Server.Services;

using System.Runtime.CompilerServices;
using Drawflow.Server.Data;
using Drawflow.Server.Data.Models;
using Drawflow.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class FormService(AppDbContext dbContext, IFileService fileService) : IFormService
{
    public async Task<Form> AddFormAsync(FormCreateModel model, [CallerMemberName] string createdAt = "")
    {
        Form _form = Form.Create(model);
        EntityEntry<Form> _entry = dbContext.Forms.Add(_form);
        await dbContext.SaveChangesAsync();
        return _entry.Entity;
    }

    public async Task<FormTemplate> AddFormTemplateAsync(long formId, FormTemplateCreateModel model, [CallerMemberName] string createdAt = "")
    {
        string _fileLocation = await fileService.SaveFileAsync(model.TemplateFile);
        FormTemplate _formTemplate = FormTemplate.Create(model, _fileLocation, formId);
        EntityEntry<FormTemplate> _entry = dbContext.FormTemplates.Add(_formTemplate);
        await dbContext.SaveChangesAsync();
        return _entry.Entity;
    }

    public Task<List<Form>> GetFormsAsync(CancellationToken token = default) => dbContext.Forms.ToListAsync(token);

    public Task<Form?> GetFormByIdAsync(long formId, CancellationToken token = default) => dbContext.Forms.FirstOrDefaultAsync(f => f.Id == formId, token);

    public async Task<Form> UpdateFormAsync(long formId, FormUpdateModel model, [CallerMemberName] string modifiedAt = "")
    {
        Form _form = await dbContext.Forms.FirstOrDefaultAsync(f => f.Id == formId) ?? throw new ArgumentException("formId is invalid", nameof(formId));
        _form.Name = model.Name;
        _form.Description = model.Description;
        await dbContext.SaveChangesAsync();
        return _form;
    }

    public async Task DeleteFormAsync(long formId, [CallerMemberName] string deletedAt = "")
    {
        Form _form = await dbContext.Forms.FirstOrDefaultAsync(f => f.Id == formId) ?? throw new ArgumentException("formId is invalid", nameof(formId));
        dbContext.Forms.Remove(_form);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteFormTemplateAsync(long formTemplateId, [CallerMemberName] string deletedAt = "")
    {
        FormTemplate _formTemplate = await dbContext.FormTemplates.FirstOrDefaultAsync(f => f.Id == formTemplateId) ?? throw new ArgumentException("formTemplateId is invalid", nameof(formTemplateId));
        dbContext.FormTemplates.Remove(_formTemplate);
        await dbContext.SaveChangesAsync();
    }
}
