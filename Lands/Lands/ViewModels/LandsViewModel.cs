using Lands.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Lands.Services;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Linq;

namespace Lands.ViewModels
{


    public class LandsViewModel : BaseViewModel
    {
        #region Services 
        private ApiService apiService;
       
        #endregion

        #region Attributes
        /*Genera una lista cambiante*/
        private ObservableCollection<LandItemViewModel> lands;
        private bool isRefreshing;
        private string filter;
        // se guarda para no volver a enviar a la rest
        //private List<Land> landsList;
        #endregion

        #region Properties
        public ObservableCollection<LandItemViewModel> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        public string Filter
        {
            get { return this.filter; }
            set { SetValue(
                ref this.filter, value);
                //cada vez que haya un cambio buscar
                this.Search();
            }
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

        #region Constructors
        //asincrono debido a que se usa una api
        private async void LoadLands()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if(!connection.IsSuccess)
            {
                this.IsRefreshing = false;
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
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("error", response.Message, "Acept");
                return;
            }
            this.IsRefreshing = false;
            //castea como lista desde el resultado de la respuesta
            //var list = (List<Land>) response.Result;
            //this.landsList= (List<Land>)response.Result; //la almacena en memoria la lista original
            MainViewModel.GetInstance().LandsList = (List<Land>)response.Result; 
            //envia la lista a la coleccion
            this.Lands = new ObservableCollection<LandItemViewModel>(
                this.ToLandItemViewModel());
        }
        #endregion

        #region Methods
        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return MainViewModel.GetInstance().LandsList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        }
        #endregion
        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                //carga el metodo que se usara al refrescar
                return new RelayCommand(LoadLands);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLandItemViewModel());//carga la lista original
            }
            else
            { //ToLower minuscula
                this.Lands = new ObservableCollection<LandItemViewModel>(
                     this.ToLandItemViewModel().Where(
                        l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                        l.Capital.ToLower().Contains(this.Filter.ToLower())
                        ));
            }
        }
        #endregion

    }
}
