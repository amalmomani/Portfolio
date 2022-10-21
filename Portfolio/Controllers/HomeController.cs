using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string name, string email, string subject, string m)
        { 
            using System.Net.Mail.SmtpClient mySmtpClient = new System.Net.Mail.SmtpClient("smtp.outlook.com", 587);
            mySmtpClient.EnableSsl = true;

            mySmtpClient.UseDefaultCredentials = false;
            NetworkCredential basicAuthenticationInfo = new
           NetworkCredential("amalportfolio@outlook.com", "a99amool78");

            mySmtpClient.Credentials = basicAuthenticationInfo;
            MailMessage message = new MailMessage("amalportfolio@outlook.com", "amalmomani99@yahoo.com");
            string body ="You recive message from your potoflio"+"\n"+"From:  " + name +"\n"+ "Message:  "+ m + "\n" + "Sender Email:  " + email;
            message.Subject = subject;
            message.Body = body;
            mySmtpClient.Send(message);
            return View();

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
