using Lands.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Lands.Services;

namespace Lands.ViewModels
{


    public class LandsViewModel : BaseViewModel
    {
        #region Services 
        private ApiService apiService;
        #endregion

        #region Attributes
        /*Genera una lista cambiante*/
        private ObservableCollection<Land> lands;
        #endregion

        #region Properties
        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        #endregion

        #region Constructors
        public LandsViewModel()
        { 
            //instnaciamos el servicio en el constructor
            this.apiService = new ApiService();
            this.LoadLands();
        }
        #endregion

        #region Methods
        private async void LoadLands()
        {

            var connection = await this.apiService.CheckConnection();
            if(!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "error", 
                    connection.Message, 
                    "Acept");
                //navegación hacía atras
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            //asincrono await con el servicio del metodo y le pasamos las variables
            var response = await this.apiService.GetList<Land>(
                "https://restcountries.eu",
                "/rest",
                "/v2/all");
            //verifica si sucedio
            if(!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("error", response.Message, "Acept");
                return;
            }
            //castea como lista desde el resultado de la respuesta
            var list = (List<Land>) response.Result;
            //envia la lista a la coleccion
            this.Lands = new ObservableCollection<Land>(list);
        }
        #endregion

    }
}
