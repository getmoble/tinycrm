using Common.Providers.Email;
using Common.Providers.Email.Models;

namespace LOG.PropznetCRM.Data.Infrastructure
{
    public class EmailHelper
    {
        public static void SmptpCredentials(string username, string password)
        {
        }
        public static SmtpConfig SmptpConfiguration()
        {
            var smtpconfig = SmtpConfig.GetConfigForMailGun("postmaster@sandbox6b0f2cd3e2564e75ad7ceebf1ee8a169.mailgun.org", "1428b2fd72f2e618bc5da7cadde89087");
            return smtpconfig;
        }

        public static bool SendEmailForRegistration(string name, string emailtext, string phone, string password)
        {
            var emailbody = "<html><body><h4>Hello " + name + ",</h4><p>We're so glad you decided to sign up for a propoznetCRM account. We're sure that you will love it.</p><p><b>For login:</b></p>To login, please click the link below or copy & paste it into your browser's address box.Use your email id as User name and your Password is " + password + "<p/><a href=http://" + AppConfigaration.GetAppName() + ".com</a>http://" + AppConfigaration.GetAppName() + ".com<p/>Thanks again.<br/>Ma Salaam,<br/>PropznetCRM</body></html>";
            var smtpconfig = SmptpConfiguration();
            var email = new Email
            {
                FromAddress = AppConfigaration.GetFromAddress(),
                ToAddress = emailtext,
                Subject = AppConfigaration.GetAppName() + " - Your account is created",
                SenderName = AppConfigaration.GetAppName(),
                Message = emailbody,
                IsHtmlEmail = true
            };
            var provider = new SmtpEmailProvider(smtpconfig);
            provider.Send(email);
            return true;
        }

        public static bool SendEmailForForgotPassword(string emailId, string name, string newPassword)
        {
            var emailbody = "<html><body><h4>Hello " + name + ",</h4><p>You're receiving this e­mail because you requested a password reset for your PropznetCRM account.</p><p>Please find the password below, login with this temporary password and change your password immediately after login</p><br/><b>New Password:</b>" + newPassword + "<br/><br/>Thanks,<br>The PropznetCRM Team</body></html>";
            var smtpconfig = SmptpConfiguration();
            var email = new Email
            {
                FromAddress = AppConfigaration.GetFromAddress(),
                ToAddress = emailId,
                Subject = AppConfigaration.GetAppName() + " - Reset Password",
                SenderName = AppConfigaration.GetAppName(),
                Message = emailbody,
                IsHtmlEmail = true
            }; var provider = new SmtpEmailProvider(smtpconfig);
            provider.Send(email);
            return true;
        }
    }
}
