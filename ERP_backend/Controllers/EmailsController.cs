using ERP_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ERP_backend.Controllers	
{
	[Route("api/emails")]
	[ApiController]
    public class EmailsController : Controller
    {
        private readonly IEmailService emailService;
        public EmailsController(IEmailService emailService)
        {
			this.emailService = emailService;

		}
		[HttpPost]
		public async Task<IActionResult> SendEmail(string receptor, string subject, string body)
		{
			await emailService.SendEmail(receptor, subject, body);

			return Ok();
		}
	}
}
