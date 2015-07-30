using Common.Settings.Entities;
using Newtonsoft.Json;
using CRMLite.Data.Model.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.Data.Data.Seeders
{
    public class SettingsSeeder
    {
        public static void Seed(DataContext context)
        {
            var logoSetting = new Setting { Key = "logo", Value = "logo.png", CreatedOn = DateTime.UtcNow, DefaultValue = "props-logo.png" };
            context.Settings.Add(logoSetting);
            context.SaveChanges();

            var pagingSetting = new Setting { Key = "pagingsize", Value = "20", CreatedOn = DateTime.UtcNow, DefaultValue = "20" };
            context.Settings.Add(pagingSetting);
            context.SaveChanges();

            var vmSetting = new SettingsModel
            {
                ElasticSearchUrl = "http://localhost:9200",
                DefaultIndex = "my-application",
                Potentialprefix = "P",
                Leadprefix = "L",
                FromAddress = "alerts@propznet.com",
                SmtpConfigUsername = "postmaster@sandbox6b0f2cd3e2564e75ad7ceebf1ee8a169.mailgun.org",
                SmtpConfigPassword = "1428b2fd72f2e618bc5da7cadde89087",
                Maxinvalidpasswordattempts = 5,
                CoockieTimeOut = 30,
                AppName = "Propznet",
                LogoMaxWidth = 145,
                LogoMaxHeight = 43
            };

            var settingSerialized = JsonConvert.SerializeObject(vmSetting);
            var siteSetting = new Setting
            {
                Key = "SiteSetting",
                Value = settingSerialized,
                DefaultValue = settingSerialized
            };
            context.Settings.Add(siteSetting);
            context.SaveChanges();
        }
    }
}
