namespace Drawflow.Server.Controllers;

using Drawflow.Server.Data.Models;
using Drawflow.Server.Models;
using Drawflow.Server.Services;
using Microsoft.AspNetCore.Mvc;

public class FormsController(IFormService formService) : ControllerBase
{
    [HttpPost]
    [Route("/api/form")]
    public Task<Form> AddForm(FormCreateModel form)
    {
        return formService.AddFormAsync(form);
    }

    [HttpPost]
    [Route("/api/forms/{formId}/template")]
    public Task<FormTemplate> AddFormTemplate(long formId, FormTemplateCreateModel formTemplate)
    {
        return formService.AddFormTemplateAsync(formId, formTemplate);
    }

    [HttpDelete]
    [Route("/api/forms/{formId}")]
    public Task DeleteForm(long formId)
    {
        return formService.DeleteFormAsync(formId);
    }

    [HttpDelete]
    [Route("/api/forms/templates/{formTemplateId}")]
    public Task DeleteFormTemplate(long formTemplateId)
    {
        return formService.DeleteFormTemplateAsync(formTemplateId);
    }

    [HttpGet]
    [Route("/api/forms/{formId}")]
    public Task<Form?> GetForm(long formId, CancellationToken token = default)
    {
        return formService.GetFormByIdAsync(formId, token);
    }

    [HttpGet]
    [Route("/api/forms")]
    public Task<List<Form>> GetForms(CancellationToken token = default)
    {
        return formService.GetFormsAsync(token);
    }

    [HttpPut]
    [Route("/api/forms/{formId}")]
    public Task<Form> UpdateForm(long formId, [FromBody] FormUpdateModel form)
    {
        return formService.UpdateFormAsync(formId, form);
    }
}