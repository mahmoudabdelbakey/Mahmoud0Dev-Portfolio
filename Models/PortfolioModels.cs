namespace MahmoudDev.Models
{
    public class SkillItem
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Context { get; set; } = string.Empty;
        public string IconSvg { get; set; } = string.Empty;
        public bool IsPrimary { get; set; } = false;
    }

    public class SkillGroup
    {
        public string Category { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IconName { get; set; } = string.Empty;
        public List<SkillItem> Skills { get; set; } = new();
    }

    public class Project
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ClientOrDomain { get; set; } = string.Empty;
        public string ValueProposition { get; set; } = string.Empty;
        public List<string> Technologies { get; set; } = new();
        public List<string> MainFeatures { get; set; } = new();
        public string LiveUrl { get; set; } = "#";
        public string GithubUrl { get; set; } = "#";
        public bool HasCaseStudy { get; set; } = true;
        public CaseStudy? CaseStudy { get; set; }
    }

    public class CaseStudy
    {
        public string Id { get; set; } = string.Empty;
        public string ProjectTitle { get; set; } = string.Empty;
        public string Tagline { get; set; } = string.Empty;
        public string TheProblem { get; set; } = string.Empty;
        public string TheOriginalIdea { get; set; } = string.Empty;
        public string MyApproach { get; set; } = string.Empty;
        public string TheSolution { get; set; } = string.Empty;
        public List<string> KeyFeatures { get; set; } = new();
        public List<string> Technologies { get; set; } = new();
        public List<string> ChallengesAndSolutions { get; set; } = new();
        public List<string> ResultsAndImpact { get; set; } = new();
        public Dictionary<string, string> Metrics { get; set; } = new();
        public string VisualMockup { get; set; } = string.Empty;
        public string LiveDemoUrl { get; set; } = "#";
        public string GithubUrl { get; set; } = "#";
    }

    public class ExperienceItem
    {
        public string Role { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public List<string> Responsibilities { get; set; } = new();
        public List<string> Contributions { get; set; } = new();
        public List<string> Results { get; set; } = new();
        public List<string> Technologies { get; set; } = new();
    }

    public class JourneyStage
    {
        public int Step { get; set; }
        public string StageTitle { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Timeframe { get; set; } = string.Empty;
        public string Story { get; set; } = string.Empty;
        public List<string> Milestones { get; set; } = new();
        public List<string> KeyLearnings { get; set; } = new();
        public string ImpactSummary { get; set; } = string.Empty;
    }

    public class EducationItem
    {
        public string Degree { get; set; } = string.Empty;
        public string Institution { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;
        public string Focus { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> KeyMilestones { get; set; } = new();
        public List<string> RelevantTopics { get; set; } = new();
    }

    public class ServiceItem
    {
        public string Title { get; set; } = string.Empty;
        public string CategoryTag { get; set; } = string.Empty;
        public string ClientBenefit { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Deliverables { get; set; } = new();
        public List<string> TechStack { get; set; } = new();
        public string IconSvg { get; set; } = string.Empty;
    }

    public class WhyWorkWithMeItem
    {
        public string Pillar { get; set; } = string.Empty;
        public string Headline { get; set; } = string.Empty;
        public string ClientPerspective { get; set; } = string.Empty;
        public string MahmoudApproach { get; set; } = string.Empty;
        public string BusinessImpact { get; set; } = string.Empty;
        public string IconSvg { get; set; } = string.Empty;
    }

    public class AchievementItem
    {
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string IssuerOrEvent { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Highlight { get; set; } = string.Empty;
    }

    public class TestimonialItem
    {
        public string ClientName { get; set; } = string.Empty;
        public string RoleAndCompany { get; set; } = string.Empty;
        public string ProjectContext { get; set; } = string.Empty;
        public string Feedback { get; set; } = string.Empty;
        public int Rating { get; set; } = 5;
        public string Initials { get; set; } = string.Empty;
    }

    public class ContactRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ProjectType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Budget { get; set; }
    }

    public class PortfolioViewModel
    {
        public string BrandName { get; set; } = "Mahmoud.Dev";
        public string DeveloperName { get; set; } = "Mahmoud";
        public string Role { get; set; } = "Full Stack .NET Developer";
        public string Tagline { get; set; } = "I don't just build your idea — I help make it better.";
        public string SubTagline { get; set; } = "I turn ideas into attractive, effective, and useful digital experiences through modern .NET, solid system architecture, and thoughtful user-centered problem solving.";
        public List<SkillGroup> SkillGroups { get; set; } = new();
        public List<Project> Projects { get; set; } = new();
        public List<ExperienceItem> Experiences { get; set; } = new();
        public List<EducationItem> EducationItems { get; set; } = new();
        public List<JourneyStage> JourneyStages { get; set; } = new();
        public List<ServiceItem> Services { get; set; } = new();
        public List<WhyWorkWithMeItem> WhyMeReasons { get; set; } = new();
        public List<AchievementItem> Achievements { get; set; } = new();
        public List<TestimonialItem> Testimonials { get; set; } = new();
    }
}
