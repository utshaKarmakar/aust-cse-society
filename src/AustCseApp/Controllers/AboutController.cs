using AustCseApp.Services;   // (we’ll add this in Step 2)
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AustCseApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly IEmailSender _email;
        private readonly SmtpOptions _smtp;

        public AboutController(IEmailSender email, IOptions<SmtpOptions> smtp)
        {
            _email = email;
            _smtp = smtp.Value;
        }

        // GET: /About
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.DeptHeadEmail = _smtp.DeptHeadEmail;
            return View();
        }

        // POST: /About/SendInquiry
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendInquiry(string senderEmail, string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                TempData["Alert"] = "Please write your inquiry.";
                return RedirectToAction(nameof(Index));
            }

            var subject = "Inquiry from AUST CSE Portal";
            var body = $@"
                <p><strong>From:</strong> {System.Net.WebUtility.HtmlEncode(senderEmail ?? "(not provided)")}</p>
                <p><strong>Message:</strong></p>
                <p>{System.Net.WebUtility.HtmlEncode(description).Replace("\n", "<br/>")}</p>";

            await _email.SendAsync(_smtp.DeptHeadEmail, subject, body, senderEmail);

            TempData["Alert"] = "Inquiry sent successfully.";
            return RedirectToAction("Index", "Home");
        }
    }
}
