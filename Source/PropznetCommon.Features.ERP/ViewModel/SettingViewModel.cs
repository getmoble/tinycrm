using System;

namespace PropznetCommon.Features.ERP.ViewModel
{
    public class SettingViewModel
    {
        public string LogoPath { get; set; }
        public int PagingSize { get; set; }

        public SettingViewModel(string logopath,string defaultValue)
        {
            if(!String.IsNullOrEmpty(logopath))
            LogoPath = logopath;
            else
                LogoPath = defaultValue;
           // PagingSize = Convert.ToInt32(pagingsize);
        }
    }
}
