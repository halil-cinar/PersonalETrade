using ETrade.Core.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        [HttpPost]
        public IActionResult Send(Mail mail)
        {
            new MailSender().SendEmail(mail.To, "Bunu OKU", mail.Message);
            return Ok(mail);
        }
    }
}
