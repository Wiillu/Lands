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
            this.apiService = new ApiService();
            this.LoadLands();
        }
        #endregion

        #region Methods
        private async void LoadLands()
        {
            var response = await this.apiService.GetList<Land>(
                "https://restcountries.eu",
                "/rest",
                "/v2/all");
            if(!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("error", response.Message, "Acept");
                return;
            }

            var list = (List<Land>) response.Result;
            this.Lands = new ObservableCollection<Land>(list);
        }
        #endregion

    }
}
