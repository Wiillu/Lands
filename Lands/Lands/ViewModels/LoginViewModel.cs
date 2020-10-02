using GalaSoft.MvvmLight.Command;
using Lands.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    //ctrl + k + f aliena el código
    //INotifyPropertyChanged cambia la interfaz se paso a BaseViewModel
    public class LoginViewModel : BaseViewModel
    {
        //ctrl + k + s añade regiónn

        #region Attributes
        //solo los atributos dependientes a refresecar se ingresan
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;

        #endregion
        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref password, value); }
        }

        public bool IsRunning
        {
            get
            { return this.isRunning; }
            set
            { SetValue(ref isRunning, value); }
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsEnabled 
        {
            get
            { return this.isEnabled; }
            set
            { SetValue(ref isEnabled, value); }
        }
        #endregion
        #region Constructor
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
            this.Email = "jzuluaga55@gmail.com";
            this.Password = "1234";
        }
        #endregion
        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                //instalar el paquete mvvmlightlibs para validar login
                return new RelayCommand(Login);
            }
        }



        //metodo que valida el login
        //metodos asincronos
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                //await obligado para asincrono, obliga a esperar a la aplicación
                //Application libreria xamarin forms. se conecta con la aplicación
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                    "Accept");
                return;
            }
            //evalua variables IsNullOrEmpty
            if (string.IsNullOrEmpty(this.Password))
            {
                //await obligado para asincrono, obliga a esperar a la aplicación
                //Application libreria xamarin forms. se conecta con la aplicación
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an Password",
                    "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if (this.Email != "jzuluaga55@gmail.com" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or Password Incorrect",
                    "Accept");
                //vacia el campo de password
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;
            
            //limpia los campos
            this.Email = string.Empty;
            this.Password = string.Empty;
            
            //1. se debe instanciar la view model, para ser referenciada; Se usa el patron singleton y evitar multiples instancias(MainViewModel) 
            MainViewModel.GetInstance().Lands = new LandsViewModel();
            //2. Se apila con método asincrono para navegacion
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());


        }
        #endregion

    }
}
