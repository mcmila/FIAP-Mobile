using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using Acr.UserDialogs;
using Plugin.Geolocator;

namespace auladesabado
{
	public partial class EnderecoPage : ContentPage
	{
		public EnderecoPage()
		{
			InitializeComponent();
		}

		async void txtCep_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
		{
			string sUrl = "http://viacep.com.br/ws/{0}/json/";

			HttpClient client = new HttpClient();

			var uri = new Uri(string.Format(sUrl, txtCep.Text));

			var response = await client.GetAsync(uri);

			CepResultModel cep = new CepResultModel();

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				cep = JsonConvert.DeserializeObject<CepResultModel>(content);
				txtEndereco.Text = cep.logradouro;
				txtBairro.Text = cep.bairro;
				txtCidade.Text = cep.localidade;
				txtEstado.Text = cep.uf;


				UserDialogs.Instance.ShowSuccess("Requisicao OK");
			}
			else
			{
				UserDialogs.Instance.ShowError("Requisicao Erro");
			}
		}
	}
}