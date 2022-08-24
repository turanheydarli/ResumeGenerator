using Application.System.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Application.Models;

public class TemplateModel : IMapFrom<Template>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public string LanguagesSection { get; set; }
    public string SkillsSection { get; set; }
    public string DemoImage { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Template, TemplateModel>().ReverseMap();
    }
}