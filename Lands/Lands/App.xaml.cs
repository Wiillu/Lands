using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lands.Helpers;
namespace Lands
{
    using Lands.ViewModels;
    using Views;
    public partial class App : Application
    {
        #region Properties
        public static NavigationPage Navigator 
        { 
            get; 
            internal set; 
        }
        #endregion

        #region Constructors
        public App()
        {
            InitializeComponent();
            //Navegación a login
            //this.MainPage = new MasterPage();
            if(string.IsNullOrEmpty(Settings.Token))
            {
                this.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
                mainViewModel.Lands = new LandsViewModel();
                this.MainPage = new MasterPage();
            }
            
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        #endregion
    }
}
