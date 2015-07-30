using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.Data.Model.Setting
{
    public class SettingsModel
    {
        public long Id { get; set; }
        public string ElasticSearchUrl { get; set; }
        public string DefaultIndex { get; set; }
        public string Potentialprefix { get; set; }
        public string Leadprefix { get; set; }
        public string FromAddress { get; set; }
        public string SmtpConfigUsername { get; set; }
        public string SmtpConfigPassword { get; set; }
        public int Maxinvalidpasswordattempts { get; set; }
        public int CoockieTimeOut { get; set; }
        public string AppName { get; set; }
        public int LogoMaxWidth { get; set; }
        public int LogoMaxHeight { get; set; }

        public SettingsModel()
        {
        }
        public SettingsModel(SettingsModel vm)
        {
            Id=vm.Id;
            ElasticSearchUrl = vm.ElasticSearchUrl;
            DefaultIndex = vm.DefaultIndex;
            Potentialprefix = vm.Potentialprefix;
            Leadprefix = vm.Leadprefix;
            FromAddress = vm.FromAddress;
            SmtpConfigUsername = vm.SmtpConfigUsername;
            SmtpConfigPassword = vm.SmtpConfigPassword;
            Maxinvalidpasswordattempts = vm.Maxinvalidpasswordattempts;
            CoockieTimeOut = vm.CoockieTimeOut;
            AppName = vm.AppName;
            LogoMaxWidth = vm.LogoMaxWidth;
            LogoMaxHeight = vm.LogoMaxHeight;
        }
    }
}
