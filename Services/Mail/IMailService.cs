using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Models.ViewModel;

namespace Services.Mail
{
    public interface IMailService
    {
        //Task<Response<EmailViewModel>> GetEmailSenderAsync(int MailModule, int Custom);
        //Task SendMailAsync(string? Subject, string Content, int MailModule, int Custom);
        //Task SendEmailAsync(string subject, string body, List<string> toEmail, List<string>? CC, List<string>? BCC);
    }
}
