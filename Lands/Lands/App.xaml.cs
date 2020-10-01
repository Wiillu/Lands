using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lands
{
    using Views;
    public partial class App : Application
    {
        #region Constructors
        public App()
        {
            InitializeComponent();
            //Navegación a login
            this.MainPage = new NavigationPage(new LoginPage());
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
