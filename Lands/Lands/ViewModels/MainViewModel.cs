using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewModels
{
    class MainViewModel
    {
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
        #endregion
        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();  
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
    }
}
