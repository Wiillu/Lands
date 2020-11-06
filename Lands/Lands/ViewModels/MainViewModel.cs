using Lands.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lands.ViewModels
{
    class MainViewModel
    {
        #region Properties
        public List<Land> LandsList
        {
            get;
            set;
        }

        public string Token { get; set; }

        public string TokenType { get; set; }

        /*public TokenResponse Token
        {
            get;
            set;
        }*/
        #endregion

        #region ViewModels
        public LoginViewModel Login
        {
            /*Se liga el objeto a la viewmodel*/
            get;
            set;
        }
        //propoiedad  que representa al view model//de view sub.binding//se instancia y evita el consumo de memoria
        public LandsViewModel Lands
        {
            get;
            set;
        }
        public LandViewModel Land
        { 
            get; 
            set; 
        }

        public ObservableCollection<MenuItemViewModel> Menus
            { 
                get; 
                set; 
            }
        #endregion
        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenu();
        }

        #endregion

        #region Singleton
        /*Singleton permite hacer un llamado de la mainviewmodel desde cualquier clase sin tener que instanciar otra mainviewmodel*/
        /*Propiedad de tipo view model*/
        private static MainViewModel instance;
        /*Metodo que devuelve una instancia de la MainViewModel*/
        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_settings",
                PageName = "MyProfilePage",
                Title = "Mi Perfil",
            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart",
                PageName = "StaticsPage",
                Title = "Estadisticas",
            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = "Salir",
            });
        }
        #endregion
    }
}
