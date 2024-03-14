namespace Drawflow.Server.Services;

using System.Runtime.CompilerServices;
using Drawflow.Server.Data.Models;
using Drawflow.Server.Models;

public interface IFormService
{
    Task<Form> AddFormAsync(FormCreateModel model, [CallerMemberName] string createdAt = "AddFormAsync");

    Task<Form> AddFormTemplateAsync(long formId, FormTemplateCreateModel model, [CallerMemberName] string createdAt = "AddFormTemplateAsync");

    Task DeleteFormAsync(long formId, [CallerMemberName] string deletedAt = "DeleteFormAsync");

    Task DeleteFormTemplateAsync(long formTemplateId, [CallerMemberName] string deletedAt = "DeleteFormTemplateAsync");

    Task<Form?> GetFormByIdAsync(long formId, CancellationToken token = default);

    Task<List<Form>> GetFormsAsync(CancellationToken token = default);

    Task<FormTemplate> GetFormTemplateByIdAsync(long formTemplateId, CancellationToken token = default);

    Task<(FileStream, string, string)> GetFormTemplateFileByFormTemplateIdAsync(long formTemplateId, CancellationToken token = default);

    Task<(IEnumerable<string> _foundVariables, IEnumerable<FormTemplateVariable> _knownVariables)> FindFormTemplateVariablesAsync(long formTemplateId, CancellationToken token = default);

    Task<Form> UpdateFormAsync(long formId, FormUpdateModel model, [CallerMemberName] string modifiedAt = "UpdateFormAsync");

    Task<FormTemplate> UpdateFormTemplateAsync(long formTemplateId, FormTemplateUpdateModel model, [CallerMemberName] string modifiedAt = "UpdateFormTemplateAsync");
}