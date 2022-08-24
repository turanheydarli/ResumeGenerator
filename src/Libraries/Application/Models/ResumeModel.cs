using Application.System.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Application.Models;

public class ResumeModel : IMapFrom<Resume>
{
    public string Name { get; set; }
    public string Content { get; set; }
    public string ImagePath { get; set; }
    public string PdfPath { get; set; }
    public ICollection<Skill> Skills { get; set; }
    public ICollection<Language> Languages { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string EducationLevel { get; set; }
    public string University { get; set; }
    public string Specialty { get; set; }
    public string Profession { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Resume,ResumeModel>().ReverseMap();
    }
}