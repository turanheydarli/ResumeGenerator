using Application.Models;

namespace Application.Services.Catalog.Interfaces;

public interface IResumeService
{
    Task<ResumeResult> CreateResume(ResumeModel resumeModel, int templateId);
}