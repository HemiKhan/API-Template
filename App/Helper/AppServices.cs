

using Services.Mail;
using Services.Services.Account;
using Services.Services.Seed;

namespace App.Helper
{
    public static class AppServices
    {
        public static IServiceCollection AddAppServices(this IServiceCollection appservices)
        {
            appservices.AddTransient<IAccountService, AccountService>();
            appservices.AddTransient<ISeedService, SeedService>();
            //appservices.AddTransient<IMailService, MailService>();
            appservices.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            //appservices.AddSingleton(Log.Logger);
            //appservices.AddScoped<IEmailAlert, EmailAlert>();

            //appservices.AddHostedService<AutoExecuteBackground>();
            //appservices.AddHostedService<AutoSendEmailComplaintSummaryReport>();
            //appservices.AddHostedService<AutoSendEmailComplaintVerification>();
            //appservices.AddHostedService<AutoSendComplaintandVerifiedBySystem>();
            //appservices.AddHostedService<AutoSendGateRegister/*>();*/
            //appservices.AddHostedService<AutoSendNonRtclotAlert>();

            return appservices;
        }
    }
}
