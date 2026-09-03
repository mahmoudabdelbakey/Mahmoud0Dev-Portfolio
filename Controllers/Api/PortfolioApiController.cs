using Microsoft.AspNetCore.Mvc;
using MahmoudDev.Models;
using MahmoudDev.Services;

namespace MahmoudDev.Controllers.Api
{
    [ApiController]
    [Route("api/portfolio")]
    [Produces("application/json")]
    public class PortfolioApiController : ControllerBase
    {
        private readonly IPortfolioDataService _portfolioService;

        public PortfolioApiController(IPortfolioDataService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        /// <summary>
        /// Retrieves the full portfolio metadata and sections.
        /// </summary>
        [HttpGet]
        public ActionResult<PortfolioViewModel> GetFullPortfolio()
        {
            return Ok(_portfolioService.GetPortfolioData());
        }

        /// <summary>
        /// Retrieves projects, optionally filtered by category.
        /// </summary>
        [HttpGet("projects")]
        public ActionResult<List<Project>> GetProjects([FromQuery] string? category = null)
        {
            return Ok(_portfolioService.GetProjects(category));
        }

        /// <summary>
        /// Retrieves a single project by ID.
        /// </summary>
        [HttpGet("projects/{id}")]
        public ActionResult<Project> GetProjectById(string id)
        {
            var project = _portfolioService.GetProjectById(id);
            if (project == null) return NotFound(new { message = $"Project with ID '{id}' was not found." });
            return Ok(project);
        }

        /// <summary>
        /// Retrieves a case study by ID.
        /// </summary>
        [HttpGet("casestudy/{id}")]
        public ActionResult<CaseStudy> GetCaseStudy(string id)
        {
            var cs = _portfolioService.GetCaseStudy(id);
            if (cs == null) return NotFound(new { message = $"Case study with ID '{id}' was not found." });
            return Ok(cs);
        }

        /// <summary>
        /// Retrieves skills categorized into groups.
        /// </summary>
        [HttpGet("skills")]
        public ActionResult<List<SkillGroup>> GetSkills()
        {
            return Ok(_portfolioService.GetSkills());
        }

        /// <summary>
        /// Retrieves professional experiences.
        /// </summary>
        [HttpGet("experience")]
        public ActionResult<List<ExperienceItem>> GetExperience()
        {
            return Ok(_portfolioService.GetExperiences());
        }

        /// <summary>
        /// Retrieves progressive career journey stages.
        /// </summary>
        [HttpGet("journey")]
        public ActionResult<List<JourneyStage>> GetJourney()
        {
            return Ok(_portfolioService.GetJourneyStages());
        }

        /// <summary>
        /// Retrieves offered engineering services.
        /// </summary>
        [HttpGet("services")]
        public ActionResult<List<ServiceItem>> GetServices()
        {
            return Ok(_portfolioService.GetServices());
        }
    }

    [ApiController]
    [Route("api/contact")]
    [Produces("application/json")]
    public class ContactApiController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactApiController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// Submits a project inquiry or message to Mahmoud.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SubmitContact([FromBody] ContactRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { success = false, message = "Invalid contact payload." });
            }

            var (success, message) = await _contactService.SubmitInquiryAsync(request);
            if (!success)
            {
                return BadRequest(new { success = false, message });
            }

            return Ok(new { success = true, message });
        }

        /// <summary>
        /// Retrieves received inquiries (demo/admin audit).
        /// </summary>
        [HttpGet("inquiries")]
        public ActionResult<List<ContactRequest>> GetInquiries()
        {
            return Ok(_contactService.GetAllInquiries());
        }
    }
}
