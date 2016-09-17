using System;
using System.Collections.Generic;
using System.Net.Http;
using Acr.UserDialogs;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace auladesabado
{
	public partial class DadosPage : ContentPage
	{
		public DadosPage()
		{
			InitializeComponent();
			getGeo();
		}

		async void getGeo()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;
			var position = await locator.GetPositionAsync(10000);

			map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),Distance.FromMiles(1)));

			var pin = new Pin
			{
				Type = PinType.Place,
				Position = new Position(position.Latitude, position.Longitude),
				Label = "Minha Localizacao",
				Address = "Terra do Nunca"
			};

			map.Pins.Add(pin);

			string url = "http://api.geonames.org/findNearByWeatherJSON?lat=" + position.Latitude.ToString() + "&lng=" + position.Longitude.ToString() + "&username=deznetfiap";

			HttpClient client = new HttpClient();

			var uri = new Uri(url);

			var response = await client.GetAsync(uri);

			TempoResultModel tempoResult = new TempoResultModel();

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				tempoResult = JsonConvert.DeserializeObject<TempoResultModel>(content);

				lblLat.Text = position.Latitude.ToString();
				lblLong.Text = position.Longitude.ToString();
				lblTemp.Text = tempoResult.weatherObservation.temperature;
				lblLoc.Text = tempoResult.weatherObservation.stationName;

				UserDialogs.Instance.ShowSuccess("Requisicao OK");
			}
			else
			{
				UserDialogs.Instance.ShowError("Requisicao Erro");
			}
		}
	}
}