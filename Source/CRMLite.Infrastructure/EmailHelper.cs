using Common.Providers.Email;
using Common.Providers.Email.Models;

namespace CRMLite.Infrastructure
{
    public class EmailHelper
    {
        static string smtpUsername;
        static string smtpPassword;
        public static void SmptpCredentials(string username, string password)
        {
            smtpUsername=username;
            smtpPassword=password;
        }
        public static SmtpConfig SmptpConfiguration()
        {
            var smtpconfig = SmtpConfig.GetConfigForMailGun("postmaster@sandbox6b0f2cd3e2564e75ad7ceebf1ee8a169.mailgun.org", "1428b2fd72f2e618bc5da7cadde89087");
            return smtpconfig;
        }

        public static bool SendEmailForRegistration(string name, string emailtext,string fromaddress,string appname, string phone,string password)
        {
            var emailbody = "<html><body><h4>Hello " + name + ",</h4><p>We're so glad you decided to sign up for a propoznetERP account. We're sure that you will love it.</p><p><b>For login:</b></p>To login, please click the link below or copy & paste it into your browser's address box.Use your email id as User name and your Password is "+ password+"<p/><a href=http://" + AppConfigaration.GetAppName() + ".com</a>http://" + AppConfigaration.GetAppName() + ".com<p/>Thanks again.<br/>Ma Salaam,<br/>CRM Lite</body></html>";
            var smtpconfig = SmptpConfiguration();
            var email = new Email
            {
                FromAddress = fromaddress,
                ToAddress = emailtext,
                Subject = appname+" - Your account is created",
                SenderName = appname,
                Message = emailbody,
                IsHtmlEmail = true
            };
            var provider = new SmtpEmailProvider(smtpconfig);
            provider.Send(email);
            return true;
        }

        public static bool SendEmailForForgotPassword(string emailId, string fromaddress, string appname, string name, string newPassword)
        {
            var emailbody = "<html><body><h4>Hello " + name + ",</h4><p>You're receiving this e­mail because you requested a password reset for your CRM Lite account.</p><p>Please find the password below, login with this temporary password and change your password immediately after login</p><br/><b>New Password:</b>"+newPassword+"<br/><br/>Thanks,<br>The Propznet Team</body></html>";
                var smtpconfig = SmptpConfiguration();
                var email = new Email
                {
                    FromAddress = fromaddress,
                    ToAddress = emailId,
                    Subject = appname + " - Reset Password",
                    SenderName = appname,
                    Message = emailbody,
                    IsHtmlEmail = true
                }; var provider = new SmtpEmailProvider(smtpconfig);
                provider.Send(email);
            return true;      
        }
    }
}
