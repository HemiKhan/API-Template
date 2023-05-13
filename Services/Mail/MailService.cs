using Data.DataConfig;
using Microsoft.Extensions.Configuration;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using FIS_Models.ViewModel;
using Data.AppContext;
using Microsoft.EntityFrameworkCore;

namespace FIS_Services.Mail
{
    //public class MailService : IMailService
    //{
    //    //private readonly IConfiguration configuration;
    //    ////private readonly fisContext context;
    //    //public MailService(IConfiguration configuration/*, fisContext context*/)
    //    //{
    //    //    this.configuration = configuration;
    //    //    //this.context = context;
    //    //}

    //    //public async Task<Response<EmailViewModel>> GetEmailSenderAsync(int MailModule, int Custom)
    //    //{
    //    //    try
    //    //    {
    //    //        List<string> to = new List<string>();
    //    //        List<string> cc = new List<string>();
    //    //        List<string> bcc = new List<string>();

    //    //        var ModuleList = context.MailModuleList.Where(x => x.Status == "Yes" && x.MailModuleF == MailModule).AsQueryable();

    //    //        if (Custom > 0)
    //    //        {
    //    //            var toemail = await ModuleList.Where(x => x.EmailCategory == "To" && x.Department == Custom).Select(s => s.Email).ToListAsync();
    //    //            if (toemail.Count > 0)
    //    //            {
    //    //                foreach (var item in toemail)
    //    //                {
    //    //                    to.Add(item!);
    //    //                }
    //    //            }
    //    //        }
    //    //        else
    //    //        {
    //    //            var toemail = await ModuleList.Where(x => x.EmailCategory == "To").Select(s => s.Email).ToListAsync();
    //    //            if (toemail.Count > 0)
    //    //            {
    //    //                foreach (var item in toemail)
    //    //                {
    //    //                    to.Add(item!);
    //    //                }
    //    //            }
    //    //        }


    //    //        var ccemail = await ModuleList.Where(x => x.EmailCategory == "CC").Select(s => s.Email).ToListAsync();
    //    //        if (ccemail.Count > 0)
    //    //        {
    //    //            foreach (var item in ccemail)
    //    //            {
    //    //                cc.Add(item!);
    //    //            }
    //    //        }

    //    //        var bccemail = await ModuleList.Where(x => x.EmailCategory == "BCC").Select(s => s.Email).ToListAsync();
    //    //        if (bccemail.Count > 0)
    //    //        {
    //    //            foreach (var item in bccemail)
    //    //            {
    //    //                bcc.Add(item!);
    //    //            }
    //    //        }

    //    //        var subject = await context.MailModules.Where(x => x.Id == MailModule).Select(s => s.MailSubject).FirstOrDefaultAsync();
    //    //        var Date = DateTime.Now.ToString("dd-MMM-yy HH:mm");

    //    //        EmailViewModel data = new EmailViewModel();
    //    //        data.Subject = subject + " - " + Date;
    //    //        data.To = to;
    //    //        data.Cc = cc;
    //    //        data.Bcc = bcc;

    //    //        return new Response<EmailViewModel>
    //    //        {
    //    //            Message = "Data Found Successfully",
    //    //            Status = true,
    //    //            Data = data
    //    //        };
    //    //    }
    //    //    catch (Exception)
    //    //    {
    //    //        throw;
    //    //    }
    //    //}
    //    //public async Task SendMailAsync(string? Subject, string Content, int MailModule, int Custom)
    //    //{
    //    //   // var res = await GetEmailSenderAsync(MailModule, Custom);
    //    //    //MailMessage mail = new MailMessage();
    //    //    //if (res.Data is not null)
    //    //    //{
    //    //    //    foreach (var item in res.Data.To!)
    //    //    //    {
    //    //    //        mail.To.Add(item);
    //    //    //    }

    //    //    //    foreach (var item in res.Data.Cc!)
    //    //    //    {
    //    //    //        mail.CC.Add(item);
    //    //    //    }

    //    //    //    foreach (var item in res.Data.Bcc!)
    //    //    //    {
    //    //    //        mail.Bcc.Add(item);
    //    //    //    }

    //    //    //    // CFL
    //    //    //    mail.From = new MailAddress(Constrant.MailFrom);
                
    //    //    //    if (Subject == "" || Subject == null)
    //    //    //        mail.Subject = res.Data.Subject;
    //    //    //    else
    //    //    //        mail.Subject = Subject;

    //    //        //mail.Body = Content;
    //    //        //mail.IsBodyHtml = true;
    //    //        //SmtpClient smtp = new SmtpClient();
    //    //        //smtp.Host = Constrant.MailHost;
    //    //        //smtp.EnableSsl = false;
    //    //        //NetworkCredential credential = new NetworkCredential();
    //    //        //credential.UserName = mail.From.Address;
    //    //        //credential.Password = Constrant.MailPassword;
    //    //        //smtp.UseDefaultCredentials = false;
    //    //        //smtp.Credentials = credential;
    //    //        //await smtp.SendMailAsync(mail);
    //    //        //smtp.Dispose();

    //    //        //Gmail
    //    //        //mail.From = new MailAddress(Constrant.MailFromGmail);
    //    //        //mail.Subject = res.Data.Subject;
    //    //        //mail.Body = Content;
    //    //        //mail.IsBodyHtml = true;
    //    //        //SmtpClient smtp = new SmtpClient();
    //    //        //smtp.Host = Constrant.MailHostGmail;
    //    //        //smtp.Port = Constrant.MailPortGmail;
    //    //        //NetworkCredential credential = new NetworkCredential();
    //    //        //credential.UserName = mail.From.Address;
    //    //        //credential.Password = Constrant.MailPasswordGmail;
    //    //        //smtp.UseDefaultCredentials = false;
    //    //        //smtp.EnableSsl = true;
    //    //        //smtp.Credentials = credential;
    //    //        //await smtp.SendMailAsync(mail);
    //    //        //smtp.Dispose();
    //    //    }
    //    //}        
    //    //public async Task SendEmailAsync(string subject, string body, List<string> toEmail, List<string>? CC, List<string>? BCC)
    //    //{
    //    //    MailMessage mail = new MailMessage();

    //    //    if (toEmail is not null)
    //    //    {
    //    //        foreach (var item in toEmail)
    //    //        {
    //    //            mail.To.Add(item);
    //    //        }
    //    //    }

    //    //    if (CC is not null)
    //    //    {
    //    //        foreach (var item in CC)
    //    //        {
    //    //            mail.CC.Add(item);
    //    //        }
    //    //    }

    //    //    if (BCC is not null)
    //    //    {
    //    //        foreach (var item in BCC)
    //    //        {
    //    //            mail.Bcc.Add(item);
    //    //        }
    //    //    }

    //    //    // CFL
    //    //    var Date = DateTime.Now.ToString("dd-MMM-yy");
    //    //    mail.From = new MailAddress(Constrant.MailFrom);
    //    //    mail.Subject = subject + " - " + Date; ;
    //    //    mail.Body = body;
    //    //    mail.IsBodyHtml = true;
    //    //    SmtpClient smtp = new SmtpClient();
    //    //    smtp.Host = Constrant.MailHost;
    //    //    smtp.EnableSsl = false;
    //    //    NetworkCredential credential = new NetworkCredential();
    //    //    credential.UserName = mail.From.Address;
    //    //    credential.Password = Constrant.MailPassword;
    //    //    smtp.UseDefaultCredentials = false;
    //    //    smtp.Credentials = credential;
    //    //    await smtp.SendMailAsync(mail);
    //    //    smtp.Dispose();

    //    //    //Gmail
    //    //    //mail.From = new MailAddress(Constrant.MailFromGmail);
    //    //    //mail.Subject = subject;
    //    //    //mail.Body = Content;
    //    //    //mail.IsBodyHtml = true;
    //    //    //SmtpClient smtp = new SmtpClient();
    //    //    //smtp.Host = Constrant.MailHostGmail;
    //    //    //smtp.Port = Constrant.MailPortGmail;
    //    //    //NetworkCredential credential = new NetworkCredential();
    //    //    //credential.UserName = mail.From.Address;
    //    //    //credential.Password = Constrant.MailPasswordGmail;
    //    //    //smtp.UseDefaultCredentials = false;
    //    //    //smtp.EnableSsl = true;
    //    //    //smtp.Credentials = credential;
    //    //    //await smtp.SendMailAsync(mail);
    //    //    //smtp.Dispose();
    //    //}
    //}
}
