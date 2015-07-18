namespace LOG.PropznetCRM.Data.ViewModel.Setting
{
    public class SettingViewModel
    {
        public string LogoPath { get; set; }
        public int PagingSize { get; set; }

        public SettingViewModel(string logopath)
        {
            LogoPath = logopath;
        }
    }
}