﻿namespace Drawflow.Server.Controllers;

using Drawflow.Server.Data.Models;
using Drawflow.Server.Models;
using Drawflow.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

public class FormsController(IFormService formService) : ControllerBase
{
    [HttpPost]
    [Route("/api/form")]
    public async Task<Form> AddForm([FromBody] FormCreateModel form)
    {
        return await formService.AddFormAsync(form);
    }

    [HttpPost, DisableRequestSizeLimit]
    [Route("/api/forms/{formId}/template")]
    public async Task<Form> AddFormTemplate(long formId, [FromForm] FormTemplateCreateModel model)
    {
        // save the file to the Uploads folder and add the template to the db.
        return await formService.AddFormTemplateAsync(formId, model);
    }

    [HttpDelete]
    [Route("/api/forms/{formId}")]
    public async Task DeleteForm(long formId)
    {
        await formService.DeleteFormAsync(formId);
    }

    [HttpDelete]
    [Route("/api/forms/templates/{formTemplateId}")]
    public async Task DeleteFormTemplate(long formTemplateId)
    {
        await formService.DeleteFormTemplateAsync(formTemplateId);
    }

    [HttpGet]
    [Route("/api/forms/{formId}")]
    public async Task<Form?> GetForm(long formId, CancellationToken token = default)
    {
        return await formService.GetFormByIdAsync(formId, token);
    }

    [HttpGet]
    [Route("/api/forms")]
    public async Task<List<Form>> GetForms(CancellationToken token = default)
    {
        return await formService.GetFormsAsync(token);
    }

    [HttpGet]
    [Route("/api/forms/templates/{formTemplateId}")]
    public async Task<FormTemplate> GetFormTemplate(long formTemplateId, CancellationToken token = default)
    {
        return await formService.GetFormTemplateByIdAsync(formTemplateId, token);
    }

    [HttpGet]
    [Route("/api/forms/templates/{formTemplateId}/file")]
    public async Task<IActionResult> GetFormTemplateFile(long formTemplateId, CancellationToken token = default)
    {
        FormTemplate _formTemplate = await formService.GetFormTemplateByIdAsync(formTemplateId, token);

        string _filePath = Path.Combine(Directory.GetCurrentDirectory(), _formTemplate.FileLocation);
        
        FileExtensionContentTypeProvider _provider = new();
        if (!_provider.TryGetContentType(_filePath, out string? _contentType))
        {
            _contentType = "application/octet-stream";
        }

        FileStream _fileStream = new(_filePath, FileMode.Open, FileAccess.Read);

        return this.File(_fileStream, _contentType, Path.GetFileName(_filePath));
    }

    [HttpPut]
    [Route("/api/forms/{formId}")]
    public async Task<Form> UpdateForm(long formId, [FromBody] FormUpdateModel form)
    {
        return await formService.UpdateFormAsync(formId, form);
    }

    [HttpPut]
    [Route("/api/forms/templates/{formTemplateId}")]
    public async Task<FormTemplate> UpdateFormTemplate(long formTemplateId, [FromBody] FormTemplateUpdateModel model)
    {
        return await formService.UpdateFormTemplateAsync(formTemplateId, model);
    }
}