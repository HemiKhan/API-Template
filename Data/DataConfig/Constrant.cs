using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataConfig
{
    public class Constrant
    {
        public static string Authenticatekey = "This is key that will be used in encryption";
        public static string AuthenticateIssuer = "http://localhost:5274";
        public static string AuthenticateAudience = "http://localhost:5274";
        public static string ApiUrl = "https://localhost:7274";

        public static string MailHost = "172.16.0.7";
        public static int MailPort = 25;
        public static string MailFrom = "alerts@combinedfabrics.com";
        public static string MailPassword = "DDR2dimm";

        public static string MailHostGmail = "smtp.gmail.com";
        public static int MailPortGmail = 587;
        public static string MailFromGmail = "hammaskhan01@gmail.com";
        public static string MailPasswordGmail = "laayuhzozamtendr";

        public static string MailHostOutlook = "smtp-mail.outlook.com";
        public static int MailPortOutlook = 587;
        public static string MailFromOutlook = "hammaskhan01@gmail.com";
        public static string MailPasswordOutlook = "laayuhzozamtendr";
    }

}
