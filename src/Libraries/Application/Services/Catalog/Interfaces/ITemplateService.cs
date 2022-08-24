using Application.Models;

namespace Application.Services.Catalog.Interfaces;

public interface ITemplateService
{
    Task<TemplateModel> CreateTemplate(TemplateModel templateModel);
    Task<List<TemplateModel>> GetAllTemplates();
    Task<TemplateModel> GetTemplateById(int id);
}