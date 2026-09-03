using Microsoft.AspNetCore.Mvc;
using MahmoudDev.Models;
using MahmoudDev.Services;

namespace MahmoudDev.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPortfolioDataService _portfolioService;
        private readonly IContactService _contactService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IPortfolioDataService portfolioService,
            IContactService contactService,
            ILogger<HomeController> logger)
        {
            _portfolioService = portfolioService;
            _contactService = contactService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _portfolioService.GetPortfolioData();
            return View(model);
        }

        [HttpGet("case-study/{id}")]
        public IActionResult CaseStudyDetail(string id)
        {
            var caseStudy = _portfolioService.GetCaseStudy(id);
            if (caseStudy == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(caseStudy);
        }

        [HttpPost("contact")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactForm(ContactRequest request)
        {
            var result = await _contactService.SubmitInquiryAsync(request);
            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToAction("ThankYou");
            }

            TempData["ErrorMessage"] = result.Message;
            return RedirectToAction("Index", null, "contact");
        }

        [HttpGet("thank-you")]
        public IActionResult ThankYou()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
