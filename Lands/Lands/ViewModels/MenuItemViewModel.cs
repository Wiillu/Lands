using GalaSoft.MvvmLight.Command;
using Lands.Views;
using Lands.Helpers;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class MenuItemViewModel
    {
        public string Icon { get; set; }
        public string PageName { get; set; }
        public string Title { get; set; }

        #region Command
        public ICommand NavigateCommand
        {
            get { return new RelayCommand(Navigate); }
        }
        #endregion

        #region Method

        private void Navigate()
        {
            if(this.PageName == "LoginPage")
            {
                Settings.Token = string.Empty;
                Settings.TokenType = string.Empty;
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = string.Empty;
                mainViewModel.TokenType = string.Empty;
                Application.Current.MainPage = new LoginPage();
            }
        }
        #endregion

    }
}
