using Application.Models;
using Application.Services.Catalog.Interfaces;
using Microsoft.AspNetCore.Hosting;
using SelectPdf;

namespace Application.Services.Catalog;

public class ResumeService : IResumeService
{
    private readonly ITemplateService _templateService;
    private readonly HtmlToPdf _htmlToPdf;
    private readonly IHostingEnvironment _environment;

    public ResumeService(ITemplateService templateService, HtmlToPdf htmlToPdf, IHostingEnvironment environment)
    {
        _templateService = templateService;
        _htmlToPdf = htmlToPdf;
        _environment = environment;
    }

    public async Task<ResumeResult> CreateResume(ResumeModel resumeModel, int templateId)
    {
        var template = await _templateService.GetTemplateById(templateId);

        if (template == null)
            return new ResumeResult(false, "Template not found");

        string templateHtml = GenerateTemplateHtml(resumeModel, template);

        PdfDocument document = _htmlToPdf.ConvertHtmlString(templateHtml);

        string fileName = Guid.NewGuid() + ".pdf";

        string path = Path.Combine(_environment.ContentRootPath, "wwwroot", "generated");

        await using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);

        await using (MemoryStream memoryStream = new MemoryStream(document.Save()))
        {
            await memoryStream.CopyToAsync(stream);
        }

        return new ResumeResult(true, "", fileName);
    }

    private string GenerateTemplateHtml(ResumeModel resumeModel, TemplateModel template)
    {
        string languagesSting = resumeModel.Languages?.Count > 0
            ? resumeModel.Languages.Aggregate("", (current, language) => 
                current + template.LanguagesSection.Replace("{language}", language.Name))
            : "";

        string skillsSting = resumeModel.Skills?.Count > 0
            ? resumeModel.Skills.Aggregate("", (current, skill) => 
                current + template.LanguagesSection.Replace("{skill}", skill.Name))
            : "";

        string content = template.Content;

        content = content.Replace("{languages}", languagesSting);
        content = content.Replace("{skills}", skillsSting);
        content = content.Replace("{content}", resumeModel.Content);
        content = content.Replace("{email}", resumeModel.Email);
        content = content.Replace("{contactNumber}", resumeModel.ContactNumber);
        content = content.Replace("{profession}", resumeModel.Profession);
        content = content.Replace("{specialty}", resumeModel.Specialty);
        content = content.Replace("{educationLevel}", resumeModel.EducationLevel);
        content = content.Replace("{fullName}", resumeModel.Name);
        content = content.Replace("{university}", resumeModel.University);

        return content;
    }
}