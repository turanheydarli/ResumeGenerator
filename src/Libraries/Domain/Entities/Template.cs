using Domain.Common;

namespace Domain.Entities;

public class Template : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public string LanguagesSection { get; set; }
    public string SkillsSection { get; set; }
    public string DemoImage { get; set; }
}