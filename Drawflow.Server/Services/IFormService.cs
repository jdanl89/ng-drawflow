namespace Drawflow.Server.Services;

using System.Runtime.CompilerServices;
using Drawflow.Server.Data.Models;
using Drawflow.Server.Models;

public interface IFormService
{
    Task<Form> AddFormAsync(FormCreateModel model, [CallerMemberName] string createdAt = "");
    Task<FormTemplate> AddFormTemplateAsync(long formId, FormTemplateCreateModel model, [CallerMemberName] string createdAt = "");
    Task<List<Form>> GetFormsAsync(CancellationToken token = default);
    Task<Form?> GetFormByIdAsync(long formId, CancellationToken token = default);
    Task<Form> UpdateFormAsync(long formId, FormUpdateModel model, [CallerMemberName] string modifiedAt = "");
    Task DeleteFormAsync(long formId, [CallerMemberName] string deletedAt = "");
    Task DeleteFormTemplateAsync(long formTemplateId, [CallerMemberName] string deletedAt = "");
}
