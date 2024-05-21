
using Microsoft.AspNetCore.Mvc;

using System;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace ProjectAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class EmailController : ControllerBase
   {
      [HttpPost]
      public IActionResult SendMail()
      {

         
            var email = new MimeMessage();
         //Add mail sent
            email.From.Add(new MailboxAddress("Chu Huu Long", "longchhe161926@fpt.edu.vn"));
         //Add mail receive Address
            email.To.Add(new MailboxAddress("Chu Huu Long", "longchuhuu@gmail.com"));

            email.Subject = "Testing out email sending";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
               Text = "<b>Hello all the way from the land of C#</b>"
            };

            using (var smtp = new SmtpClient())
            {
               smtp.Connect("smtp.gmail.com", 587, false);

               // Note: only needed if the SMTP server requires authentication
               smtp.Authenticate("longchhe161926@fpt.edu.vn", "qalcpisbhnxvwbrg");

               smtp.Send(email);
               smtp.Disconnect(true);
            }
         return Ok();
      }
   }
}
