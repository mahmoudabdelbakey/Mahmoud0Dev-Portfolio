using MahmoudDev.Models;

namespace MahmoudDev.Services
{
    public interface IPortfolioDataService
    {
        PortfolioViewModel GetPortfolioData();
        List<Project> GetProjects(string? category = null);
        Project? GetProjectById(string id);
        CaseStudy? GetCaseStudy(string id);
        List<SkillGroup> GetSkills();
        List<ExperienceItem> GetExperiences();
        List<JourneyStage> GetJourneyStages();
        List<ServiceItem> GetServices();
    }

    public interface IContactService
    {
        Task<(bool Success, string Message)> SubmitInquiryAsync(ContactRequest request);
        List<ContactRequest> GetAllInquiries();
    }
}
