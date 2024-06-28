using BusinessLogic.Business.SendmailService;
using BusinessLogic.Dtos.SendMailModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingTourAPI.Controllers.MailController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public SendMailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendMail(request);
            return Ok();
        }
    }
}
