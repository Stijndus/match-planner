using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

namespace Matchplanner.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
    [HttpPost("SendEmail")]
    public IActionResult SendEmail([FromBody] string emailContent)
    {
        // Replace the placeholders below with your own SMTP server credentials:
        // - Replace 'your_email@example.com' with your email address.
        // - Replace 'your_password' with your SMTP server password.
        // Ensure you set up your own SMTP server
        try
        {
            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("your_email@gmail.com", "your_app_password"); // email and password removed for privacy, setup your own SMTP

                var message = new MailMessage("from@gmail.com", "to@gmail.com") // emails removed for privacy
                {
                    Subject = "Test Subject",
                    Body = emailContent,
                    IsBodyHtml = true
                };

                smtpClient.Send(message);
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Error sending email: {ex.Message}");
        }
    }

    [HttpPost("sendConfirmEmail")]
    public IActionResult SendConfirmationEmail([FromBody] string emailContent)
    {
        // Replace the placeholders below with your own SMTP server credentials:
        // - Replace 'your_email@example.com' with your email address.
        // - Replace 'your_password' with your SMTP server password.
        // Ensure you set up your own SMTP server
        try
        {
            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("your_email@gmail.com", "your_app_password"); // email and password removed for privacy, setup your own SMTP

                var message = new MailMessage("from@gmail.com", emailContent) // emails removed for privacy
                {
                    Subject = "Confirm emailadress",
                    Body = "Your email is confirmed",
                    IsBodyHtml = true
                };
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Error sending email: {ex.Message}");
        }
    }
}