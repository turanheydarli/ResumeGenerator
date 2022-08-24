using Application.Models;
using Application.Services.Catalog.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Catalog;

public class TemplateService : ITemplateService
{
    private readonly IRepository<Template> _templateRepository;
    private readonly IMapper _mapper;
    
    public TemplateService(IRepository<Template> templateRepository, IMapper mapper)
    {
        _templateRepository = templateRepository;
        _mapper = mapper;
    }

    public async Task<TemplateModel> CreateTemplate(TemplateModel templateModel)
    {
        Template template = await _templateRepository.InsertAsync(_mapper.Map<Template>(templateModel));
        return _mapper.Map<TemplateModel>(template);
    }

    public async Task<List<TemplateModel>> GetAllTemplates()
    {
        var templates = await _templateRepository.GetAll.ToListAsync();

        return _mapper.Map<List<TemplateModel>>(templates);
    }

    public async Task<TemplateModel> GetTemplateById(int id)
    {
        var template = await _templateRepository.GetAsync(t => t.Id == id);

        return _mapper.Map<TemplateModel>(template);
    }
}