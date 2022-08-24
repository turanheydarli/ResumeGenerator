using Domain.Common;

namespace Domain.Entities;

public class Resume : Entity
{
    public string Name { get; set; }
    public string Content { get; set; }
    public string ImagePath { get; set; }
    public ICollection<Skill> Skills { get; set; }
    public ICollection<Language> Languages { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string EducationLevel { get; set; }
    public string University { get; set; }
    public string Specialty { get; set; }
    public string Profession { get; set; }
    public string PdfPath { get; set; }
    
}